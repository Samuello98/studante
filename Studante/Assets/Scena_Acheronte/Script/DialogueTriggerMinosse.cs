using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerMinosse : Interactable
{
    public Dialogue dialogue;
    private bool clicked = false;
    public override void Interact(GameObject caller)
    {
        if (clicked == false)
        {
            TriggerDialogue();
            clicked = true;
        }
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManagerMinosse>().StartDialogue(dialogue);

    }
}