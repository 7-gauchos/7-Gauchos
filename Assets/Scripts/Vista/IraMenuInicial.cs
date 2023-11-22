using UnityEngine;
using UnityEngine.SceneManagement;

public class IraMenuInicial : MonoBehaviour
{
    // permite ir directo a la primera escena que se supone es la pantalla principal
    public void gotoMainEscene()
    {
        SceneManager.LoadScene(0);
    }
}
