using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CortinaCambioDia : MonoBehaviour
{
    [SerializeField] Image[] personajesImagenes ;
    [SerializeField] TextMeshProUGUI[] personajesTextos;
    [SerializeField] RawImage[] personajesFondo;
    [SerializeField] Texture[] Fondos;
    [SerializeField] AudioSource sndClickBoton;             // para reproducir el sonido de click del boton

    public void AsignarElementos(String[] textos, string[] tipos)
    {
        for (int i = 0; i < personajesImagenes.Length; i++)
        {
            personajesTextos[i].text = textos[i];
            personajesFondo[i].texture = Fondos[Indice_DeFondosSegunTipo(tipos[i])];
        }
    }
    public void ContinuarElDia()
    {
        // play el sonido del click del boton
        sndClickBoton.Play();

        GetComponent<Animator>().Play("Abrir"); // Sube el Telon => Se va 
    }
    public void CerrarElDia()
    {
        GetComponent<Animator>().Play("cierre"); // Baja el Telon => Se ve la presentacion
    }

    private int Indice_DeFondosSegunTipo(string tipoAccion) {
        // Segun como se agrego en el inspector es:
        switch (tipoAccion) {
            case "Trabajo": return 0;
            case "Ocio": return 1;
            case "Descanso": return 2;
            case "Suerte": return 3;
            case "Catastrofe": return 4;

            default: return -1;
        }
    }  
}
