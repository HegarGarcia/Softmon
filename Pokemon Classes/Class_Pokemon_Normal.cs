using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softmon
{
    public class PokemonNormal : Pokemon
    {
        public PokemonNormal() 
        {
            this.Type = "normal";
            MoveSet[0] = "tacle";
            MoveSet[1] = "scratch";
        }

        public int Attacking(Pokemon defender) //Returns damage dealt to the opponent
        {
            //Damage Equation
            float levelDamage = ((2 * this.Level) / 5) + 2;
            float modifier = Effectiveness(defender.Type);
            float attackVsDefence = this.Attack / defender.Defense;
            return (int) (((levelDamage * attackVsDefence) / 50 + 2) * modifier);
        }



        private float Effectiveness(string dType) => 1f; //Returns Damage modifier based in Pokemon Type

        
    }
}
