using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItemOnClick : MonoBehaviour {
   
    void OnEnable()
    {
        EventManager.StartListening("popUp", AddItemToSeenList);
    }

    void OnDisable()
    {
        EventManager.StopListening("popUp", AddItemToSeenList);
    }

    void AddItemToSeenList(string itemName, string translation)
    {
        Debug.Log("Another Test Fuction was called with message: " + itemName);
        Debug.Log("Translation sent with it " + translation);
        ExploreManager.AddExploreItemsToList(itemName, translation);
    }
}
