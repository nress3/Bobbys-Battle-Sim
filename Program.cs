using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace textGameMaybe
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*objectives: 1v1 battle sim with two "automated" characters. ask player for a name, make attributes for it, give random values, 
             * and giove the second character random values. then make them fight.
             * HARD VERSION: making the characters have two or three attacks and the player can pick one.*/


            /* intializing global statistics + variables:

            
            Random dice = new Random();
            bool success = false;

            string playerName = "";
            string dungeonName = "";
            string bossName = "";
            string treasureName = "";
            string playerArmourName = "";
            string playerWeaponName = "";
            string attackSelection = "";
            int bossStrength = dice.Next(1, 4);
            int playerStrength = dice.Next(1, 7);
            int playerToughness = dice.Next(1, 7);
            int playerArmourBonus = 0;
            int playerWeaponBonus = 0;
            int playerSpeed = 12;
            int bossArmour = dice.Next(3, 10);
            int bossSpeed = 15;
            int playerHealth = 100;
            int bossHealth = 150;
            bool dead = false;
            bool newGame = false;



            Console.WriteLine("Hello. Welcome to Bobby's Battle Sim.");
            Console.WriteLine("Press enter to begin");
            Console.ReadLine();
            Console.Clear();


            do
            {
                Console.WriteLine("Enter your name as you'd like to be referred to throughout the game.");
                playerName = Console.ReadLine();

                if (playerName != "")
                {
                    Console.Clear();
                    Console.WriteLine($"Welcome, {playerName}. In this short game you will be fighting a boss in a dungeon to get to a fancy treasure.");
                }
            } while (playerName == "");

            Console.Clear();
            Console.WriteLine($"Now, {playerName}, let's give you some stats. To do so we will roll dice.");
            Console.WriteLine($"You will have two stats, STRENGTH and TOUGHNESS.");
            Console.WriteLine("Each of these stats will be a number between one and six according to what you roll.");
            Console.WriteLine("Strength will be a number added to your attack roll. Toughness will be a number deducted from your opponent's attack roll.");
            Console.WriteLine("Press enter to roll");
            Console.ReadLine();
            Console.Clear();


            Console.WriteLine($"You rolled {playerStrength} for your strength stat.");
            if (playerStrength == 6)
            {
                Console.WriteLine("You're jacked out of your mind and will be able to effectively use heavy weapons.");
            }
            else if (playerStrength <= 2)
            {
                Console.WriteLine("You're rather weak and should hope you rolled well on your toughness roll.");
            }
            else
            {
                Console.WriteLine("you're of medium strength. You will be able to fight well.");
            }

            Console.WriteLine($"You rolled {playerToughness} for your toughness stat.");
            if (playerToughness == 6)
            {
                Console.WriteLine("You're a hearty warrior.");
            }
            else if (playerToughness <= 2)
            {
                Console.WriteLine("You're not very tough.");
            }
            else
            {
                Console.WriteLine("You're of normal toughness.");
            }
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Now that you have your stats, you will choose your weapon and armour before entering the dungeon.");
            Console.WriteLine("Weapons and armour have their own stats which will be explained as you choose.");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("First, choose your armour.");
            Console.WriteLine("Armour has two stats: PROTECTION and SPEED. The more protection your armour has the more damage it will negate, but the slower your character will attack.");
            Console.WriteLine("The more speed your armour has the faster you will move, so you will often hit the enemy first. However, you will have less protection from its blows.");
            Console.WriteLine("Finally, armour with higher protection will require a higher toughness to wear, so if you rolled poorly above you may not be able to wear certain items.");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("ARMOUR OPTIONS:\n");
            Console.WriteLine("1. PLATE ARMOUR:\tSPEED (-3) // PROTECTION (+7) // Minimum Toughness: (5)");
            Console.WriteLine("2. CHAINMAIL ARMOUR:\tSPEED (+1) // PROTECTION (+4) // No Minimum Toughness");
            Console.WriteLine("3. LEATHER ARMOUR:\tSPEED (+5) // PROTECTION (+1) // No Minimum Toughness");
            Console.WriteLine();


            do
            {
                Console.WriteLine("Type your armour choice and press enter.");
                string armourSelect = Console.ReadLine();
                int armourChoice;
                success = false;
                success = int.TryParse(armourSelect, out armourChoice);

                switch (armourChoice)
                {
                    case 1:
                        playerArmourName = "Plate Armour";
                        playerSpeed -= 3;
                        playerArmourBonus += 7;
                        if (playerToughness < 5)
                        {
                            Console.WriteLine("You are not tough enough to wear this armour.");
                            success = false;
                        }
                        break;

                    case 2:
                        playerArmourName = "Chainmail Armour";
                        playerSpeed += 1;
                        playerArmourBonus += 4;
                        break;

                    case 3:
                        playerArmourName = "Leather Armour";
                        playerSpeed += 5;
                        playerArmourBonus += 1;
                        break;

                    default:
                        success = false;
                        break;

                }
            } while (success == false);

            Console.Clear();
            Console.WriteLine($"You chose {playerArmourName}.");
            Console.WriteLine("Next, you will choose your weapon.");
            Console.ReadLine();

            //add weapon system
            Console.Clear();
            Console.WriteLine("Weapons have two stats: SPEED and DAMAGE.\nThe Damage stat of your weapon will be added to your attacks, but your weapon will be slower.");
            Console.WriteLine("The Speed stat will help you hit the enemy faster but you may do less damage at a time.");
            Console.WriteLine("Finally, some weapons have a minimum STRENGTH requirement. If you do not meed this requirement you will be unable to use the weapon.");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("WEAPON OPTIONS:\n");
            Console.WriteLine("1. DAGGER:\tSPEED (+5) // DAMAGE (+1) // No Minimum Strength");
            Console.WriteLine("2. AX:\t\tSPEED (+2) // DAMAGE (+3) // No Minimum Strength");
            Console.WriteLine("3. HAMMER:\tSPEED (-3) // DAMAGE (+6) // Minimum Strength: (5)");
            Console.WriteLine();
            do
            {
                Console.WriteLine("Type your weapon choice and press enter.");
                string weaponSelect = Console.ReadLine();
                int weaponChoice;
                success = false;
                success = int.TryParse(weaponSelect, out weaponChoice);

                switch (weaponChoice)
                {
                    case 1:
                        playerWeaponName = "Dagger";
                        playerSpeed += 5;
                        playerWeaponBonus = 1;
                        break;

                    case 2:
                        playerWeaponName = "Ax";
                        playerSpeed += 2;
                        playerWeaponBonus += 3;
                        break;

                    case 3:
                        playerWeaponName = "Hammer";
                        playerSpeed -= 3;
                        playerWeaponBonus += 6;

                        if (playerStrength < 5)
                        {
                            Console.WriteLine("You are not strong enough to carry this weapon.");
                            success = false;
                        }
                        break;

                    default:
                        success = false;
                        break;
                }
            } while (success == false);


            Console.Clear();
            Console.WriteLine($"You chose {playerWeaponName}.");
            Console.WriteLine("Good luck on your adventure");
            Console.ReadLine();
            Console.Clear();





            Console.WriteLine($"Now that you have your stats you must choose which dungeon to enter. Each dungeon has a different enemy and a different treasure");

            do
            {

                Console.WriteLine("You may choose between the 1. FIRE DUNGEON, the 2. SPIRIT DUNGEON, or the 3. DARKNESS DUNGEON");
                Console.WriteLine();


                do
                {
                    Console.WriteLine("Select the number of the dungeon you'd like to explore and press enter.");
                    string dungeonSelect = Console.ReadLine();
                    int dungeonChoice;
                    success = false;
                    success = int.TryParse(dungeonSelect, out dungeonChoice);

                    switch (dungeonChoice)
                    {
                        case 1:
                            dungeonName = "The Fire Dungeon";
                            bossName = "Fire Demon";
                            treasureName = "The Sword of Flame";
                            break;

                        case 2:
                            dungeonName = "The Spirit Dungeon";
                            bossName = "The Spirit Wrangler";
                            treasureName = "The Spirit Blade";
                            break;

                        case 3:
                            dungeonName = "The Darkness Dungeon";
                            bossName = "The Lord of Darkness";
                            treasureName = "The Black Sword";
                            break;

                        default:
                            success = false;
                            break;
                    }
                } while (success == false);

                Console.Clear();
                Console.WriteLine($"You chose to fight {bossName} in {dungeonName}. Good Luck!");
                Console.ReadLine();
                Console.Clear();


                do
                {
                    // playerSwing = dice.Next(21) + playerStrength + playerWeaponBonus - bossArmour;
                    // bossSwing = (dice.Next(21) + bossStrength) - (playerToughness + playerArmourBonus);
                    int playerSwing = 0;
                    int bossSwing = 0;

                    int bossAttackChoice = (dice.Next(6));
                    switch (bossAttackChoice)
                    {
                        case 0 - 2:
                            bossSwing = (dice.Next(21) + bossStrength) - (playerToughness + playerArmourBonus);
                            Console.WriteLine($"{bossName} used Basic Attack with {treasureName}!");
                            if (bossSwing <= 0)
                            {
                                bossSwing = 0;
                                Console.WriteLine($"{bossName}'s attack missed!");
                            }
                            else
                            {
                                Console.WriteLine($"{bossName} hit {playerName} for {bossSwing} damage." +
                                    $"\n{playerName} now has {playerHealth -= bossSwing} health remaining.");
                            }

                            break;


                        case 3 - 4:
                            Console.WriteLine($"{bossName} used Double Attack with {treasureName}!");
                            int attackCounter = 0;
                            string attackNumber = "";


                            if (bossSpeed + dice.Next(1, 10) >= 19)
                            {
                                do
                                {
                                    attackCounter++;
                                    if (attackCounter == 1)
                                    {
                                        attackNumber = "first";
                                    }
                                    else if (attackCounter == 2)
                                    {
                                        attackNumber = "second";
                                    }

                                    bossSwing = (dice.Next(21) + bossStrength) - (playerToughness + playerArmourBonus);

                                    if (bossSwing <= 0)
                                    {
                                        bossSwing = 0;
                                        Console.WriteLine($"{bossName}'s {attackNumber} attack missed!");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{bossName}'s {attackNumber} hit {playerName} for {bossSwing} damage." +
                                            $"\n{playerName} now has {playerHealth -= bossSwing} health remaining.");
                                    }

                                } while (attackCounter < 2);
                            }
                            else 
                            {
                                Console.WriteLine($"{bossName} wasn't fast enough to attack twice! Only one attack landed.");
                                bossSwing = ((dice.Next(21) + bossStrength) - (playerToughness + playerArmourBonus));
                                if (bossSwing <= 0)
                                {
                                    bossSwing = 0;
                                    Console.WriteLine($"{bossName}'s attaack missed!");
                                }
                                else 
                                {
                                    Console.WriteLine($"{bossName}'s attack hit {playerName} for {bossSwing} damage.\n" +
                                        $"{playerName} now has {playerHealth -= bossSwing} health remaining.");
                                }
                            }
                           
                            break;


                        case 5:
                            Console.WriteLine($"{bossName} used block! You won't be able to damage it next turn");

                            break;


                    }

                    do
                    {
                        Console.WriteLine("Choose your move:");
                        Console.WriteLine("1. Basic Attack\n2. Double Attack\n3. Block");
                        attackSelection = Console.ReadLine();
                        int attackChoice;
                        success = false;
                        success = int.TryParse(attackSelection, out attackChoice);

                        switch (attackChoice)
                        {
                            case 1:
                                playerSwing = dice.Next(21) + playerStrength + playerWeaponBonus - bossArmour;

                                if (playerSwing <= 0)
                                {
                                    playerSwing = 0;
                                    Console.WriteLine($"{playerName}'s attack missed!");
                                }
                                else 
                                {
                                    Console.WriteLine($"{playerName} used Basic Attack with their {playerWeaponName}!");
                                    Console.WriteLine($"{playerName} did {playerSwing} damage to {bossName}.\n" +
                                        $"{bossName} now has {bossHealth -= playerSwing} health remaining.");
                                }

                                success = true;
                                break;




                            case 2:
                                Console.WriteLine($"{playerName} used Double Attack with their {playerWeaponName}!");
                                int attackCounter = 0;
                                string attackNumber = "";

                                if ((playerSpeed + dice.Next(7)) >= 18)
                                {
                                    do
                                    {
                                        attackCounter++;
                                        playerSwing = dice.Next(21) + playerStrength + playerWeaponBonus - bossArmour;

                                        if (attackCounter == 1)
                                        {
                                            attackNumber = "first";
                                        }
                                        else if (attackCounter == 2)
                                        {
                                            attackNumber = "second";
                                        }

                                        Console.WriteLine($"{playerName}'s {attackNumber} attack hit {bossName} for {playerSwing} damage!\n" +
                                            $"{bossName} now has {bossHealth - playerSwing} health remaining.");


                                    } while (attackCounter < 2);
                                }
                                else 
                                {
                                    Console.WriteLine($"{playerName} wasn't fast enough to attack twice! Only one attack landed");
                                    playerSwing =  dice.Next(21) + playerStrength + playerWeaponBonus - bossArmour;
                                    Console.WriteLine($"{playerName}'s attack hit {bossName} for {playerSwing} damage.\n" +
                                        $"{bossName} now has {bossHealth -= playerSwing} health remaining.");
                                }

                                success = true;
                                break;




                            case 3:

                                Console.WriteLine($"{playerName} used block!");

                                success = true;
                                break;

                        }
                    } while (success == false);


                } while ((playerHealth > 0) && (bossHealth > 0));

                if (playerHealth > 0)
                {
                    Console.WriteLine("You Won!");
                    Console.WriteLine($"You got the {treasureName}! You weild the power of the {dungeonName}. POG!\n");
                    dead = false;

                    do
                    {
                        Console.WriteLine("Would you like to enter another dungeon? Enter yes or no");
                        string newGameSelect = Console.ReadLine();
                        success = false;

                        if (newGameSelect.ToLower().Trim() == "yes")
                        {
                            newGame = true;
                            success = true;
                        }
                        else if (newGameSelect.ToLower().Trim() == "no")
                        {
                            newGame = false;
                            success = true;
                            Console.WriteLine("That's a shame, see you next time.");
                        }
                        else
                        {
                            success = false;
                        }

                    } while (success == false);


                }
                else
                {
                    Console.WriteLine("You died! Game Over");
                    dead = true;
                }



            } while (dead == false && newGame == true);

            Console.WriteLine("Thanks for playing Bobby's Battle Sim! Now go donate to me on venmo @nress3");

            */

            Random random = new Random();
            int gold = 0;
            string dungeon = "";
            string boss = "";
            string treasure = "";
            string[] dungeonChoices = { "Dungeon of Dispair", "Dungeon of Greed", "Dungeon of Wrath" };
            string[] bossChoices = { "The Lord of Dispair", "The Taker of all Things", "The Cruel One\t" };
            string[] treasureChoices = { "The Soul Scythe", "The Daggers of Wealth", "The Mace of Suffering" };
            string roomNumber = "";
            int roomNumberCounter = 0;

            BanditEnemy[] banditEnemies;
            GoblinEnemy[] goblinEnemies;







            

            Console.WriteLine("Thank you for playing Bobby's battle sim! Have fun ya freak.");
            PlayerCharacter player = new PlayerCharacter();

            DungeonSelect();

            EnterRoom();

            EnterRoom();




            
            //player selects the dungeon
            void DungeonSelect()
            {
                Console.WriteLine("You can choose one of three dungeons to enter and explore. Each one contains a different boss enemy and treasure. They are listed below.");
                for (int i = 0; i < dungeonChoices.Length; i++)
                {
                    Console.WriteLine($"Dungeon {i + 1}: {dungeonChoices[i]}\t Boss: {bossChoices[i]}\t Treasure: {treasureChoices[i]}");
                }

                bool selectionInRange = false;
                do
                {
                    
                    int dungeonSelection = GetNumberSelection();
                    selectionInRange = true;

                    switch (dungeonSelection) 
                    {
                        case 1:
                            dungeon = dungeonChoices[dungeonSelection - 1];
                            boss = bossChoices[dungeonSelection - 1];
                            treasure = treasureChoices[dungeonSelection - 1];
                            break;
                        case 2:
                            dungeon = dungeonChoices[dungeonSelection - 1];
                            boss = bossChoices[dungeonSelection - 1];
                            treasure = treasureChoices[dungeonSelection - 1];
                            break;
                        case 3:
                            dungeon = dungeonChoices[dungeonSelection - 1];
                            boss = bossChoices[dungeonSelection - 1];
                            treasure = treasureChoices[dungeonSelection - 1];
                            break;
                        default:
                            selectionInRange = false;
                            break;
                    }
                } while (selectionInRange == false);

                Console.WriteLine($"You chose to enter {dungeon} to search for {treasure}. You will have to face {boss} in the end. Good Luck.");
                Console.ReadLine();
            }



            /*
             * enter room %
             * spawn enemies %
             * 
             * Give player options for each turn:
             * choose to attack
             * choose to use a special ability & on who if applicable
             * 
             * for attack: 
             * choose enemy
             * fastest player or enemy goes first
             * potential for multi attack based on speed + random roll
             * damage enemy and take damage
             * 
             * loops back to select menu if player lives and still enemies
             * 
            */

            void Battle()
            {

                do
                {
                    Console.WriteLine("What will you do?");
                    Console.WriteLine("1. Attack an enemy.");
                    Console.WriteLine("2. Use your special ability.");

                    int battleSelection = GetNumberSelection();



                } while (true);







                //int attackerSwing = attackerStrength + random.Next(1, 7) - defenderToughness;

                //defenderHealth -= attackerSwing;

                //Console.WriteLine($"{attacker} did {attackerSwing} damage to {defender}. {defender} now has {defenderHealth}HP remaining.");
                //Console.ReadLine();
                //eventually this will work
            }

            //player enters room, displayes enter room message, maaayyyyybe uses enemy appears method to "spawn" baddies
            void EnterRoom()
            {
                roomNumberCounter++;
                switch (roomNumberCounter)
                {
                    case 1:
                        roomNumber = "first";
                        break;

                    case 2:
                    case 3:
                    case 4:
                        roomNumber = "next";
                        break;

                    case 5:
                        roomNumber = "final";
                        break;
                }
                Console.WriteLine($"You enter the {roomNumber} room of the {dungeon}.");
                EnemyAppears(roomNumberCounter);
                Console.ReadLine();
            }



            //"spawns" baddies
            void EnemyAppears(int a_RoomNumber)
            {

                int maxEnemies = 0;

                switch (a_RoomNumber)
                {
                    case 1:
                        maxEnemies = 2;
                        break;
                    case 2:
                        maxEnemies = 3;
                        break;
                    case 3:
                    case 4:
                        maxEnemies = 4;
                        break;
                    case 5:
                        maxEnemies = 5;
                        break;
                    default:
                        maxEnemies = 50;
                        break;
                }

                goblinEnemies = new GoblinEnemy[random.Next(1, maxEnemies + 1)];

                for (int i = 0; i < goblinEnemies.Length; i++)
                {
                    goblinEnemies[i] = new GoblinEnemy(random);
                }

            }




        }

        //helper method for numerical menu selection
        public static int GetNumberSelection()
        {
            int response = 0;
            string readResponse = "";
            bool success = false;

            do
            {
                Console.WriteLine("Type the number of your selection and press enter.");
                readResponse = Console.ReadLine();

                if (readResponse != "")
                {
                    success = int.TryParse(readResponse, out response);
                }
                else success = false;

            } while (success == false);

            return response;
        }

    }
}



