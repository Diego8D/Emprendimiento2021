
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

using System.Linq;

public abstract class ObjetoInteractuableBase : MonoBehaviour
{

    [Header("ObjetoInteractuable")]
    [SerializeField] private CinemachineVirtualCamera m_virtualCam = default;


    private bool p_isOnFocus;

    private bool p_objectHaveBeenUsed;

    public bool ObjectHaveBeenUsed => p_objectHaveBeenUsed;

    protected void SetUsedStatus()
    {
        p_objectHaveBeenUsed = true;
    }

    public void OnTriggerExit(Collider coll)
    {
        if (p_isOnFocus && coll.gameObject.CompareTag("Player"))
        {
            p_isOnFocus = false;
            TriggerInternalExit();
            SetCameraVisualStatus(false);

        };
    }

    public void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            p_isOnFocus = true;
            TriggerInternalEnter();

            SetCameraVisualStatus(true );
        };
    }


    private void SetCameraVisualStatus(bool newStatus)
    {
        if (m_virtualCam != null)
        {
            m_virtualCam.gameObject.SetActive(newStatus);
        };
    }

    protected abstract void TriggerInternalEnter();
    protected abstract void TriggerInternalExit();

    protected void ForceInteractionExit()
    {
        SetCameraVisualStatus(false);
    }

}