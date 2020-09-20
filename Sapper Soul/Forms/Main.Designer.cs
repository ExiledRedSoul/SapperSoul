namespace Sapper_Soul.Forms
{
    partial class Main
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
            this.AboutBtn = new System.Windows.Forms.Button();
            this.SettingsGameBtn = new System.Windows.Forms.Button();
            this.ExitApplicationBtn = new System.Windows.Forms.Button();
            this.StartGameBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            //
            // ExitApplicationBtn
            //
            this.ExitApplicationBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitApplicationBtn.Location = new System.Drawing.Point(284, 461);
            this.ExitApplicationBtn.Name = "ExitApplicationBtn";
            this.ExitApplicationBtn.Size = new System.Drawing.Size(439, 90);
            this.ExitApplicationBtn.TabIndex = 4;
            this.ExitApplicationBtn.Text = "Выйти";
            this.ExitApplicationBtn.UseVisualStyleBackColor = true;
            //
            // AboutBtn
            //
            this.AboutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AboutBtn.Location = new System.Drawing.Point(284, 368);
            this.AboutBtn.Name = "AboutBtn";
            this.AboutBtn.Size = new System.Drawing.Size(439, 90);
            this.AboutBtn.TabIndex = 3;
            this.AboutBtn.Text = "Об авторе";
            this.AboutBtn.UseVisualStyleBackColor = true;
            //
            //SettingGameBtn
            //
            this.SettingsGameBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsGameBtn.Location = new System.Drawing.Point(284, 272);
            this.SettingsGameBtn.Name = "SettingsGameBtn";
            this.SettingsGameBtn.Size = new System.Drawing.Size(439, 90);
            this.SettingsGameBtn.TabIndex = 2;
            this.SettingsGameBtn.Text = "Настройки";
            this.SettingsGameBtn.UseVisualStyleBackColor = true;
            // 
            // StartGameBtn
            // 
            this.StartGameBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartGameBtn.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartGameBtn.Location = new System.Drawing.Point(284, 176);
            this.StartGameBtn.Name = "StartGameBtn";
            this.StartGameBtn.Size = new System.Drawing.Size(439, 90);
            this.StartGameBtn.TabIndex = 0;
            this.StartGameBtn.Text = "Играть";
            this.StartGameBtn.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.StartGameBtn);
            this.panel1.Controls.Add(this.SettingsGameBtn);
            this.panel1.Controls.Add(this.AboutBtn);
            this.panel1.Controls.Add(this.ExitApplicationBtn);
            this.panel1.Location = new System.Drawing.Point(178, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(906, 565);
            this.panel1.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1283, 724);
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.Add(this.panel1);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button StartGameBtn;
        private System.Windows.Forms.Button AboutBtn;
        private System.Windows.Forms.Button SettingsGameBtn;
        private System.Windows.Forms.Button ExitApplicationBtn;
    }
}