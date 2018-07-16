using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryElement : MonoBehaviour {

    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        //Debug.Log("I am a story element");
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }


}
