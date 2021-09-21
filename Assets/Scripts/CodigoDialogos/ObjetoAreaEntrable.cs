using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using Cinemachine;

public class ObjetoAreaEntrable : ObjetoInteractuableBase
{
    [Header("ObjetoAreaEntrable")]
    [SerializeField] private CinemachineVirtualCamera m_thinkCamera = default;


    protected override void TriggerInternalEnter()
    {
        SetCameraVisualStatus(true);

    }

    protected override void TriggerInternalExit()
    {
        SetCameraVisualStatus(false);

    }



    private void SetCameraVisualStatus(bool newStatus)
    {
        if (m_thinkCamera != null)
        {
            m_thinkCamera.gameObject.SetActive(newStatus);
        };
    }



}
