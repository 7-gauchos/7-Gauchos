using UnityEngine;
using UnityEngine.SceneManagement;

public class IraMenuInicial : MonoBehaviour
{
    public AudioSource sndBoton;

    // permite ir directo a la primera escena que se supone es la pantalla principal
    public void gotoMainEscene()
    {
        StartCoroutine(ReproducirSonido());
    }

    private System.Collections.IEnumerator ReproducirSonido()
    {
        // Reproduce el sonido
        if (sndBoton != null)
        {
            sndBoton.Play();

            // Espera hasta que el sonido haya terminado de reproducirse
            yield return new WaitForSeconds(sndBoton.clip.length);
        }

        // Carga la siguiente escena
        SceneManager.LoadScene(0);
    }

}
