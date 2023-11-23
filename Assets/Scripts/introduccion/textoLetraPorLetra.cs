using System.Collections;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public TextMeshProUGUI fraseCompleta;
    public TextMeshProUGUI textoEscrito;
    public float waitTime = 0.06f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Reloj());
    }

    IEnumerator Reloj()
    {
        foreach (char caracter in fraseCompleta.text.ToString())
        {
            textoEscrito.text = textoEscrito.text + caracter;
            yield return new WaitForSeconds(waitTime);
        }
    }
}