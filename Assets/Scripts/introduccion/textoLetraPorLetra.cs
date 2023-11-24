using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public TextMeshProUGUI fraseCompleta;
    public TextMeshProUGUI textoEscrito;
    public float waitTime = 0.06f;
    public Button btnContinuar;
    public AudioSource audioTeclas;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Reloj());
        
    }

    IEnumerator Reloj()
    {
        audioTeclas.Play();
        foreach (char caracter in fraseCompleta.text.ToString())
        {
            textoEscrito.text = textoEscrito.text + caracter;
            yield return new WaitForSeconds(waitTime);
        }

        // cuando termina de pasar las letras activa el boton para terminar
        audioTeclas.Stop();
        btnContinuar.gameObject.SetActive(true);
    }
}