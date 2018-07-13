using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

    public static GameControl control;
    private static List<string> seenExploreItems;

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

    public static void AddExploreItemsToList(string itemName)
    {
        // create a new list if one does not already exist
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
