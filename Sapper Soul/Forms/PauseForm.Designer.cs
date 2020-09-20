namespace Sapper_Soul.Forms
{
    partial class PauseForm
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
            this.ResumeBtn = new System.Windows.Forms.Button();
            this.SettingsBtn = new System.Windows.Forms.Button();
            this.MainMenuBtn = new System.Windows.Forms.Button();
            this.ExitToApplicationBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ResumeBtn
            // 
            this.ResumeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResumeBtn.Location = new System.Drawing.Point(51, 71);
            this.ResumeBtn.Name = "ResumeBtn";
            this.ResumeBtn.Size = new System.Drawing.Size(308, 64);
            this.ResumeBtn.TabIndex = 0;
            this.ResumeBtn.Text = "Resume";
            this.ResumeBtn.UseVisualStyleBackColor = true;
            // 
            // SettingsBtn
            // 
            this.SettingsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsBtn.Location = new System.Drawing.Point(51, 165);
            this.SettingsBtn.Name = "SettingsBtn";
            this.SettingsBtn.Size = new System.Drawing.Size(308, 64);
            this.SettingsBtn.TabIndex = 1;
            this.SettingsBtn.Text = "Settings";
            this.SettingsBtn.UseVisualStyleBackColor = true;
            // 
            // MainMenuBtn
            // 
            this.MainMenuBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MainMenuBtn.Location = new System.Drawing.Point(51, 260);
            this.MainMenuBtn.Name = "MainMenuBtn";
            this.MainMenuBtn.Size = new System.Drawing.Size(308, 64);
            this.MainMenuBtn.TabIndex = 2;
            this.MainMenuBtn.Text = "Main menu";
            this.MainMenuBtn.UseVisualStyleBackColor = true;
            // 
            // ExitToApplicationBtn
            // 
            this.ExitToApplicationBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitToApplicationBtn.Location = new System.Drawing.Point(51, 353);
            this.ExitToApplicationBtn.Name = "ExitToApplicationBtn";
            this.ExitToApplicationBtn.Size = new System.Drawing.Size(308, 64);
            this.ExitToApplicationBtn.TabIndex = 3;
            this.ExitToApplicationBtn.Text = "Exit";
            this.ExitToApplicationBtn.UseVisualStyleBackColor = true;
            // 
            // PauseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(415, 494);
            this.Controls.Add(this.ExitToApplicationBtn);
            this.Controls.Add(this.MainMenuBtn);
            this.Controls.Add(this.SettingsBtn);
            this.Controls.Add(this.ResumeBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PauseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PauseForm";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ResumeBtn;
        private System.Windows.Forms.Button SettingsBtn;
        private System.Windows.Forms.Button MainMenuBtn;
        private System.Windows.Forms.Button ExitToApplicationBtn;
    }
}