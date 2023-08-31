using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace textGameMaybe
{
    public class Program
    {
        public string thisString = "hello?";

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
            string[] bossChoices = { "The Lord of Dispair", "The Taker of all Things", "The Cruel One" };
            string[] treasureChoices = { "The Soul Scythe", "The Daggers of Wealth", "The Mace of Suffering" };
            string roomNumber = "";
            int roomNumberCounter = 0;
            int abilityCounter = 3;

            BanditEnemy[] banditEnemies;
            //GoblinEnemy[] goblinEnemies;

            List<GoblinEnemy> enemyGoblins = new List<GoblinEnemy>();

            /*
            List<Character> roomEnemies = new List<Character>();


            Console.WriteLine("writing the list out" + roomEnemies.Count + "," + roomEnemies.Capacity);
            for(int i = 0; i < roomEnemies.Count; i++)
            {
                Console.WriteLine(roomEnemies[i]);
            }

            Character myChar = new Character(5,6,7);

            roomEnemies.Add(myChar);
            roomEnemies.Add(new Character());
            roomEnemies.Add(new Character(1,2,3));
            roomEnemies.Add(new Character());
            roomEnemies.Add(new Character());


            Console.WriteLine("writing the list out, " + roomEnemies.Count + "," + roomEnemies.Capacity);
            for(int i = 0; i < roomEnemies.Count; i++)
            {
                Console.WriteLine(roomEnemies[i]);
            }

            roomEnemies.RemoveAt(2);
            Console.WriteLine("writing the list out, " + roomEnemies.Count + "," + roomEnemies.Capacity);
            for (int i = 0; i < roomEnemies.Count; i++)
            {
                Console.WriteLine(roomEnemies[i]);
            }


            Console.WriteLine("Does the list contain the myChar? " + roomEnemies.Contains(myChar));

            roomEnemies.Remove(myChar);
            Console.WriteLine("writing the list out, " + roomEnemies.Count + "," + roomEnemies.Capacity);
            for (int i = 0; i < roomEnemies.Count; i++)
            {
                Console.WriteLine(roomEnemies[i]);
            }


            Console.WriteLine("Does the list contain the myChar? " + roomEnemies.Contains(myChar));

            Character newChar = new Character(9, 8, 7);
            roomEnemies.Insert(1, newChar); 
            Console.WriteLine("writing the list out, " + roomEnemies.Count + "," + roomEnemies.Capacity);
            for (int i = 0; i < roomEnemies.Count; i++)
            {
                Console.WriteLine(roomEnemies[i]);
            }


            roomEnemies.Clear();
            roomEnemies.Capacity = 0;
            Console.WriteLine("writing the list out, " + roomEnemies.Count + "," + roomEnemies.Capacity);
            for (int i = 0; i < roomEnemies.Count; i++)
            {
                Console.WriteLine(roomEnemies[i]);
            }


            //returns the list as an array but you still have access to the list
            Character[] myCharArray = roomEnemies.ToArray();
            Console.WriteLine(myCharArray.Length);
            */


            

            Console.WriteLine("Thank you for playing Bobby's battle sim! Have fun ya freak.");
            PlayerCharacter player = new PlayerCharacter();

            DungeonSelect();

            // what da heeeeeeeeek
            // i mean you can just use a for loop here no? or a while loopbased on player health? 
            // :)  -- thinking that at the very end i will create a method called "gameplay" or something that will be the whole game.

            EnterRoom();

            Battle();

            EnterRoom();

            Battle();

            EnterRoom();

            Battle();

            EnterRoom();

            Battle();

            EnterRoom();




            
            //player selects the dungeon
            void DungeonSelect()
            {
                Console.WriteLine("You can choose one of three dungeons to enter and explore. Each one is said to contain a different treasure.");
                for (int i = 0; i < dungeonChoices.Length; i++)
                {
                    Console.WriteLine($"Dungeon {i + 1}: {dungeonChoices[i]}\tTreasure: {treasureChoices[i]}");
                }

                bool selectionInRange = false;
                do
                {
                    
                    int dungeonSelection = GetNumberSelection();
                    selectionInRange = true; // oh i see, you're setting it here and not in the cases... maybe you should comment these things ...  :)

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
            //this shit doesn't work... might have to start over

            void Battle()//this works except I can't get the loop to end. for some reason number of enemies is not going down when goblins die
            {
                int numberOfEnemies = enemyGoblins.Count;
                do
                {
                    //Console.WriteLine($"number of enemies: {numberOfEnemies}");
                    Console.WriteLine("What will you do?");
                    Console.WriteLine("1. Attack an enemy.");
                    Console.WriteLine("2. Use your special ability.");

                    int battleSelection = GetNumberSelection();
                    
                    switch (battleSelection)// yeah you should probably just use two different methods inside this switch statenment instead of writing out all the code here
                        // like maybe one method per player choice. Just easer to follow here
                    {
                        case 1:

                            player.NumberOfAttacks = 1;

                            int attackChoice = EnemyToAttack();

                            if (player.Speed > (3 * enemyGoblins[attackChoice - 1].Speed)) 
                            {
                                player.NumberOfAttacks = 2;
                                Console.WriteLine($"{player.PlayerName} is fast enough to attack {enemyGoblins[attackChoice - 1].GoblinName} twice!");

                                for (int i = player.NumberOfAttacks; i > 0; i--)
                                {
                                    PlayerSwing(player, enemyGoblins[attackChoice - 1]);
                                    if (enemyGoblins[attackChoice - 1].Dead == true)
                                    {
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                PlayerSwing(player, enemyGoblins[attackChoice - 1]);
                            }


                            //ALL goblins hit back -- DAMN All goblins? this guy it getting fucked XD
                            if (numberOfEnemies > 0)
                            {
                                Console.WriteLine("The goblins fight back!");
                                Console.WriteLine();

                                for (int i = 0; i < enemyGoblins.Count; i++)
                                {
                                    if (enemyGoblins[i].Dead != true)
                                    {
                                        GoblinSwing(enemyGoblins[i], player);
                                    }
                                }
                            }
                            break;

                        case 2:

                            abilityCounter--;
                            if (abilityCounter < 0) // the way this is implemented if the player is out of special attacks he still gets hit by ALL the goblins
                                // not sure if intended but brutal if it was. :)
                            { Console.WriteLine("You have already used your special ability 3 times. You are out of ability uses."); }
                            else 
                            {
                                Console.WriteLine($"You chose to use your ability: {player.PlayerAbility}.");

                                switch (player.PlayerAbility) // please god, just as before, make these all methods. makes life way easier
                                {
                                    case "Revitalize":
                                        int heal = random.Next(5, 20);
                                        player.Health += heal;
                                        Console.WriteLine($"You healed {heal} health. You now have {player.Health} HP.");
                                        Console.ReadLine();
                                        break;

                                    case "Fury":

                                        Console.WriteLine($"You attack your enemies in a flurry of blows with your {player.PlayerWeapon}.");
                                        int attackCounter = 3;

                                        while (attackCounter > 0 && numberOfEnemies > 0)
                                        {
                                            
                                            attackChoice = EnemyToAttack();

                                            PlayerSwing(player, enemyGoblins[attackChoice - 1]);

                                            attackCounter--;
                                            if (numberOfEnemies == 0)
                                            { break; }
                                            Console.WriteLine($"You have {attackCounter} more attacks.");
                                            Console.WriteLine();
                                        }
                                        break;

                                    case "Hypnotize":
                                        //entrance ability goes here. i have no clue how to do this.
                                        // RYE: if you want the enemies to not attack with this, you could just add a field//property called Asleep or something
                                        // and check if they are not asleep before running their attack code
                                        break;

                                }
                            }
                            //ALL goblins hit back
                            if (numberOfEnemies > 0 && abilityCounter >= 0)
                            {
                                Console.WriteLine("The goblins fight back!");
                                Console.WriteLine();

                                for (int i = 0; i < enemyGoblins.Count; i++)
                                {
                                    if (enemyGoblins[i].Dead != true)
                                    {
                                        GoblinSwing(enemyGoblins[i], player);    
                                    }
                                }
                            }
                            break;
                    }

                    numberOfEnemies = enemyGoblins.Count; // fixes the number of enemies loop by checking again what the number is

                } while ((player.Dead == false) && (numberOfEnemies > 0)); // honestly if im comparing integers, i almost always use > or  < instead of == or !=
            }

            //player enters room, displayes enter room message, maaayyyyybe uses enemy appears method to "spawn" baddies
            void EnterRoom()
            {
                roomNumberCounter++;
                switch (roomNumberCounter) // i see, this prints out which room youre entering. 
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
                EnemyAppears(roomNumberCounter); // good use of a separatemethod inside this one!
                Console.ReadLine();
            }


            //"spawns" baddies
            // Good method!! 
            void EnemyAppears(int a_RoomNumber)
            {
                int minEnemies = 0;
                int maxEnemies = 0;

                switch (a_RoomNumber)
                {
                    case 1:
                        minEnemies = 1;
                        maxEnemies = 2;
                        break;
                    case 2:
                        minEnemies = 1;
                        maxEnemies = 3;
                        break;
                    case 3:
                    case 4:
                        minEnemies = 3;
                        maxEnemies = 5;
                        break;
                    case 5:
                        minEnemies = 4;
                        maxEnemies = 6;
                        break;
                    default: // i low key might have led you astray talking about setting a default you can never get to. 
                        // in retrospect i sdont think its really good practice
                        minEnemies = 25;
                        maxEnemies = 50;
                        break;
                }

                for (int i = 0; i < random.Next(minEnemies, maxEnemies + 1); i++)
                {
                    enemyGoblins.Add(new GoblinEnemy(random));
                }
                if (a_RoomNumber == 5)
                {
                    BossEnemy theBoss = new BossEnemy(dungeon, random);
                }

            }

            // you do have the methods, you just gotta plug them in! < 3 easy peasy
            // you might just have to update it based on what your attacks are/can be but hey


            void PlayerSwing(PlayerCharacter playerAttacker, GoblinEnemy enemy)
            {
                int playerSwing = (player.Strength + random.Next(1, 7) + player.WeaponDamage) - enemy.Toughness;
                if (playerSwing <= 0)
                {
                    playerSwing = 0;
                    Console.WriteLine($"{player.PlayerName}'s attack missed!");
                }
                else
                {
                    enemy.Health -= playerSwing;
                    Console.WriteLine($"{player.PlayerName} did {playerSwing} damage to {enemy.GoblinName} with their {player.PlayerWeapon}.");
                    Console.WriteLine($"{enemy.GoblinName} has {enemy.Health} HP remaining.");

                    if (enemy.Health <= 0)
                    {
                        enemy.Dead = true;
                        Console.WriteLine($"{player.PlayerName} killed {enemy.GoblinName}!");
                        enemyGoblins.Remove(enemy);
                        //Console.WriteLine($"enemies within method: {enemiesNumber}"); //this is the source of the bug
                        //Console.WriteLine($"{numberOfEnemies}");
                    }
                }
                Console.ReadLine();
            }

            // this might be easier if you pass in the goblin and access these properties on that object
            void GoblinSwing(GoblinEnemy goblin, PlayerCharacter playerDefender)
            {
                int goblinSwing = (goblin.Strength + random.Next(1,7)) - playerDefender.Toughness;
                if (goblinSwing <= 0)
                {
                    goblinSwing = 0;
                    Console.WriteLine($"{goblin.GoblinName}'s attack missed.");
                }
                else
                {
                    playerDefender.Health -= goblinSwing;
                    Console.WriteLine($"{goblin.GoblinName} did {goblinSwing} damage to {playerDefender.PlayerName} with its {goblin.GoblinWeapon}.");
                    Console.WriteLine($"{playerDefender.PlayerName} has {playerDefender.Health} HP remaining.");

                    if (playerDefender.Health <= 0)
                    {
                        Console.WriteLine($"{playerDefender.PlayerName} died!");
                        playerDefender.Dead = true;
                    }
                }
                Console.ReadLine();
            }


            int EnemyToAttack()
            {
                Console.WriteLine("Which enemy would you like to attack?");

                for (int i = 0; i < enemyGoblins.Count; i++)
                {
                    if (enemyGoblins[i].Dead != true)
                    {
                        Console.WriteLine($"{i + 1}: {enemyGoblins[i].GoblinName}");
                    }
                    else
                    {
                        Console.WriteLine($"{i + 1}: {enemyGoblins[i].GoblinName} is dead. He won't get more dead.");
                    }
                }
                int attackThisGuy = 0;
                bool selectionInRange = false;
                do
                {
                    attackThisGuy = GetNumberSelection();
                    if (attackThisGuy > 0 && attackThisGuy <= enemyGoblins.Count && enemyGoblins[attackThisGuy - 1].Dead == false)
                    { selectionInRange = true; }

                } while (selectionInRange == false);

                return attackThisGuy;
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



