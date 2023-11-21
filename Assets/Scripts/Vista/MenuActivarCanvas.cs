using UnityEngine;

public class MenuActivarCanvas : MonoBehaviour
{
    
    public Canvas canvasAnimacion;
    public Canvas canvasMenu;

    // permite desactivar el canvas del menu princial y desactivar la aninamacion inicial
    public void activarCanvas()
    {
        canvasAnimacion.gameObject.SetActive(false);
        canvasMenu.gameObject.SetActive(true);     
    }


}

