using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Upgrades
{
    public class Upgrade
    {
        public static Sprite sprite;
        protected string title;
        protected string description;

        public virtual void Execute() { }

        public virtual int GetID()
        {
            return 0;
        }

        public virtual int GetLVL()
        {
            return 0;
        }

        public virtual int GetMaxLVL()
        {
            return 0;
        }

        public string GetTitle()
        {
            return title;
        }

        public string GetDescription()
        {
            return description;
        }
    }

    public class Heal : Upgrade
    {
        private static int id = 0;
        private static int healLVL = 0;
        private static int healMaxLVL = 1;

        public Heal()
        {
            title = "Heal";
            description = "Heal 25% base health";
        }

        public override void Execute()
        {
            PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();

            int healthGain = (int)(player.GetPlayerBaseHealth() * 0.25f);

            if (player.playerHealth + healthGain >= player.playerMaxHealth)
            {
                player.playerHealth = player.playerMaxHealth;
                return;
            }

            player.playerHealth += healthGain;
        }

        public override int GetID()
        {
            return id;
        }

        public override int GetLVL()
        {
            return healLVL;
        }

        public override int GetMaxLVL()
        {
            return healMaxLVL;
        }
    }

    public class Grit : Upgrade
    {
        private static int id = 1;
        private static int gritLVL = 0;
        private static int gritMaxLVL = 3;

        public Grit()
        {
            title = "Grit LVL " + (gritLVL + 1);
            description = "Max health +10%";
        }

        public override void Execute()
        {
            gritLVL++;

            PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();

            int healthGain = (int)(player.GetPlayerBaseHealth() * 0.1f);

            player.playerMaxHealth += healthGain;

            player.playerHealth += healthGain;
        }

        public override int GetID()
        {
            return id;
        }

        public override int GetLVL()
        {
            return gritLVL;
        }

        public override int GetMaxLVL()
        {
            return gritMaxLVL;
        }
    }

    public class Rush : Upgrade
    {
        private static int id = 2;
        private static int rushLVL = 0;
        private static int rushMaxLVL = 3;

        public Rush()
        {
            title = "Rush LVL " + (rushLVL + 1);
            description = "Movement speed +10%";
        }

        public override void Execute()
        {
            rushLVL++;

            PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();

            player.moveSpeed += (player.GetBaseMoveSpeed() * 0.1f);
        }

        public override int GetID()
        {
            return id;
        }

        public override int GetLVL()
        {
            return rushLVL;
        }

        public override int GetMaxLVL()
        {
            return rushMaxLVL;
        }
    }

    public class Might : Upgrade
    {
        private static int id = 3;
        private static int mightLVL = 0;
        private static int mightMaxLVL = 3;

        public Might()
        {
            title = "Might LVL " + (mightLVL + 1);
            description = "Player damage +10%";
        }

        public override void Execute()
        {
            mightLVL++;

            PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();

            player.playerDamage += (int)(player.GetPlayerBaseDamage() * 0.1f);
        }

        public override int GetID()
        {
            return id;
        }

        public override int GetLVL()
        {
            return mightLVL;
        }

        public override int GetMaxLVL()
        {
            return mightMaxLVL;
        }
    }
}
