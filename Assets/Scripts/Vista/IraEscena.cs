using UnityEngine;
using UnityEngine.SceneManagement;

public class IraEscena : MonoBehaviour
{
    public int nroescena;
    public AudioSource sndButton;

    public void goToEscene()
    {
        // si esta el sonido ejectura el sonido y llama a la escena, sino solo carga la escena
        if (sndButton != null) {
            StartCoroutine(ReproducirSonido(nroescena));
        }
        else
        {
            SceneManager.LoadScene(nroescena);
        }

        
    }

    public void goToPreviousEscene()
    {
        if (sndButton != null) { 
            StartCoroutine(ReproducirSonido(nroescena-2)); 
        }
        else { 
            SceneManager.LoadScene(nroescena-2);
        }
    }


    private System.Collections.IEnumerator ReproducirSonido(int nroEscena)
    {
        // Reproduce el sonido
        sndButton.Play();

        // Espera hasta que el sonido haya terminado de reproducirse
        yield return new WaitForSeconds(sndButton.clip.length);

        // Carga la siguiente escena
        SceneManager.LoadScene(nroEscena);
    }

}
