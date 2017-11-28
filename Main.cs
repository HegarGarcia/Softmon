using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace Softmon
{
    public partial class Main : Form
    {
        private List<Pokemon> Pokedex = new List<Pokemon>();

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //Create Serializer
            XmlSerializer serializer = new XmlSerializer(typeof(List<Pokemon>));

            try //Read file
            {
                //Get file
                StreamReader file = new StreamReader($@"{Environment.CurrentDirectory}\\Pokedex.xml");
                
                //Get data from file
                Pokedex = (List<Pokemon>)serializer.Deserialize(file);

                //Close file
                file.Close();
            }
            catch //Create and fill File
            {
                //Adding starting pokemons...

                
                //Create file
                FileStream file = File.Create($"{Environment.CurrentDirectory}//Pokedex.xml");

                //Set data in file
                serializer.Serialize(file, Pokedex);

                //Close file and restart application
                file.Close();
                Application.Restart();
            }
        }
    }
}
