namespace ProjectStellar.FormLauncher
{
    partial class Launcher
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.fullscreen = new System.Windows.Forms.CheckBox();
            this.resolution = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.launch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fullscreen
            // 
            this.fullscreen.AutoSize = true;
            this.fullscreen.Location = new System.Drawing.Point(89, 84);
            this.fullscreen.Name = "fullscreen";
            this.fullscreen.Size = new System.Drawing.Size(108, 17);
            this.fullscreen.TabIndex = 0;
            this.fullscreen.Text = "Mode plein écran";
            this.fullscreen.UseVisualStyleBackColor = true;
            this.fullscreen.CheckedChanged += new System.EventHandler(this.FullScreen_CheckedChanged);
            // 
            // resolution
            // 
            this.resolution.FormattingEnabled = true;
            this.resolution.Items.AddRange(new object[] {
            "640 * 360",
            "1024 *576",
            "1280 * 720",
            "1366 * 768",
            "1920 * 1080",
            "2560 * 1440",
            "3840 * 2160"});
            this.resolution.Location = new System.Drawing.Point(113, 32);
            this.resolution.Name = "resolution";
            this.resolution.Size = new System.Drawing.Size(121, 21);
            this.resolution.TabIndex = 1;
            this.resolution.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Résolution";
            // 
            // launch
            // 
            this.launch.Location = new System.Drawing.Point(102, 125);
            this.launch.Name = "launch";
            this.launch.Size = new System.Drawing.Size(75, 23);
            this.launch.TabIndex = 3;
            this.launch.Text = "Lancer";
            this.launch.UseVisualStyleBackColor = true;
            this.launch.Click += new System.EventHandler(this.Launch_Click);
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 160);
            this.Controls.Add(this.launch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resolution);
            this.Controls.Add(this.fullscreen);
            this.Name = "Launcher";
            this.Text = "Project STELLAR Launcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox fullscreen;
        private System.Windows.Forms.ComboBox resolution;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button launch;
    }
}

