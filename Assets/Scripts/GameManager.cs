using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    private SaveSystem saveSystem;
    private LoadSystem loadSystem;

    void Start()
    {
        saveSystem = GetComponent<SaveSystem>();
        loadSystem = GetComponent<LoadSystem>();

        // Load game data when the game starts
        // SaveData savedData = loadSystem.LoadGame();
        
        // if (savedData != null)
        // {
        //     loadCorals(savedData);
        // }
    }

    void OnApplicationQuit()
    {
        // get the corals (which are saved in CoralController) and add them here
        List<string> placedCorals = new List<string>(); 
        saveSystem.SaveGame(placedCorals); // Save the game
    }

    void loadCorals(SaveData savedData)
    {
        // then here load corals that were saved before
        Debug.Log("loaded based on saved data.");
    }
}
