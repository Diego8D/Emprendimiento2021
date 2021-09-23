
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

using System.Linq;

public abstract class ObjetoDestruibleBase : MonoBehaviour
{
    private bool p_isDestroyed;

    public void OnTriggerEnter(Collider coll)
    {
        if (p_isDestroyed) { return; };
        if (coll.gameObject.CompareTag("ArgomAttack"))
        {
            p_isDestroyed = true;
            DestroyMeNow();
        };
    }

    protected abstract void DestroyMeNow();



}