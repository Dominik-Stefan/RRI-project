using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class InGameHUDController : MonoBehaviour
{
    private VisualElement root;
    private Label timeLabel;
    private ProgressBar hpBar;
    private ProgressBar expBar;
    private PlayerController playerController;
    private GameController gameController;
    private float currentTime = 0f;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        timeLabel = root.Q<Label>("Time");
        hpBar = root.Q<ProgressBar>("HP");
        expBar = root.Q<ProgressBar>("EXP");
    }



    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        timeLabel.text = "00:00";

        hpBar.value = 100;
        hpBar.title = "HP: 100/100";

        expBar.value = 0;
        expBar.title = "EXP: 0/100";
    }

    void Update()
    {
        hpBar.value = playerController.playerHealth;
        hpBar.title = "HP: " + playerController.playerHealth + "/" + playerController.playerMaxHealth;

        expBar.value = playerController.exp;
        expBar.title = "EXP: " + playerController.exp + "/" + playerController.expToLevelUp;

        if (gameController.timerActive)
        {
            currentTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(currentTime / 60F);
            int seconds = Mathf.FloorToInt(currentTime % 60F);
            timeLabel.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}

