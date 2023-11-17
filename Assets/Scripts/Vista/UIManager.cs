using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    public PersonajeManager personajeManager;
    public GameObject[] personajeSlots;
    public GameObject[] personajeStats;
    public AccionManager accionManager;
    public GameObject[] accionSlots;
    public GameObject botonContinuar;
    public TextMeshProUGUI dinero;

    public static float dineroXRonda = 0;
    public static float dineroTotal = 100;

    private void Start() {
        accionManager.CrearAcciones();
        accionManager.DefinirValoresAcciones(personajeManager.personajes);
        RefrescarTablero();
    }

    private void RefrescarTablero()
    {
        dinero.text = dineroTotal.ToString();
        for (int i = 0; i < accionManager.acciones.Count; i++)
        {
            accionSlots[i].GetComponent<Image>().sprite = accionManager.acciones[i].accionSprite;
            accionSlots[i].transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = accionManager.acciones[i].costo_felicidad.ToString();
            accionSlots[i].transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = accionManager.acciones[i].ganancia.ToString();
            accionSlots[i].SetActive(true);
        }

        for (int i = 0; i < personajeManager.personajes.Count; i++)
        {
            personajeStats[i].transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = personajeManager.personajes[i].felicidad.ToString();
            personajeStats[i].transform.GetChild(1).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = personajeManager.personajes[i].multiplicadorDinero.ToString();
        }
    }

    public void RevisarSiTenemosQueMostrarBoton() {
        int count = 1;
        for (int i = 0; i < accionSlots.Length; i++)        {

            if (accionSlots[i].GetComponent<Carta_Accion>().dropping != null)
            {
                count++;
            }
        }

        botonContinuar.SetActive(count == 3);
    }

    public void AsignarAccionAPersonaje(Carta_Accion c)
    {
        int test2 = System.Array.IndexOf(accionSlots, c.gameObject);
        int test = System.Array.IndexOf(personajeSlots, c.transform.parent.gameObject);
        personajeManager.personajes[test].setAccion(accionManager.acciones[test2]);
    }


    // Logica unica de game 
    public void Jugar() {
        accionManager.LimpiarAcciones();
        accionManager.CrearAcciones();
        accionManager.DefinirValoresAcciones(personajeManager.personajes);
        RefrescarTablero();

        float dineroXdia = 0;
        dineroXRonda += dineroXdia;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {

            Jugar();
        }



        // implementar clase rondas con "dias" , luego la ganancia individual por dia pasado
        // se va a poso comun
    }



    private void ConsumirAcciones() {
        for (int i = 0; i < personajeManager.personajes.Count; i++)
        {
            personajeManager.personajes[i].HacerAccion();
        }
    }

    private void ResetPosicionDeAcciones() {
        for (int i = 0; i < accionSlots.Length; i++) {
            accionSlots[i].GetComponent<Carta_Accion>().ATuCasa();
        }
    }

    public void PasarTurno() {
        ConsumirAcciones();

        //item.GetComponent<AudioSource>().Play();
        if (dineroTotal <= 50) {
            SceneManager.LoadScene(5);
        }

        if (dineroTotal >= 150 ) {
            SceneManager.LoadScene(6);
        }

        ResetPosicionDeAcciones();
        RevisarSiTenemosQueMostrarBoton();
        Jugar();
    }

}
