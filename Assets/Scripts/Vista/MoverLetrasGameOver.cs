using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoverLetrasGameOver : MonoBehaviour
{
    public Image imgLetrasGameOver;
    public Button btnGoInicio;

    private void Start()
    {
        moveWordsGameOver();     
    }

    // permite mover primero las letras y luego que aparezca el boton de ir al inicio
    public void moveWordsGameOver()
    {
        Debug.Log("entro en la clase");
        LeanTween.moveX(imgLetrasGameOver.GetComponent<RectTransform>(), 22, 1.5f).setDelay(0.5f)
            .setEase(LeanTweenType.easeOutBounce);
        
        LeanTween.moveY(btnGoInicio.GetComponent<RectTransform>(), -183, 1.5f).setDelay(2f)
            .setEase(LeanTweenType.easeOutCirc);

    }

}
