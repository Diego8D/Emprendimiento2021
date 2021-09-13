using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MovementPrincipalCharacter : MonoBehaviour
{ 
    public float MaxSpeedWalk = 8f;
    public float speed = 25f;
    public float jumpPower = 8f;
    public float CharacterSize = 5f;
    private bool limitjumpfinish;
    private bool ArgomAttackLaser;
    private bool jump;
    private bool Down;
    private Rigidbody rb;
    private Animator anim;
    private SpriteRenderer RotateAxis;
    public bool grounded;
    private bool groundedagregadoinnecesario;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        RotateAxis = GetComponent<SpriteRenderer>();
        transform.localScale = new Vector3(CharacterSize, CharacterSize, 1);
        grounded = true;
    }

    // Update is called once per frame 
    void Update()
    { 
        
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("Gravity", rb.velocity.y);
        anim.SetBool("KeyDown", Down);
        anim.SetBool("grounded", grounded);
        anim.SetBool("ArgomAttackLaser", ArgomAttackLaser);
        float gravity = rb.velocity.y;
        float limitjump = Mathf.Abs(gravity);
        if (limitjump < 0.05)
        {
            limitjumpfinish = true;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ArgomAttackLaser = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            ArgomAttackLaser = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Down = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            Down = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && limitjumpfinish)
        {
            jump = true;
            limitjumpfinish = false;
        }
    }

    void OnTriggerStay(Collider obj)
    {
        if (obj.tag == "border_wall")
        {
            //AYUDAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
            grounded = false;
            groundedagregadoinnecesario = true;
            Debug.Log("si funciona le borde");
        }
    }
    void FixedUpdate()
    {
        if (groundedagregadoinnecesario = true)
        {
            grounded = true;
            groundedagregadoinnecesario = false;
        }
        float speedinjump = Mathf.Abs(rb.velocity.x);
       
        float h = Input.GetAxis("Horizontal");
        if (grounded = true)
        {
            rb.AddForce(Vector2.right * speed * h);
            if (h > 0)
            {
                RotateAxis.flipX = false;
            }
            if (h < 0)
            {
                RotateAxis.flipX = true;
            }
        }
        if (Input.GetKey(KeyCode.LeftControl))
     {
         if (speedinjump > (MaxSpeedWalk * 3f))
         {
             float LimitedSpeedRun = Mathf.Clamp(rb.velocity.x, -MaxSpeedWalk, MaxSpeedWalk);
             LimitedSpeedRun = LimitedSpeedRun * 3f;
             rb.velocity = new Vector2(LimitedSpeedRun, rb.velocity.y);   
         }
     }
     else
     {
         float LimitedSpeedRun = Mathf.Clamp(rb.velocity.x, -MaxSpeedWalk, MaxSpeedWalk);
         LimitedSpeedRun = LimitedSpeedRun;
         rb.velocity = new Vector2(LimitedSpeedRun, rb.velocity.y); 
     }
        if (jump)
     {
         rb.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
         jump = false;
     }
    }
}

