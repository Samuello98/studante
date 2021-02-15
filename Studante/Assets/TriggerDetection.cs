        }
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour    
{
    public GameObject Virgilio;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        Virgilio.SetActive(true);
    }
}
