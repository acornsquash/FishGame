using UnityEngine;
using System.Collections.Generic;

public class FishController: MonoBehaviour
{
    // all possible fish
    public GameObject[] Fish;

    public class FishData {
        // the data we need to save about each fish
        public int fishIndex;
        
        public string fishType;

        // how will placement be determined if not in a rigid spot but also can't overlap other things?
    }

    // fish currently visible
    public List <FishData> CurrentFishList;

    // for use in GameManager when saving, reopening
    public List <FishData> getCurrentFishList() {
        return CurrentFishList;
    }

    // create a space where fish can appear randomly, should likely be less rigid than the spaces to attach corals?
    // create relationships between fish and certain corals
    // write a script that chooses fish based on fish already present (we want it to change every time), corals placed, and how long the player has been around 
}