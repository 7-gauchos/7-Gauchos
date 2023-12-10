using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


[RequireComponent(typeof(Outline))]

public class ControlBordes : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        CursorController.yo.VerMano();
      GetComponent<Outline>().enabled = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        CursorController.yo.VerFlecha();
        print("Afuera");
        GetComponent<Outline>().enabled = false;
    }
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
