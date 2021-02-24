using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatriceManager : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject Controller;
    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Controller.GetComponent<FirstPersonCharacterController>().enabled = true;
            Canvas.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
        
    }
}
