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

}