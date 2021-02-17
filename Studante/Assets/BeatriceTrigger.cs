using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatriceTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Beatricedue;
    public bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered == false)
        {
            Beatricedue.SetActive(true);
            triggered = true;

        }
    }

}
