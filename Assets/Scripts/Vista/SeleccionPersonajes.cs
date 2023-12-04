using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

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
    public GameObject[] personajesEnUIEquipo;
    public List<Personaje> personajesEnEquipo = new List<Personaje>();
    public GameObject botonAgregar;
    public GameObject botonQuitar;
    public GameObject botonContinuar;
    public GameObject signoBloqueado;
    public TMP_Text MontoInicialxEquipo;
    public AudioSource aubtnSeleccionPersonaje;
    public AudioSource aubtnAgregarPersonaje;
    public AudioSource aubtnQuitarPersonaje;


    // Start is called before the first frame update
    void Start()
    {
        imagenEnPantalla.GetComponent<Image>().enabled = false;
        for (int i = 0; i < personajesSeleccionables.Length; i++)
        {
            personajesEnScroll[i].GetComponent<Image>().sprite = personajesSeleccionables[i].sprite;

        }
        for (int i = 0; i < personajesEnUIEquipo.Length; i++)
        {
            personajesEnUIEquipo[i].SetActive(false);
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
            if (!personajeEnPantalla.habilitado)
            {
                signoBloqueado.SetActive(true);
                botonAgregar.SetActive(false);
                botonQuitar.SetActive(false);
            }
            else
            {
                if (personajesEnEquipo.Contains(personajeEnPantalla))
                {
                    botonAgregar.SetActive(false);
                    botonQuitar.SetActive(true);
                    signoBloqueado.SetActive(false);
                }
                else
                {
                    botonAgregar.SetActive(true);
                    botonQuitar.SetActive(false);
                    signoBloqueado.SetActive(false);
                }
            }

        }
        botonContinuar.SetActive(personajesEnEquipo.Count == 3);
    }

    public void test(int i)
    {
        personajeEnPantalla = personajesSeleccionables[i];

        // reproduce el sonido al hacer click sobre el personaje para elegirlo
        aubtnSeleccionPersonaje.Play();


    }

    public void agregarPersonajeAlEquipo()
    {
        if (!personajesEnEquipo.Contains(personajeEnPantalla) && personajesEnEquipo.Count < 3)
        {
            // play sonido al agregar el personaje
            aubtnAgregarPersonaje.Play();

            personajesEnEquipo.Add(personajeEnPantalla);
            int i = personajesEnEquipo.IndexOf(personajeEnPantalla);

            personajesEnUIEquipo[i].GetComponent<Image>().sprite = personajeEnPantalla.sprite;
            personajesEnUIEquipo[i].SetActive(true);
            MontoInicialxEquipo.text = (int.Parse(MontoInicialxEquipo.text) + personajeEnPantalla.dineroInicial).ToString();
        }

    }

    public void quitarPersonajeDelEquipo()
    {
        if (personajesEnEquipo.Contains(personajeEnPantalla))
        {
            // play sonido al quitar el personaje
            aubtnQuitarPersonaje.Play();

            int i = personajesEnEquipo.IndexOf(personajeEnPantalla);
            while (i + 1 < personajesEnEquipo.Count)
            {
                personajesEnUIEquipo[i].GetComponent<Image>().sprite = personajesEnUIEquipo[i + 1].GetComponent<Image>().sprite;
                i++;
            }

            personajesEnUIEquipo[i].GetComponent<Image>().sprite = null;
            personajesEnUIEquipo[i].SetActive(false);
            MontoInicialxEquipo.text = (int.Parse(MontoInicialxEquipo.text) - personajeEnPantalla.dineroInicial).ToString();
            personajesEnEquipo.Remove(personajeEnPantalla);
        }

    }

    public void IrAPantallaSeleccionMision()
    {
        SceneManager.LoadScene(2);
    }
}
