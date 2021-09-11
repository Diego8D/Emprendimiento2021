using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBasic : MonoBehaviour
{

    public Rigidbody rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float speed = 0.5f;
    private float WaitTime;
    public float startwaittime = 2;
    private int i = 0;
    private Vector2 actualPos;
    public Transform[] moveSpots;
    private bool liberate;
    public float CharacterSize = 5f;
    
    
    
    
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(CharacterSize, CharacterSize, 1);
        WaitTime = startwaittime; 
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CheckEnemiMoving());
        if (liberate == false)
        {

            transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, moveSpots[i].transform.position) < 0.1f)
            {
                if (WaitTime <= 0)
                {
                    if (moveSpots[i] != moveSpots[moveSpots.Length - 1])
                    {
                        i++;
                    }
                    else
                    {
                        i = 0;
                    }

                    WaitTime = startwaittime;
                }
                else
                {
                    WaitTime -= Time.deltaTime;
                }
            }
        }
        else if (liberate == true)
        {
            rb.AddForce(Vector2.right * -speed * 6f);
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

    void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "ArgomAttack")
        {
            liberate = true;
            StartCoroutine(AfterExplote());
            
        }
    }

    IEnumerator AfterExplote()
    {
        yield return new WaitForSeconds(0.3f);
        transform.localScale = new Vector3(CharacterSize*9, CharacterSize*9, 1);
        spriteRenderer.flipX = true;
    }
}
