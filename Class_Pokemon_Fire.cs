using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softmon
{
    class PokemonFire : Pokemon
    {
        public float Attacking(Pokemon defender)
        {
            float levelDamage = ((2 * this.Level) / 5) + 2;
            float modifier = Effectiveness(defender.Type);
            float attackVsDefence = this.Attack / defender.Defence;
            return ((levelDamage * attackVsDefence) / 50 + 2) * modifier;
        }

        private float Effectiveness(string dType)
        {
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
        }   
    }
}
