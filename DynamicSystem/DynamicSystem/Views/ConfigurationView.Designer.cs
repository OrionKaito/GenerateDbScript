namespace DynamicSystem.Views
{
    partial class ConfigurationView
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
            this.chklistboxTable = new System.Windows.Forms.CheckedListBox();
            this.chckAll = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chklistboxTable
            // 
            this.chklistboxTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chklistboxTable.FormattingEnabled = true;
            this.chklistboxTable.Location = new System.Drawing.Point(29, 47);
            this.chklistboxTable.Name = "chklistboxTable";
            this.chklistboxTable.Size = new System.Drawing.Size(586, 379);
            this.chklistboxTable.TabIndex = 1;
            this.chklistboxTable.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chklistboxTable_ItemCheck);
            // 
            // chckAll
            // 
            this.chckAll.AutoSize = true;
            this.chckAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chckAll.Location = new System.Drawing.Point(29, 12);
            this.chckAll.Name = "chckAll";
            this.chckAll.Size = new System.Drawing.Size(56, 29);
            this.chckAll.TabIndex = 2;
            this.chckAll.Text = "All";
            this.chckAll.UseVisualStyleBackColor = true;
            this.chckAll.CheckedChanged += new System.EventHandler(this.CheckAll_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(280, 437);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 33);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ConfigurationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 482);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chckAll);
            this.Controls.Add(this.chklistboxTable);
            this.Name = "ConfigurationView";
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.ConfigurationView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chklistboxTable;
        private System.Windows.Forms.CheckBox chckAll;
        private System.Windows.Forms.Button btnSave;
    }
}