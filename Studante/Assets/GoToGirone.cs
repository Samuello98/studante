using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToGirone : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadSceneAsync("Scena_Girone2");
        SceneManager.UnloadSceneAsync("Scena_Acheronte");
    }
}
