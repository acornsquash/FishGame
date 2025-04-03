using UnityEngine;

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

   public GameObject[] PlacedCorals;

    private SpriteRenderer spriteRenderer;


   void Start()
   {

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

        // Instantiate the coral at the spot
        if (targetSpot != null) {
            Instantiate(chosenCoral, targetSpot.transform.position, Quaternion.identity, targetSpot.transform);

            // adjust list of current placed corals to be saved when game closes
            // PlacedCorals = updated placed corals?? 
        } else {
            Debug.LogWarning("invalid placement selection");
        };
   }
}
