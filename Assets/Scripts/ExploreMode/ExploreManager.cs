﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class ExploreManager : MonoBehaviour {

    public static List<string> exploreTranslations;
    public Text exploreItemsText;


	void Awake () {
        // this auto updates because exploreTranslations now points
        // to GameControl.exploreTranslations position in memory
        exploreTranslations = GameControl.exploreTranslations;

	}

    void Update () {
        // this probably should not happen once per frame
        // should only happen if AddExploreItems was called.
        if (exploreTranslations.Count == 0) // no items but seen explore items Text exists, seenExploreItems does not exist
        {
            exploreItemsText.text = "No items found yet";
        }
        //else if (seenExploreItems.Count > 0 && exploreItemsText != null)
        else if (exploreTranslations.Count > 0)
        {
            exploreItemsText.text = "";

            foreach (var itemName in exploreTranslations)
            {
                exploreItemsText.text += itemName;
                exploreItemsText.text += "\n";
            }
        }
       
	}


    public static void AddExploreItemsToList(string itemName, string translation)
    {

        // only add the item if it hasn't already been found
        if (!GameControl.seenExploreItems.Contains(itemName))
        {
            GameControl.UpdateExploreItems(itemName, translation);
        }
    }


}
