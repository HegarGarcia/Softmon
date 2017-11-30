using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Softmon
{
    public partial class Change_Pokemon : Form
    {
        private Trainer Player = new Trainer();
        public Pokemon current
        {
            get;
            private set;
        } = null;

        public Change_Pokemon(Trainer player)
        {
            InitializeComponent();
            this.Player = player;
        }

        private void Change_Pokemon_Shown(object sender, EventArgs e)
        {
            List<Pokemon> pokemons = Player.Pokemons;

            for(var i = 0; i < pokemons.Count; i++)
            {
                Button b = this.Controls.Find($"Pokemon{i + 1}", false)[0] as Button;
                switch (pokemons[i].Name.ToLower())
                {
                    case "bulbasaur":
                        b.BackgroundImage = Properties.Resources.bulbasaur;
                        break;
                    case "squirtle":
                        b.BackgroundImage = Properties.Resources.squirtle;
                        break;
                    case "charmander":
                        b.BackgroundImage = Properties.Resources.charmander;
                        break;
                    case "pidgey":
                        b.BackgroundImage = Properties.Resources.pidgey;
                        break;
                    case "spearow":
                        b.BackgroundImage = Properties.Resources.spearow;
                        break;
                    case "rattata":
                        b.BackgroundImage = Properties.Resources.rattata;
                        break;
                }
                b.Text = pokemons[i].Name;
                b.Enabled = (pokemons[i].Health > 0 ? true : false);
                b.Tag = i;
            }
        }

        private void Pokemon1_Click(object sender, EventArgs e)
        {
            int index = Int32.Parse(Pokemon1.Tag.ToString());
            current = Player.Pokemons[index];
            this.Close();
        }

        private void Pokemon2_Click(object sender, EventArgs e)
        {
            int index = Int32.Parse(Pokemon2.Tag.ToString());
            current = Player.Pokemons[index];
            this.Close();
        }

        private void Pokemon3_Click(object sender, EventArgs e)
        {
            int index = Int32.Parse(Pokemon3.Tag.ToString());
            current = Player.Pokemons[index];
            this.Close();
        }
    }
}
