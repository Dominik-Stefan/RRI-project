using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Upgrades;

public class UpgradeOptionController : MonoBehaviour
{
    private List<Upgrade> allOptions = new List<Upgrade> { new Grit(), new Rush(), new Might(), new CompanyBonus() };

    public List<Upgrade> GetUpgradeOptions()
    {
        PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();

        if (player.GetLevel() > 5)
        {
            allOptions.RemoveAll(upgrade => upgrade.GetID() == 4);
        }

        List<Upgrade> options = new List<Upgrade>();

        switch (allOptions.Count)
        {
            case 0:
                options.Add(new Heal());
                return options;
            case 1:
                options.Add(allOptions[0]);
                return options;
            case 2:
                options.Add(allOptions[0]);
                options.Add(allOptions[1]);
                return options;
            case 3:
                options.Add(allOptions[0]);
                options.Add(allOptions[1]);
                options.Add(allOptions[2]);
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

        return options;
    }

    public void RemoveOption(Upgrade option)
    {
        if (option.GetLVL() == option.GetMaxLVL())
        {
            allOptions.RemoveAll(upgrade => upgrade.GetID() == option.GetID());
        }
    }
}
