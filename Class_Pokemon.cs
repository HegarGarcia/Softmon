using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Softmon
{
    [XmlInclude(typeof(PokemonNormal))]
    public class Pokemon
    {
        protected int Id
        {
            get;
            set;
        }

        protected string Name
        {
            get;
            set;
        }

        protected string Type
        {
            get;
            set;
        }

        protected int Level
        {
            get;
            set;
        }

        protected int Attack
        {
            get;
            set;
        }
        protected int Defence
        {
            get;
            set;
        }

        protected int Health
        {
            get;
            set;
        }

        protected int Speed
        {
            get;
            set;
        }

        public float Attacking(Pokemon defender)
        {
            float levelDamage = ((2 * this.Level) / 5) + 2;
            float modifier = Effectiveness(defender.Type);
            float attackVsDefence = this.Attack / defender.Defence;
            return ((levelDamage * attackVsDefence) / 50 + 2) * modifier;
        }

        //Normal, Fire, Water, Ground, Flying
        private float Effectiveness(string dType)
        {
            switch (this.Type)
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
