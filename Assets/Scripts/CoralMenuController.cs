using UnityEngine;
using UnityEngine.UI;
public class CoralMenuController : MonoBehaviour
{
    public GameObject coralMenu;  // The panel to show/hide
    public Button[] coralButtons;  // Buttons to choose corals
    public GameObject CoralSpaceLeft; // Left coral spot reference
    public GameObject CoralSpaceRight; // Right coral spot reference

    private CoralController coralController;

    private void Start()
    {
        // Initially hide the coral menu
        // coralMenu.SetActive(false);

        coralController = FindFirstObjectByType<CoralController>();

        // Set up button listeners to add corals
        foreach (var button in coralButtons)
        {
            button.onClick.AddListener(() => AddCoral(button));
        }
    }

    public void ShowCoralMenu(string coralSpot)
    {
        coralMenu.SetActive(true);

        // pass the string into AddCoral so it know where to put the coral???
        // public chosenPlacement coralSpot;
    }

    void AddCoral(Button coralButton)
    {
        Debug.Log("Coral added: " + coralButton.name);
        coralMenu.SetActive(false); // Hide menu after selection

        coralController.AddCoralToSpot("Left", 0);

    }

}
