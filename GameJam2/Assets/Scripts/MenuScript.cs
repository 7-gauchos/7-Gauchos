using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    static int escena = 0;
    // Called when we click the "Play" button.
    public void OnPlayButton ()
    {
        Debug.Log("Jugar");
        SceneManager.LoadScene(++escena);
    }
    // Called when we click the "Credits" button.
    public void OnCreditsButton ()
    {
        Debug.Log("Créditos");
        SceneManager.LoadScene(4);
    }
    // Called when we click the "Quit" button.
    public void OnQuitButton ()
    {
        Debug.Log("Salir");
        Application.Quit();
    }
}