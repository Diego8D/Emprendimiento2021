using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvasControl : MonoBehaviour
{
    [Header("MainCanvasControl")]
    [SerializeField] private VentanaPanelDialogo m_dialogue = default;
    [SerializeField] private InteractionPanel m_interaction = default;
    [SerializeField] private InitialPanel m_initial = default;
    [SerializeField] private VentanaPausa m_pause = default;
    [SerializeField] private VentanaConstante m_constant = default;

    public VentanaPanelDialogo Dialogue => m_dialogue;
    public InteractionPanel Interaction => m_interaction;
    public InitialPanel Initial => m_initial;
    public VentanaPausa Pausa => m_pause;
    public VentanaConstante Constante => m_constant;

    public void Start()
    {
        Dialogue.Setup();
        Interaction.Setup();
        Initial.Setup();
        Pausa.Setup();
        Constante.Setup();
    }




    public void IniciarEstadoPausa()
    {
        m_dialogue.CloseAll();

        m_interaction.ClosePanel();
        m_initial.CloseAll();

        m_constant.CloseAll();

        Pausa.AbrirVentanaPausa();

        FedesoftGame.MainPlayer.ModifcyUsedValue(false);

    }



    public void TerminarEstadoPause()
    {

        m_constant.Abrir();

        Pausa.CloseAll();

        FedesoftGame.MainPlayer.ModifcyUsedValue(true);

    }

}
