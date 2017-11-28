using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Softmon
{
    [XmlInclude(typeof(PokemonNormal))]
    [XmlInclude(typeof(PokemonFire))]
    [XmlInclude(typeof(PokemonWater))]
    [XmlInclude(typeof(PokemonGround))]
    [XmlInclude(typeof(PokemonGround))]

    public class Pokemon
    {
        protected int Id
        {
            get;
            set;
        }
        protected string Name
        {
            get;
            set;
        }
        protected internal string Type
        {
            get;
            set;
        }
        protected internal int Level
        {
            get;
            set;
        }
        protected internal int Attack
        {
            get;
            set;
        }
        protected internal int Defence
        {
            get;
            set;
        }
        protected internal int Health
        {
            get;
            set;
        }
        protected internal int Speed
        {
            get;
            set;
        }

        //Normal, Fire, Water, Ground, Flying
    }
}
