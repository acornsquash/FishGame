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
        Debug.Log("on application quit");
        // get the corals (which are saved in CoralController) and add them here
    //     GameObject[] placedCorals = coralController.GetPlacedCorals;

    //     foreach (var item in placedCorals) {
    //         Debug.Log("placed" + item);
    //     } 
    //     Debug.Log("placed Corals");
    //     saveSystem.SaveGame(placedCorals); // Save the game
    }

    // void loadCorals(SaveData savedData)
    // {
    //     // then here load corals that were saved before
    //     Debug.Log("loaded based on saved data.");
    // }
}
