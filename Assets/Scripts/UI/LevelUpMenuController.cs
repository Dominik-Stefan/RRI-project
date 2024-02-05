using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelUpMenuController : MonoBehaviour
{
    private VisualElement root;
    private Button buttonConfirm;
    private PlayerController playerController;
    private GameController gameController;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        buttonConfirm = root.Q<Button>("ConfirmButton");

        buttonConfirm.clicked += () => gameController.HideLevelUpMenu();
    }

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
}

