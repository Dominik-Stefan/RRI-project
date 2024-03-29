using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using Upgrades;

public class UpgradeOptionController : MonoBehaviour
{
    public static List<Upgrade> selectedOptions;
    private bool added = false;
    private List<Upgrade> allOptions = new List<Upgrade> { new Grit(), new Rush(), new Might(), new CompanyBonus(), new QuickReload() };
    private PlayerController player;
    private UpgradeDisplayController upgradeDisplayController;

    public List<Upgrade> GetUpgradeOptions()
    {
        if (!added)
        {
            player = GameObject.Find("Player").GetComponent<PlayerController>();
            upgradeDisplayController = GameObject.Find("UpgradeDisplay").GetComponent<UpgradeDisplayController>();

            selectedOptions = new List<Upgrade>();

            switch (Gun.selectedGun)
            {
                case "Pistol":
                    allOptions.Add(new BulletSpeed());
                    allOptions.Add(new RapidFire());
                    break;
                case "Shotgun":
                    allOptions.Add(new MorePellets());
                    allOptions.Add(new IncreaseSpread());
                    allOptions.Add(new Piercing());
                    break;
                case "Minigun":
                    allOptions.Add(new FireRate());
                    allOptions.Add(new AmmoReserve());
                    break;
            }

            added = true;
        }

        if (RapidFire.rapidFireLVL == RapidFire.rapidFireMaxLVL && !selectedOptions.Any(upgrade => upgrade.GetID() == 13))
        {
            allOptions.Add(new DualWielding());
        }

        if (AmmoReserve.ammoReserveLVL == 3 && !selectedOptions.Any(upgrade => upgrade.GetID() == 14))
        {
            allOptions.Add(new ExtraSupplies());
        }

        if (Might.mightLVL == Might.mightMaxLVL && Piercing.piercingLVL == Piercing.piercingMaxLVL && !selectedOptions.Any(upgrade => upgrade.GetID() == 16))
        {
            allOptions.Add(new DoublePellets());
        }

        if (Gun.selectedGun == "Minigun" && Might.mightLVL == 2 && Grit.gritLVL == 2 && !selectedOptions.Any(upgrade => upgrade.GetID() == 17))
        {
            allOptions.Add(new LifeSteal());
        }

        List<Upgrade> options = new List<Upgrade>();

        switch (allOptions.Count)
        {
            case 0:
                options.Add(new Heal());
                return options;
            case 1:
                options.Add(allOptions[0]);
                options.Add(new Heal());
                return options;
            case 2:
                options.Add(allOptions[0]);
                options.Add(allOptions[1]);
                options.Add(new Heal());
                return options;
            case 3:
                options.Add(allOptions[0]);
                options.Add(allOptions[1]);
                options.Add(allOptions[2]);
                options.Add(new Heal());
                return options;
        }

        System.Random rand = new System.Random();

        HashSet<int> selectedIndices = new HashSet<int>();

        while (selectedIndices.Count < 3)
        {
            int randIndex = rand.Next(0, allOptions.Count);
            if (!selectedIndices.Contains(randIndex))
            {
                selectedIndices.Add(randIndex);
                options.Add(allOptions[randIndex]);
            }
        }

        if (player.GetLevel() == 2)
        {
            options.Add(new Curse());
        }

        options.Add(new Heal());

        return options;
    }

    public void RemoveOption(Upgrade option)
    {
        if (option.GetLVL() == option.GetMaxLVL())
        {
            allOptions.RemoveAll(upgrade => upgrade.GetID() == option.GetID());
        }
    }

    public void AddSelectedOption(Upgrade option)
    {
        selectedOptions.Add(option);
        upgradeDisplayController.AddUpgradeToDisplay(option);
    }

    public static void RemoveSelectedOption(int id)
    {
        selectedOptions.RemoveAll(upgrade => upgrade.GetID() == id);
    }
}
