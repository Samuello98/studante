using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInferno : MonoBehaviour
{
    // Start is called before the first frame update
    private bool triggered = false;
    public Dialogue dialogue;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(triggered == false)
        {
            triggered = true;
            TriggerDialogue();
        }
    }public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManagerQuiz>().StartDialogue(dialogue);
        
    }
}
