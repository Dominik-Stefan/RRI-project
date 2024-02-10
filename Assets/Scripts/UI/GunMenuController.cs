using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GunMenuController : MonoBehaviour
{
    public UIDocument gunMenuUIDocument;

    private void OnEnable()
    {
        VisualElement root = gunMenuUIDocument.rootVisualElement;

        Button buttonPistol = root.Q<Button>("PistolButton");
        Button buttonShotgun = root.Q<Button>("ShotgunButton");
        Button buttonMinigun = root.Q<Button>("MinigunButton");
        Button buttonCancel = root.Q<Button>("CancelButton");

        buttonPistol.clicked += () => GunPicker("Pistol");
        buttonShotgun.clicked += () => GunPicker("Shotgun");
        buttonMinigun.clicked += () => GunPicker("Minigun");
        buttonCancel.clicked += () => gunMenuUIDocument.rootVisualElement.style.display = DisplayStyle.None;
    }

    private void GunPicker(string gunName)
    {
        Gun.selectedGun = gunName;

        SceneManager.LoadScene("Main");
    }
}

