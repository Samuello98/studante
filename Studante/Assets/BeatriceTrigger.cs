using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatriceTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Beatricedue;

    private void OnTriggerEnter(Collider other)
    {
        Beatricedue.SetActive(true);
    }

}
