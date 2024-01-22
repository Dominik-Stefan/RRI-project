using UnityEngine;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    public UIDocument pauseMenuUI;
    public static bool paused;
    public KeyCode pauseButton;
    void Start()
    {
        ResumeGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(pauseButton))
        {
            if (paused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        paused = false;
        pauseMenuUI.rootVisualElement.style.display = DisplayStyle.None;
        Time.timeScale = 1f;
    }

    private void PauseGame()
    {
        paused = true;
        pauseMenuUI.rootVisualElement.style.display = DisplayStyle.Flex;
        Time.timeScale = 0f;
    }
}
