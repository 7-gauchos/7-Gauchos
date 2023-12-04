using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicalBotones : MonoBehaviour
{

    static int escena = 0;

    public void OnPlayButton(AudioSource audioBackground)
    {
        StartCoroutine(ReproducirSonido(++escena,audioBackground));
    }
    
    // Called when we click the "Credits" button.
    public void OnCreditsButton(AudioSource audioBackground)
    {
        StartCoroutine(ReproducirSonido(5, audioBackground));
    }
    // Called when we click the "Quit" button.
    public void OnQuitButton(AudioSource audioBackground)
    {
        Debug.Log("Salir");
        audioBackground.Play();
        Application.Quit();
    }

    // Permite reproducir o parar la musica de fondo
    // Mejora para proxima version, se pueda regular el volumen desde el mismo boton
    public void OnToogleButton(AudioSource audioBackground)
    {
        if (audioBackground.isPlaying)
        {
            audioBackground.Stop();
        }
        else
        {
            audioBackground.Play();  
        }
    }


    private System.Collections.IEnumerator ReproducirSonido(int nroEscena, AudioSource audio)
    {
        // Reproduce el sonido
        audio.Play();

        // Espera hasta que el sonido haya terminado de reproducirse
        yield return new WaitForSeconds(audio.clip.length);

        // Carga la siguiente escena
        SceneManager.LoadScene(nroEscena);
    }
}
