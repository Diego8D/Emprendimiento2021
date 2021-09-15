using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvasControl : MonoBehaviour
{
    [Header("MainCanvasControl")]
    [SerializeField] private VentanaPanelDialogo m_dialogue = default;
    [SerializeField] private InteractionPanel m_interaction = default;
    [SerializeField] private InitialPanel m_initial = default;

    
    public VentanaPanelDialogo Dialogue => m_dialogue;
    public InteractionPanel Interaction => m_interaction;
    public InitialPanel Initial => m_initial;

    public void Start()
    {
        Dialogue.Setup();
        Interaction.Setup();
        Initial.Setup();

    }

}
