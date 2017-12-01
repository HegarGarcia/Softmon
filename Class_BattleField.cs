using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Xml;
using System.Runtime.Serialization;
using System.IO;

namespace Softmon
{
    public class BattleField
    {
        private string pokedexFilePath = $@"{Environment.CurrentDirectory}\\Pokedex.xml";
        private string trainerFilePath = $@"{Environment.CurrentDirectory}\\Trainer.xml";

        private DataContractSerializer pokedexSerializer = new DataContractSerializer(typeof(List<Pokemon>));
        private DataContractSerializer trainerSerializer = new DataContractSerializer(typeof(Trainer));

        static Random rnd = new Random();

        public List<Pokemon> LoadPokedex() //Carga Pokedex a memoria
        {
            //Get Pokedex File
            FileStream pokedexFile = new FileStream(pokedexFilePath, FileMode.Open);

            //Get data from file
            List<Pokemon> Pokedex = (List<Pokemon>)pokedexSerializer.ReadObject( pokedexFile);

            //Close file
            pokedexFile.Close();

            return Pokedex;
        }

        public Trainer LoadTrainer() //Carga jugador a memoria
        {
            //Get Pokedex File
            FileStream trainerFile = new FileStream(trainerFilePath, FileMode.Open);

            //Get data from file
            Trainer Player = (Trainer)trainerSerializer.ReadObject(trainerFile);

            //Close file
            trainerFile.Close();

            return Player;
        }

        public void CreatePokedex(XmlWriterSettings settings) //Crea archivo de Pokedex
        {
            if (!File.Exists(pokedexFilePath))
            {
                List<Pokemon> Pokedex = new List<Pokemon>();
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
                    Defense = 55,
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
        }

        public void CreateTrainer(XmlWriterSettings settings, List<Pokemon> Pokedex) //Crea archivo de Trainer
        {
            if (!File.Exists(trainerFilePath))
            {
                Trainer Player = new Trainer();
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
        }

        public Trainer CreatePC(List<Pokemon> Pokedex) //Crea el jugador de PC
        {
            Trainer PC = new Trainer();
            PC = new Trainer("PC", "Intel");

            List<Pokemon> temp = Pokedex.OrderBy(Poke => rnd.Next()).ToList<Pokemon>();

            PC.AddPokemons(temp);

            return PC;
        }

        public void SaveTrainer(Trainer Player) //Guarda los datos al archivo de jugador
        {
            //Create Settings
            XmlWriterSettings settings = new XmlWriterSettings { Indent = true };

            //Recreate file
            XmlWriter trainerFile = XmlWriter.Create(trainerFilePath, settings);

            //Put data in file and close file
            trainerSerializer.WriteObject(trainerFile, Player);
            trainerFile.Close();
        }

        public Trainer SavePokemon(Trainer Player) //Actualiza los datos del pokemon en el jugador
        {
            Player.Pokemons.Where(a => a.Id == Player.currentPokemon.Id).First().Health = Player.currentPokemon.Health;
            return Player;
        }

        public Trainer PlayerNormalAttack(Trainer Player, Trainer PC) //Jugador usa ataque normal contra PC
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
            MessageBox.Show(Player.currentPokemon.Name + " used " + Player.currentPokemon.MoveSet[0] + "!");

            return PC;
        }

        public Trainer PlayerSpecialAttack(Trainer Player, Trainer PC) //Jugador usa ataque especial contra PC
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
            MessageBox.Show(Player.currentPokemon.Name + " used " + Player.currentPokemon.MoveSet[1] + "!");

            return PC;
        }

        public Trainer PcAttacking(Trainer Player, Trainer PC) //Lógica de Ataque de PC
        {
            if (rnd.Next(0, 11) < 5)
            {
                Player = PcNormalAttack(Player, PC);
            }
            else
            {
                Player = PcSpecialAttack(Player, PC);
            }

            return Player;
        }

        private Trainer PcNormalAttack(Trainer Player, Trainer PC) //PC usa ataque normal contra Jugador
        {
            switch (PC.currentPokemon.Type)
            {
                case "fire":
                    PokemonFire fire = PC.currentPokemon as PokemonFire;
                    fire.Attacking(Player.currentPokemon);
                    break;
                case "flying":
                    PokemonFlying fly = PC.currentPokemon as PokemonFlying;
                    fly.Attacking(Player.currentPokemon);
                    break;
                case "grass":
                    PokemonGrass grass = PC.currentPokemon as PokemonGrass;
                    grass.Attacking(Player.currentPokemon);
                    break;
                case "normal":
                    PokemonNormal normal = PC.currentPokemon as PokemonNormal;
                    normal.Attacking(Player.currentPokemon);
                    break;
                case "water":
                    PokemonWater water = PC.currentPokemon as PokemonWater;
                    water.Attacking(Player.currentPokemon);
                    break;
                default:
                    break;
            }
            MessageBox.Show(PC.currentPokemon.Name + " used " + PC.currentPokemon.MoveSet[0] + "!");

            return Player;
        }

        private Trainer PcSpecialAttack(Trainer Player, Trainer PC) //PC usa ataque especial contra Jugador
        {
            switch (PC.currentPokemon.Type)
            {
                case "fire":
                    PokemonFire fire = PC.currentPokemon as PokemonFire;
                    fire.SpAttacking(Player.currentPokemon);
                    break;
                case "flying":
                    PokemonFlying fly = PC.currentPokemon as PokemonFlying;
                    fly.SpAttacking(Player.currentPokemon);
                    break;
                case "grass":
                    PokemonGrass grass = PC.currentPokemon as PokemonGrass;
                    grass.SpAttacking(Player.currentPokemon);
                    break;
                case "normal":
                    PokemonNormal normal = PC.currentPokemon as PokemonNormal;
                    normal.SpAttacking(Player.currentPokemon);
                    break;
                case "water":
                    PokemonWater water = PC.currentPokemon as PokemonWater;
                    water.SpAttacking(Player.currentPokemon);
                    break;
                default:
                    break;
            }
            MessageBox.Show(PC.currentPokemon.Name + " used " + PC.currentPokemon.MoveSet[0] + "!");

            return Player;
        }

        public bool CheckGameOver(Trainer Player) //Checa si el jugador perdio
        {
            if (Player.Pokemons.TrueForAll(poke => poke.Health == 0))
            {
                MessageBox.Show("GAME OVER!!!");
                File.Delete(trainerFilePath);
                Application.Restart();
                return true;
            }
            return false;

        }

    }
}
