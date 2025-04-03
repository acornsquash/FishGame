using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadSystem : MonoBehaviour
{
    private string savePath;

    void Awake()
    {
        savePath = Application.persistentDataPath + "/saveData.json";
    }

    // Method to load game data
    public SaveData LoadGame()
    {
        if (File.Exists(savePath)) // Check if the save file exists
        {
            string json = File.ReadAllText(savePath); // Read the file contents
            SaveData data = JsonUtility.FromJson<SaveData>(json); // Deserialize JSON into SaveData object
            return data; // Return the loaded data
        }
        else
        {
            Debug.Log("No saved data found.");
            return null; // Return null if there's no save data
        }
    }
}
