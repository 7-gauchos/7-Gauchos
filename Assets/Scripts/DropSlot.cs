using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public GameObject item;
    public UIManager ui_manager;

    public float move_x = 0;
    public float move_y = -20;

    private void Start()
    {
        ui_manager = FindObjectOfType<UIManager>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Drop");


        MatchearAccionConPersonaje();

        //ui_manager.Test(DragHandler.itemDragging);
        if (!item)
        {
            item = DragHandler.itemDragging;
            item.GetComponent<AudioSource>().Play();
            item.transform.SetParent(transform);
            item.transform.position = new Vector3(transform.position.x + move_x, transform.position.y + move_y, transform.position.z);
        }
    }

    private void MatchearAccionConPersonaje()
    {
        ui_manager.IncrementarListaDeSelecciones(DragHandler.itemDragging);
        ui_manager.RevisarSiTenemosQueMostrarBoton();
    }

    private void Update()
    {
        if (item != null && item.transform.parent != transform)
        {
            Debug.Log("Remover");
            item = null;
        }
    }
}
