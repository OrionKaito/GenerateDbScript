namespace DynamicSystem.Views
{
    partial class MenuView
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.generateScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configGenerateScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configConnectionStringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateScriptToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(892, 42);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // generateScriptToolStripMenuItem
            // 
            this.generateScriptToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateToolStripMenuItem,
            this.configurationToolStripMenuItem});
            this.generateScriptToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateScriptToolStripMenuItem.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.generateScriptToolStripMenuItem.Name = "generateScriptToolStripMenuItem";
            this.generateScriptToolStripMenuItem.Size = new System.Drawing.Size(191, 36);
            this.generateScriptToolStripMenuItem.Text = "Generate Script";
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(243, 36);
            this.generateToolStripMenuItem.Text = "Generate...";
            this.generateToolStripMenuItem.Click += new System.EventHandler(this.generateToolStripMenuItem_Click);
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configGenerateScriptToolStripMenuItem,
            this.configConnectionStringToolStripMenuItem});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(243, 36);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // configGenerateScriptToolStripMenuItem
            // 
            this.configGenerateScriptToolStripMenuItem.Name = "configGenerateScriptToolStripMenuItem";
            this.configGenerateScriptToolStripMenuItem.Size = new System.Drawing.Size(366, 36);
            this.configGenerateScriptToolStripMenuItem.Text = "Config Generate Script";
            this.configGenerateScriptToolStripMenuItem.Click += new System.EventHandler(this.configGenerateScriptToolStripMenuItem_Click);
            // 
            // configConnectionStringToolStripMenuItem
            // 
            this.configConnectionStringToolStripMenuItem.Name = "configConnectionStringToolStripMenuItem";
            this.configConnectionStringToolStripMenuItem.Size = new System.Drawing.Size(366, 36);
            this.configConnectionStringToolStripMenuItem.Text = "Config Connection String";
            this.configConnectionStringToolStripMenuItem.Click += new System.EventHandler(this.connectionStringToolStripMenuItem_Click);
            // 
            // MenuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(892, 543);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(20, 20);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MenuView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.MenuView_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem generateScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configGenerateScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configConnectionStringToolStripMenuItem;
    }
}