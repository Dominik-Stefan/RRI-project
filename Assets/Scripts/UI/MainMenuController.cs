using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuController : MonoBehaviour
{
    public UIDocument menuUIDocument;
    public UIDocument controlsUIDocument;
    private void OnEnable()
    {
        VisualElement root = menuUIDocument.rootVisualElement;

        Button buttonStart = root.Q<Button>("StartButton");
        Button buttonControls = root.Q<Button>("ControlsButton");
        Button buttonQuit = root.Q<Button>("QuitButton");

        buttonStart.clicked += () => SceneManager.LoadScene("Main");
        buttonControls.clicked += () => ShowControls();
        buttonQuit.clicked += () => Application.Quit();

        controlsUIDocument.rootVisualElement.style.display = DisplayStyle.None;
    }

    private void ShowControls()
    {
        controlsUIDocument.rootVisualElement.style.display = DisplayStyle.Flex;
        menuUIDocument.rootVisualElement.style.display = DisplayStyle.None;
    }
}
