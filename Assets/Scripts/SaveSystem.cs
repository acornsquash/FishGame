using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private string savePath;

    void Awake()
    {
        // Set the path for the save file
        savePath = Application.persistentDataPath + "/saveData.json";
    }

    // Method to save game data
    public void SaveGame(List<string> placedCorals)
    {
        SaveData data = new SaveData();
        data.lastExitTime = DateTime.Now.ToString();
        data.placedCorals = placedCorals;
        string json = JsonUtility.ToJson(data); // Serialize the data to JSON format

        // Write the JSON string to the save file
        File.WriteAllText(savePath, json);

        Debug.Log("Game saved.");
    }
}
