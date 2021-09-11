using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentanaPanelDialogo : MonoBehaviour
{
    [Header("VentanaPanelDialogo")]
    [SerializeField] private AreaTextoDialogo m_area = default;
    [SerializeField] private BotonTextoDialogo m_button = default;

    [Header("VentanaPanelDialogo")]
    [SerializeField] private bool m_continueCallback = default;

    private Coroutine p_internalRutine;

    public void Start()
    {
        gameObject.SetActive(false);

        m_area.ResetAll();
        m_button.DesaparecerButon();
    }

    public void ShowDialogue(List<string> dialogueList)
    {
        gameObject.SetActive(true);

        if (p_internalRutine != null) { StopCoroutine(p_internalRutine); };
        p_internalRutine = StartCoroutine(InternalRutine(dialogueList));
    }

    private IEnumerator InternalRutine(List<string> dialogueList)
    {
        yield return null;

        if (dialogueList.Count <= 0) { yield break; };

        foreach (string item in dialogueList)
        {
            m_continueCallback = false;
            m_button.DesaparecerButon();
            m_area.MostarTexto(item);
            yield return new WaitForSeconds(1);
            m_button.AparecerButon();

            yield return new WaitUntil(() => m_continueCallback );

            yield return null;

        }

    }


    public void SetReadyToCOntinue()
    {
        m_continueCallback = true;
    }
}