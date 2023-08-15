using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textGameMaybe
{
    internal class BossEnemy : Character
    {
        protected string bossName = "";
        public string BossName
        {
            get { return bossName; }
        }
        protected string bossWeapon = "";
        public string BossWeapon
        {
            get { return bossWeapon; }
        }

        private string[] bossTaunts = { "I'll show you the meaning of sorrow", "I'll take everything from you", "There will be no end to your suffering" };
        protected string bossTaunt = "";

        BossEnemy(string dungeonName, Random bossRandom)
        {
            switch (dungeonName)
            {
                case "Dungeon of Dispair":
                    bossName = "The Lord of Dispair";
                    bossWeapon = "The Soul Scythe";
                    bossTaunt = bossTaunts[0];
                    break;

                case "Dungeon of Greed":
                    bossName = "The Taker of all Things";
                    bossWeapon = "The Daggers of Wealth";
                    bossTaunt = bossTaunts[1];
                    break;

                case "Dungeon of Wrath":
                    bossName = "The Cruel One";
                    bossWeapon = "The Mace of Suffering";
                    bossTaunt = bossTaunts[2];
                    break;
            }

            health = bossRandom.Next(125, 175);
            toughness = bossRandom.Next(3, 16);
            strength = bossRandom.Next(3, 16);
            speed = bossRandom.Next(3,13);

            Console.WriteLine($"At the back of the room you see {bossName} on a huge ornate thrown. He stands, grabbing {bossWeapon} as he points to you.");
            Console.WriteLine($"'You dare enter my sanctum?!' He roars as his minions scramble towards you.");
            Console.WriteLine($"'{bossTaunt}!'");
        }

    }
}
