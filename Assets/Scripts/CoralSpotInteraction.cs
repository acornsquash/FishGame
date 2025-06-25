using UnityEngine;

public class CoralSpotInteraction : MonoBehaviour
{
    private CoralMenuController coralMenuController;

    public ValidPlacement chosenPlacement;
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
