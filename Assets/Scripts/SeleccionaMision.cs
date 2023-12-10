using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SeleccionaMision : MonoBehaviour, IPointerClickHandler
{
    public Button btnSiguiente;
    public GameObject panMision;
    public int grosorBorde = 5;

    // Controla cuando se hace click sobre el panel para controlar la seleccion de la mision
    public void OnPointerClick(PointerEventData eventData)
    {

       if (!btnSiguiente.IsActive()) {  

           btnSiguiente.gameObject.SetActive(true);

           Image imgPanel = panMision.GetComponent<Image>();
           if (imgPanel != null)
            {
                // Obtener el RectTransform del panel
                RectTransform rectTransform = panMision.GetComponent<RectTransform>();

                // Ajustar el tamaño del RectTransform para incluir el borde
                rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x + 2 * grosorBorde, rectTransform.sizeDelta.y + 2 * grosorBorde);

                Color colorImage = Color.blue;
                colorImage.a = 0.8f;

                // Ajustar el color del panel 
                imgPanel.GetComponent<Image>().color = colorImage;
           }

        }
    }

}
