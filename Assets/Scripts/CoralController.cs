using UnityEngine;

public class CoralController : MonoBehaviour
{
   public GameObject CoralSpaceLeft;
   public GameObject CoralSpaceRight;

   public GameObject[] Corals;

   void Start()
   {
        if (CoralSpaceLeft == null || CoralSpaceRight == null) 
        {
            Debug.LogError("no spots defined for coral placement.");
        }
   }

   public void AddCoralToSpot(string placement, int coralIndex)
   {
        Debug.Log("adding corals?");
        if (Corals.Length == 0)
        {
            Debug.LogError("No coral prefabs assigned!");
            return;
        }

        // select the coral by the index
        GameObject chosenCoral = Corals[coralIndex];

        // Determine which spot to place it in
        GameObject targetSpot = placement == "Left" ? CoralSpaceLeft : CoralSpaceRight;

        // Instantiate the coral at the spot
        Instantiate(chosenCoral, targetSpot.transform.position, Quaternion.identity, targetSpot.transform);
   }
}
