using UnityEngine;
using System.Collections;


public class EnterVehicle : MonoBehaviour
{
    private bool inVehicle = false;
    public BoatMovement vehicleScript;
    public GameObject guiObj;
    public GameObject player;


    void Start()
    {
        
        
        guiObj.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && inVehicle == false)
        {
            guiObj.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                guiObj.SetActive(false);
                player.transform.parent = gameObject.transform;
                vehicleScript.enabled = true;
                player.SetActive(false);
                inVehicle = true;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            guiObj.SetActive(false);
        }
    }
    void Update()
    {
        if (inVehicle == true && Input.GetKey(KeyCode.F))
        {
            vehicleScript.enabled = false;
            player.SetActive(true);
            player.transform.parent = null;
            inVehicle = false;
        }
    }
}