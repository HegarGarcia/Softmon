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
        private string Gender
        {
            get;
            set;
        }

        [DataMember]
        private List<Pokemon> Pokemons = new List<Pokemon>();

        public Trainer(string nombre)
        {
            this.Name = nombre;
        }

        
    }
}
