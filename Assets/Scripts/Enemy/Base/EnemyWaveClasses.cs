using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Waves{

    public class Wave{
        public int bombChance;
        public int treasureChance;
        public int gunslinger1Chance;
        public int gunslinger2Chance; 
        public int gunslinger3Chance;
        public int slime1Chance; 
        public int slime2Chance;
        public int slime3Chance;
    }

    public class Wave1 : Wave{
        public Wave1()
        {
            bombChance = 0;
            treasureChance = 5;
            gunslinger1Chance = 20;
            gunslinger2Chance = 0;
            gunslinger3Chance = 0;
            slime1Chance = 65;
            slime2Chance = 10;
            slime3Chance = 0;
        }
    }

    public class Wave2 : Wave{
        public Wave2()
        {
            bombChance = 2;
            treasureChance = 5;
            gunslinger1Chance = 35;
            gunslinger2Chance = 8;
            gunslinger3Chance = 0;
            slime1Chance = 10;
            slime2Chance = 40;
            slime3Chance = 0;
        }
    }

    public class Wave3 : Wave{
        public Wave3()
        {
            bombChance = 2;
            treasureChance = 5;
            gunslinger1Chance = 20;
            gunslinger2Chance = 30;
            gunslinger3Chance = 0;
            slime1Chance = 0;
            slime2Chance = 40;
            slime3Chance = 3;
        }
    }

    public class Wave4 : Wave{
        public Wave4()
        {
            bombChance = 5;
            treasureChance = 5;
            gunslinger1Chance = 0;
            gunslinger2Chance = 25;
            gunslinger3Chance = 15;
            slime1Chance = 0;
            slime2Chance = 30;
            slime3Chance = 20;
        }
    }

    public class Wave5 : Wave{
        public Wave5()
        {
            bombChance = 5;
            treasureChance = 5;
            gunslinger1Chance = 0;
            gunslinger2Chance = 5;
            gunslinger3Chance = 40;
            slime1Chance = 0;
            slime2Chance = 5;
            slime3Chance = 40;
        }
    }
}
