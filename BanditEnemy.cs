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


        protected string[] banditNames = { "Barret Black Lung", "Gerard the Fool", "Thorburn the Hunter", "Ravi Rebel", 
                                            "Irving Three Toes", "Roberto Grimm", "Sawyer Serpent", "Roy Smiley", "Carlos Hawkeye", 
                                            "Steve the Serpent", "Mad Man Milton", "Cyrus Razor", "Brandon Bulletproof", "Alex the Liar", 
                                            "Dwayne the Brute", "Reginald the Shark", "Holden the Devil", "Newton Smiley", 
                                            "Terris Bullseye", "Hyatt Witty", "Jagger Blowhard" };
        protected string banditName;
        public string BanditName
        {
            get { return banditName; }
        }

        protected string[] banditInsults = { "Have at you then!", "Who are you?", "You dare you desecrate this place!", "You won't get past me!", "You're as good as dead!",
                                            "I'll have your head!", "You'll never make it out of here alive.", "Your mother was a hamster and your father smelled of elderberries!",
                                            "I'll kill you!", "Get Out!", "Get fucked bahd!", "That's it, you're dead!", "I'll mount your skull on my mantle!"};




        public BanditEnemy()
        {
            banditName = banditNames[banditRandom.Next(banditNames.Length)];
            banditweapon = banditWeaponChoices[banditRandom.Next(banditWeaponChoices.Length)];
            banditWeaponDamage = banditRandom.Next(0, 4);
            health = banditRandom.Next(10, 16);
            toughness = banditRandom.Next(0, 4);
            strength = banditRandom.Next(0, 4);

            Console.WriteLine($"There is a bandit in the room named {banditName}. He points at you and says {banditInsults[banditRandom.Next(banditInsults.Length)]}.");
        }




    }
}
