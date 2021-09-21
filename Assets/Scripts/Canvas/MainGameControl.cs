using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameControl : MonoBehaviour
{
    [Header("ObjetoInteractuable")]
    [SerializeField] private MainCanvasControl m_mainCanvas = default;
    [SerializeField] private MovementPrincipalCharacter m_mainPlayer = default;




    [Header("Primeros Objetos narrativos")]
    [SerializeField] private GameObject m_limitiesPrimeraParte = default;
    [SerializeField] private ObjetoInteractuable m_primeraCharla = default;
    
    
    [Header("Segundos Objetos narrativos")]
    [SerializeField] private GameObject m_limitiesSegunda = default;
    [SerializeField] private ObjetoInteractuable m_segundaCharla = default;

    [Header("Terceros Objetos narrativos")]
    [SerializeField] private GameObject m_limitiesTercera = default;
    [SerializeField] private ObjetoInteractuable m_terceraCharla = default;
    
    
    [Header("Cuartos Objetos narrativos")]
    [SerializeField] private GameObject m_limitiesCuarta = default;
    [SerializeField] private ObjetoInteractuable m_cuartaCharla = default;
    
    
    [Header("Quintos Objetos narrativos")]
    [SerializeField] private GameObject m_limitiesQuinta = default;
    [SerializeField] private ObjetoInteractuable m_quintaCharla = default;
    
    
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
//PrimeraCharla//
        yield return null;

        m_limitiesPrimeraParte.SetActive(true);

        yield return new WaitUntil(() => m_primeraCharla.IsDoneTalking);


        m_limitiesPrimeraParte.SetActive(false);

        yield return new WaitForSeconds(1);

        //PrimeraCharla//
        
        
        
        
//SegundaCharla//
        yield return null;

        m_limitiesSegunda.SetActive(true);

        yield return new WaitUntil(() => m_segundaCharla.IsDoneTalking);


        m_limitiesSegunda.SetActive(false);

        yield return new WaitForSeconds(1);

//AcabaSegundaCharla//

//terceraCharla//
        yield return null;

        m_limitiesTercera.SetActive(true);

        yield return new WaitUntil(() => m_terceraCharla.IsDoneTalking);


        m_limitiesTercera.SetActive(false);

        yield return new WaitForSeconds(1);

//AcabaterceraCharla//


//cuartaCharla//
        yield return null;

        m_limitiesCuarta.SetActive(true);

        yield return new WaitUntil(() => m_cuartaCharla.IsDoneTalking);


        m_limitiesCuarta.SetActive(false);

        yield return new WaitForSeconds(1);

//AcabacuartaCharla//


//quintaCharla//
        yield return null;

        m_limitiesQuinta.SetActive(true);

        yield return new WaitUntil(() => m_quintaCharla.IsDoneTalking);


        m_limitiesQuinta.SetActive(false);

        yield return new WaitForSeconds(1);

//Acabaquintaharla//


        List<string> debugText = new List<string>() { "...", "..."};
        m_mainCanvas.Dialogue.ShowDialogue(debugText, null);




        yield return new WaitForSeconds(1);
        m_mainCanvas.Dialogue.ShowDialogue(m_parrafoObj.Parrafos, null);


    }

    [SerializeField] private DialogueLines m_parrafoObj = default;

}
