using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameControl : MonoBehaviour
{
    [Header("ObjetoInteractuable")]
    [SerializeField] private MainCanvasControl m_mainCanvas = default;
    [SerializeField] private MovementPrincipalCharacter m_mainPlayer = default;




    [Header("Objetos narrativos")]
    [SerializeField] private GameObject m_limitiesPrimeraParte = default;
    [SerializeField] private ObjetoInteractuable m_primeraCharla = default;

    public MainCanvasControl MainCanvas => m_mainCanvas;
    public MovementPrincipalCharacter MainPlayer => m_mainPlayer;

    private Coroutine p_internalRutine;


    private IEnumerator Start()
    {
        //yield return new WaitForSeconds(1);
        yield return new WaitForFixedUpdate();

        m_mainCanvas.Initial.ShowInitial();
    }


    public void StartGameIteration()
    {
        MainPlayer.ActivateCharacter();

        if (p_internalRutine != null) { StopCoroutine(p_internalRutine); };
        p_internalRutine = StartCoroutine(MainGameRutine());
    }



    private IEnumerator MainGameRutine()
    {

        yield return null;

        m_limitiesPrimeraParte.SetActive(true);

        yield return new WaitUntil(() => m_primeraCharla.IsDoneTalking);


        m_limitiesPrimeraParte.SetActive(false);

        yield return new WaitForSeconds(1);



        List<string> debugText = new List<string>() { "Sigue adelante", "estas cerca"};
        m_mainCanvas.Dialogue.ShowDialogue(debugText, null);




        yield return new WaitForSeconds(1);
        m_mainCanvas.Dialogue.ShowDialogue(m_parrafoObj.Parrafos, null);


    }

    [SerializeField] private DialogueLines m_parrafoObj = default;

}
