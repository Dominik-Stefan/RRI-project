using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class InGameHUDController : MonoBehaviour
{
    private VisualElement root;
    private Label timeLabel;
    private ProgressBar hpBar;
    private ProgressBar expBar;
    private ProgressBar ammoBar;
    private PlayerController playerController;
    private GameController gameController;
    private float currentTime = 0f;
    private float reloadTimer;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        timeLabel = root.Q<Label>("Time");
        hpBar = root.Q<ProgressBar>("HP");
        expBar = root.Q<ProgressBar>("EXP");
        ammoBar = root.Q<ProgressBar>("Ammo");
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
        if (ShootingController.currentAmmo > 0)
        {
            ammoBar.value = ShootingController.currentAmmo;
            ammoBar.highValue = ShootingController.ammo;
            ammoBar.title = ShootingController.currentAmmo + "/" + ShootingController.ammo;
            reloadTimer = 0;
        }
        else
        {
            reloadTimer += Time.deltaTime;
            float reloadProgress = reloadTimer / ShootingController.reloadTime;
            ammoBar.value = Mathf.Lerp(ShootingController.currentAmmo, ShootingController.ammo, reloadProgress);
            ammoBar.title = Mathf.FloorToInt((reloadProgress * 100)) + "%";
        }

        hpBar.value = playerController.playerHealth;
        hpBar.highValue = playerController.playerMaxHealth;
        hpBar.title = "HP: " + playerController.playerHealth + "/" + playerController.playerMaxHealth;

        expBar.value = playerController.exp;
        expBar.highValue = playerController.expToLevelUp;
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

