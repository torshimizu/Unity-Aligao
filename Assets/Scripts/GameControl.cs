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
    public Text exploreItemsText;

    public Dialogue dialogue;

    private static string filePath;


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

        filePath = Application.persistentDataPath + "/playerInfo.dat";
	}

    // load seen items
    void OnEnable()
    {
        if(File.Exists(filePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filePath, FileMode.Open);

            PlayerData data = (PlayerData)bf.Deserialize(file); // casts the data to the PlayerData class
            file.Close();

            seenExploreItems = data.seenItems;

            string debugMessage = seenExploreItems != null ? "successfully loaded" : "error with loading";
            Debug.Log(debugMessage);
        }
    }

    void Update()
    {
        if(seenExploreItems != null)
        {
            exploreItemsText.text = "";

            foreach(var itemName in seenExploreItems)
            {
                exploreItemsText.text += itemName;
                exploreItemsText.text += "\n";
            }
        }
        else
        {
            exploreItemsText.text = "No items found yet";
        }
    }



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
            Save();

        }

        // print the last item added to the list
        Debug.Log(seenExploreItems[seenExploreItems.Count - 1]);
        Debug.Log(seenExploreItems.Count);
    }

    private static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file;

        file = File.Exists(filePath) ? File.Open(filePath, FileMode.Open) : File.Create(filePath);

        PlayerData data = new PlayerData();
        data.seenItems = seenExploreItems;

        try
        {
            bf.Serialize(file, data);
            Debug.Log("successfully saved");
        }
        catch
        {
            Debug.Log("Unable to save");
        }

        file.Close();

    }
}

[Serializable]
class PlayerData
{
    public List<string> seenItems;
}
