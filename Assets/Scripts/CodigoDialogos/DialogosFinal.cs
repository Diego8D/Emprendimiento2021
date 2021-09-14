using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogosFinal : MonoBehaviour
{
    public TextMeshProUGUI textD;

    [TextArea(3,30)]
    public string[] parrafos;

    int index;
    public float velparrafo;

    public GameObject botonContinuer;
    public GameObject botonQuitar;

    public GameObject panelDialogo;
    public GameObject botonleer;

    private void Start()
    {
        botonQuitar.SetActive(false);
        botonleer.SetActive(false);
        panelDialogo.SetActive(false);
    }

    
   private void Update()
    {
      if (textD.text==parrafos[index])
        {
            botonContinuer.SetActive(true);
        }
    }

    IEnumerator TextDialogo()
    {
        foreach(char letra in parrafos[index].ToCharArray())
        {
            textD.text += letra;

            yield return new WaitForSeconds(velparrafo);

        }
    }
    public void siguienteParrafo()
    {
        botonContinuer.SetActive(false);
            if(index < parrafos.Length - 1)
        {
            index++;
            textD.text = "";
            StartCoroutine(TextDialogo());
        }
            else
        {
            textD.text = "";
            botonContinuer.SetActive(false);
            botonQuitar.SetActive(true);
        }
            
    }
    private void OnTriggerEnter(Collider Collision)
    {
        if(Collision.gameObject.CompareTag("Player"))
        {
            botonleer.SetActive(true);
            Debug.Log("NoSirvenLosTriggers");
        }
        else
        {
            botonleer.SetActive(false);
            Debug.Log("NoSirvenLosTriggers");
        }
    }
    public void activarBotonLeer()
    {
        panelDialogo.SetActive(true);
        StartCoroutine(TextDialogo()); 
    }
    public void botonCerrar()
    {
        panelDialogo.SetActive(false);
        botonleer.SetActive(false);
       
    }
}
