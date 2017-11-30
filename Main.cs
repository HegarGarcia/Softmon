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
using System.Runtime.Serialization;
using System.IO;

namespace Softmon
{
    public partial class Main : Form
    {
        private List<Pokemon> Pokedex = new List<Pokemon>();
        private Trainer Player = new Trainer();
        private Trainer PC = new Trainer();

        private string pokedexFilePath = $@"{Environment.CurrentDirectory}\\Pokedex.xml";
        private string trainerFilePath = $@"{Environment.CurrentDirectory}\\Trainer.xml";

        private DataContractSerializer pokedexSerializer = new DataContractSerializer(typeof(List<Pokemon>));
        private DataContractSerializer trainerSerializer = new DataContractSerializer(typeof(Trainer));

        static Random rnd = new Random();

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Initialize(); //Carga Trainer y Pokedex a Memoria

            playerPokemon.Parent = pictureBox1;
            pcPokemon.Parent = pictureBox1;
            pictureBox1.BackColor = Color.Transparent;

            savingTimer.Enabled = true;
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            LoadPokemon(Player.currentPokemon, false);
            LoadPokemon(PC.currentPokemon, true);
        }

        private void Normal_Attack_Click(object sender, EventArgs e)
        {
            switch (Player.currentPokemon.Type)
            {
                case "fire":
                    PokemonFire fire = Player.currentPokemon as PokemonFire;
                    fire.Attacking(PC.currentPokemon);
                    break;
                case "flying":
                    PokemonFlying fly = Player.currentPokemon as PokemonFlying;
                    fly.Attacking(PC.currentPokemon);
                    break;
                case "grass":
                    PokemonGrass grass = Player.currentPokemon as PokemonGrass;
                    grass.Attacking(PC.currentPokemon);
                    break;
                case "normal":
                    PokemonNormal normal = Player.currentPokemon as PokemonNormal;
                    normal.Attacking(PC.currentPokemon);
                    break;
                case "water":
                    PokemonWater water = Player.currentPokemon as PokemonWater;
                    water.Attacking(PC.currentPokemon);
                    break;
                default:
                    break;
            }

            LoadPokemon(PC.currentPokemon, true);
        }

        private void Special_Attack_Click(object sender, EventArgs e)
        {
            switch (Player.currentPokemon.Type)
            {
                case "fire":
                    PokemonFire fire = Player.currentPokemon as PokemonFire;
                    fire.SpAttacking(PC.currentPokemon);
                    break;
                case "flying":
                    PokemonFlying fly = Player.currentPokemon as PokemonFlying;
                    fly.SpAttacking(PC.currentPokemon);
                    break;
                case "grass":
                    PokemonGrass grass = Player.currentPokemon as PokemonGrass;
                    grass.SpAttacking(PC.currentPokemon);
                    break;
                case "normal":
                    PokemonNormal normal = Player.currentPokemon as PokemonNormal;
                    normal.SpAttacking(PC.currentPokemon);
                    break;
                case "water":
                    PokemonWater water = Player.currentPokemon as PokemonWater;
                    water.SpAttacking(PC.currentPokemon);
                    break;
                default:
                    break;
            }

            LoadPokemon(PC.currentPokemon, true);
        }

        private void savingTimer_Tick(object sender, EventArgs e)
        {
            SaveTrainer();
        }

        private void Initialize()
        {
            try //Read files and create PC Player
            {
                LoadPokedex();
                LoadTrainer();
                CreatePC();
            }
            catch //Create and fill File
            {
                XmlWriterSettings settings = new XmlWriterSettings { Indent = true };
                bool pokedexExists = File.Exists(pokedexFilePath);
                bool trainerExists = File.Exists(trainerFilePath);

                if (!pokedexExists) //Create Pokedex File and Set data to file
                    CreatePokedex(settings);

                if (!trainerExists) //Create Trainer File and Set data to file
                    CreateTrainer(settings);

                this.Close();
                Application.Restart();
            }
        }

        public void LoadPokedex()
        {
            //Get Pokedex File
            FileStream pokedexFile = new FileStream(pokedexFilePath, FileMode.Open);

            //Get data from file
            Pokedex = (List<Pokemon>)pokedexSerializer.ReadObject(pokedexFile);

            //Close file
            pokedexFile.Close();
        }

        public void LoadTrainer()
        {
            //Get Pokedex File
            FileStream trainerFile = new FileStream(trainerFilePath, FileMode.Open);

            //Get data from file
            Player = (Trainer)trainerSerializer.ReadObject(trainerFile);

            //Close file
            trainerFile.Close();
        }

        private void LoadPokemon(Pokemon poke, bool isPc)
        {
            if (!isPc)
            {
                HP_Player.Maximum = poke.MaxHealth;
                HP_Player.Minimum = 0;
                HP_Player.Value = poke.Health;
                Name_Player.Text = poke.Name;
                HPNumber_Player.Text = $"{poke.Health}/{poke.MaxHealth}";
            }
            else
            {
                HP_PC.Maximum = poke.MaxHealth;
                HP_PC.Minimum = 0;
                HP_PC.Value = poke.Health;
                Name_PC.Text = poke.Name;
                HPNumber_PC.Text = $"{poke.Health}/{poke.MaxHealth}";
            }
            LoadPokemonImage(poke.Name, isPc);
        }

