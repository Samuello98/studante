using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class BookTrigger : MonoBehaviour
{
    private bool triggered = false;
    public Dialogue dialogue;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "libro_aperto")
        {
            FindObjectOfType<DialogueManagerLibro>().StartDialogue(dialogue);
        }
    }
}
