using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class ObjetoInteractuable : MonoBehaviour
{
    [Header("ObjetoInteractuable")]
    [SerializeField] private MainCanvasControl m_mainCanvas = default;
    [SerializeField] private MovementPrincipalCharacter m_mainPlayer = default;

    [SerializeField] [TextArea(3, 30)] private string[] parrafos;

    private bool isOnFocus;

    private bool imDoneTalking;

    public bool IsDoneTalking => imDoneTalking;

    public void OnTriggerExit(Collider coll)
    {
        if (isOnFocus && coll.gameObject.CompareTag("Player"))
        {
            isOnFocus = false;
            m_mainCanvas.Interaction.ClosePanel();
            //Debug.Log("OnTriggerExit | Player");
        };
    }

    public void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.CompareTag("Player"))
        {
            isOnFocus = true;
            m_mainCanvas.Interaction.ShowInteraccion("Leer", ShowDialogue);     
        };
    }


    private void ShowDialogue()
    {
        m_mainPlayer.ModifcyUsedValue(false);
        m_mainCanvas.Dialogue.ShowDialogue(parrafos.ToList(), OnEndDialogue);
    }

    private void OnEndDialogue()
    {
        m_mainPlayer.ModifcyUsedValue(true);

        imDoneTalking = true;
    }

}
