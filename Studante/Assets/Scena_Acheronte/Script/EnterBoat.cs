using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBoat : MonoBehaviour
{
    private bool inVehicle = false;
    public GameObject player;
    public BoatMovement boatScript;
    public GameObject guiObj;
    
    void Start()
    {
        
        guiObj.SetActive(false);
        boatScript.enabled = false; 
    }

    void OnTriggerStay(Collider other)
    {
        if (inVehicle == false)
        {
            guiObj.SetActive(true);
            if (Input.GetKey(KeyCode.Space))
            {
                guiObj.SetActive(false);
                player.transform.parent = gameObject.transform;
                boatScript.enabled = true;
                player.SetActive(true);
                inVehicle = true;

            }
        }
    }
    void onTriggerExit(Collider other)
    {
        guiObj.SetActive(false);
    }
        
    
    void Update()
    {
        if( inVehicle == true && Input.GetKey(KeyCode.Space))
        {
            boatScript.enabled = false;
            player.SetActive(true);
            player.transform.parent = null;
            inVehicle = false;
        }
    }
}
