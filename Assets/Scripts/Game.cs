using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class Game : MonoBehaviour {
    // Variables de Game
    [SerializeField] Button botonContinuar_;                    // Boton Continuar
    [SerializeField] List<GameObject> Lista_Paneles_Personajes; // Lista de Paneles P..
    [SerializeField] List<GameObject> Lista_CARTAS_Acciones_;   // Lista contenedora de Acciones 

    [SerializeField] GameObject prefabCartaAccion;              // Prefabricado de la Carta Accion
    [SerializeField] Canvas canvasPadre;                        // Padre original de las cartas
    [SerializeField] ContadorDinero text_Dinero_Conjunto;

    private void Awake() {
        // boton continuar inicia desactivado
        botonContinuar_.gameObject.SetActive(false);
        
    }

    void Start() {
        int dineroArranque = 0;
        foreach (var elem in Lista_Paneles_Personajes)
        {
            dineroArranque += elem.transform.GetComponent<Personaje>().dineroObtenido;
        }
        text_Dinero_Conjunto.setDinero(dineroArranque);
    }

    void Update() {

        if (Lista_Paneles_Personajes.Count != 0 && Lista_CARTAS_Acciones_.Count != 0) {
            // Todos los paneles tienen su carta
            if (Lista_Paneles_Personajes.All(elemento => elemento.transform.GetComponent<Drop>().espacio_Ocupado_)) {
                botonContinuar_.gameObject.SetActive(true);
                //Debug.Log("Todas las cartas puestas");
            } else {
                botonContinuar_.gameObject.SetActive(false);
            }
        }
    }
    //Esto implica crear nuevas cartas y asociar a la lista de "CARTAS" los nuevos sprites y valores. 
    public void PasarDia(){ 
        int auxInt = 0;
        int dineroBase = 0;
        // Paso 1) Los personajes realizan las acciones
        foreach (var elem in Lista_Paneles_Personajes) {
            dineroBase += elem.transform.GetComponent<Personaje>().dineroObtenido;
            var costo_Fel = elem.transform.GetComponent<Drop>().transform.GetChild(0).GetComponent<Accion>().Costo_felicidad;
            var dinero = elem.transform.GetComponent<Drop>().transform.GetChild(0).GetComponent<Accion>().Dinero;
            elem.transform.GetComponent<Personaje>().HacerAccion(dinero,costo_Fel);
            // Paso 2) se separan de ellas 
            elem.transform.GetComponent<Drop>().QuitarHijaPorPasoTurno();
            auxInt+=elem.transform.GetComponent<Personaje>().dineroObtenido;
        }
        // Paso 3) Sumo lo recaudado
        StartCoroutine(text_Dinero_Conjunto.EfectoDeCambio(auxInt-dineroBase, dineroBase));
        // Paso 4) Se crean nuevas cartas de Accion 
        List<GameObject> nuevaLista = new List<GameObject>();
        foreach (var elem in Lista_CARTAS_Acciones_) {
            GameObject nuevaCarta = Instantiate(prefabCartaAccion);
            RectTransform rectTransformElem = elem.transform.GetComponent<RectTransform>();

            nuevaCarta.transform.SetParent(canvasPadre.transform);
            nuevaCarta.transform.position = elem.transform.GetComponent<Carta_Accion>().initialPosition;
            nuevaCarta.transform.localScale = Vector3.one;
            nuevaCarta.GetComponent<RectTransform>().sizeDelta = rectTransformElem.sizeDelta;
            nuevaCarta.GetComponent<RectTransform>().anchoredPosition = rectTransformElem.anchoredPosition;

            nuevaLista.Add(nuevaCarta);
        }

        // Se destruyen las viejas
        for (int i = Lista_CARTAS_Acciones_.Count - 1; i >= 0; i--) {
            Destroy(Lista_CARTAS_Acciones_[i]);
            Lista_CARTAS_Acciones_.RemoveAt(i);
        } 
        // Se actualiza la lista
        Lista_CARTAS_Acciones_ = nuevaLista;

        StartCoroutine(aparecerIndividualmente());

        IEnumerator aparecerIndividualmente()
        {
            for (int i = 0; i < Lista_CARTAS_Acciones_.Count; i++)
            {
                yield return new WaitForSecondsRealtime(0.5f);
                Lista_CARTAS_Acciones_[i].SetActive(true);
                Lista_CARTAS_Acciones_[i].GetComponent<Animator>().Play("caida");
            }
        }

    }

}