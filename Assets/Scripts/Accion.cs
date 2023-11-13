using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Accion
{
    public string descripcion;
    public int ganancia = 1;
    public int costo_felicidad = 0;
    public string tipoAccion;
    public Sprite accionSprite;

    // constantes provisionales de control 
    private int MAX_Felicidad=5;
    private int Min_Felicidad=-5;
    private int MAX_Dinero=15;
    private int Min_Dinero=-15;



    public Accion()
    {
        int random = Random.Range(0,101);
        if (random<80)
        {
            if (random<50)
            {
                // generar Trabajo
                tipoAccion = "Trabajo";
                accionSprite = Resources.Load<Sprite>("Sprites/cartas/Trabajo");
            }
            else
            {
                // generar Ocio
                tipoAccion = "Ocio";
                accionSprite = Resources.Load<Sprite>("Sprites/cartas/Ocio");
            }
            costo_felicidad = (int)(Random.Range(Min_Felicidad, MAX_Felicidad + 1));
            ganancia = (int)(Random.Range(Min_Dinero, MAX_Dinero + 1));
        }
        else if (random < 95)
        {
            // generar Descanso
            tipoAccion = "Descanso";
            costo_felicidad = (int)(Random.Range((int)(Min_Felicidad/2), (int)(MAX_Felicidad / 2) + 1));
            ganancia = (int)(Random.Range((int)(Min_Dinero / 2), (int)(MAX_Dinero / 2) + 1));
            accionSprite = Resources.Load<Sprite>("Sprites/cartas/Descanso");

        }
        else if (random < 98)
        {
            // generar Suerte
            tipoAccion = "Suerte";

            costo_felicidad = (int)(Random.Range((int)(MAX_Felicidad / 2), (int)(MAX_Felicidad ) + 1));
            ganancia = (int)(Random.Range((int)(MAX_Dinero / 2), (int)(MAX_Dinero) + 1));
            accionSprite = Resources.Load<Sprite>("Sprites/cartas/Suerte");
        }
        else 
        {
            // generar Catastrofe
            tipoAccion = "Catastrofe";
            //Revisar
            costo_felicidad = (int)(Random.Range( (int)(Min_Felicidad), (int)(Min_Felicidad / 2)+1));
            ganancia = (int)(Random.Range((int)(Min_Dinero), (int)(Min_Dinero / 2) + 1));
            accionSprite = Resources.Load<Sprite>("Sprites/cartas/Catastrofe");
        }
    }

    public Accion(Sprite d, int g, int c)
    {
        accionSprite = d;
        ganancia = g;
        costo_felicidad = c;
    }


    // Logica unica de la clase
    public void AutoDefinirse(int value)
    {
        // Valores de costo de felicidad Rango de [-5,5] + fel del personaje
        int auxF = (int)(Random.Range(Min_Felicidad, MAX_Felicidad + 1));
        Debug.Log("Valor auxF: "+auxF);
        auxF += value;
        //Debug.Log("Valor auxF+value: "+auxF);

        costo_felicidad = auxF > MAX_Felicidad ? MAX_Felicidad: auxF < Min_Felicidad ? Min_Felicidad: auxF;
        //Debug.Log("Costo Felicidad Final: " + costo_felicidad);

        // Recibe un value (Felicidad de un jugador) => Define su ganancia y costo en base*

        // Logica de dinero
        //ganancia = (int)(Random.Range(Min_Dinero, MAX_Dinero + 1) );

    }
}
