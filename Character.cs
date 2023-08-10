 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textGameMaybe
{
    internal class Character
    {
        //vars for ALL characters
        protected int health;
        protected int strength;
        protected int toughness;
        protected int numberOfAttacks;
        protected int speed;
        protected int armour;
        protected int weaponDamage;



        public int Health
        {
            get { return health; }

            set 
            {
                if (value < 0)
                {
                    value = 0;
                }
                health = value;
            }
        }

        public int Strength
        { 
            get { return strength; }
        }

        public int Toughness
        { 
            get { return strength; }
        }

        public int NumberOfAttacks
        {
            get { return numberOfAttacks; }
            set { numberOfAttacks = value; }
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public int Armour
        {
            get { return armour; }
            set { armour = value; }
        }


        public Character()
        {
            health = 0;
        }

        public Character(int h, int s, int t)
        {
            health = h;
            strength = s;
            toughness = t;
        }


    }
}
