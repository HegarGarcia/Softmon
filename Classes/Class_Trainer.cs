using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Softmon
{
    [DataContract]
    public class Trainer
    {
        [DataMember]
        private string Name
        {
            get;
            set;
        }

        [DataMember]
        private string City
        {
            get;
            set;
        }

        [DataMember]
        public List<Pokemon> Pokemons
        {
            get;
            private set;
        } = new List<Pokemon>();

        [DataMember]
        public List<string> BattleRecords = new List<string>();

        [DataMember]
        public Pokemon currentPokemon
        {
            get;
            set;
        }

        public Trainer(string nombre, string ciudad)
        {
            this.Name = nombre;
            this.City = ciudad;
        }

        public Trainer() { }

        public void AddPokemons(List<Pokemon> PokemonList)
        {
            Pokemons = PokemonList;
            this.currentPokemon = Pokemons[0];
        }
    }
}
