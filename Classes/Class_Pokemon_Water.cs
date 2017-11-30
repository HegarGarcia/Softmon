using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Softmon
{
    public class PokemonWater : Pokemon
    {
        public PokemonWater()
        {
            this.Type = "water";
            this.Level = 1;
            this.MaxHealth = this.Health;
            this.MoveSet[0] = "tackle";
            this.MoveSet[1] = "Water Gun";
        }

        public float Attacking(Pokemon defender)
        {
            float levelDamage = ((2 * this.Level) / 5) + 2;
            float modifier = Effectiveness(defender.Type);
            float attackVsDefence = this.Attack / defender.Defense;
            return ((levelDamage * attackVsDefence) / 50 + 2) * modifier;
        }

        public float SpAttacking(Pokemon defender)
        {
            float levelDamage = ((2 * this.Level) / 5) + 2;
            float modifier = Effectiveness(defender.Type);
            float attackVsDefence = this.Attack / defender.Defense;
            return ((levelDamage * attackVsDefence * this.SpAttack) / 50 + 2) * modifier;
        }

        private float Effectiveness(string dType)
        {
            switch (dType)
            {
                case "grass":
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
        }
    }
}
