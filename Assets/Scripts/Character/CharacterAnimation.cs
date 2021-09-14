using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Animator m_anim = default;


    private string p_OnGround = "OnGround";
    private string p_JumpStart = "JumpStart";
    private string p_OnAir = "OnAir";
    private string p_Speed = "Speed";


    public void TriggerJum()
    {
    }


    public void UpdateSpeed(float newSpeed)
    {
        m_anim.SetFloat(p_Speed, newSpeed);

    }

    public void TriggerJumpStart( )
    {
        m_anim.SetTrigger(p_JumpStart);

    }

    public void TriggerOnAir()
    {
        m_anim.SetTrigger(p_OnAir);

    }

    public void TriggerGround()
    {
        m_anim.SetTrigger(p_OnGround);

    }
}
