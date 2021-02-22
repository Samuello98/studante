using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBarcaManager : MonoBehaviour
{
    public GameObject muro;
    public GameObject virgilio_B;

    

    void OnTriggerEnter(Collider other)

    {
        Debug.Log("Barca nel trigger");
        if (other.name != "barca")
        {
            Debug.Log("Allowed Player");
            muro.SetActive(false);
            virgilio_B.SetActive(true); 
        }
        
    }
    
}
