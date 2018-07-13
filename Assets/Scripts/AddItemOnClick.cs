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

    void AddItemToSeenList(string message)
    {
        Debug.Log("Another Test Fuction was called with message: " + message);
        GameControl.AddExploreItemsToList(message);
    }
}
