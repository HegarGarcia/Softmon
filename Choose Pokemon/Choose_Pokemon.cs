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
    public partial class Choose_Pokemon : Form
    {
        private List<Pokemon> Pokedex;
        public List<Pokemon> choices = new List<Pokemon>();
        private int counter = 3;

        public Choose_Pokemon(List<Pokemon> pokedex)
        {
            InitializeComponent();
            Pokedex = pokedex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            choices.Add(Pokedex[0]);
            checker();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.button2.Enabled = false;
            choices.Add(Pokedex[1]);
            checker();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.button3.Enabled = false;
            choices.Add(Pokedex[2]);
            checker();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.button4.Enabled = false;
            choices.Add(Pokedex[3]);
            checker();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.button5.Enabled = false;
            choices.Add(Pokedex[4]);
            checker();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.button6.Enabled = false;
            choices.Add(Pokedex[5]);
            checker();
        }

        private void checker()
        {
            counter--;

            if (counter == 0)
                this.Close();
            else
                this.label1.Text = $"Elige {counter} Pokemones";
        }
    }
}
