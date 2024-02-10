using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ConfirmationMenuController : MonoBehaviour
{
    public UIDocument confirmationMenuDocument;

    private void OnEnable()
    {
        VisualElement root = confirmationMenuDocument.rootVisualElement;

        Button buttonYes = root.Q<Button>("YesButton");
        Button buttonNo = root.Q<Button>("NoButton");

        buttonYes.clicked += () => SceneManager.LoadScene("MainMenu");
        buttonNo.clicked += () => confirmationMenuDocument.rootVisualElement.style.display = DisplayStyle.None;
    }
}
