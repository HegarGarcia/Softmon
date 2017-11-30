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
    public partial class Trainer_Registration : Form
    {
        public Trainer_Registration()
        {
            InitializeComponent();
        }

        public Trainer player
        {
            get;
            set;
        } = null;

        private void createTrainerButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string city = cityTextBox.Text;

            player = new Trainer(name, city);
            this.Close();
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            createTrainerButton.Enabled = !string.IsNullOrWhiteSpace(this.nameTextBox.Text) &&
                !string.IsNullOrWhiteSpace(this.cityTextBox.Text);
        }

        private void cityTextBox_TextChanged(object sender, EventArgs e)
        {
            createTrainerButton.Enabled = !string.IsNullOrWhiteSpace(this.nameTextBox.Text) &&
                !string.IsNullOrWhiteSpace(this.cityTextBox.Text);
        }
    }
}
