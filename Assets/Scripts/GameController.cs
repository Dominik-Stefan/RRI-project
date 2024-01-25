using UnityEngine;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    public UIDocument pauseMenuUI;
    public UIDocument gameOverMenuUI;
    public static bool paused;
    public bool gameOver;
    public KeyCode pauseButton;
    void Start()
    {
        gameOverMenuUI.rootVisualElement.style.display = DisplayStyle.None;
        ResumeGame();
        gameOver = false;
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
        if (gameOver)
        {
            gameOverMenuUI.rootVisualElement.style.display = DisplayStyle.Flex;
            Time.timeScale = 0f;
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
