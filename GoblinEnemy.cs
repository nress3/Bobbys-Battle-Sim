using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textGameMaybe
{
    internal class GoblinEnemy : Character
    {
        Random goblinRandom = new Random();

        private string[] goblinNameOptions = { "Ooga", "Booga", "Jurgun", "Huron", "Lemour", "Knackjer", "groghun",
                                                "shream",  "hiccup", "Gricket", "havor", "Bargelow", "gregor", "Meshawk",
                                                "Pronglin", "Gurgle", "Yerugli", "Deez"};
        private string goblinName;
        public string GoblinName
        {
            get { return goblinName; }
        }

        private string[] goblinWeaponChoices = { "crude bow", "jagged knife", "spear", "stone sword"};
        private string goblinWeapon;
        public string GoblinWeapon
        {
            get { return goblinWeapon; }
        }

        private string[] goblinActions = { "approaches you and bears his teeth", "stands and readies his weapon", "drags his weapon accross the ground as he runs at you",
                                            "flicks you off", "bares his teeth", "charges you", "calls you a bum", "punds his chest", "catcalls you", "scratches the wall with his sharp claws"};


        public GoblinEnemy()
        {
            goblinWeapon = goblinWeaponChoices[goblinRandom.Next(goblinWeaponChoices.Length)];
            goblinName = goblinNameOptions[goblinRandom.Next(goblinNameOptions.Length)];
            health = goblinRandom.Next(9, 13);
            toughness = goblinRandom.Next(1, 4);
            strength = goblinRandom.Next(1, 3);

            Console.WriteLine($"A goblin named {GoblinName} is in the room. He {goblinActions[goblinRandom.Next(goblinActions.Length)]}.");
        }



    }
}
