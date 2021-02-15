using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStop : MonoBehaviour
{
    // Start is called before the first frame update
    private bool triggered = false;
    public Dialogue dialogue;
    public Animator animator;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (triggered == false)
        {
            animator.SetBool("rotating", false);
            triggered = true;
            TriggerDialogue();
        }
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

    }
}
