using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

    // Variables Eventos y constantes
    [SerializeField] Evento_Elegir_Mision Mision_Elegida;
    private int dias_mision_objetivo;                           // Variable de dias a cumplir la mision
    private int dinero_mision_objetivo;                         // Variable de dinero a cumplir la mision
    [SerializeField] TextMeshProUGUI text_Dinero_deMision;      // Texto para el dinero de la mision

    // Variable para Animacion Cortina                          
    [SerializeField] private GameObject objeto_Cortina;

    // Variables de Game
    [SerializeField] Button botonContinuar_;                    // Boton Continuar
    [SerializeField] List<GameObject> Lista_Paneles_Personajes; // Lista de Paneles P..
    [SerializeField] List<GameObject> Lista_CARTAS_Acciones_;   // Lista contenedora de Acciones 

    [SerializeField] GameObject prefabCartaAccion;              // Prefabricado de la Carta Accion
    [SerializeField] GameObject objetoPadre_DeCartas;           // Padre original de las cartas
    [SerializeField] ContadorDinero text_Dinero_Conjunto;
    [SerializeField] TextMeshProUGUI texto_Dias;                // Texto para Dias en el juego
    private int dias_pasados;                                   // variable int para Dias
    [SerializeField] private int dinero_Total_acumulado = 0;    // Variable int para DineroTotal Acumulado.
    [SerializeField] AudioSource sndClickBoton;                 // Sonido del boton continuar



    private void Awake() {
        // boton continuar inicia desactivado
        botonContinuar_.gameObject.SetActive(false);

        // Cortina inicia desactivada
        objeto_Cortina.SetActive(false);


        // Suscripcion a evento Mision 
        Mision_Elegida.Datos_De_Mision += Fijar_Datos_Mision;

        // Background del Panel => Transparente
        foreach (var elem in Lista_Paneles_Personajes) {
            elem.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        }

    }

    void Start() {

        // ========== PROVICIONAL SI NO HAY ESCENA DE MISION QUE INVOQUE ELEGIR_MISION
        dias_mision_objetivo = 14;
        dinero_mision_objetivo = 200;

        // ==================================================
        text_Dinero_deMision.text = "Dinero necesario:\n"+dinero_mision_objetivo.ToString();

        texto_Dias.text = dias_mision_objetivo.ToString();
        dias_pasados = 0;

        int dineroArranque = 0;
        foreach (var elem in Lista_Paneles_Personajes) {
            dineroArranque += elem.transform.GetComponent<Personaje>().dineroObtenido;
        }
        text_Dinero_Conjunto.setDinero(dineroArranque);

        CreacionDestruccionCartas();
        ModificarSlidersDEPersonajes();
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
        if (texto_Dias != null) {
            texto_Dias.text = (dias_mision_objetivo-dias_pasados).ToString();
        }

    }
    //Esto implica crear nuevas cartas y asociar a la lista de "CARTAS" los nuevos sprites y valores. 
    public void PasarDia() {
        // Sonido del boton
        sndClickBoton.Play();

        // Efecto de Cortina
        Asignar_DescripcionCartas_ACortina();

        // Aumenta dias en 1
        dias_pasados += 1;

        int auxInt = 0;
        int dineroBase = 0;
        // Paso 1) Los personajes realizan las acciones
        foreach (var elem in Lista_Paneles_Personajes) {
            dineroBase += elem.transform.GetComponent<Personaje>().dineroObtenido;
            var costo_Fel = elem.transform.GetComponent<Drop>().transform.GetChild(0).GetComponent<Accion>().Costo_felicidad;
            var dinero = elem.transform.GetComponent<Drop>().transform.GetChild(0).GetComponent<Accion>().Dinero;
            elem.transform.GetComponent<Personaje>().HacerAccion(dinero, costo_Fel);


            // Paso 2) se separan de ellas 
            elem.transform.GetComponent<Drop>().QuitarHijaPorPasoTurno();
            auxInt += elem.transform.GetComponent<Personaje>().dineroObtenido;
            dinero_Total_acumulado = auxInt;
            Debug.Log("Acumulado:" + dinero_Total_acumulado);
        }
        // Paso 2.1) Se modifican los Sliders de los Personajes
        ModificarSlidersDEPersonajes();

        // Paso 3) Sumo lo recaudado
        StartCoroutine(text_Dinero_Conjunto.EfectoDeCambio(auxInt - dineroBase, dineroBase));

        // Paso 3.1) Verifico condicion de Derrota o Victoria
        Condicion_Victoria_Derrota();
        // Paso 3.2) Modifico el color del texto dias
        CambiarColorTextoDias();

        // Paso 4) Se crean y destruyen cartas de Accion 
        CreacionDestruccionCartas();

        StartCoroutine(aparecerIndividualmente());

        IEnumerator aparecerIndividualmente() {
            for (int i = 0; i < Lista_CARTAS_Acciones_.Count; i++) {
                yield return new WaitForSecondsRealtime(0.5f);
                Lista_CARTAS_Acciones_[i].SetActive(true);
                Lista_CARTAS_Acciones_[i].transform.GetChild(0).GetComponent<Animator>().Play("caida");
            }
        }


    }
    public void CreacionDestruccionCartas() {
        List<GameObject> nuevaLista = new List<GameObject>();
        int IndicePersonaje = 0;
        foreach (var elem in Lista_CARTAS_Acciones_) {
            GameObject nuevaCarta = Instantiate(prefabCartaAccion);
            RectTransform rectTransformElem = elem.transform.GetComponent<RectTransform>();

            nuevaCarta.GetComponent<Accion>().Crear_Carta(Lista_Paneles_Personajes[IndicePersonaje++].GetComponent<Personaje>().felicidad);

            nuevaCarta.transform.SetParent(objetoPadre_DeCartas.transform);
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
    }

    // Metodo set invocado desde Escena Mision
    private void Fijar_Datos_Mision(int dinero, int dias) {
        dinero_mision_objetivo = dinero;
        dias_mision_objetivo = dias;
    }

    private void Condicion_Victoria_Derrota() {

        // Condicion Victoria
        if (dinero_Total_acumulado >= dinero_mision_objetivo) {
            SceneManager.LoadScene("Victoria");
            // Condicion de Derrota
        } else if (dias_mision_objetivo - dias_pasados <= 0 || dinero_Total_acumulado <= 0) {
            SceneManager.LoadScene("GameOver");

        }
    }

    private void CambiarColorTextoDias(){
        texto_Dias.color = (dias_mision_objetivo - dias_pasados) <= 7 ? (dias_mision_objetivo - dias_pasados)>3? Color.yellow : Color.red: Color.black;
    }

    private void Asignar_DescripcionCartas_ACortina() {
        if (objeto_Cortina.activeSelf == false) {
            objeto_Cortina.SetActive(true);
        }
        // El orden en la cortina siempre es: Pachorra | Cacha | el otro se corresponde con posicion 0,1,2 en la listaPersonajes
        string[] descripciones = new string[Lista_Paneles_Personajes.Count];
        string[] tiposAcciones = new string[Lista_Paneles_Personajes.Count];
        int i = 0;
        foreach (var elem in Lista_Paneles_Personajes) {
            descripciones[i] = elem.GetComponent<Drop>().GetComponentInChildren<Accion>().DevolverDescripcion();
            tiposAcciones[i++] = elem.GetComponent<Drop>().GetComponentInChildren<Accion>().DevolverTipoAcciones();
        }

        objeto_Cortina.GetComponent<CortinaCambioDia>().AsignarElementos(descripciones, tiposAcciones);
        objeto_Cortina.GetComponent<CortinaCambioDia>().CerrarElDia(); // Llamar a la cortina
    }

    private void ModificarSlidersDEPersonajes() {
        foreach(var elem in Lista_Paneles_Personajes) {
            elem.GetComponent<ControlSliders>().CambioFelicidad = elem.GetComponent<Personaje>().felicidad;
            elem.GetComponent<ControlSliders>().CambioProductividad = (int)elem.GetComponent<Personaje>().multiplicadorDinero;
        }
    }

} // Fin clase
