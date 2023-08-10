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
        protected string headBanditName = "Bandito Musselini";
        public string HeadBandit
        { 
            get { return headBanditName; }
        }

 

        protected string[] banditWeaponChoices = { "knife", "sword", "club", "ax" };
        protected string banditweapon;
        protected int banditWeaponDamage;


        BanditEnemy()
        {
            banditweapon = banditWeaponChoices[banditRandom.Next(banditWeaponChoices.Length)];
            banditWeaponDamage = banditRandom.Next(0, 4);
            health = banditRandom.Next(10, 16);
            toughness = banditRandom.Next(0, 4);
            strength = banditRandom.Next(0, 4);
            

        }






    }
}
