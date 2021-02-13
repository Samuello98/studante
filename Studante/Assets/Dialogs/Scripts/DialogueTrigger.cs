using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : Interactable
{
    public Dialogue dialogue;
    private bool clicked = false;
    public override void  Interact(GameObject caller)
    {
        if(clicked==false) 
        { 
        TriggerDialogue();
            clicked =true;
    }
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        
    }
}