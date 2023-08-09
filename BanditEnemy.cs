using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textGameMaybe
{
    internal class BanditEnemy : Character
    {
        Random banditRandom = new Random();
        public string banditName = "Bandito Musselini";
        
        public int banditHealthPoints = 15;
        public int banditStrength = 3;
        public int banditToughness = 2;
        public string[] banditWeaponChoices = { "knife", "sword", "club", "ax" };
        public int[] banditWeaponDamageOPtions = { 1, 3, 2, 2 };
        public string banditweapon;
        public int banditWeaponDamage;
    }
}
