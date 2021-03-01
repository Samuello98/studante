﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBook : MonoBehaviour
{
    public static bool BookIsOpen = false;
    public GameObject BookUI;
    public GameObject AltroDaAttivare;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("pressed");
            if (BookIsOpen)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        BookUI.SetActive(false);
        AltroDaAttivare.SetActive(false);
        Time.timeScale = 1f;
        BookIsOpen = false;
        Cursor.lockState = CursorLockMode.Locked;

        FindObjectOfType<AudioManager>().Play("Book");
    }

    void Pause()
    {
        BookUI.SetActive(true);
        AltroDaAttivare.SetActive(true);
        Time.timeScale = 0f;
        BookIsOpen = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        FindObjectOfType<AudioManager>().Play("Book");
    }
}
