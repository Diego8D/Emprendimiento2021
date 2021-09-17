using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIalogosPersonaje : MonoBehaviour
{
    [Header("VentanaPanelDialogo")]
    [SerializeField] private List<string> m_dialogosDePrueba = default;

    [SerializeField] private VentanaPanelDialogo m_ventanaDialogos = default;

    [ContextMenu("Button")]
    public void ProbarDialogos()
    {
        m_ventanaDialogos.ShowDialogue(m_dialogosDePrueba, EndMethod);
    }

    public void EndMethod()
    {
        Debug.Log("Fin");
    }


}
