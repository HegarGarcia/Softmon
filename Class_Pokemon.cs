using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softmon
{
    class Pokemon
    {
        
        protected string name;
        protected string type;
        protected int level;

        protected int attack;
        protected int defence;
        protected int health;
        protected int speed;

        public float Attack(Pokemon defender)
        {
            float levelDamage = ((2 * this.level) / 5) + 2;
            float modifier = Effectiveness(defender.type);
            float attackVsDefence = this.attack / defender.defence;

            return ((levelDamage * attackVsDefence) / 50 + 2) * modifier;
        }

        public string Name => this.name;
        public string Type => this.type;
        public int Level => this.level;

        //Normal, Fire, Water, Ground, Flying
        private float Effectiveness(string dType)
        {
            switch (this.type)
            {
                case "normal":
                case "flying":
                    return 1;
                case "fire":
                    switch (dType)
                    {
                        case "normal":
                        case "ground":
                        case "flying":
                            return 1;
                        case "water":
                        case "fire":
                            return 0.5f;
                        default:
                            return 1;
                    }
                case "water":
                    switch (dType)
                    {
                        case "ground":
                        case "fire":
                            return 2;
                        case "normal":
                        case "flying":
                            return 1;
                        case "water":
                            return 0.5f;
                        default:
                            return 1;
                    }
                case "ground":
                    switch (dType)
                    {
                        case "fire":
                            return 2;
                        case "normal":
                        case "water":
                        case "ground":
                            return 1;
                        case "flying":
                            return 0;
                        default:
                            return 1;
                    }
                default:
                    return 1;
            }
        }
    }
}
