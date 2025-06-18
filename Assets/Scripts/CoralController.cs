using UnityEngine;
using System.Collections.Generic;

public enum ValidPlacement
   {
    Left,
    Right,
    BottomLeft,
    BottomRight
   };

public class CoralController : MonoBehaviour
{
   public GameObject CoralSpaceLeft;
   public GameObject CoralSpaceRight;

   public GameObject CoralSpaceBottomRight;

   public GameObject CoralSpaceBottomLeft;

   public GameObject[] Corals;

    [System.Serializable]
   public class CoralData {
        public int coralIndex;
        public string coralType;
        public ValidPlacement placement;
   }

   public GameObject[] PlacedCorals = new GameObject[4];

   public List<CoralData> PlacedCoralsList;

   public List<CoralData> GetPlacedCoralsList() {
        return PlacedCoralsList;
   }

   private SpriteRenderer spriteRenderer;



   void Start()
   {
        Debug.Log("Coral Controller Start");
        // if no saved corals, initialize empty list
        if (PlacedCoralsList == null) {
            PlacedCoralsList = new List<CoralData>();
        }
   }

   public void AddCoralToSpot(ValidPlacement placement, int coralIndex)
   {
        if (Corals.Length == 0)
        {
            Debug.LogError("No coral prefabs assigned!");
            return;
        }

        // select the coral by the index
        GameObject chosenCoral = Corals[coralIndex];

        // Determine which spot to place it in
        GameObject targetSpot = placement switch
        {
            ValidPlacement.Left => CoralSpaceLeft,
            ValidPlacement.Right => CoralSpaceRight,
            ValidPlacement.BottomLeft => CoralSpaceBottomLeft,
            ValidPlacement.BottomRight => CoralSpaceBottomRight,
            _ => null
        };

        spriteRenderer = targetSpot.GetComponent<SpriteRenderer>();

        spriteRenderer.enabled = false;

        // if there is already a coral in the spot, remove it
        if (targetSpot.transform.childCount > 0)
        {
            foreach (Transform child in targetSpot.transform)
            {
                Destroy(child.gameObject);
            }
        };

        // Instantiate new coral
        GameObject newCoral = Instantiate(chosenCoral, targetSpot.transform.position, Quaternion.identity, targetSpot.transform);

        // update list
        PlacedCoralsList.RemoveAll(c => c.placement == placement);
        PlacedCoralsList.Add(new CoralData
            {   
                coralIndex = coralIndex,
                coralType = Corals[coralIndex].name,
                placement = placement
            });
   }
}
