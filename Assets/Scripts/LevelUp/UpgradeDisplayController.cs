using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Upgrades;

public class UpgradeDisplayController : MonoBehaviour
{
    public GameObject upgradePrefab;
    private UpgradeOptionController upgradeOptionController;
    private float currentXPosition = 20f;
    private const float itemSpacing = 10f;

    private void Start()
    {
        upgradeOptionController = gameObject.GetComponent<UpgradeOptionController>();
    }

    public void AddUpgradeToDisplay(Upgrade upgrade)
    {
        if (upgrade.GetID() == 0)
        {
            return;
        }

        if (upgrade.GetLVL() == upgrade.GetMaxLVL())
        {
            foreach (Transform child in gameObject.transform)
            {
                if (child.name == upgrade.spriteName)
                {
                    child.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/UpgradeSprites/" + upgrade.spriteName + "_max");
                    return;
                }
            }
        }

        if (DoesUpgradeExist(upgrade.spriteName))
        {
            return;
        }

        GameObject imgObject = Instantiate(upgradePrefab, gameObject.transform);
        imgObject.name = upgrade.spriteName;

        RectTransform rectTransform = imgObject.GetComponent<RectTransform>();

        rectTransform.anchorMin = new Vector2(0, 1);
        rectTransform.anchorMax = new Vector2(0, 1);

        rectTransform.sizeDelta = new Vector2(30, 30);

        rectTransform.anchoredPosition = new Vector2(currentXPosition, -20);

        Image image = imgObject.GetComponent<Image>();
        Sprite sprite = Resources.Load<Sprite>("Sprites/UpgradeSprites/" + upgrade.spriteName);

        image.sprite = sprite;

        currentXPosition += rectTransform.rect.width + itemSpacing;
    }

    public bool DoesUpgradeExist(string spriteName)
    {
        foreach (Transform child in gameObject.transform)
        {
            /* Image childImage = child.GetComponent<Image>();
            if (childImage != null && childImage.sprite != null && childImage.sprite.name == spriteName)
            {
                return true;
            } */
            if (child.name == "RapidFire" && spriteName == "DualWielding")
            {
                child.name = "DualWielding";
                child.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/UpgradeSprites/DualWielding");
                return true;
            }

            if (child.name == spriteName)
            {
                return true;
            }
        }
        return false;
    }


}
