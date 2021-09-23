using Fryos.Core;
using System;
using UnityEngine;


public class FedesoftGame : FryosSingleton<FedesoftGame>
{
    protected FedesoftGame() { }

    [Header("Game Singleton")]
    [SerializeField] private MainCanvasControl m_mainCanvas = default;
    [SerializeField] private MovementPrincipalCharacter m_mainPlayer = default;

    public static MainCanvasControl MainCanvas => Instance.m_mainCanvas;
    public static MovementPrincipalCharacter MainPlayer => Instance.m_mainPlayer;




    private Transform m_lastCheckpoint = default;


    public static void UpdateCheckpoint(Transform lastCheckpoint)
    {
        Instance.m_lastCheckpoint = lastCheckpoint;
    }


    public static void ForzarRestauracion( )
    {
        if (Instance.m_lastCheckpoint == null) { return; };
        MainPlayer.transform.position = Instance.m_lastCheckpoint.position;
    }
}