namespace Softmon
{
    partial class Change_Pokemon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Change_Pokemon));
            this.Pokemon1 = new System.Windows.Forms.Button();
            this.Pokemon2 = new System.Windows.Forms.Button();
            this.Pokemon3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Pokemon1
            // 
            this.Pokemon1.Location = new System.Drawing.Point(13, 18);
            this.Pokemon1.Name = "Pokemon1";
            this.Pokemon1.Size = new System.Drawing.Size(75, 75);
            this.Pokemon1.TabIndex = 0;
            this.Pokemon1.Text = "Pokemon 1";
            this.Pokemon1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Pokemon1.UseVisualStyleBackColor = true;
            this.Pokemon1.Click += new System.EventHandler(this.Pokemon1_Click);
            // 
            // Pokemon2
            // 
            this.Pokemon2.Location = new System.Drawing.Point(105, 18);
            this.Pokemon2.Name = "Pokemon2";
            this.Pokemon2.Size = new System.Drawing.Size(75, 75);
            this.Pokemon2.TabIndex = 1;
            this.Pokemon2.Text = "Pokemon 2";
            this.Pokemon2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Pokemon2.UseVisualStyleBackColor = true;
            this.Pokemon2.Click += new System.EventHandler(this.Pokemon2_Click);
            // 
            // Pokemon3
            // 
            this.Pokemon3.Location = new System.Drawing.Point(197, 18);
            this.Pokemon3.Name = "Pokemon3";
            this.Pokemon3.Size = new System.Drawing.Size(75, 75);
            this.Pokemon3.TabIndex = 2;
            this.Pokemon3.Text = "Pokemon 3";
            this.Pokemon3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Pokemon3.UseVisualStyleBackColor = true;
            this.Pokemon3.Click += new System.EventHandler(this.Pokemon3_Click);
            // 
            // Change_Pokemon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 111);
            this.Controls.Add(this.Pokemon3);
            this.Controls.Add(this.Pokemon2);
            this.Controls.Add(this.Pokemon1);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Change_Pokemon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambia de Pokemon";
            this.Shown += new System.EventHandler(this.Change_Pokemon_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Pokemon1;
        private System.Windows.Forms.Button Pokemon2;
        private System.Windows.Forms.Button Pokemon3;
    }
}