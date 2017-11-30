using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softmon
{
    public class PokemonFire : Pokemon
    {
        public PokemonFire()
        {
            this.Type = "fire";
            this.Level = 1;
            this.MaxHealth = this.Health;
            this.MoveSet[0] = "tackle";
            this.MoveSet[1] = "flamethrower";
        }

        public void Attacking(Pokemon defender)
        {
            float levelDamage = ((2 * this.Level) / 5) + 2;
            float modifier = Effectiveness(defender.Type) + 0.1f;
            float attackVsDefence = this.Attack / defender.Defense;
            int damage = (int)(((levelDamage * attackVsDefence) / 50 + 2 + rnd.Next(1, 8)) * modifier);
            defender.Health = (defender.Health - damage <= 0 ? 0 : defender.Health - damage);
        }

        public void SpAttacking(Pokemon defender)
        {
            float levelDamage = ((2 * this.Level) / 5) + 2;
            float modifier = Effectiveness(defender.Type) + 0.1f;
            float attackVsDefence = this.Attack / defender.Defense;
            int damage = (int)(((levelDamage * attackVsDefence * this.SpAttack) / 50 + 2 + rnd.Next(1, 8)) * modifier);
            defender.Health = (defender.Health - damage <= 0 ? 0 : defender.Health - damage);
        }

        private float Effectiveness(string dType)
        {
            switch (dType)
            {
                case "normal":
                case "grass":
                case "flying":
                    return 1;
                case "water":
                case "fire":
                    return 0.5f;
                default:
                    return 1;
            }
        }   
    }
}
