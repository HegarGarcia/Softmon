using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softmon
{
    public class PokemonNormal : Pokemon
    {
        public PokemonNormal() //Inicializa el pokemon con Nivel, Tipo y Movimientos
        {
            this.Type = "normal";
            this.Level = 1;
            this.MaxHealth = this.Health;
            this.MoveSet[0] = "Tackle";
            this.MoveSet[1] = "Scratch";
        }

        public override void Attacking(Pokemon defender) //Ecuacion de Ataque Normal
        {
            float levelDamage = (float)(((2 * this.Level) / Math.Sqrt((double)30)) + 2);
            float modifier = Effectiveness(defender.Type) + 0.1f;
            float attackVsDefence = this.Attack / defender.Defense;
            int damage = (int)(((levelDamage * attackVsDefence) / 50 + 2 + rnd.Next(1, 8)) * modifier);
            defender.Health = (defender.Health - damage <= 0 ? 0 : defender.Health - damage);
        }

        public override void SpAttacking(Pokemon defender) //Ecuacion de Ataque Especial
        {
            float levelDamage = ((2 * this.Level) / 5) + 2;
            float modifier = Effectiveness(defender.Type) + 0.1f;
            float attackVsDefence = this.Attack / defender.Defense;
            int damage = (int)(((levelDamage * attackVsDefence * this.SpAttack) / 50 + 2 + rnd.Next(1, 8)) * modifier);
            defender.Health = (defender.Health - damage <= 0 ? 0 : defender.Health - damage);
        }

        private float Effectiveness(string dType) => 1f; //Regresa efectividad de ataque contra tipo de pokemon


    }
}
