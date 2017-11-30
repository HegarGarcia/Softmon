﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
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

        private BattleField battle = new BattleField();

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
            PCHPBack.Parent = pictureBox1;
            PlayerHPBack.Parent = pictureBox1;
            pictureBox1.BackColor = Color.Transparent;
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            LoadPokemon(Player.currentPokemon, false);
            LoadPokemon(PC.currentPokemon, true);
        }

        private void Normal_Attack_Click(object sender, EventArgs e)
        {
            Normal_Attack.Enabled = Special_Attack.Enabled = Change_Pokemon.Enabled = false;

            PC = battle.PlayerNormalAttack(Player, PC);
            LoadPokemon(PC.currentPokemon, true);

            if (PC.currentPokemon.Health > 0)
            {
                Player = battle.PcAttacking(Player, PC);
                LoadPokemon(Player.currentPokemon, false);
            }

            Player = battle.SavePokemon(Player);
            battle.SaveTrainer(Player);

            if (!battle.CheckGameOver(Player))
            { 
                if (PC.currentPokemon.Health <= 0 || Player.currentPokemon.Health <= 0)
                    ChangePokemon();

                Player = battle.SavePokemon(Player);
                battle.SaveTrainer(Player);

                Normal_Attack.Enabled = Special_Attack.Enabled = Change_Pokemon.Enabled = true;
            }

        }

        private void Special_Attack_Click(object sender, EventArgs e)
        {
            Normal_Attack.Enabled = Special_Attack.Enabled = Change_Pokemon.Enabled = false;

            PC = battle.PlayerSpecialAttack(Player, PC);
            LoadPokemon(PC.currentPokemon, true);

            if (PC.currentPokemon.Health > 0)
            {
                Player = battle.PcAttacking(Player, PC);
                LoadPokemon(Player.currentPokemon, false);
            }

            Player = battle.SavePokemon(Player);
            battle.SaveTrainer(Player);

            if (!battle.CheckGameOver(Player))
            {
                if (PC.currentPokemon.Health <= 0 || Player.currentPokemon.Health <= 0)
                    ChangePokemon();

                Player = battle.SavePokemon(Player);
                battle.SaveTrainer(Player);

                Normal_Attack.Enabled = Special_Attack.Enabled = Change_Pokemon.Enabled = true;
            }
        }

        private void Change_Pokemon_Click(object sender, EventArgs e)
        {
            var form = new Change_Pokemon(Player);
            form.ShowDialog();
            if (form.current != null)
            {
                Player.currentPokemon = form.current;
                LoadPokemon(Player.currentPokemon, false);
            }
        }

        private void Initialize()
        {
            try //Read files and create PC Player
            {
                this.Pokedex = battle.LoadPokedex();
                this.Player = battle.LoadTrainer();
                this.PC = battle.CreatePC(Pokedex);
            }
            catch //Create and fill File
            {
                XmlWriterSettings settings = new XmlWriterSettings { Indent = true };
                this.battle.CreatePokedex(settings);
                if (this.Pokedex.Count > 0)
                    this.battle.CreateTrainer(settings, Pokedex);
                Application.Restart();
            }
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
                    if (!isPC) playerPokemon.BackgroundImage = Properties.Resources.bulbasaur_back;
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

        private void ChangePokemon()
        {
            if (Player.currentPokemon.Health == 0)
            {
                var form = new Change_Pokemon(Player);
                form.ShowDialog();
                Player.currentPokemon = form.current;
                LoadPokemon(Player.currentPokemon, false);
            }

            if (PC.currentPokemon.Health == 0)
            {
                PC.Pokemons.Remove(PC.currentPokemon);
                if (PC.Pokemons.Count > 1)
                {
                    PC.currentPokemon = PC.Pokemons[rnd.Next(0, PC.Pokemons.Count)];
                    LoadPokemon(PC.currentPokemon, true);
                }
                else
                {
                    this.PC = this.battle.CreatePC(Pokedex);
                }
            }
        }

    }
}
