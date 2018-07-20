using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

        if (seenExploreItems == null)
        {
            seenExploreItems = new List<string>();
        }

	}

    public static void UpdateExploreItems(string itemName)
    {
        seenExploreItems.Add(itemName);
        Debug.Log(itemName + " added to GameControl list");
    }


}