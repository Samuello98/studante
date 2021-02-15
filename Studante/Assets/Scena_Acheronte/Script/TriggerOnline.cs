using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnline : MonoBehaviour
{

    private bool inTrigger;
    private GameObject player;
    public ManagerOnline carMan;

    void Update()
    {
        if (inTrigger == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                carMan.vehicleControl(player);
                inTrigger = false;
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        inTrigger = true;
        player = col.gameObject;
    }
    void OnTriggerExit()
    {
        inTrigger = false;
        player = null;
    }
}