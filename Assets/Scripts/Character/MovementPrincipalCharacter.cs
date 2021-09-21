using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MovementPrincipalCharacter : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private bool m_canBeUsed = default;

    public void ModifcyUsedValue(bool canBeUsed) { m_canBeUsed = canBeUsed; if (!canBeUsed) { ResetLocomotion(); }; }

    [Header("Components")]
    [SerializeField] private Rigidbody m_rigidbody = default;
    [SerializeField] private CharacterAnimation m_animControl = default;

    [Header("Ground")]
    [SerializeField] private Transform m_groundPos = default;
    [SerializeField] private Transform m_groundRadius = default;
    [SerializeField] private LayerMask m_groundMask = default;

    [Header("Locomotion")]
    [SerializeField] private float m_moveSpeed = default;
    [SerializeField] private float m_runSpeed = default;

    [Header("JumpVariables")]
    [SerializeField] private float m_jumpDelay = default;
    [SerializeField] private float m_jumpCooldown = default;
    [SerializeField] private float m_jumpPower = default;

    private float p_horizontalInput;
    private Coroutine p_jumpRutine;

    private bool p_canJump;
    private bool p_isJumping;
    private bool p_grounded;

    public void ActivateCharacter()
    {
        m_canBeUsed = true;
        p_canJump = true;
    }

    public void ResetLocomotion()
    {
        m_animControl.UpdateSpeed(0);

    }


    [Header("Wall detection")]
    [SerializeField] private float m_wallRadius = default;
    [SerializeField] private float m_wallHorizontalOffset = default;
    [SerializeField] private float m_wallVerticalOffset = default;
    [SerializeField] private float m_wallHeight = default;
    [Space(5)]
    [SerializeField] private bool m_drawGizmos = default;

    [Header("Wall detection")]
    [SerializeField] private bool m_HAVEWALL = default;

    public void Update()
    {
       if (!m_canBeUsed) { return; };

        bool wasGrounded = p_grounded;

        bool haveGround = Physics.CheckSphere(m_groundPos.position, Mathf.Max(0, m_groundRadius.localScale.x * 0.5F), m_groundMask);
        p_grounded = haveGround;

        p_horizontalInput = Input.GetAxis("Horizontal");

        float moveSpeed = 0;


        bool haveMoveInput = Mathf.Abs(p_horizontalInput) >= 0.1F;

        if (haveMoveInput)
        {
            bool isRight = p_horizontalInput > 0;
            Vector3 startPos = m_groundPos.position + (Vector3.up * m_wallVerticalOffset) + (Vector3.right * (m_wallHorizontalOffset * (isRight ? 1 : -1)));

            if (m_drawGizmos)
            {
                Debug.DrawRay(startPos, Vector3.up * m_wallHeight, Color.blue);
                Debug.DrawRay(startPos + (Vector3.right * m_wallRadius), Vector3.up * m_wallHeight, Color.green);
                Debug.DrawRay(startPos + (Vector3.left * m_wallRadius), Vector3.up * m_wallHeight, Color.green);
            };

            Ray wallRay = new Ray(startPos, Vector3.up * m_wallHeight);
            bool haveWallColl = Physics.SphereCast(wallRay, m_wallRadius, m_wallHeight, m_groundMask);


            m_HAVEWALL = haveWallColl;

            if (!haveWallColl)
            {
                bool useRunInput = p_isJumping ? false : Input.GetKey(KeyCode.LeftShift);
                moveSpeed = p_horizontalInput * (useRunInput ? m_runSpeed : m_moveSpeed) * Time.deltaTime;
                Vector3 newPos = transform.position + (Vector3.right * moveSpeed);
                m_rigidbody.MovePosition(newPos);

                Vector3 finalScale = new Vector3(p_horizontalInput > 0 ? 1 : -1, 1, 1);
                m_animControl.transform.localScale = finalScale;
            }
            else
            {
                
                Vector3 currentVel = m_rigidbody.velocity;
                currentVel.x = 0;
                m_rigidbody.velocity = currentVel;
                
            };

    




        };





        if (Input.GetKey(KeyCode.Space) && p_canJump && p_grounded)
        {
            p_canJump = false;

            if (p_jumpRutine != null) { StopCoroutine(p_jumpRutine); };
            p_jumpRutine = StartCoroutine(JumpRutine());
        }

        m_animControl.UpdateSpeed(Mathf.Abs(moveSpeed));
        if (p_canJump && wasGrounded && !p_grounded) { m_animControl.TriggerOnAir(); };
        if (!wasGrounded && p_grounded) { m_animControl.TriggerGround();  };
    }

    public IEnumerator JumpRutine()
    {
        m_animControl.TriggerJumpStart();
        p_isJumping = true;
        yield return new WaitForSeconds(m_jumpDelay);
        m_rigidbody.AddForce(Vector2.up * m_jumpPower, ForceMode.Impulse);
        yield return new WaitForSeconds(m_jumpCooldown);
        p_isJumping = false;
        p_canJump = true;
    }
}