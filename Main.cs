using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Xml;
using System.Runtime.Serialization;
using System.IO;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace Softmon
{
    public partial class Main : Form
    {
        private List<Pokemon> Pokedex = new List<Pokemon>();
        private Trainer Player = new Trainer();
        private Trainer PC = new Trainer();

        private BattleField battle = new BattleField();

        public Main()
        {
            InitializeComponent();
            CustomFontInit();
        }

        private void Main_Load(object sender, EventArgs e) //Inicia formatos y tracking de Mouse
        {
            Initialize(); //Carga Trainer y Pokedex a Memoria

            //Generar Transparencias
            playerPokemon.Parent = pictureBox1;
            pcPokemon.Parent = pictureBox1;
            PCHPBack.Parent = pictureBox1;
            PlayerHPBack.Parent = pictureBox1;
            pictureBox1.BackColor = Color.Transparent;            

            //Tracking de Mouse
            Normal_Attack.MouseEnter += OnMouseEnterButton1;
            Normal_Attack.MouseLeave += OnMouseLeaveButton1;
            Special_Attack.MouseEnter += OnMouseEnterButton2;
            Special_Attack.MouseLeave += OnMouseLeaveButton2;
            Change_Pokemon.MouseEnter += OnMouseEnterChangeP;
            Change_Pokemon.MouseLeave += OnMouseLeaveChangeP;
        }

        private void Main_Shown(object sender, EventArgs e) //Cargar Pokemones al UI
        {
            LoadPokemon(Player.currentPokemon, false);
            LoadPokemon(PC.currentPokemon, true);
        }

        private void OnMouseEnterChangeP(object sender, EventArgs e) //EventHandler de Mouse
        {
            Change_Pokemon.BackgroundImage = Properties.Resources.change_hover;
        }

        private void OnMouseLeaveChangeP(object sender, EventArgs e) //EventHandler de Mouse
        {
            Change_Pokemon.BackgroundImage = Properties.Resources.change;
        }

        private void OnMouseEnterButton1(object sender, EventArgs e) //EventHandler de Mouse
        {
            Normal_Attack.BackgroundImage = Properties.Resources.button_back_hover;
        }

        private void OnMouseLeaveButton1(object sender, EventArgs e) //EventHandler de Mouse
        {
            Normal_Attack.BackgroundImage = Properties.Resources.button_back;
        }

        private void OnMouseEnterButton2(object sender, EventArgs e) //EventHandler de Mouse
        {
            Special_Attack.BackgroundImage = Properties.Resources.button_back_hover;
        }

        private void OnMouseLeaveButton2(object sender, EventArgs e) //EventHandler de Mouse
        {
            Special_Attack.BackgroundImage = Properties.Resources.button_back;
        }

        private void Normal_Attack_Click(object sender, EventArgs e) //EventHandler de Mouse
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

        private void Special_Attack_Click(object sender, EventArgs e) //EventHandler de Mouse
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

        private void Change_Pokemon_Click(object sender, EventArgs e) //EventHandler de Mouse
        {
            var form = new Change_Pokemon(Player);
            form.ShowDialog();
            if (form.current != null)
            {
                Player.currentPokemon = form.current;
                LoadPokemon(Player.currentPokemon, false);
            }
        }

        private void Initialize() //Load or Create the pokedex and trainer
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

        private void LoadPokemon(Pokemon poke, bool isPc) //Carga assets y texto a UI
        {
            if (!isPc)
            {
                HP_Player.Maximum = poke.MaxHealth;
                HP_Player.Minimum = 0;
                HP_Player.Value = poke.Health;
                Name_Player.Text = poke.Name;
                HPNumber_Player.Text = $"{poke.Health}/{poke.MaxHealth}";
                Normal_Attack.Text = poke.MoveSet[0].ToUpper();
                Special_Attack.Text = poke.MoveSet[1].ToUpper();
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

        private void LoadPokemonImage(string pokemonName, bool isPC) //Carga imagen de Pokemon
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

        private void ChangePokemon() //Maneja los cambios de personaje
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
                PC.Pokemons.RemoveAt(0);
                if (PC.Pokemons.Count >= 1)
                {
                    PC.currentPokemon = PC.Pokemons[0];
                    LoadPokemon(PC.currentPokemon, true);
                }
                else
                {
                    this.PC = this.battle.CreatePC(Pokedex);
                }
            }
        }

        private void CustomFontInit() //Inicializa las fuentes
        {
            //Create your private font collection object.
            PrivateFontCollection pfc = new PrivateFontCollection();

            //Select your font from the resources.
            int fontLength = Properties.Resources.pokemon_pixel_font.Length;

            // create a buffer to read in to
            byte[] fontdata = Properties.Resources.pokemon_pixel_font;

            // create an unsafe memory block for the font data
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            // copy the bytes to the unsafe memory block
            Marshal.Copy(fontdata, 0, data, fontLength);

            // pass the font to the font collection
            pfc.AddMemoryFont(data, fontLength);

            Normal_Attack.Font = new Font(pfc.Families[0], Normal_Attack.Font.Size);
            Special_Attack.Font = new Font(pfc.Families[0], Special_Attack.Font.Size);
            Change_Pokemon.Font = new Font(pfc.Families[0], Change_Pokemon.Font.Size);
            Name_Player.Font = new Font(pfc.Families[0], Name_Player.Font.Size);
            Name_PC.Font = new Font(pfc.Families[0], Name_PC.Font.Size);
        }
    }
}
