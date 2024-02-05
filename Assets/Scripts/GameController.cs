using UnityEngine;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    public UIDocument pauseMenuUI;
    public UIDocument gameOverMenuUI;
    public UIDocument inGameHUD;
    public UIDocument levelUpMenuUI;
    public static bool paused;
    public bool gameOver;
    public bool timerActive = true;
    public bool levelUp = false;
    public KeyCode pauseButton;
    void Start()
    {
        gameOverMenuUI.rootVisualElement.style.display = DisplayStyle.None;
        levelUpMenuUI.rootVisualElement.style.display = DisplayStyle.None;
        inGameHUD.rootVisualElement.style.display = DisplayStyle.Flex;
        ResumeGame();
        gameOver = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(pauseButton) && !gameOver && !levelUp)
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

    public void ShowLevelUpMenu()
    {
        levelUp = true;
        levelUpMenuUI.rootVisualElement.style.display = DisplayStyle.Flex;
        Time.timeScale = 0f;
        timerActive = false;
    }

    public void HideLevelUpMenu()
    {
        levelUp = false;
        levelUpMenuUI.rootVisualElement.style.display = DisplayStyle.None;
        Time.timeScale = 1f;
        timerActive = true;
    }
}
