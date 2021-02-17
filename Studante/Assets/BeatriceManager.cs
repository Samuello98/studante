using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatriceManager : MonoBehaviour
{
    public GameObject Canvas;
    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Canvas.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
        
    }
}
