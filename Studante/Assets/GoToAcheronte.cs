using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToAcheronte : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
           { 
        SceneManager.UnloadSceneAsync("ScenaSelva");
        SceneManager.LoadSceneAsync("Scena_Acheronte");
        }
    }
}
