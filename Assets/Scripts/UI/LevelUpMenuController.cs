using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;



public class LevelUpMenuController : MonoBehaviour
{
    private class BasicStatUpgrade
    {
        public string description;
        private float maxHealth;
        private float attack;
        private float moveSpeed;
        private PlayerController player;
        private System.Random rnd;

        public BasicStatUpgrade()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>(); ;
            rnd = new System.Random();
            maxHealth = 0.05f * rnd.Next(-5, 6);
            attack = 0.05f * rnd.Next(-5, 6);
            moveSpeed = 0.05f * rnd.Next(-5, 6);
            description = "Movement speed: " + moveSpeed * 100 + "% , Max health: " + maxHealth * 100 + "% , Attack: " + attack * 100 + "%";
        }

        public void Upgrade()
        {
            player.playerMaxHealth = player.playerMaxHealth + (int)(player.playerMaxHealth * maxHealth);
            if (player.playerHealth > player.playerMaxHealth)
            {
                player.playerHealth = player.playerMaxHealth;
            }
            player.moveSpeed = player.moveSpeed + player.moveSpeed * moveSpeed;
            player.playerDamage = player.playerDamage + (int)(player.playerDamage * attack);
        }
    }


    private VisualElement root;
    private Button buttonConfirm;
    private PlayerController playerController;
    private GameController gameController;
    private RadioButtonGroup levelUpOptions;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        List<BasicStatUpgrade> options = new List<BasicStatUpgrade> { new BasicStatUpgrade(), new BasicStatUpgrade(), new BasicStatUpgrade() };

        List<string> choices = new List<string> { options[0].description, options[1].description, options[2].description };

        levelUpOptions = root.Q<RadioButtonGroup>("LevelUpOptions");
        levelUpOptions.choices = choices;
        levelUpOptions.value = 0;

        buttonConfirm = root.Q<Button>("ConfirmButton");

        buttonConfirm.clicked += () =>
        {
            options[levelUpOptions.value].Upgrade();
            gameController.HideLevelUpMenu();
        };
    }

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
}

