using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseMenuController : MonoBehaviour
{
    public GameController gameController;
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button buttonResume = root.Q<Button>("ResumeButton");
        Button buttonMainMenu = root.Q<Button>("MainMenuButton");
        Button buttonQuit = root.Q<Button>("QuitButton");

        buttonResume.clicked += () => gameController.ResumeGame();
        buttonMainMenu.clicked += () => SceneManager.LoadScene("MainMenu");
        buttonQuit.clicked += () => Application.Quit();
    }
}
