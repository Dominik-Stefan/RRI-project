using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class GameOverController : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button buttonRestart = root.Q<Button>("RestartButton");
        Button buttonMainMenu = root.Q<Button>("MainMenuButton");
        Button buttonQuit = root.Q<Button>("QuitButton");

        buttonRestart.clicked += () => SceneManager.LoadScene("Main");
        buttonMainMenu.clicked += () => SceneManager.LoadScene("MainMenu");
        buttonQuit.clicked += () => Application.Quit();
    }
}

