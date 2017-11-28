using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Softmon
{
    [XmlInclude(typeof(PokemonNormal))]
    [XmlInclude(typeof(PokemonFire))]
    [XmlInclude(typeof(PokemonWater))]
    [XmlInclude(typeof(PokemonGround))]
    [XmlInclude(typeof(PokemonGround))]
    [DataContract]
    public class Pokemon
    {
        [DataMember]
        protected int Id
        {
            get;
            set;
        }

        [DataMember]
        protected string Name
        {
            get;
            set;
        }

        [DataMember]
        protected internal string Type
        {
            get;
            set;
        }

        [DataMember]
        protected internal int Level
        {
            get;
            set;
        }

        [DataMember]
        protected internal int Attack
        {
            get;
            set;
        }

        [DataMember]
        protected internal int Defence
        {
            get;
            set;
        }

        [DataMember]
        protected internal int Health
        {
            get;
            set;
        }

        [DataMember]
        protected internal int Speed
        {
            get;
            set;
        }

        [DataMember]
        protected internal int XP
        {
            get;
            protected set;
        }
    }
}
