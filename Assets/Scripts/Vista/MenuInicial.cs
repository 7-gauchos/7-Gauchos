using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInicial : MonoBehaviour
{
    //permite configurar y ejecutar el sonido de fondo de la pantalla principal
    public AudioSource audioBackground;
    
    public void Start()
    {
        audioBackground.volume = 0.5f;
        audioBackground.Play();
    }
}
