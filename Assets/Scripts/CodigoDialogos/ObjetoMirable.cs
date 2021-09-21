using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoMirable : ObjetoInteractuableBase
{

    [Header("ObjetoInteractuable")]
    [SerializeField] private DialogueLines m_parrafoObj = default;


    protected override void TriggerInternalEnter()
    {
        FedesoftGame.MainCanvas.Interaction.ShowInteraccion("Leer", ShowDialogue);

    }

    protected override void TriggerInternalExit()
    {
        FedesoftGame.MainCanvas.Interaction.ClosePanel();

    }



    private void ShowDialogue()
    {
        FedesoftGame.MainPlayer.ModifcyUsedValue(false);
        FedesoftGame.MainCanvas.Dialogue.ShowDialogue(m_parrafoObj.Parrafos, OnEndDialogue);
    }

    private void OnEndDialogue()
    {
        FedesoftGame.MainPlayer.ModifcyUsedValue(true);

        SetUsedStatus();

        ForceInteractionExit();
    }


}
