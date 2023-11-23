using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControlSliders : MonoBehaviour
{
    [SerializeField]
    Image carita;
    [SerializeField]
    Slider felicidad_slider;
    [SerializeField]
    Slider productividad_slider;
    [SerializeField]
    List<Sprite> caras;

    private int Felicidad;

    public int CambioFelicidad
    {
      
        set { Felicidad = value;
            felicidad_slider.value = Felicidad;
           
            if (Felicidad > 0)
            {
                
              carita.sprite = caras[0];
            }
            else
            {
               carita.sprite = caras[1];
            }
        }
    }

    private int Productividad;

    public int CambioProductividad
    {
        set { Productividad = value;
            productividad_slider.value = Productividad;
        }
    }

  
}
