using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO;

namespace Softmon
{
    public partial class Main : Form
    {
        private List<Pokemon> Pokedex = new List<Pokemon>();
        private Trainer Player = new Trainer("Hegar");

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //Create Serializer
            DataContractSerializer pokedexSerializer = new DataContractSerializer(typeof(List<Pokemon>));
            DataContractSerializer trainerSerializer = new DataContractSerializer(typeof(Trainer));

            var pokedexFilePath = $@"{Environment.CurrentDirectory}\\Pokedex.xml";
            var trainerFilePath = $@"{Environment.CurrentDirectory}\\Trainer.xml";

            try //Read file
            {
                //Get Pokedex File
                FileStream pokedexFile = new FileStream(pokedexFilePath, FileMode.Open);
                FileStream trainerFile = new FileStream(trainerFilePath, FileMode.Open);

                //Get data from file
                Pokedex = (List<Pokemon>)pokedexSerializer.ReadObject(pokedexFile);
                Player = (Trainer)trainerSerializer.ReadObject(trainerFile);

                //Close file
                pokedexFile.Close();
                trainerFile.Close();
            }
            catch //Create and fill File
            {
                XmlWriterSettings settings = new XmlWriterSettings { Indent = true };

                //Adding starting pokemons...

                //Create file
                XmlWriter pokedexFile = XmlWriter.Create(pokedexFilePath, settings);
                XmlWriter trainerFile = XmlWriter.Create(trainerFilePath, settings);

                //Set data in file
                pokedexSerializer.WriteObject(pokedexFile, Pokedex);
                trainerSerializer.WriteObject(trainerFile, Player);

                //Close file and restart application
                pokedexFile.Close();
                trainerFile.Close();
                Application.Restart();
            }
        }

    }
}
