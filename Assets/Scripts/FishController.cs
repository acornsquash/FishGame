using UnityEngine;
using System.Collections.Generic;

public class FishController: MonoBehaviour
{
    // all possible fish
    public GameObject[] Fish;
    public Transform FishSpawnArea;
    private bool fishSpawned = false;

    public class FishData {
        // the data we need to save about each fish
        public int fishIndex;
        
        public string fishType;

        // how will placement be determined if not in a rigid spot but also can't overlap other things?
    }

    // fish currently visible
    public List <FishData> CurrentFishList = new List<FishData>();

    // for use in GameManager when saving, reopening
    public List <FishData> getCurrentFishList() {
        return CurrentFishList;
    }

    public void TrySpawnFish(List<CoralController.CoralData> placedCorals)
    {
        if (!fishSpawned && placedCorals != null && placedCorals.Count > 0)
        {
            SpawnFish();
            fishSpawned = true;
        }
    }

    void SpawnFish()
    {
        Debug.Log("spawn fish");

        // choose how many fish to spawn
        int numberToSpawn = Random.Range(1, 5);

        // Track already spawned indices to avoid duplicates
        // or do we want duplicates to be ok?? 
        HashSet<int> usedIndices = new HashSet<int>();

        for (int i = 0; i < numberToSpawn; i++)
        {
            // choose a random fish from the array
            int randomIndex;
            do
            {
                randomIndex = Random.Range(0, Fish.Length);
            } while (usedIndices.Contains(randomIndex) && usedIndices.Count < Fish.Length);

        usedIndices.Add(randomIndex);

        Vector3 spawnPos = GetRandomFishSpawnPosition();
        GameObject newFish = Instantiate(Fish[randomIndex], spawnPos, Quaternion.identity);

        // save fish data to your current fish list
        FishData fishData = new FishData
        {
            fishIndex = randomIndex,
            fishType = Fish[randomIndex].name
        };

        CurrentFishList.Add(fishData);
    }
}

    Vector3 GetRandomFishSpawnPosition()
    {
        // randomized placement ?
        Vector2 randomPos = new Vector2(Random.Range(-2f, 2f), Random.Range(-1f, 1f));
        Debug.Log($"random: {randomPos}");
        return FishSpawnArea != null ? FishSpawnArea.position + (Vector3)randomPos : randomPos;
    }
}

    // create relationships between fish and certain corals
    // write a script that chooses fish based on fish already present (we want it to change every time), corals placed, and how long the player has been around 