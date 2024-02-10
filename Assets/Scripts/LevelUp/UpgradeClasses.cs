using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Upgrades
{
    public class Upgrade
    {
        public string spriteName;
        protected string title;
        protected string description;

        public Upgrade() { }

        ~Upgrade()
        {
            ResetLVL();
        }

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

        public virtual void UpdateTitle() { }

        public virtual void ResetLVL() { }

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
            spriteName = "Grit";
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

        public override void UpdateTitle()
        {
            title = "Grit LVL " + (gritLVL + 1);
        }

        public override void ResetLVL()
        {
            gritLVL = 0;
        }
    }

    public class Rush : Upgrade
    {
        private static int id = 2;
        private static int rushLVL = 0;
        private static int rushMaxLVL = 5;

        public Rush()
        {
            spriteName = "Rush";
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

        public override void UpdateTitle()
        {
            title = "Rush LVL " + (rushLVL + 1);
        }

        public override void ResetLVL()
        {
            rushLVL = 0;
        }
    }

    public class Might : Upgrade
    {
        private static int id = 3;
        public static int mightLVL = 0;
        public static int mightMaxLVL = 5;

        public Might()
        {
            spriteName = "Might";
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

        public override void UpdateTitle()
        {
            title = "Might LVL " + (mightLVL + 1);
        }

        public override void ResetLVL()
        {
            mightLVL = 0;
        }
    }

    public class CompanyBonus : Upgrade
    {
        private static int id = 4;
        private static int companyBonusLVL = 0;
        private static int companyBonusMaxLVL = 1;

        public CompanyBonus()
        {
            spriteName = "CompanyBonus";
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

        public override void ResetLVL()
        {
            companyBonusLVL = 0;
        }
    }

    public class QuickReload : Upgrade
    {
        private static int id = 5;
        private static int quickReloadLVL = 0;
        private static int quickReloadMaxLVL = 5;

        public QuickReload()
        {
            spriteName = "QuickReload";
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

        public override void UpdateTitle()
        {
            title = "Quick Reload LVL " + (quickReloadLVL + 1);
        }

        public override void ResetLVL()
        {
            quickReloadLVL = 0;
        }
    }

    public class BulletSpeed : Upgrade
    {
        private static int id = 6;
        private static int bulletSpeedLVL = 0;
        private static int bulletSpeedMaxLVL = 5;

        public BulletSpeed()
        {
            spriteName = "BulletSpeed";
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

        public override void UpdateTitle()
        {
            title = "Bullet Speed LVL " + (bulletSpeedLVL + 1);
        }

        public override void ResetLVL()
        {
            bulletSpeedLVL = 0;
        }
    }

    public class RapidFire : Upgrade
    {
        private static int id = 7;
        public static int rapidFireLVL = 0;
        public static int rapidFireMaxLVL = 5;

        public RapidFire()
        {
            spriteName = "RapidFire";
            title = "Rapid Fire LVL " + (rapidFireLVL + 1);
            description = "Fires one more bullet";
        }

        public override void Execute()
        {
            rapidFireLVL++;

            ShootingController.quickShoot += 1;
        }

        public static void Undo()
        {
            ShootingController.quickShoot = 1;
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

        public override void UpdateTitle()
        {
            title = "Rapid Fire LVL " + (rapidFireLVL + 1);
        }

        public override void ResetLVL()
        {
            rapidFireLVL = 0;
        }
    }

    public class MorePellets : Upgrade
    {
        private static int id = 8;
        private static int morePelletsLVL = 0;
        private static int morePelletsMaxLVL = 5;

        public MorePellets()
        {
            spriteName = "MorePellets";
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

        public override void UpdateTitle()
        {
            title = "More Pellets LVL " + (morePelletsLVL + 1);
        }

        public override void ResetLVL()
        {
            morePelletsLVL = 0;
        }
    }

    public class IncreaseSpread : Upgrade
    {
        private static int id = 9;
        private static int increaseSpreadLVL = 0;
        private static int increaseSpreadMaxLVL = 5;

        public IncreaseSpread()
        {
            spriteName = "IncreaseSpread";
            title = "Increase Spread LVL " + (increaseSpreadLVL + 1);
            description = "Spread +20%";
        }

        public override void Execute()
        {
            increaseSpreadLVL++;

            ShootingController.spreadAngle += (0.2f * ShootingController.spreadAngle);
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

        public override void UpdateTitle()
        {
            title = "Increase Spread LVL " + (increaseSpreadLVL + 1);
        }

        public override void ResetLVL()
        {
            increaseSpreadLVL = 0;
        }
    }

    public class FireRate : Upgrade
    {
        private static int id = 10;
        private static int fireRateLVL = 0;
        private static int fireRateMaxLVL = 5;

        public FireRate()
        {
            spriteName = "FireRate";
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

        public override void UpdateTitle()
        {
            title = "Fire Rate LVL " + (fireRateLVL + 1);
        }

        public override void ResetLVL()
        {
            fireRateLVL = 0;
        }
    }

    public class AmmoReserve : Upgrade
    {
        private static int id = 11;
        public static int ammoReserveLVL = 0;
        private static int ammoReserveMaxLVL = 5;

        public AmmoReserve()
        {
            spriteName = "AmmoReserve";
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

        public override void UpdateTitle()
        {
            title = "Ammo Reserve LVL " + (ammoReserveLVL + 1);
        }

        public override void ResetLVL()
        {
            ammoReserveLVL = 0;
        }
    }

    public class Curse : Upgrade
    {
        private static int id = 12;
        private static int curseLVL = 0;
        private static int curseMaxLVL = 1;

        public Curse()
        {
            spriteName = "Curse";
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

        public override void ResetLVL()
        {
            curseLVL = 0;
        }
    }

    public class DualWielding : Upgrade
    {
        private static int id = 13;
        private static int dualWieldingLVL = 0;
        private static int dualWieldingMaxLVL = 1;

        public DualWielding()
        {
            spriteName = "DualWielding";
            title = "Dual Wielding";
            description = "x2 max ammo, x2 fire rate, removes rapid fire";
        }

        public override void Execute()
        {
            RapidFire.Undo();
            UpgradeOptionController.RemoveSelectedOption(7);

            dualWieldingLVL++;

            ShootingController.ammo = ShootingController.ammo * 2;
            ShootingController.currentAmmo = ShootingController.ammo;

            ShootingController.timeBetweenFiring = (ShootingController.timeBetweenFiring / 2f);
        }

        public override int GetID()
        {
            return id;
        }

        public override int GetLVL()
        {
            return dualWieldingLVL;
        }

        public override int GetMaxLVL()
        {
            return dualWieldingMaxLVL;
        }

        public override void ResetLVL()
        {
            dualWieldingLVL = 0;
        }
    }

    public class ExtraSupplies : Upgrade
    {
        private static int id = 14;
        private static int extraSuppliesLVL = 0;
        private static int extraSuppliesMaxLVL = 1;

        public ExtraSupplies()
        {
            spriteName = "ExtraSupplies";
            title = "Extra Supplies";
            description = "-30% movement speed, x2 max ammo, +50% max health";
        }

        public override void Execute()
        {
            extraSuppliesLVL++;

            ShootingController.ammo = ShootingController.ammo * 2;
            ShootingController.currentAmmo = ShootingController.ammo;

            PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();

            player.moveSpeed -= (player.GetBaseMoveSpeed() * 0.3f);

            int healthGain = (int)(player.GetPlayerBaseHealth() * 0.5f);

            player.playerMaxHealth += healthGain;

            player.playerHealth += healthGain;
        }

        public override int GetID()
        {
            return id;
        }

        public override int GetLVL()
        {
            return extraSuppliesLVL;
        }

        public override int GetMaxLVL()
        {
            return extraSuppliesMaxLVL;
        }

        public override void ResetLVL()
        {
            extraSuppliesLVL = 0;
        }
    }

    public class Penetration : Upgrade
    {
        private static int id = 15;
        public static int penetrationLVL = 0;
        public static int penetrationMaxLVL = 2;

        public Penetration()
        {
            spriteName = "Penetration";
            title = "Penetration LVL " + (penetrationLVL + 1);
            description = "Bullet penetration +1";
            BulletController.penetration = 0;
        }

        public override void Execute()
        {
            penetrationLVL++;

            BulletController.penetration++;
        }

        public override int GetID()
        {
            return id;
        }

        public override int GetLVL()
        {
            return penetrationLVL;
        }

        public override int GetMaxLVL()
        {
            return penetrationMaxLVL;
        }

        public override void UpdateTitle()
        {
            title = "Penetration LVL " + (penetrationLVL + 1);
        }

        public override void ResetLVL()
        {
            penetrationLVL = 0;
        }
    }

    public class DoublePellets : Upgrade
    {
        private static int id = 16;
        public static int doublePelletsLVL = 0;
        public static int doublePelletsMaxLVL = 1;

        public DoublePellets()
        {
            spriteName = "DoublePellets";
            title = "Double Pellets";
            description = "x2 pellets";
        }

        public override void Execute()
        {
            doublePelletsLVL++;

            ShootingController.pellets *= 2;
        }

        public override int GetID()
        {
            return id;
        }

        public override int GetLVL()
        {
            return doublePelletsLVL;
        }

        public override int GetMaxLVL()
        {
            return doublePelletsMaxLVL;
        }

        public override void ResetLVL()
        {
            doublePelletsLVL = 0;
        }
    }
}
