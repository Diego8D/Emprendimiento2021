using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialPanel : MonoBehaviour
{
    [Header("InteractionPanel")]
    [SerializeField] private MainGameControl m_mainGameControl = default;

    public void Setup()
    {
        CloseAll();

    }

    public void ShowInitial()
    {
        gameObject.SetActive(true);

    }

    public void CloseAll()
    {
        gameObject.SetActive(false);
    }


    public void InitGame()
    {
        m_mainGameControl.StartGameIteration();

        CloseAll();
    }

}
