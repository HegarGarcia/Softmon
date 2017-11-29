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
            this.savingTimer = new System.Windows.Forms.Timer(this.components);
            this.Normal_Attack = new System.Windows.Forms.Button();
            this.Special_Attack = new System.Windows.Forms.Button();
            this.Change_Pokemon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // savingTimer
            // 
            this.savingTimer.Interval = 1000;
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
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.Change_Pokemon);
            this.Controls.Add(this.Special_Attack);
            this.Controls.Add(this.Normal_Attack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SOFTMON";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer savingTimer;
        private System.Windows.Forms.Button Normal_Attack;
        private System.Windows.Forms.Button Special_Attack;
        private System.Windows.Forms.Button Change_Pokemon;
    }
}

