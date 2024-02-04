using UnityEngine;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    public UIDocument pauseMenuUI;
    public UIDocument gameOverMenuUI;
    public UIDocument gameUI;
    public static bool paused;
    public bool gameOver;
    public bool timerActive = true;
    public KeyCode pauseButton;
    private InGameHUDController inGameHUDController;
    void Start()
    {
        gameOverMenuUI.rootVisualElement.style.display = DisplayStyle.None;
        gameUI.rootVisualElement.style.display = DisplayStyle.Flex;
        ResumeGame();
        gameOver = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(pauseButton) && !gameOver)
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
            timerActive = false;
        }
    }

    public void ResumeGame()
    {
        paused = false;
        pauseMenuUI.rootVisualElement.style.display = DisplayStyle.None;
        Time.timeScale = 1f;
        timerActive = true;
    }

    private void PauseGame()
    {
        paused = true;
        pauseMenuUI.rootVisualElement.style.display = DisplayStyle.Flex;
        Time.timeScale = 0f;
        timerActive = false;
    }
}
