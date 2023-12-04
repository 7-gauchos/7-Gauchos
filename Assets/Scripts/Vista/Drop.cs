using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Drop : MonoBehaviour, IDropHandler {
    [SerializeField]
    public bool espacio_Ocupado_ = false; // Bool para registrar si el objeto ha sido colocado en un panel.

    [SerializeField] TextMeshProUGUI texto_dinero;

    [SerializeField] AudioSource sndEfectoDrop;

    public void OnDrop(PointerEventData eventData) {
        var cartaPresionada = eventData.pointerDrag.transform.GetComponent<Carta_Accion>();
        if (!espacio_Ocupado_ && transform.childCount < 1) {
            // ejecutar sonido de drop
            sndEfectoDrop.Play();
            HacerAccionHija(cartaPresionada);
            Debug.Log("Una carta esta en el slot");
        }
    }

    public void HacerAccionHija(Carta_Accion c) {
        // Si su padre es otro
        if (!ReferenceEquals(c.transform.parent, this)) {
            c.transform.SetParent(transform);
            c.transform.position = this.transform.position;

        }
    }
    public void QuitarHijaPorPasoTurno() {
        espacio_Ocupado_ = false;
         transform.GetChild(0).transform.GetComponent<Carta_Accion>().ATuCasa();
    }

    // Construir la logica para en su update, que un elemento Panel para Felicidad y Dinero 
    // Si no es nulo, actualize esos valores y tambien si no es nulo La carta (osea tiene hija)

    private void Update() {
        if (texto_dinero != null) {
            Personaje scripPersonaje = GetComponent<Personaje>();
            // Si este objeto, tiene una hija y por lo tanto esta ocupado
            if (espacio_Ocupado_ && transform.childCount == 1) {
                // Mostrar cambios de el Personaje y la Accion conjuntas.

                texto_dinero.text = (scripPersonaje.multiplicadorDinero * transform.GetChild(0).GetComponent<Accion>().Dinero).ToString();
            } else {
                texto_dinero.text = "0";
            }
            // IMPORTANTE : El texto del dinero por ganar al colocar la carta
            //              es el mismo que el multiplicador sin tener carta encima
        }
    }
}
