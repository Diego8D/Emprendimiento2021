using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float speed;
    public Collider collider;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public GameObject destroyParticle;
    private Rigidbody rb;
    private bool explote;
    private bool rebote_derecha;
    private bool rebote_izquierda;
    public float MaxSpeedWalk;
    private Vector2 actualPos;
    private bool liberate;
    public float CharacterSize = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rebote_izquierda = true;
        rebote_derecha = false;
        transform.localScale = new Vector3(CharacterSize, CharacterSize, 1);
    }

    void OnTriggerEnter(Collider obj)
    {
        if (liberate == false)
        {
            if (obj.tag == "rebote_izquierda")
            {
                rebote_izquierda = true;
                rebote_derecha = false;
            }

            if (obj.tag == "rebote_derecha")
            {
                rebote_izquierda = false;
                rebote_derecha = true;
            }
        }

        if (obj.tag == "ArgomAttack")
        {
            liberate = true;
            StartCoroutine(AfterExplote());
            
        }
    }
    void FixedUpdate()
    {
        if (rebote_izquierda = true)
        { 
            rb.AddForce(Vector2.right * speed);
            float LimitedSpeedRun = Mathf.Clamp(rb.velocity.x, -MaxSpeedWalk, MaxSpeedWalk);
            rb.velocity = new Vector2(LimitedSpeedRun, rb.velocity.y); 
            //Debug.Log("Ando funcionando");
        }
        if (rebote_derecha = true)
        {
            rb.AddForce(Vector2.right * -speed);
            float LimitedSpeedRun = Mathf.Clamp(rb.velocity.x, -MaxSpeedWalk, MaxSpeedWalk);
            rb.velocity = new Vector2(-LimitedSpeedRun, rb.velocity.y); 
            //Debug.Log("Prueba falladida");
        }
    }
    
    IEnumerator CheckEnemiMoving()
    {
        actualPos = transform.position;
        yield return new WaitForSeconds(0.5f);

        if (transform.position.x>actualPos.x)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("Idle", false);
        }
        else if (transform.position.x<actualPos.x)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("Idle", false);
        }
        else if (transform.position.x==actualPos.x && liberate == false)
        {
            animator.SetBool("Idle", true);
        }
        else if (transform.position.x==actualPos.x && liberate == true)
        {
            animator.SetBool("Liberate", true);
        }
    }
    

    IEnumerator AfterExplote()
    {
        yield return new WaitForSeconds(0.2f);
        transform.localScale = new Vector3(CharacterSize*2, CharacterSize*2, 1);
        spriteRenderer.flipX = true;
    }
}
