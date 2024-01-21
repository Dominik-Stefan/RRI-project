using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuController : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button buttonStart = root.Q<Button>("StartButton");
        Button buttonQuit = root.Q<Button>("QuitButton");

        buttonStart.clicked += () => SceneManager.LoadScene("Main");
        buttonQuit.clicked += () => Application.Quit();
    }
}
