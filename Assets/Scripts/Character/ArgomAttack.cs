using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArgomAttack : MonoBehaviour
{

    [Header("Components")]
    [SerializeField] private Animator m_anim = default;

    private string p_attack = "Power";

    public void TriggerAttack()
    {
        gameObject.SetActive(true);
        m_anim.SetTrigger(p_attack);

    }

    public void EndAttack()
    {
        gameObject.SetActive(false);


    }

    



    /*
    private bool ArgomAttackLaser;
    private Animator anim;
    private SpriteRenderer RotateAxis;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        RotateAxis = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        anim.SetBool("ArgomAttackLaser", ArgomAttackLaser);
        float h = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ArgomAttackLaser = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            ArgomAttackLaser = false;
        }
        if (h > 0)
        {
            RotateAxis.flipX = false;
        }
        if (h < 0)
        {
            RotateAxis.flipX = true;
        }

    }*/
}
