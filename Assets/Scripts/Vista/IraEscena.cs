using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class IraEscena : MonoBehaviour
{
    public int nroescena;

    public void goToEscene()
    {
        SceneManager.LoadScene(nroescena);
    }

    public void goToPreviousEscene()
    {
        SceneManager.LoadScene(nroescena-2);
    }


}
