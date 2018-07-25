using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Dialogue initialDialogue;
    public Dialogue planeDialogue;
    public Text dialogueText;
    public Text continueButtonText;

    public Animator animator;

    //private static bool initialExploreVisit;
    private Queue<string> sentences;

    // Use this for initialization
    void Start()
    {
        if (GameControl.initialExploreVisit)
        {
            sentences = new Queue<string>();
            animator.SetTrigger("StartInstruction");
            StartDialogue(initialDialogue);
            GameControl.ToggleInitialExploreVisit();
        }

        if (GameControl.InFlightMode())
        {
            sentences = new Queue<string>();
            animator.SetTrigger("StartInstruction");
            StartDialogue(planeDialogue);
        }
     
    }

    public void StartDialogue(Dialogue dialogue)
    {

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            continueButtonText.text = "Close Instruction";
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        Debug.Log("All sentences have been printed");
        animator.SetTrigger("EndInstruction");

        if (GameControl.InFlightMode())
        {
            GameControl.StartPlaneSimulator();
        }
    }
}
