using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    public PersonajeManager personajeManager;
    public GameObject[] personajeSlots;
    public AccionManager accionManager;
    public GameObject[] accionSlots;
    public List<Personaje> PersonajesAplicadosEnAcciones = new List<Personaje>();
    public GameObject botonContinuar;
    public TextMeshProUGUI dinero;

    public static float dineroXRonda = 0;
    public static float dineroTotal = 100;

    public int cinco = 5;

    private void Start() {
        accionManager.CrearAcciones();
        accionManager.DefinirValoresAcciones(personajeManager.personajes);

    }

    public void IncrementarListaDeSelecciones(GameObject item) {
        for (int i = 0; i < personajeManager.personajes.Count; i++) {
            if (personajeSlots[i] == item && !PersonajesAplicadosEnAcciones.Contains(personajeManager.personajes[i])) {
                PersonajesAplicadosEnAcciones.Add(personajeManager.personajes[i]);
            }

        }
        // Debug.Log("Tamaño de Personajes Aplicados" + PersonajesAplicadosEnAcciones.Count.ToString());
    }

    public void DisminuirListaDeSelecciones(GameObject item) {
        for (int i = 0; i < personajeManager.personajes.Count; i++) {
            if (personajeSlots[i] == item)
                PersonajesAplicadosEnAcciones.Remove(personajeManager.personajes[i]);
        }
        // Debug.Log("Tamaño de Personajes Aplicados" + PersonajesAplicadosEnAcciones.Count.ToString());
    }

    public void RevisarSiTenemosQueMostrarBoton() {
        if (PersonajesAplicadosEnAcciones.Count == 3) {
            botonContinuar.SetActive(true);
        } else {
            botonContinuar.SetActive(false);
        }
    }


    // Logica unica de game 
    public void Jugar() {
        accionManager.LimpiarAcciones();
        accionManager.CrearAcciones();
        accionManager.DefinirValoresAcciones(personajeManager.personajes);


        // Se llamo a Jugar desde otro lado (Click Hacer accion)
        // bool mostrarResumen = r.aumentarDia();
        // if (mostrarResumen)
        // {
        //     // Invoca un evento para mostrar valores le pasamos dineroXRonda
        //     Debug.Log("Dinero de la ronda: " + dineroXRonda);
        //     dineroXRonda = 0;
        // }
        //am.DefinirValoresAcciones(pm.listaPersonajes_.Find(p=>p.Nombre_=="Pepe").Felicidad_,0);

        // Redefine acciones con random fel PJ

        // am.DefinirValoresAcciones(pm.DevolverFelicidad());
        // var listAccionesAlAzar = am.listaAcciones_.OrderBy(x => UnityEngine.Random.value).ToList();
        float dineroXdia = 0;
        // for (int i = 0; i < listAccionesAlAzar.Count; i++)
        // {
        //     // Debug.Log("Accion[" + i + "] Ganancia: " + listAccionesAlAzar[i].Ganancia_ + "Costo F :( " + listAccionesAlAzar[i].Costo_felicidad);
        //     // pm.RealizarAccion(listAccionesAlAzar[i].Ganancia_, listAccionesAlAzar[i].Costo_felicidad, pm.listaPersonajes_[i].Nombre_);

        //     dineroXdia = (int)(pm.listaPersonajes_[i].MultiplicadorDinero_ * listAccionesAlAzar[i].Ganancia_);
        //     dineroTotal += dineroXdia;
        // }

        dineroXRonda += dineroXdia;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {

            Jugar();
        }



        // implementar clase rondas con "dias" , luego la ganancia individual por dia pasado
        // se va a poso comun
    }



    private void ActivarAcciones() {
        for (int i = 0; i < personajeSlots.Length; i++) {
            GameObject item2 = personajeSlots[i].transform.parent.gameObject;
            // Debug.Log("ParentName" + item2.name);
            Accion accionTemp = accionManager.acciones[i];
            personajeManager.personajes[i].HacerAccion(accionTemp.ganancia, accionTemp.costo_felicidad);
        }
    }

    private void ResetPosicionDePersonajes() {

        for (int i = 0; i < personajeSlots.Length; i++) {
            Carta_Accion test = FindObjectOfType<Carta_Accion>();
            personajeSlots[i].transform.position = personajeSlots[i].transform.GetComponent<Carta_Accion>().initialPosition;
            DisminuirListaDeSelecciones(personajeSlots[i]);
        }
    }

    public void PasarTurno() {
        ActivarAcciones();
        Debug.Log("Chanchito: " + dineroTotal);
        //item.GetComponent<AudioSource>().Play();
        if (dineroTotal <= 50) {

            SceneManager.LoadScene(5);
        }

        if (101 <= dineroTotal) {

            SceneManager.LoadScene(6);
            Debug.Log("Chanchitooooooooooooo: " + cinco);
           
            ResetPosicionDePersonajes();
            RevisarSiTenemosQueMostrarBoton();
            Jugar();
        }
    }

}
