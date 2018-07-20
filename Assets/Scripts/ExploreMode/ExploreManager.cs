using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ExploreManager : MonoBehaviour {

    public static List<string> seenExploreItems;
    public Text exploreItemsText;


	void Awake () {
        seenExploreItems = GameControl.seenExploreItems;

	}

    void Update () {
        // this probably should not happen once per frame
        // should only happen if AddExploreItems was called.
        if (seenExploreItems.Count == 0) // no items but seen explore items Text exists, seenExploreItems does not exist
        {
            exploreItemsText.text = "No items found yet";
        }
        //else if (seenExploreItems.Count > 0 && exploreItemsText != null)
        else if (seenExploreItems.Count > 0)
        {
            exploreItemsText.text = "";

            foreach (var itemName in seenExploreItems)
            {
                exploreItemsText.text += itemName;
                exploreItemsText.text += "\n";
            }
        }
       
	}


    public static void AddExploreItemsToList(string itemName)
    {

        Debug.Log(seenExploreItems.Contains(itemName));
        // only add the item if it hasn't already been found
        if (!seenExploreItems.Contains(itemName))
        {

            GameControl.UpdateExploreItems(itemName);
        }
    }


}
