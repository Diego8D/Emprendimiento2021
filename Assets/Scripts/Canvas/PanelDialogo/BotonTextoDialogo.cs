using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonTextoDialogo : MonoBehaviour
{
    [Header("VentanaPanelDialogo")]
    [SerializeField] private VentanaPanelDialogo m_ventanaDialogos = default;


    public void DesaparecerButon()
    {
        gameObject.SetActive(false);
    }


    public void AparecerButon()
    {
        gameObject.SetActive(true);

    }


    public void PublicButton()
    {
        m_ventanaDialogos.SetReadyToCOntinue();
    }
}
