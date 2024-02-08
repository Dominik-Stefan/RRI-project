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
        private static int gritMaxLVL = 5;

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
        private static int rushMaxLVL = 5;

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
        private static int mightMaxLVL = 5;

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

    public class CompanyBonus : Upgrade
    {
        private static int id = 4;
        private static int companyBonusLVL = 0;
        private static int companyBonusMaxLVL = 1;

        public CompanyBonus()
        {
            title = "Company bonus";
            description = "Max health, movement speed and damage +5%";
        }

        public override void Execute()
        {
            companyBonusLVL++;

            PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();

            int healthGain = (int)(player.GetPlayerBaseHealth() * 0.05f);

            player.playerMaxHealth += healthGain;

            player.playerHealth += healthGain;

            player.moveSpeed += (player.GetBaseMoveSpeed() * 0.05f);

            player.playerDamage += (int)(player.GetPlayerBaseDamage() * 0.05f);
        }

        public override int GetID()
        {
            return id;
        }

        public override int GetLVL()
        {
            return companyBonusLVL;
        }

        public override int GetMaxLVL()
        {
            return companyBonusMaxLVL;
        }
    }

    public class QuickReload : Upgrade
    {
        private static int id = 5;
        private static int quickReloadLVL = 0;
        private static int quickReloadMaxLVL = 5;

        public QuickReload()
        {
            title = "Quick Reload LVL " + (quickReloadLVL + 1);
            description = "Reload speed +15%";
        }

        public override void Execute()
        {
            quickReloadLVL++;

            ShootingController.reloadTime -= (0.15f * ShootingController.reloadTime);
        }

        public override int GetID()
        {
            return id;
        }

        public override int GetLVL()
        {
            return quickReloadLVL;
        }

        public override int GetMaxLVL()
        {
            return quickReloadMaxLVL;
        }
    }

    public class BulletSpeed : Upgrade
    {
        private static int id = 6;
        private static int bulletSpeedLVL = 0;
        private static int bulletSpeedMaxLVL = 5;

        public BulletSpeed()
        {
            title = "Bullet Speed LVL " + (bulletSpeedLVL + 1);
            description = "Bullet speed +25%";
        }

        public override void Execute()
        {
            bulletSpeedLVL++;

            ShootingTypes.force += (0.25f * ShootingTypes.force);
        }

        public override int GetID()
        {
            return id;
        }

        public override int GetLVL()
        {
            return bulletSpeedLVL;
        }

        public override int GetMaxLVL()
        {
            return bulletSpeedMaxLVL;
        }
    }

    public class RapidFire : Upgrade
    {
        private static int id = 7;
        private static int rapidFireLVL = 0;
        private static int rapidFireMaxLVL = 5;

        public RapidFire()
        {
            title = "Rapid Fire LVL " + (rapidFireLVL + 1);
            description = "Fires one more bullet";
        }

        public override void Execute()
        {
            rapidFireLVL++;

            ShootingController.quickShoot += 1;
        }

        public override int GetID()
        {
            return id;
        }

        public override int GetLVL()
        {
            return rapidFireLVL;
        }

        public override int GetMaxLVL()
        {
            return rapidFireMaxLVL;
        }
    }

    public class MorePellets : Upgrade
    {
        private static int id = 8;
        private static int morePelletsLVL = 0;
        private static int morePelletsMaxLVL = 5;

        public MorePellets()
        {
            title = "More Pellets LVL " + (morePelletsLVL + 1);
            description = "Pellet count +3";
        }

        public override void Execute()
        {
            morePelletsLVL++;

            ShootingController.pellets += 3;
        }

        public override int GetID()
        {
            return id;
        }

        public override int GetLVL()
        {
            return morePelletsLVL;
        }

        public override int GetMaxLVL()
        {
            return morePelletsMaxLVL;
        }
    }

    public class IncreaseSpread : Upgrade
    {
        private static int id = 9;
        private static int increaseSpreadLVL = 0;
        private static int increaseSpreadMaxLVL = 5;

        public IncreaseSpread()
        {
            title = "Increase Spread LVL " + (increaseSpreadLVL + 1);
            description = "Spread +30%";
        }

        public override void Execute()
        {
            increaseSpreadLVL++;

            ShootingController.spreadAngle += (0.3f * ShootingController.spreadAngle);
        }

        public override int GetID()
        {
            return id;
        }

        public override int GetLVL()
        {
            return increaseSpreadLVL;
        }

        public override int GetMaxLVL()
        {
            return increaseSpreadMaxLVL;
        }
    }

    public class FireRate : Upgrade
    {
        private static int id = 10;
        private static int fireRateLVL = 0;
        private static int fireRateMaxLVL = 5;

        public FireRate()
        {
            title = "Fire Rate LVL " + (fireRateLVL + 1);
            description = "FireRate +20%";
        }

        public override void Execute()
        {
            fireRateLVL++;

            ShootingController.timeBetweenFiring -= (0.2f * ShootingController.timeBetweenFiring);
        }

        public override int GetID()
        {
            return id;
        }

        public override int GetLVL()
        {
            return fireRateLVL;
        }

        public override int GetMaxLVL()
        {
            return fireRateMaxLVL;
        }
    }

    public class AmmoReserve : Upgrade
    {
        private static int id = 11;
        private static int ammoReserveLVL = 0;
        private static int ammoReserveMaxLVL = 5;

        public AmmoReserve()
        {
            title = "Ammo Reserve LVL " + (ammoReserveLVL + 1);
            description = "Max ammo +20%";
        }

        public override void Execute()
        {
            ammoReserveLVL++;

            ShootingController.ammo += (int)(0.20f * ShootingController.ammo);
            ShootingController.currentAmmo = ShootingController.ammo;
        }

        public override int GetID()
        {
            return id;
        }

        public override int GetLVL()
        {
            return ammoReserveLVL;
        }

        public override int GetMaxLVL()
        {
            return ammoReserveMaxLVL;
        }
    }

    public class Curse : Upgrade
    {
        private static int id = 12;
        private static int curseLVL = 0;
        private static int curseMaxLVL = 1;

        public Curse()
        {
            title = "Curse";
            description = "33% max health, +50% damage, x2 movement speed";
        }

        public override void Execute()
        {
            curseLVL++;

            PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();

            player.playerMaxHealth = (int)(player.playerMaxHealth * 0.33f);

            player.playerHealth = player.playerMaxHealth;

            player.moveSpeed = player.GetBaseMoveSpeed() * 2f;

            player.playerDamage += (int)(player.GetPlayerBaseDamage() * 0.5f);
        }

        public override int GetID()
        {
            return id;
        }

        public override int GetLVL()
        {
            return curseLVL;
        }

        public override int GetMaxLVL()
        {
            return curseMaxLVL;
        }
    }
}
