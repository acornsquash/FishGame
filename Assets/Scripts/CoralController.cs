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

   public void AddCoral(bool isLeft)
   {
        Debug.Log("adding corals?");
        if (Corals.Length == 0)
        {
            Debug.LogError("No coral prefabs assigned!");
            return;
        }

        // Choose a random coral from the list
        GameObject chosenCoral = Corals[Random.Range(0, Corals.Length)];

        // Determine which spot to place it in
        GameObject targetSpot = isLeft ? CoralSpaceLeft : CoralSpaceRight;

        // Instantiate the coral at the spot
        Instantiate(chosenCoral, targetSpot.transform.position, Quaternion.identity, targetSpot.transform);
   }
}
