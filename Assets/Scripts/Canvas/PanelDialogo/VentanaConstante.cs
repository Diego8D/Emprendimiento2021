using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentanaConstante : MonoBehaviour
{

    public void Setup()
    {

        CloseAll();
    }

    public void CloseAll()
    {
        gameObject.SetActive(false);
    }

    public void Abrir()
    {
        gameObject.SetActive(true);

    }


    public void BotonPause()
    {
        FedesoftGame.MainCanvas.IniciarEstadoPausa();
    }

}
