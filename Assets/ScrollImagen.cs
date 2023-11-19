using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollImagen : MonoBehaviour
{
    [SerializeField]
    Vector2 velocidad;
    [SerializeField]
    RawImage imagen;
    // Start is called before the first frame update
    void Start()
    {
       imagen = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        imagen.uvRect = new Rect(imagen.uvRect.position + velocidad * Time.deltaTime, imagen.uvRect.size);
    }
}
