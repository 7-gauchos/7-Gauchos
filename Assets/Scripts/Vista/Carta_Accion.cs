using UnityEngine;
using UnityEngine.EventSystems;

public class Carta_Accion : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    [HideInInspector] public Vector2 initialPosition; // Nueva variable para almacenar la posición inicial.
    [HideInInspector] public  Transform originalParent; // Nueva variable para almacenar el padre original.
    public Drop dropping;

    private void Start() {
        this.tag = "Carta";
        canvas = GetComponentInParent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        initialPosition = rectTransform.anchoredPosition; // Almacenar la posición inicial al inicio.
        originalParent = transform.parent; // Almacenar el padre original al inicio.
    }

    public void OnBeginDrag(PointerEventData eventData) {
        // Si cuando inicia , tiene padre y es uno de tag panel, entonces ese ya no lo tiene y esta libre
        if (transform.parent.CompareTag("Panel_Personaje")) {
            dropping.espacio_Ocupado_ = false;
        }
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }


    // Ver si cae dentro o fuera del panel, ver si esta ocupado 
    public void OnEndDrag(PointerEventData eventData) {
        canvasGroup.blocksRaycasts = true;
        // Si el objeto donde cae NO es nulo (pero puede ser el fondo)
        if (eventData != null) {
            // ademas este es uno con el tag Panel Personaje.
            if (eventData.pointerEnter.CompareTag("Panel_Personaje")) {
                Debug.Log("Se solto encima de un Panel ");

                // HAY UNA SITUACION , si cae encima de "algo" , la imagen tapa , por lo que puede que no reconoce
                // que cae en un panel, sino en una carta, ahi podria hacer el reemplazo preguntando si tienen padres
                // o simplemente volver al lugar. TAMBIEN MIRAR LAS IMAGENES O EL RAYCAST DE LOS OBJETOS

                // si esta ocupado
                if (eventData.pointerEnter.GetComponent<Drop>().espacio_Ocupado_) {
                    Debug.Log("El panel estaba ocupado ");
                    // Pero la Carta estaba en un panel?
                    if (dropping != null) { // Estaba
                        transform.position = transform.parent.position;
                    } else {
                        ATuCasa();
                    }


                } else { // si no esta ocupado, ahora lo esta
                    eventData.pointerEnter.GetComponent<Drop>().espacio_Ocupado_ = true;
                    dropping = eventData.pointerEnter.GetComponent<Drop>();
                }
                // Tocaste carta con padre (osea detras hay un slot)
            } else if (eventData.pointerEnter.CompareTag("Carta") && eventData.pointerEnter.transform.GetComponent<Carta_Accion>().dropping != null) {
                Debug.Log("Se solto encima de una carta que tenia un padre Panel ");
                // Si la carta que se movio NO tiene padre.
                if (this.transform.parent == originalParent) {
                    ReturnToOriginalPosition();

                } else {

                    // La carta vuelve a su posicion dentro del padre
                    transform.position = transform.parent.position;


                }
                // Aqui puede ocurrir 2 cosas , que vuelva a su posicion en el slot 
            } else {
                Debug.Log("Se solto fuera de un panel y de una carta");
                // Siempre que lo sueltes vuelve , a menos que entre por algun if
                ATuCasa();
            }
        } else {
            // si cae en un objeto null
            Debug.Log("Se solto en un objeto null");
            // Siempre que lo sueltes vuelve , a menos que entre por algun if
            ATuCasa();
        }
    }
    public void ReturnToOriginalPosition() {
        rectTransform.anchoredPosition = initialPosition;
    }
    public void ATuCasa() { // Si conoces el meme sabes como sigue...
        transform.SetParent(originalParent);
        ReturnToOriginalPosition();
        if (dropping != transform.CompareTag("Panel_Personaje")) {
            dropping.espacio_Ocupado_ = false;
        }
        dropping = null;
    }
    public void AutoDestruirse() {
            ATuCasa();
            Destroy(gameObject);
    }
}
