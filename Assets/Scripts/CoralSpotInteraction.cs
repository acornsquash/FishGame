using UnityEngine;

public class CoralSpotInteraction : MonoBehaviour
{
    private CoralMenuController coralMenuController;

    public string chosenPlacement; // left or right
    void Start()
    {
        coralMenuController = FindFirstObjectByType<CoralMenuController>();
        
    }

    private void OnMouseDown()
    {
        if (coralMenuController != null)
        {
            coralMenuController.ShowCoralMenu(chosenPlacement);
        }
    }
}
