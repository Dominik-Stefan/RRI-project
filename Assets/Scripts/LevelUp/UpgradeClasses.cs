using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Upgrades
{
    public class Grit
    {
        public static int gritLVL = 0;
        public static Sprite sprite;
        private string title;
        private string description = "Max health +10%";

        public Grit()
        {
            gritLVL++;
            title = "Grit LVL " + gritLVL;
        }

        public void Upgrade()
        {
            PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();

            int healthGain = (int)(player.GetPlayerBaseHealth() * 0.1f);

            player.playerMaxHealth += healthGain;

            player.playerHealth += healthGain;
        }

        public string GetTitle(){
            return title;
        }

        public string GetDescription(){
            return description;
        }
    }
}
