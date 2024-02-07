using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuController : MonoBehaviour
{
    public UIDocument menuUIDocument;
    public UIDocument controlsUIDocument;
    public UIDocument gunMenuUIDocument;

    private void OnEnable()
    {
        VisualElement root = menuUIDocument.rootVisualElement;

        Button buttonStart = root.Q<Button>("StartButton");
        Button buttonControls = root.Q<Button>("ControlsButton");
        Button buttonQuit = root.Q<Button>("QuitButton");

        buttonStart.clicked += () => ShowGunMenu();
        buttonControls.clicked += () => ShowControls();
        buttonQuit.clicked += () => Application.Quit();

        controlsUIDocument.rootVisualElement.style.display = DisplayStyle.None;
        gunMenuUIDocument.rootVisualElement.style.display = DisplayStyle.None;
    }

    private void ShowGunMenu()
    {
        gunMenuUIDocument.rootVisualElement.style.display = DisplayStyle.Flex;
    }

    private void ShowControls()
    {
        controlsUIDocument.rootVisualElement.style.display = DisplayStyle.Flex;
        menuUIDocument.rootVisualElement.style.display = DisplayStyle.None;
    }
}
