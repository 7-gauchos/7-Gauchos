using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicalBotones : MonoBehaviour
{

    static int escena = 0;

    public void OnPlayButton(AudioSource audioBackground)
    {
        Debug.Log("Jugar");
        audioBackground.Play();
        SceneManager.LoadScene(++escena);
    }
    // Called when we click the "Credits" button.
    public void OnCreditsButton(AudioSource audioBackground)
    {
        Debug.Log("Créditos");
        audioBackground.Play();
        SceneManager.LoadScene(4);
    }
    // Called when we click the "Quit" button.
    public void OnQuitButton(AudioSource audioBackground)
    {
        Debug.Log("Salir");
        audioBackground.Play();
        Application.Quit();
    }

    public void OnToogleButton()
    {
        Debug.Log("Toogle Button Volumen");
        AudioSource audioSource = GetComponent<AudioSource>();

        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        else
        {
            audioSource.Play();  
        }
    }
}
