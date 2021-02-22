using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBarcaManager : MonoBehaviour
{
    public GameObject muro; 

    

    void OnTriggerEnter(Collider other)
    {
        if(other.name != "barca")
        {
            Debug.Log("Barca nel trigger");
            muro.SetActive(false);
        }
        
    }
    
}
