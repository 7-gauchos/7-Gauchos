using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Personaje : MonoBehaviour
{
    // Variables de Clase
    public string nombre;
    public float multiplicadorDinero = 1;
    public int felicidad = 0;
    public string descripcion = "";
    public int dineroInicial = 0;
    public Sprite sprite;
    public int dineroObtenido=0;
    // Variables de Control
    private int max_Felicidad = 5;
    private int min_Felicidad = -5;
    private int max_multiplicador = 5;
    private float min_multiplicador = 1 / 256;
    public bool habilitado = true;


    // Logica propia de la clase 

    public void HacerAccion(int ganancia, int costo_Felicidad) {
        // DineroIndividual += ganancia * multiplicadorDinero_;
        felicidad += costo_Felicidad;
        Debug.Log(nombre + " trabajo! Su Dinero: " + ganancia * multiplicadorDinero + " Su felicidad: " + felicidad);
        dineroObtenido += (int)(ganancia * multiplicadorDinero);

        RestablecerFelicidad();
    }

    private void RestablecerFelicidad()
    {
        if ((felicidad < min_Felicidad))
        {
            multiplicadorDinero = (multiplicadorDinero >= 0 && multiplicadorDinero <= 1) ? multiplicadorDinero * .5f : multiplicadorDinero - 1;
            if (multiplicadorDinero <= min_multiplicador)
            {
                multiplicadorDinero = min_multiplicador;
                felicidad = min_Felicidad;
            }
            else
            {
                felicidad = 0;
            }
            // Debug.Log("Tope depresion: " + multiplicadorDinero_);
        }
        else if (felicidad > max_Felicidad)
        {
            multiplicadorDinero = (multiplicadorDinero >= 0 && multiplicadorDinero <= 1) ? multiplicadorDinero * 2 : multiplicadorDinero + 1;
            if (multiplicadorDinero >= max_multiplicador)
            {
                multiplicadorDinero = max_multiplicador;
                felicidad = max_Felicidad;
                // Si el multiplicador esta en el tope, no hay reset de felisidat n.n
            }
            else
            {
                felicidad = 0;
            }
            // Debug.Log("Tope dopamina: " + multiplicadorDinero_);
        }
    }
} // Fin clase 
