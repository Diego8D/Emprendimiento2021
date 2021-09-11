using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public Collider collider;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public GameObject destroyParticle;
    private bool explote;

    void FixedUpdate()
    {
        if (explote = true)
        {
            
        }
    }


    private void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "ArgomAttack")
        {
            explote = true;
        }
    }


}
