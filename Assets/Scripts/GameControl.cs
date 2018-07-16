using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    public static GameControl control;
    public static List<string> seenExploreItems;

    public Dialogue dialogue;



	private void Awake()
    {
        if (control == null) 
        {
            DontDestroyOnLoad(this.gameObject);
            control = this;
        }
        else if (control != this) 
        {
            Destroy(this.gameObject);    
        }

	}

    //public void LoadByIndex(int sceneIndex)
    //{
    //    if(sceneIndex == 1 && initialExploreVisit)
    //    {
    //        SceneManager.LoadScene(sceneIndex);

    //        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

    //        initialExploreVisit = false;
    //    }
    //    else
    //    {
    //        SceneManager.LoadScene(sceneIndex);
    //    }


    //}


    public static void AddExploreItemsToList(string itemName)
    {
         //create a new list if one does not already exist
        if(seenExploreItems == null)
        {
            seenExploreItems = new List<string>();
        }

        // only add the item if it hasn't already been found
        if(!seenExploreItems.Contains(itemName))
        {
            seenExploreItems.Add(itemName);
        }

        // print the last item added to the list
        Debug.Log(seenExploreItems[seenExploreItems.Count - 1]);
        Debug.Log(seenExploreItems.Count);
    }
}
