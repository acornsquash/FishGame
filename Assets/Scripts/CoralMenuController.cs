using UnityEngine;
using UnityEngine.UI;
public class CoralMenuController : MonoBehaviour
{
    public GameObject coralMenu;  // The panel to show/hide
    public Button[] coralButtons;  // Buttons to choose corals
    public GameObject CoralSpaceLeft; // Left coral spot reference
    public GameObject CoralSpaceRight; // Right coral spot reference

    public GameObject CoralSpaceBottomLeft;

    public GameObject CoralSpaceBottomRight;

    private CoralController coralController;
    private ValidPlacement selectedPlacement = ValidPlacement.Left;


    private void Start()
    {
        // Initially hide the coral menu
        coralMenu.SetActive(false);

        coralController = FindFirstObjectByType<CoralController>();

        // Set up button listeners to add corals
        foreach (var button in coralButtons)
        {
            button.onClick.AddListener(() => AddCoral(button));
        }
    }

    public void ShowCoralMenu(ValidPlacement coralSpot)
    {
        coralMenu.SetActive(true);

       selectedPlacement = coralSpot;
    }

    void AddCoral(Button coralButton)
    {
        Debug.Log("Coral added: " + coralButton.name);
        coralMenu.SetActive(false); // Hide menu after selection

        int coralIndex = coralButton.name == "coral1button" ? 0 : 1;
        
        coralController.AddCoralToSpot(selectedPlacement, coralIndex);

    }

}
