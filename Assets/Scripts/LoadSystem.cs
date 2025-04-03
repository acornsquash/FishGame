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
    public SaveData LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath); // Read the file contents
            SaveData data = JsonUtility.FromJson<SaveData>(json); // Deserialize JSON into SaveData object
            return data;
        }
        else
        {
            Debug.Log("No saved data found.");
            return null;
        }
    }
}
