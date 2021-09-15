using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionPanel : MonoBehaviour
{
    [Header("InteractionPanel")]
    [SerializeField] private Button m_button = default;
    [SerializeField] private Text m_buttonText = default;

    private Action p_cachedButtonAction;

    public void Setup()
    {
        gameObject.SetActive(false);
    }

    public void ShowInteraccion(string buttonText, Action buttonAction)
    {
        gameObject.SetActive(true);

        m_buttonText.text = buttonText;
        p_cachedButtonAction = buttonAction;
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
        ResetAll();

    }

    public void ClickOnMethod()
    {
        p_cachedButtonAction?.Invoke();
        ClosePanel();
    }

    private void ResetAll()
    {
        m_buttonText.text = "";
        p_cachedButtonAction = null;
    }
}
