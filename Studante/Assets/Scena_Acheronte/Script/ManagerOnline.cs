﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ManagerOnline : MonoBehaviour
{
    public Camera sceneCam;
    public Camera carCam;
    public BoatMovement boatScript;
    public GameObject virgilioA;

    private bool inVeh;
    public GameObject player;

    void Start()
    {
        boatScript.enabled = false;
        carCam.enabled = false;
        carCam.GetComponent<AudioListener>().enabled = false;
        inVeh = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            virgilioA.SetActive(false);
            if (inVeh == true)
            {
                vehicleControl(null);
            }
        }
    }

    public void vehicleControl(GameObject playerObj)
    {
        if (inVeh == false)
        {
            player = playerObj;
            sceneCam.enabled = false;
            sceneCam.GetComponent<AudioListener>().enabled = false;
            carCam.enabled = true;
            carCam.GetComponent<AudioListener>().enabled = true;
            boatScript.enabled = true;
            player.SetActive(false);
            player.transform.parent = this.transform;

            StartCoroutine(Time(true));
        }
        else
        {
            player.SetActive(true);
            sceneCam.enabled = true;
            sceneCam.GetComponent<AudioListener>().enabled = true;
            carCam.enabled = false;
            carCam.GetComponent<AudioListener>().enabled = false;
            boatScript.enabled = false;
            player.transform.parent = null;

            player = null;

            StartCoroutine(Time(false));
        }
    }

    private IEnumerator Time(bool inVehicle)
    {
        yield return new WaitForSeconds(1);
        inVeh = inVehicle;
    }
}