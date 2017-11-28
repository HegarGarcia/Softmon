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

        public string pokedexFilePath = $@"{Environment.CurrentDirectory}\\Pokedex.xml";
        public string trainerFilePath = $@"{Environment.CurrentDirectory}\\Trainer.xml";

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //Create Serializer
            DataContractSerializer pokedexSerializer = new DataContractSerializer(typeof(List<Pokemon>));
            DataContractSerializer trainerSerializer = new DataContractSerializer(typeof(Trainer));

            bool pokedexExists = File.Exists(pokedexFilePath);
            bool trainerExists = File.Exists(trainerFilePath);

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

                if (!pokedexExists) //Create Pokedex File and Set data to file
                {
                    MessageBox.Show("Creating Pokedex");
                    //Adding starting pokemons...

                    XmlWriter pokedexFile = XmlWriter.Create(pokedexFilePath, settings);
                    pokedexSerializer.WriteObject(pokedexFile, Pokedex);
                    pokedexFile.Close();
                }

                if (!trainerExists) //Create Trainer File and Set data to file
                {
                    MessageBox.Show("Creating Trainer");
                    XmlWriter trainerFile = XmlWriter.Create(trainerFilePath, settings);
                    trainerSerializer.WriteObject(trainerFile, Player);
                    trainerFile.Close();
                }

                Application.Restart();
            }
        }

        
        private void savingTimer_Tick(object sender, EventArgs e)
        {
            //Create Serializer and Settings
            DataContractSerializer trainerSerializer = new DataContractSerializer(typeof(Trainer));
            XmlWriterSettings settings = new XmlWriterSettings { Indent = true };

            //Recreate file
            XmlWriter trainerFile = XmlWriter.Create(trainerFilePath, settings);

            //Put data in file and close file
            trainerSerializer.WriteObject(trainerFile, Player);
            trainerFile.Close();
        }
    }
}
