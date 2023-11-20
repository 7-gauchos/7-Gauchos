using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioSource audioBackground;

    public void Start()
    {
            audioBackground.volume = 0.5f;
            audioBackground.Play();
    }

}