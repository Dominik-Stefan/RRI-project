using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class LevelUpMenuController : MonoBehaviour
{
    private VisualElement root;
    private Button buttonConfirm;
    private PlayerController playerController;
    private GameController gameController;
    private RadioButtonGroup levelUpOptions;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        List<string> choices = new List<string> { "Option 1", "Option 2", "Option 3" };

        levelUpOptions = root.Q<RadioButtonGroup>("LevelUpOptions");
        levelUpOptions.choices = choices;
        levelUpOptions.value = 0;

        buttonConfirm = root.Q<Button>("ConfirmButton");

        buttonConfirm.clicked += () => gameController.HideLevelUpMenu();
    }

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
}

