using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

// PLEASE GOD COMMENT THIS
// whatever the fuck you want boss - this is showing how to merge
// i'm sorry i think i broke it

namespace textGameMaybe
{
    internal class PlayerCharacter : Character
    {
        Random playerRoll = new Random();
        private string playerWeapon;
        public string PlayerWeapon
        {
            get { return playerWeapon; }
        }
        private string playerName;
        public string PlayerName
        {
            get { return playerName; }
        }
        protected string playerClass = "";
        private string[] playerClasses = { "priest", "marauder", "bard" };
        private string[] classAbilities = { "heal one d20 health", "triple attack", "enemy can't attack for two turns" };
        private string[] weaponChoices = { "mace", "rapier", "sword & shield", "club", "dual knives" };
        private string[] weaponRequirements = { "\t\tmin strength: 6\t\tspeed: -5\tdamage: +7", 
                                                "\t\tmin strength: 3\t\tspeed: +5\tdamage: +3", 
                                                "\tmin strength: 3\t\tspeed: -1\tdamage: +4", 
                                                "\t\tmin strength: 5\t\tspeed: -3\tdamage: +5", 
                                                "\tmin strength: 1\t\tspeed: +7\tdamage: +2"};

        public PlayerCharacter()
        {
            EnterName();
            StatsRoll();
            ClassSelect();
            WeaponSelection();
        }


        protected void WeaponSelection()
        {
            Console.WriteLine("Choose your weapon from the list below:");
            Console.WriteLine("Each weapon has a required strength to weild, will modify your speed attribute, and will give a damage boost for each attack.");
            for (int i = 0; i < weaponChoices.Length; i++) 
            {
                Console.WriteLine($"{i + 1}: {weaponChoices[i]} -- {weaponRequirements[i]}");
            }

            bool success = false;
            do
            {
                Console.WriteLine("Type the number of your choice and press enter.");
                string readResponse = Console.ReadLine();
                if (readResponse != "")
                {
                    success = int.TryParse(readResponse, out int weaponChoice);
                    switch (weaponChoice)
                    {
                        case 1:
                            if (strength >= 6)
                            {
                                playerWeapon = weaponChoices[weaponChoice - 1];
                            }
                            else
                            {
                                Console.WriteLine($"You are not strong enough to weild the {weaponChoices[weaponChoice - 1]}.\nThis weapon requires strength 6. You have strength {strength}.");
                                Console.ReadLine();
                                success = false;
                            }
                            break;

                        case 2:
                            if (strength >= 3)
                            {
                                playerWeapon = weaponChoices[weaponChoice - 1];
                            }
                            else
                            {
                                Console.WriteLine($"You are not strong enough to weild the {weaponChoices[weaponChoice - 1]}.\nThis weapon requires strength 3. You have strength {strength}.");
                                Console.ReadLine();
                                success = false;
                            }
                            break;

                        case 3:
                            if (strength >= 3)
                            {
                                playerWeapon = weaponChoices[weaponChoice - 1];
                            }
                            else
                            {
                                Console.WriteLine($"You are not strong enough to weild the {weaponChoices[weaponChoice - 1]}.\nThis weapon requires strength 3. You have strength {strength}.");
                                Console.ReadLine();
                                success = false;
                            }
                            break;

                        case 4:
                            if (strength >= 5)
                            {
                                playerWeapon = weaponChoices[weaponChoice - 1];
                            }
                            else
                            {
                                Console.WriteLine($"You are not strong enough to weild the {weaponChoices[weaponChoice - 1]}.\nThis weapon requires strength 5. You have strength {strength}.");
                                Console.ReadLine();
                                success = false;
                            }
                            break;

                        case 5:
                            playerWeapon = weaponChoices[weaponChoice - 1];
                            break;

                        default:
                            success = false;
                            break;

                    }
                }

            } while (success == false);



            Console.WriteLine($"You chose the {playerWeapon}.");
            Console.ReadLine(); 
        }


        private void  EnterName()
        {
            string readResponse = "";

            do
            {
                Console.WriteLine($"Type the name you'd like to be called and press enter.");

                readResponse = Console.ReadLine();

                if (readResponse != "")
                {
                    playerName = readResponse;
                }

            } while (readResponse == "");



            Console.WriteLine($"Okay, for the duration of the game you will be referred to as {playerName}.");
            Console.ReadLine();
        }

        private void ClassSelect()
        {
            string readResponse = "";

            Console.WriteLine("Choose your class from the list below.");
            Console.WriteLine("Each class has it's own special ability that can be used 3 times each game.\n");

            for (int i = 0; i < playerClasses.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {playerClasses[i]} - {classAbilities[i]}");
            
            }

            bool success = false;
            do
            {
                int result = 0;
                Console.WriteLine("Type the number of your choice and press enter.");
                readResponse = Console.ReadLine();
                if (readResponse != "")
                {
                    success = int.TryParse(readResponse, out result);
                }
                else continue;

                switch (result)
                {
                    case 1:
                        playerClass = playerClasses[result - 1];
                        break;
                    case 2:
                        playerClass = playerClasses[result - 1];
                        break;
                    case 3:
                        playerClass = playerClasses[result - 1];
                        break;
                    default:
                        success = false;
                        continue;
                
                }

            } while (success == false);

            Console.WriteLine($"You chose the {playerClass} class.\n");
            Console.ReadLine();

        }

        private void StatsRoll()
        {
            Console.WriteLine("To Begin you will roll d10's for your base stats, strength, toughness, and speed.\n");
            Console.WriteLine("These stats will have an effect on what weapons and armour you can wear and weild - will you be strong or tough enough to use them?");
            Console.WriteLine("In turn, these weapons and armour will increase or decrease your speed.\n");
            Console.WriteLine("All of these stats together will affect how you do in combat once you enter your chosen dungeon.");

            string readResponse;
            do
            {
                Console.WriteLine("Type 'roll' and press enter to roll for your stats.");
                readResponse = Console.ReadLine();

                if (readResponse.ToLower() == "roll")
                {
                    strength = playerRoll.Next(1, 11);
                    toughness = playerRoll.Next(1, 11);
                    speed = playerRoll.Next(1, 11);

                    Console.WriteLine($"You rolled:\nStrength: {strength}\nToughness: {toughness}\nSpeed: {speed}");
                    Console.ReadLine();
                }

            } while (readResponse.ToLower() != "roll");
        
        }

    }
}
