using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Grit
{
    public class Grit
    {
        public static int gritLVL = 0;
        public static Sprite sprite;
        private string title;
        private string description;

        public Grit()
        {
            gritLVL++;
            title = "Grit LVL " + gritLVL;
        }

        public void Upgrade()
        {
            PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();
        }
    }
}
