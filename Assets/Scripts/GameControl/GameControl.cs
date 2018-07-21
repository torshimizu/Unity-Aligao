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

    public static bool initialExploreVisit = true;
    private static string filePath;


    public Dialogue dialogue;

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 50, 50), "Clear File"))
        {
            try
            {
                File.Delete(filePath);
            }
            catch
            {
                Debug.Log("unable to delete file");
                return;
            }
            Debug.Log("successfully cleared file");
            initialExploreVisit = true;
            seenExploreItems = null;
        }

    }


	private void Awake()
    {
        // singleton
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


        filePath = Application.persistentDataPath + "/playerInfo.dat";

	}

    // when the game loads up
    // but if going to quiz then going back to explore, shouldn't show dialogue
    // Dialogue will no longer show because Dialogue Manager calls GC to
    // toggle GC initialExploreVisit to false
    void OnEnable()
    {
        if (File.Exists(filePath))
        {
            initialExploreVisit = false;
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filePath, FileMode.Open);

            PlayerData data = (PlayerData)bf.Deserialize(file); // casts the data to the PlayerData class
            file.Close();

            seenExploreItems = data.seenItems;

            string debugMessage = seenExploreItems != null ? "successfully loaded" : "error with loading";
            Debug.Log(debugMessage);
        }
    }

    public static void ToggleInitialExploreVisit()
    {
        initialExploreVisit = false;
    }



    public static void UpdateExploreItems(string itemName)
    {
        seenExploreItems.Add(itemName);
        Save();
        Debug.Log(itemName + " added to GameControl list");
        Debug.Log(seenExploreItems.Count.ToString() + " items in the list");
    }

    public static void ResetExplore()
    {
        // should trigger an "are you sure?"
        Debug.Log("Reset explore called in Game Control");
        initialExploreVisit = true;
        GameControl.seenExploreItems.Clear();
        SceneManager.LoadScene(1);
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
