using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoEnemigo : ObjetoDestruibleBase
{
    [Header("ObjetoPensamiento")]
    [SerializeField] private Animator m_enemiAnim = default;

    private string p_destroyTrigger = "Destroy";

    protected override void DestroyMeNow()
    {
        m_enemiAnim.SetTrigger(p_destroyTrigger);
    }




}
