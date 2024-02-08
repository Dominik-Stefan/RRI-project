using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;

using Upgrades;

public class LevelUpMenuController : MonoBehaviour
{
    private VisualElement root;
    private Button buttonConfirm;
    private PlayerController playerController;
    private GameController gameController;
    private UpgradeOptionController upgradeOptionController;
    private RadioButtonGroup levelUpOptions;
    private List<Upgrade> options;
    private List<string> choices;
    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        levelUpOptions = root.Q<RadioButtonGroup>("LevelUpOptions");

        upgradeOptionController = gameObject.GetComponent<UpgradeOptionController>();

        Refresh();

        buttonConfirm = root.Q<Button>("ConfirmButton");

        buttonConfirm.clicked += () =>
        {
            options[levelUpOptions.value].Execute();
            upgradeOptionController.RemoveOption(options[levelUpOptions.value]);
            gameController.HideLevelUpMenu();
        };
    }

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public void Refresh()
    {
        options = upgradeOptionController.GetUpgradeOptions();

        choices = new List<string>();

        for (int i = 0; i < options.Count; i++)
        {
            choices.Add(options[i].GetTitle() + "\n" + options[i].GetDescription());
        }

        levelUpOptions.choices = choices;
        levelUpOptions.value = 0;
    }
}

