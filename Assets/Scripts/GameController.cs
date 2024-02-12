using UnityEngine;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    public UIDocument pauseMenuUI;
    public UIDocument gameOverMenuUI;
    public UIDocument gameDoneMenuUI;
    public UIDocument inGameHUD;
    public UIDocument levelUpMenuUI;
    public static bool paused;
    public bool gameOver;
    public bool timerActive = true;
    public bool levelUp = false;
    public KeyCode pauseButton;
    private AudioSource audioSo;
    public AudioClip levelUpSound;
    void Start()
    {
        gameOverMenuUI.rootVisualElement.style.display = DisplayStyle.None;
        gameDoneMenuUI.rootVisualElement.style.display = DisplayStyle.None;
        levelUpMenuUI.rootVisualElement.style.display = DisplayStyle.None;
        inGameHUD.rootVisualElement.style.display = DisplayStyle.Flex;
        audioSo = GetComponent<AudioSource>();
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

    public void GameDone()
    {
        timerActive = false;
        gameDoneMenuUI.rootVisualElement.style.display = DisplayStyle.Flex;
        Time.timeScale = 0f;
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
        levelUpMenuUI.GetComponent<LevelUpMenuController>().Refresh();
        levelUpMenuUI.rootVisualElement.style.display = DisplayStyle.Flex;
        Time.timeScale = 0f;
        timerActive = false;
        audioSo.PlayOneShot(levelUpSound);
    }

    public void HideLevelUpMenu()
    {
        levelUp = false;
        levelUpMenuUI.rootVisualElement.style.display = DisplayStyle.None;
        Time.timeScale = 1f;
        timerActive = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().AddExpToPlayer(0);
    }
}
