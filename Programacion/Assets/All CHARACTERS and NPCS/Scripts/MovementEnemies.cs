using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemies : MonoBehaviour
{
    public float Speed;
    public float RealSpeed;
    private Rigidbody rb;
    bool Right;
    
    
 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        bool RotateAxis;
        float gravity = rb.velocity.y;

        transform.Translate(new Vector3(Speed, 0));
        }
    void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "BorderPlatform")
        {
            Speed = 0;
            if (Speed == 0 && Right == true)
            {
                Speed = -RealSpeed;
                Right = false;
                Invoke("Tiempode1s",1f);
                Debug.Log("fallo");
            }

            if (Speed == 0 && Right == false)
            {
                Speed = RealSpeed;
                Right = true;
                Debug.Log("devolverse");
                Invoke("Tiempode1s",1f);
            }
        }
    }
    public void Tiempode1s()
    {
        Debug.Log("Funcionaaffads");
    }
    
    }
