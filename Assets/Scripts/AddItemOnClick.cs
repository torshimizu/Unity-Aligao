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

    void AddItemToSeenList(string itemName)
    {
        Debug.Log("Another Test Fuction was called with message: " + itemName);
        ExploreManager.AddExploreItemsToList(itemName);
    }
}
