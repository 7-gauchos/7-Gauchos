using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler {
    [SerializeField]
    public bool espacio_Ocupado_ = false; // Bool para registrar si el objeto ha sido colocado en un panel.

    public void OnDrop(PointerEventData eventData) {
        var cartaPresionada = eventData.pointerDrag.transform.GetComponent<Carta_Accion>();
        if (!espacio_Ocupado_ && transform.childCount < 1) {
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

}
