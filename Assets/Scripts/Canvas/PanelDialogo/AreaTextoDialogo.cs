using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaTextoDialogo : MonoBehaviour
{
    [Header("VentanaPanelDialogo")]
    [SerializeField] private Text m_textObject = default;

    public void MostarTexto(string nuevoTexto)
    {
        m_textObject.text = nuevoTexto;
    }

    public void ResetAll()
    {
        m_textObject.text = "";

    }
}
