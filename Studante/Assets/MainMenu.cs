using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour

{
    public GameObject PannelloMenù;
    public GameObject ControlPanel;
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("ScenaSelva");
        SceneManager.UnloadSceneAsync("Menu");
        
    }
    public void ShowCommands()
    {
        PannelloMenù.SetActive(false);
        ControlPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        PannelloMenù.SetActive(true);
        ControlPanel.SetActive(false);
    }
}
