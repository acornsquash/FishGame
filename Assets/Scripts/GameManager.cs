using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public CoralController coralController;
    public FishController fishController;
    void Start()
    {
        LoadPlacedCorals();
        LoadFish();
    }

    void OnApplicationQuit()
    {
        Debug.Log("on application quit");
        // get the corals (which are saved in CoralController) and add them here
        if (coralController != null) {
            List<CoralController.CoralData> placedCoralsList = coralController.GetPlacedCoralsList();
            Debug.Log($" saving placedCorals: {placedCoralsList}");
            SaveCorals(placedCoralsList);
        } else {
            Debug.Log("No Coral Controller");
        }
    }

    void SaveCorals(List<CoralController.CoralData> corals)
    {
        Debug.Log($"Save these Corals: " + corals[0]);
        string json = JsonUtility.ToJson(new CoralSaveDataWrapper(corals));
        Debug.Log($"Saving JSON: " + json);
        PlayerPrefs.SetString("PlacedCorals", json);
        PlayerPrefs.Save();
    }

    [System.Serializable]
    public class CoralSaveDataWrapper
    {
        public List<CoralController.CoralData> corals;

        public CoralSaveDataWrapper(List<CoralController.CoralData> coralList)
        {
            corals = coralList;
        }
    }


    public void LoadPlacedCorals()
    {
        string json = PlayerPrefs.GetString("PlacedCorals", "");
        Debug.Log("Loaded JSON: " + json);

        if (!string.IsNullOrEmpty(json))
        {
            CoralSaveDataWrapper wrapper = JsonUtility.FromJson<CoralSaveDataWrapper>(json);
        
            Debug.Log($"wrapper, {wrapper}");
            if (wrapper != null && wrapper.corals != null)
            {
                Debug.Log($"wrapper, {wrapper.corals}");
                foreach (CoralController.CoralData coral in wrapper.corals)
                {
                    // add the saved coral
                     coralController.AddCoralToSpot(coral.placement, coral.coralIndex);
                }
            }
            else
            {
                Debug.LogWarning("Loaded wrapper or coral list was null.");
            }
        }
        else
        {
            Debug.Log("No coral data found to load.");
        }
    }

    public void LoadFish()
    {
        List<CoralController.CoralData> placedCorals = coralController.GetPlacedCoralsList();
        Debug.Log("Load Fish");
        fishController.TrySpawnFish(placedCorals);
    }
}
