using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public TextMeshProUGUI fraseCompleta;
    public TextMeshProUGUI textoEscrito;
    public float tiempoDeDifuminacion = 2f;
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
        float desv = 0.12f;
        float variacionDeTransparencia = 1/(tiempoDeDifuminacion / desv);
        audioTeclas.Play();
        foreach (char caracter in fraseCompleta.text.ToString())
        {
            if (caracter == '\n') // difumino las letras
            {
                for (float i = 0; i < tiempoDeDifuminacion; i += desv)
                {
                    Color c = textoEscrito.color;
                    c.a = c.a - variacionDeTransparencia;
                    textoEscrito.color = c;
                    yield return new WaitForSeconds(desv);
                }
                textoEscrito.text = "";
                textoEscrito.color = Color.white;
            }
            else
            {
                textoEscrito.text = textoEscrito.text + caracter;
                yield return new WaitForSeconds(waitTime);
            }
        }
        // cuando termina de pasar las letras activa el boton para terminar
        audioTeclas.Stop();
        btnContinuar.gameObject.SetActive(true);
    }
}