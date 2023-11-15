using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Personaje
{
    public string nombre;
    public float multiplicadorDinero = 1;
    public int felicidad = 0;
    public string descripcion = "";
    public int dineroInicial = 0;
    public Sprite sprite;

    private int max_Felicidad = 5;
    private int min_Felicidad = -5;

    private int max_multiplicador = 5;
    private float min_multiplicador = 1 / 256;

    // Logica propia de la clase 
    public void HacerAccion(int ganancia, int costo)
    {
        // DineroIndividual += ganancia * multiplicadorDinero_;
        felicidad += costo;
        Debug.Log(nombre + " trabajo! Su Dinero: " + ganancia * multiplicadorDinero + " Su felicidad: " + felicidad);
        UIManager.dineroTotal += ganancia * multiplicadorDinero;
        UIManager.dineroXRonda += ganancia * multiplicadorDinero;
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

    /* public void HacerAccion(int ganancia, int costo)
     {
         // DineroIndividual += ganancia * multiplicadorDinero_;
         Felicidad_ += costo;
         Debug.Log(nombre_ + " trabajo! Su Dinero: " + ganancia * multiplicadorDinero_ + " Su felicidad: " + felicidad_);
         RestablecerFelicidad();
     }


     private void RestablecerFelicidad()
     {
         if ((Felicidad_ < min_Felicidad))
         {
             multiplicadorDinero_ = (multiplicadorDinero_ >= 0 && multiplicadorDinero_ <= 1) ? multiplicadorDinero_ * .5f : multiplicadorDinero_ - 1;
             if (multiplicadorDinero_ <= min_multiplicador)
             {
                 multiplicadorDinero_ = min_multiplicador;
                 Felicidad_ = min_Felicidad;
             }
             else
             {
                 Felicidad_ = 0;

             }
            // Debug.Log("Tope depresion: " + multiplicadorDinero_);
         }
         else if (Felicidad_ > max_Felicidad)
         {
             multiplicadorDinero_ = (multiplicadorDinero_ >= 0 && multiplicadorDinero_ <= 1) ? multiplicadorDinero_ * 2 : multiplicadorDinero_ + 1;
             if (multiplicadorDinero_ >= max_multiplicador)
             {
                 multiplicadorDinero_ = max_multiplicador;
                 Felicidad_ = max_Felicidad;
                 // Si el multiplicador esta en el tope, no hay reset de felisidat n.n
             }
             else
             {
                 Felicidad_ = 0;
             }
             // Debug.Log("Tope dopamina: " + multiplicadorDinero_);
         }
     }*/

} // Fin clase 