        private void LoadPokemonImage(string pokemonName, bool isPC)
        {
            switch (pokemonName.ToLower())
            {
                case "bulbasaur":
                    if(!isPC) playerPokemon.BackgroundImage = Properties.Resources.bulbasaur_back;
                    else pcPokemon.BackgroundImage = Properties.Resources.bulbasaur;
                    break;
                case "squirtle":
                    if (!isPC) playerPokemon.BackgroundImage = Properties.Resources.squirtle_back;
                    else pcPokemon.BackgroundImage = Properties.Resources.squirtle;
                    break;
                case "charmander":
                    if (!isPC) playerPokemon.BackgroundImage = Properties.Resources.charmander_back;
                    else pcPokemon.BackgroundImage = Properties.Resources.charmander;
                    break;
                case "pidgey":
                    if (!isPC) playerPokemon.BackgroundImage = Properties.Resources.pidgey_back;
                    else pcPokemon.BackgroundImage = Properties.Resources.pidgey;
                    break;
                case "spearow":
                    if (!isPC) playerPokemon.BackgroundImage = Properties.Resources.spearow_back;
                    else pcPokemon.BackgroundImage = Properties.Resources.spearow;
                    break;
                case "rattata":
                    if (!isPC) playerPokemon.BackgroundImage = Properties.Resources.rattata_back;
                    else pcPokemon.BackgroundImage = Properties.Resources.rattata;
                    break;
            }
        }

        private void CreatePokedex(XmlWriterSettings settings)
        {
            //Adding starting pokemons...
            Pokemon bulbasaur = new PokemonGrass()
            {
                Name = "Bulbasaur",
                Health = 45,
                MaxHealth = 45,
                Attack = 49,
                Defense = 49,
                SpAttack = 65,
                Id = 1
            };

            Pokemon charmander = new PokemonFire()
            {
                Name = "Charmander",
                Health = 39,
                MaxHealth = 39,
                Attack = 52,
                Defense = 43,
                SpAttack = 60,
                Id = 2
            };

            Pokemon squirtle = new PokemonWater()
            {
                Name = "Squirtle",
                Health = 44,
                MaxHealth = 44,
                Attack = 48,
                Defense = 65,
                SpAttack = 50,
                Id = 3
            };

            Pokemon pidgey = new PokemonFlying()
            {
                Name = "Pidgey",
                Health = 40,
                MaxHealth = 40,
                Attack = 45,
                Defense = 40,
                SpAttack = 35,
                Id = 4
            };

            Pokemon rattata = new PokemonNormal()
            {
                Name = "Rattata",
                Health = 30,
                MaxHealth = 30,
                Attack = 56,
                Defense = 35,
                SpAttack = 25,
                Id = 5
            };

            Pokemon spearow = new PokemonFlying()
            {
                Name = "Spearow",
                Health = 40,
                MaxHealth = 40,
                Attack = 60,
                Defense = 30,
                SpAttack = 31,
                Id = 6
            };

            Pokedex.Add(bulbasaur);
            Pokedex.Add(charmander);
            Pokedex.Add(squirtle);
            Pokedex.Add(pidgey);
            Pokedex.Add(rattata);
            Pokedex.Add(spearow);

            XmlWriter pokedexFile = XmlWriter.Create(pokedexFilePath, settings);
            pokedexSerializer.WriteObject(pokedexFile, Pokedex);
            pokedexFile.Close();
        }

        private void CreateTrainer(XmlWriterSettings settings)
        {
            var formCreateTrainer = new Trainer_Registration();
            formCreateTrainer.ShowDialog();

            Player = (formCreateTrainer.player == null ? new Trainer("Ash", "Pueblo Paleta") :
                formCreateTrainer.player);

            var formAddPokemon = new Choose_Pokemon(Pokedex);
            formAddPokemon.ShowDialog();

            Player.AddPokemons(formAddPokemon.choices);

            XmlWriter trainerFile = XmlWriter.Create(trainerFilePath, settings);
            trainerSerializer.WriteObject(trainerFile, Player);
            trainerFile.Close();
        }

        private void SaveTrainer()
        {
            //Create Settings
            XmlWriterSettings settings = new XmlWriterSettings { Indent = true };

            //Recreate file
            XmlWriter trainerFile = XmlWriter.Create(trainerFilePath, settings);

            //Put data in file and close file
            trainerSerializer.WriteObject(trainerFile, Player);
            trainerFile.Close();
        }

        private void CreatePC()
        {
            PC = new Trainer("PC", "Intel");

            List<Pokemon> temp = new List<Pokemon>();

            while(temp.Count < 3)
            {
                temp.Add(Pokedex[rnd.Next(0, 6)]);
            }

            PC.AddPokemons(temp);
        }

        private void ChangePokemon(bool isPc)
        {
            if (!isPc)
            {

            }
            else
            {

            }
        }
    }
}
