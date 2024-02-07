using UnityEngine;
using UnityEngine.UIElements;

public class ControlsMenuController : MonoBehaviour
{
    public UIDocument menuUIDocument;
    public UIDocument controlsUIDocument;
    private void OnEnable()
    {
        VisualElement root = controlsUIDocument.rootVisualElement;

        Button buttonBack = root.Q<Button>("BackButton");

        buttonBack.clicked += () => ShowMain();
    }

    private void ShowMain()
    {
        controlsUIDocument.rootVisualElement.style.display = DisplayStyle.None;
        menuUIDocument.rootVisualElement.style.display = DisplayStyle.Flex;
    }
}
