using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SeleccionPersonajes : MonoBehaviour
{
    public Personaje personajeEnPantalla;
    public Personaje[] personajesSeleccionables;
    public GameObject[] personajesEnScroll;
    public TMP_Text nombreEnPantalla;
    public TMP_Text ModificadorDineroEnPantalla;
    public TMP_Text MedidorFelicidadEnPantalla;
    public TMP_Text descripcionEnPantalla;
    public TMP_Text dineroInicialEnPantalla;
    public GameObject imagenEnPantalla;

    // Start is called before the first frame update
    void Start()
    {
        imagenEnPantalla.GetComponent<Image>().enabled = false;
        for (int i = 0; i < personajesSeleccionables.Length; i++)
        {
            personajesEnScroll[i].GetComponent<Image>().sprite = personajesSeleccionables[i].sprite;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(personajeEnPantalla.nombre != "")
        {
            nombreEnPantalla.text = personajeEnPantalla.nombre;
            ModificadorDineroEnPantalla.text = personajeEnPantalla.multiplicadorDinero.ToString();
            MedidorFelicidadEnPantalla.text = personajeEnPantalla.felicidad.ToString();
            descripcionEnPantalla.text = personajeEnPantalla.descripcion;
            dineroInicialEnPantalla.text = personajeEnPantalla.dineroInicial.ToString();
            imagenEnPantalla.GetComponent<Image>().sprite = personajeEnPantalla.sprite;
            imagenEnPantalla.GetComponent<Image>().enabled = true;
        }
    }

    public void test(int i)
    {
        personajeEnPantalla = personajesSeleccionables[i];
    }
}
