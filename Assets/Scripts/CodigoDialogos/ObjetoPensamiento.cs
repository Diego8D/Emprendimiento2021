using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoPensamiento : ObjetoInteractuableBase
{
    [Header("ObjetoPensamiento")]
    [SerializeField] private Transform m_restorePoint = default;
    [SerializeField] private DialogueLines m_parrafoObj = default;
    [SerializeField] private CinemachineVirtualCamera m_thinkCamera = default;

    private bool p_isUsed;

    protected override void TriggerInternalEnter()
    {
        if (p_isUsed) { return; };


        FedesoftGame.UpdateCheckpoint(m_restorePoint);


        SetCameraVisualStatus(true);

        FedesoftGame.MainPlayer.ModifcyUsedValue(false);
        FedesoftGame.MainCanvas.Dialogue.ShowDialogue(m_parrafoObj.Parrafos, OnEndDialogue);

    }

    protected override void TriggerInternalExit() {  }

    private void SetCameraVisualStatus(bool newStatus)
    {
        if (m_thinkCamera != null)
        {
            m_thinkCamera.gameObject.SetActive(newStatus);
        };
    }




    private void OnEndDialogue()
    {
        SetCameraVisualStatus(false);

        FedesoftGame.MainPlayer.ModifcyUsedValue(true);

        SetUsedStatus();

        ForceInteractionExit();

        p_isUsed = true;
    }


}
