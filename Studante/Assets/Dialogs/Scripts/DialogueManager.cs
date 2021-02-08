using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Animator animator_D;
    public Animator animator_Q;
    public bool isQuiz;
    public Text nameText;
    public Text dialogueText;
    public Text rightAnswer;
    public Text wrongAnswer1;
    public Text wrongAnswer2;
    public Text wrongAnswer3;
    public Button button;



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

        if (sentences.Count == 1)
        {
            if (isQuiz)
            {
                button.interactable = false;
                animator_Q.SetBool("DisplayQuiz", true);
            }
        }

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
        EndQuiz();

    }

    public void StartQuiz()
    {   button.interactable = false;
        Debug.Log(button.interactable);
        animator_Q.SetBool("DisplayQuiz", true);
        
    }

    public void CorrectAnswer()
    {

        string feedback = "Right Answer!";
        Debug.Log(feedback);
        sentences.Enqueue(feedback);
        DisplayNextSentence();
        button.interactable = true;



    }

    public void WrongAnswer()
    {
        string feedback = "Wrong Answer, try again";
        Debug.Log(feedback);
        sentences.Enqueue(feedback);
        DisplayNextSentence();

        
    }


    public void EndQuiz()
    {
        animator_Q.SetBool("DisplayQuiz", false);
    }

        
    

}