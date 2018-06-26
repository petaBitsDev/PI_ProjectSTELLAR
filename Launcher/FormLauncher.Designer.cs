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
            this.fullscreen.Location = new System.Drawing.Point(134, 129);
            this.fullscreen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fullscreen.Name = "fullscreen";
            this.fullscreen.Size = new System.Drawing.Size(156, 24);
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
            "2048 * 1280",
            "2160 * 1440",
            "2560 * 1440",
            "3840 * 2160",
            "3840 * 2400"});
            this.resolution.Location = new System.Drawing.Point(170, 49);
            this.resolution.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.resolution.Name = "resolution";
            this.resolution.Size = new System.Drawing.Size(180, 28);
            this.resolution.TabIndex = 1;
            this.resolution.SelectedIndex = 2;
            this.resolution.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Résolution";
            // 
            // launch
            // 
            this.launch.Location = new System.Drawing.Point(153, 192);
            this.launch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.launch.Name = "launch";
            this.launch.Size = new System.Drawing.Size(112, 35);
            this.launch.TabIndex = 3;
            this.launch.Text = "Lancer";
            this.launch.UseVisualStyleBackColor = true;
            this.launch.Click += new System.EventHandler(this.Launch_Click);
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 246);
            this.Controls.Add(this.launch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resolution);
            this.Controls.Add(this.fullscreen);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Launcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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

