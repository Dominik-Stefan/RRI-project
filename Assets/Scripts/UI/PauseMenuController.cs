using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseMenuController : MonoBehaviour
{
    public GameController gameController;
    public UIDocument confirmationUIDocument;
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button buttonResume = root.Q<Button>("ResumeButton");
        Button buttonMainMenu = root.Q<Button>("MainMenuButton");
        Button buttonQuit = root.Q<Button>("QuitButton");

        buttonResume.clicked += () => gameController.ResumeGame();
        buttonMainMenu.clicked += () => confirmationUIDocument.rootVisualElement.style.display = DisplayStyle.Flex;
        buttonQuit.clicked += () => Application.Quit();

        confirmationUIDocument.rootVisualElement.style.display = DisplayStyle.None;
    }
}
