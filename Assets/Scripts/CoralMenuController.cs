using UnityEngine;
using UnityEngine.UI;
public class CoralMenuController : MonoBehaviour
{
    public GameObject coralMenu;
    public Button[] coralButtons;
    public GameObject CoralSpaceLeft;
    public GameObject CoralSpaceRight;

    public GameObject CoralSpaceBottomLeft;

    public GameObject CoralSpaceBottomRight;

    private CoralController coralController;
    private ValidPlacement selectedPlacement = ValidPlacement.Left;


    private void Start()
    {
        coralMenu.SetActive(false);

        coralController = FindFirstObjectByType<CoralController>();

        // button listeners to add corals
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
        coralMenu.SetActive(false); 

        int coralIndex = coralButton.name == "coral1button" ? 0 : 1;
        
        coralController.AddCoralToSpot(selectedPlacement, coralIndex);

    }

}
