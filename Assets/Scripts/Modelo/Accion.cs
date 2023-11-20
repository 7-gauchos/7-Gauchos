using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ===========
using TMPro;
using UnityEngine.UI;
public class Accion : MonoBehaviour {
    // Constantes definidas aleatoriamente
    private string descripcion;
    private int dinero;
    private int costo_felicidad;
    private string tipoAccion;
    public int Dinero { get => dinero; }
    public int Costo_felicidad { get => costo_felicidad; }

    // constantes de control MIN/MAX
    private int MAX_Felicidad = 5;
    private int MIN_Felicidad = -5;
    private int MAX_Dinero = 15;
    private int MIN_Dinero = -15;

    // Otras variables 
    [SerializeField] TextMeshProUGUI texto_felicidad;
    [SerializeField] TextMeshProUGUI texto_dinero;
    [SerializeField] TextMeshProUGUI texto_de_descripcion;

    private string rutaSprite = "Assets/Resources/Sprites/cartas/";

    private GeneratorQuote generadorFrases;


    private void Start() {
        generadorFrases = new GeneratorQuote();

        int random = Random.Range(0, 101);
        if (random < 80) {
            if (random < 50) {
                // generar Trabajo
                tipoAccion = "Trabajo";
                costo_felicidad = (int)(Random.Range(MIN_Felicidad, 0));
                dinero = (int)(Random.Range(0, MAX_Dinero + 1));
                descripcion = generadorFrases.DevolverFrase(tipoAccion, dinero, MIN_Dinero, MAX_Dinero, costo_felicidad, MIN_Felicidad, MAX_Felicidad);
            } else {
                // generar Ocio
                tipoAccion = "Ocio";
                costo_felicidad = (int)(Random.Range(0, MAX_Felicidad + 1));
                dinero = (int)(Random.Range(MIN_Dinero, 0));
                descripcion = generadorFrases.DevolverFrase(tipoAccion, dinero, MIN_Dinero, MAX_Dinero, costo_felicidad, MIN_Felicidad, MAX_Felicidad);
            }
          
        } else if (random < 95) {
            // generar Descanso
            tipoAccion = "Descanso";
            costo_felicidad = (int)(Random.Range((int)(MIN_Felicidad / 2), (int)(MAX_Felicidad / 2) + 1));
            dinero = (int)(Random.Range((int)(MIN_Dinero / 2), (int)(MAX_Dinero / 2) + 1));
            descripcion = generadorFrases.DevolverFrase(tipoAccion, dinero, MIN_Dinero, MAX_Dinero, costo_felicidad, MIN_Felicidad, MAX_Felicidad);


        } else if (random < 98) {
            // generar Suerte
            tipoAccion = "Suerte";

            costo_felicidad = (int)(Random.Range((int)(MAX_Felicidad / 2), (int)(MAX_Felicidad) + 1));
            dinero = (int)(Random.Range((int)(MAX_Dinero / 2), (int)(MAX_Dinero) + 1));
            descripcion = generadorFrases.DevolverFrase(tipoAccion, dinero, MIN_Dinero, MAX_Dinero, costo_felicidad, MIN_Felicidad, MAX_Felicidad);

        } else {
            // generar Catastrofe (nombre interno Desastre)
            tipoAccion = "Catastrofe";
            //Revisar
            costo_felicidad = (int)(Random.Range((int)(MIN_Felicidad), (int)(MIN_Felicidad / 2) + 1));
            dinero = (int)(Random.Range((int)(MIN_Dinero), (int)(MIN_Dinero / 2) + 1));
            descripcion = generadorFrases.DevolverFrase(tipoAccion, dinero, MIN_Dinero, MAX_Dinero, costo_felicidad, MIN_Felicidad, MAX_Felicidad);

        }

        // Propio del Awake
        if (texto_felicidad != null && texto_dinero != null) {
            texto_dinero.text = dinero.ToString();
            texto_felicidad.text = costo_felicidad.ToString();            
        }
        // Carga la imagen desde la carpeta

        // Asigna la imagen al componente Image

        // Debug.Log(descripcion+" || "+transform.name.ToString() +" | "+tipoAccion);
        Image imageComponent = GetComponent<Image>();
        string ruta = rutaSprite + tipoAccion + ".png";
        Texture2D texture = LoadTexture(ruta);
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        imageComponent.sprite = sprite;


    } // Fin Start
    // Método para cargar una textura desde la ruta
    private Texture2D LoadTexture(string path) {
        byte[] fileData = System.IO.File.ReadAllBytes(path);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(fileData); // Esta línea convierte los datos de la imagen en la textura
        return texture;
    }
} // Fin Clase
