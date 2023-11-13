using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public static GameObject itemDragging;
    public UIManager ui_manager;


    public Vector3 originalPosition;
    public Transform originalParent;

    private Transform dragParent;
 
    private CanvasGroup canvasGroup;
 

    private void Start() 
    {
        ui_manager = FindObjectOfType<UIManager>();
        dragParent = GameObject.FindGameObjectWithTag("DragParent").transform;
        canvasGroup = GetComponent<CanvasGroup>();
        originalPosition = transform.position;
        originalParent = transform.parent;

    }

    #region DragFunctions

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        itemDragging = gameObject;


        transform.SetParent(dragParent);

        canvasGroup.blocksRaycasts = false;


    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.blocksRaycasts = true;
        if (transform.parent == dragParent)
        {
            transform.position = originalPosition;
            transform.SetParent(originalParent);
            DesmarcarrAccionConPersonaje();
        }       
    }

    #endregion

    private void Update()
    {

    }

    private void DesmarcarrAccionConPersonaje()
    {
        ui_manager.DisminuirListaDeSelecciones(itemDragging);
        ui_manager.RevisarSiTenemosQueMostrarBoton();
    }
}
