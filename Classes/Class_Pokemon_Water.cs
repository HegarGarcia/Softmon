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

        public void Attacking(Pokemon defender)
        {
            float levelDamage = ((2 * this.Level) / 5) + 2;
            float modifier = Effectiveness(defender.Type);
            float attackVsDefence = this.Attack / defender.Defense;
            int damage = (int)(((levelDamage * attackVsDefence) / 50 + 2 + rnd.Next(0, 6)) * modifier);
            defender.Health = (defender.Health - damage <= 0 ? 0 : defender.Health - damage);
        }

        public void SpAttacking(Pokemon defender)
        {
            float levelDamage = ((2 * this.Level) / 5) + 2;
            float modifier = Effectiveness(defender.Type);
            float attackVsDefence = this.Attack / defender.Defense;
            int damage = (int)(((levelDamage * attackVsDefence * this.SpAttack) / 50 + 2 + rnd.Next(0, 6)) * modifier);
            defender.Health = (defender.Health - damage <= 0 ? 0 : defender.Health - damage);
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
