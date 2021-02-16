using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnline : MonoBehaviour
{

    private bool inTrigger;
    public GameObject player;
    public ManagerOnline carMan;
    public Canvas canvas;

    void Start()
    {
        canvas.enabled = false;
    }

    void Update()
    {
        if (inTrigger == true)

        {
            canvas.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {

                carMan.vehicleControl(player);
                inTrigger = false;
                canvas.enabled = false;
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        inTrigger = true;
        player = col.gameObject;
        canvas.enabled = true;
    }
    void OnTriggerExit()
    {
        inTrigger = false;
        player = null;
        canvas.enabled = false;
    }
}