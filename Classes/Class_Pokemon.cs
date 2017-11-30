using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Softmon
{
    [DataContract]
    [KnownType(typeof(PokemonNormal))]
    [KnownType(typeof(PokemonFire))]
    [KnownType(typeof(PokemonFlying))]
    [KnownType(typeof(PokemonGrass))]
    [KnownType(typeof(PokemonWater))]
    public class Pokemon
    {
        protected static Random rnd = new Random();

        [DataMember]
        public string[] MoveSet = new string[2];

        [DataMember]
        public int Id
        {
            get;
            set;
        }

        [DataMember]
        public string Name
        {
            get;
            set;
        }

        [DataMember]
        public string Type
        {
            get;
            set;
        }

        [DataMember]
        public int Level
        {
            get;
            set;
        }

        [DataMember]
        public int Attack
        {
            get;
            set;
        }

        [DataMember]
        public int SpAttack
        {
            get;
            set;
        }

        [DataMember]
        public int Defense
        {
            get;
            set;
        }

        [DataMember]
        public int Health
        {
            get;
            set;
        }

        [DataMember]
        public int MaxHealth
        {
            get;
            set;
        }

        [DataMember]
        public string SpritePath
        {
            get;
            set;
        }
    }
}
