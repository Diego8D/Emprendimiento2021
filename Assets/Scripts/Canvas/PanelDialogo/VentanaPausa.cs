using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentanaPausa : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(false);

    }


    public void AbrirVentanaPausa()
    {
        gameObject.SetActive(true);

    }

    public void CloseAll()
    {

        gameObject.SetActive(false);
    }


    public void CerrarJuego()
    {
        Debug.Log("Cerrar JUEGO");

        Application.Quit();
    }



    public void ContinuarJuego()
    {


        FedesoftGame.MainCanvas.TerminarEstadoPause();

    }


}
