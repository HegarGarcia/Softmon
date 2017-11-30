namespace Softmon
{
    partial class Main
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.savingTimer = new System.Windows.Forms.Timer(this.components);
            this.Normal_Attack = new System.Windows.Forms.Button();
            this.Special_Attack = new System.Windows.Forms.Button();
            this.Change_Pokemon = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Name_PC = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Name_Player = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.HP_PC = new System.Windows.Forms.ProgressBar();
            this.HP_Player = new System.Windows.Forms.ProgressBar();
            this.HPNumber_PC = new System.Windows.Forms.Label();
            this.HPNumber_Player = new System.Windows.Forms.Label();
            this.playerPokemon = new System.Windows.Forms.PictureBox();
            this.pcPokemon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPokemon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcPokemon)).BeginInit();
            this.SuspendLayout();
            // 
            // savingTimer
            // 
            this.savingTimer.Interval = 10000;
            this.savingTimer.Tick += new System.EventHandler(this.savingTimer_Tick);
            // 
            // Normal_Attack
            // 
            this.Normal_Attack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Normal_Attack.Location = new System.Drawing.Point(0, 280);
            this.Normal_Attack.Name = "Normal_Attack";
            this.Normal_Attack.Size = new System.Drawing.Size(256, 160);
            this.Normal_Attack.TabIndex = 0;
            this.Normal_Attack.Text = "Normal Attack";
            this.Normal_Attack.UseVisualStyleBackColor = true;
            this.Normal_Attack.Click += new System.EventHandler(this.Normal_Attack_Click);
            // 
            // Special_Attack
            // 
            this.Special_Attack.Location = new System.Drawing.Point(256, 280);
            this.Special_Attack.Name = "Special_Attack";
            this.Special_Attack.Size = new System.Drawing.Size(256, 160);
            this.Special_Attack.TabIndex = 1;
            this.Special_Attack.Text = "Special Attack";
            this.Special_Attack.UseVisualStyleBackColor = true;
            // 
            // Change_Pokemon
            // 
            this.Change_Pokemon.Location = new System.Drawing.Point(512, 280);
            this.Change_Pokemon.Name = "Change_Pokemon";
            this.Change_Pokemon.Size = new System.Drawing.Size(110, 160);
            this.Change_Pokemon.TabIndex = 2;
            this.Change_Pokemon.Text = "Change Pokemon";
            this.Change_Pokemon.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(622, 281);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Name_PC
            // 
            this.Name_PC.AutoSize = true;
            this.Name_PC.BackColor = System.Drawing.Color.White;
            this.Name_PC.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name_PC.Location = new System.Drawing.Point(17, 14);
            this.Name_PC.Name = "Name_PC";
            this.Name_PC.Size = new System.Drawing.Size(64, 28);
            this.Name_PC.TabIndex = 4;
            this.Name_PC.Text = "Name";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Location = new System.Drawing.Point(12, 9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(290, 88);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // Name_Player
            // 
            this.Name_Player.AutoSize = true;
            this.Name_Player.BackColor = System.Drawing.Color.White;
            this.Name_Player.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name_Player.Location = new System.Drawing.Point(324, 191);
            this.Name_Player.Name = "Name_Player";
            this.Name_Player.Size = new System.Drawing.Size(64, 28);
            this.Name_Player.TabIndex = 7;
            this.Name_Player.Text = "Name";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox3.Location = new System.Drawing.Point(320, 186);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(290, 88);
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // HP_PC
            // 
            this.HP_PC.Location = new System.Drawing.Point(12, 46);
            this.HP_PC.Name = "HP_PC";
            this.HP_PC.Size = new System.Drawing.Size(290, 15);
            this.HP_PC.TabIndex = 9;
            // 
            // HP_Player
            // 
            this.HP_Player.Location = new System.Drawing.Point(320, 223);
            this.HP_Player.Name = "HP_Player";
            this.HP_Player.Size = new System.Drawing.Size(290, 15);
            this.HP_Player.TabIndex = 10;
            // 
            // HPNumber_PC
            // 
            this.HPNumber_PC.AutoSize = true;
            this.HPNumber_PC.BackColor = System.Drawing.Color.White;
            this.HPNumber_PC.Location = new System.Drawing.Point(253, 64);
            this.HPNumber_PC.Name = "HPNumber_PC";
            this.HPNumber_PC.Size = new System.Drawing.Size(38, 13);
            this.HPNumber_PC.TabIndex = 11;
            this.HPNumber_PC.Text = "Health";
            // 
            // HPNumber_Player
            // 
            this.HPNumber_Player.AutoSize = true;
            this.HPNumber_Player.BackColor = System.Drawing.Color.White;
            this.HPNumber_Player.Location = new System.Drawing.Point(562, 241);
            this.HPNumber_Player.Name = "HPNumber_Player";
            this.HPNumber_Player.Size = new System.Drawing.Size(38, 13);
            this.HPNumber_Player.TabIndex = 12;
            this.HPNumber_Player.Text = "Health";
            // 
            // playerPokemon
            // 
            this.playerPokemon.BackColor = System.Drawing.Color.Transparent;
            this.playerPokemon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.playerPokemon.Location = new System.Drawing.Point(56, 125);
            this.playerPokemon.Margin = new System.Windows.Forms.Padding(0);
            this.playerPokemon.Name = "playerPokemon";
            this.playerPokemon.Size = new System.Drawing.Size(200, 200);
            this.playerPokemon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.playerPokemon.TabIndex = 13;
            this.playerPokemon.TabStop = false;
            // 
            // pcPokemon
            // 
            this.pcPokemon.BackColor = System.Drawing.Color.Transparent;
            this.pcPokemon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcPokemon.Location = new System.Drawing.Point(367, 19);
            this.pcPokemon.Name = "pcPokemon";
            this.pcPokemon.Size = new System.Drawing.Size(200, 200);
            this.pcPokemon.TabIndex = 14;
            this.pcPokemon.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.HPNumber_Player);
            this.Controls.Add(this.HP_Player);
            this.Controls.Add(this.Name_Player);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.Normal_Attack);
            this.Controls.Add(this.pcPokemon);
            this.Controls.Add(this.playerPokemon);
            this.Controls.Add(this.HPNumber_PC);
            this.Controls.Add(this.HP_PC);
            this.Controls.Add(this.Name_PC);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Change_Pokemon);
            this.Controls.Add(this.Special_Attack);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SOFTMON";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPokemon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcPokemon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer savingTimer;
        private System.Windows.Forms.Button Normal_Attack;
        private System.Windows.Forms.Button Special_Attack;
        private System.Windows.Forms.Button Change_Pokemon;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Name_PC;
        private System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.Label Name_Player;
        private System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.ProgressBar HP_PC;
        public System.Windows.Forms.ProgressBar HP_Player;
        public System.Windows.Forms.Label HPNumber_PC;
        public System.Windows.Forms.Label HPNumber_Player;
        private System.Windows.Forms.PictureBox playerPokemon;
        private System.Windows.Forms.PictureBox pcPokemon;
    }
}

