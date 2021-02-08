using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Animator animator_D;
    public Animator animator_Q;
    public Text nameText;
    public Text dialogueText;
    public Text rightAnswer;
    public Text wrongAnswer1;
    public Text wrongAnswer2;
    public Text wrongAnswer3;


    private Queue<string> sentences; 
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {

        animator_D.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence() {

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        animator_D.SetBool("IsOpen", false);

    }

    public void StartQuiz()
    {
        animator_Q.SetBool("DisplayQuiz", true);
    }

    public void CorrectAnswer()
    {
        Debug.Log("Right Answer");
        EndQuiz();
    }

    public void WrongAnswer()
    {
        Debug.Log("Wrong Answer");
    }


    public void EndQuiz()
    {
        animator_Q.SetBool("DisplayQuiz", false);
    }

        
    

}