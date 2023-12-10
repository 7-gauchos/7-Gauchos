using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CursorController : MonoBehaviour
{
   public static CursorController yo;
    [SerializeField]
     Texture2D mano;
    [SerializeField]
    
     Texture2D flecha;
    // Start is called before the first frame update
   public void VerMano()
    {
        Cursor.SetCursor(mano, Vector2.zero, CursorMode.Auto);
    }
    public void VerFlecha()
    {
        Cursor.SetCursor(flecha, Vector2.zero, CursorMode.Auto);
    }
    private void Awake()
    {
        if (yo == null)
        {
            yo = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
