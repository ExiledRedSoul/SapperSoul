namespace Sapper_Soul.Forms
{
    partial class SettingsForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.SaveAndExitBtn = new System.Windows.Forms.Button();
            this.ApplyBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.GeneralPanel = new System.Windows.Forms.Panel();
            this.SelectLanguage = new System.Windows.Forms.ComboBox();
            this.LabelLanguage = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SaveAndExitBtn);
            this.panel1.Controls.Add(this.ApplyBtn);
            this.panel1.Controls.Add(this.CancelBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(0, 544);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1060, 72);
            this.panel1.TabIndex = 0;
            // 
            // SaveAndExitBtn
            // 
            this.SaveAndExitBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.SaveAndExitBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.SaveAndExitBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.SaveAndExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveAndExitBtn.ForeColor = System.Drawing.Color.Black;
            this.SaveAndExitBtn.Location = new System.Drawing.Point(700, 17);
            this.SaveAndExitBtn.Name = "SaveAndExitBtn";
            this.SaveAndExitBtn.Size = new System.Drawing.Size(112, 39);
            this.SaveAndExitBtn.TabIndex = 3;
            this.SaveAndExitBtn.Text = "Сохранить";
            this.SaveAndExitBtn.UseVisualStyleBackColor = true;
            // 
            // ApplyBtn
            // 
            this.ApplyBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.ApplyBtn.Enabled = false;
            this.ApplyBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ApplyBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ApplyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ApplyBtn.ForeColor = System.Drawing.Color.Black;
            this.ApplyBtn.Location = new System.Drawing.Point(818, 17);
            this.ApplyBtn.Name = "ApplyBtn";
            this.ApplyBtn.Size = new System.Drawing.Size(112, 39);
            this.ApplyBtn.TabIndex = 2;
            this.ApplyBtn.Text = "Принять";
            this.ApplyBtn.UseVisualStyleBackColor = true;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.CancelBtn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.CancelBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBtn.ForeColor = System.Drawing.Color.Red;
            this.CancelBtn.Location = new System.Drawing.Point(936, 17);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(112, 39);
            this.CancelBtn.TabIndex = 1;
            this.CancelBtn.Text = "Отмена";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // GeneralPanel
            // 
            this.GeneralPanel.Controls.Add(this.SelectLanguage);
            this.GeneralPanel.Controls.Add(this.LabelLanguage);
            this.GeneralPanel.Location = new System.Drawing.Point(185, 22);
            this.GeneralPanel.Name = "GeneralPanel";
            this.GeneralPanel.Size = new System.Drawing.Size(847, 499);
            this.GeneralPanel.TabIndex = 1;
            this.GeneralPanel.Visible = false;
            // 
            // SelectLanguage
            // 
            this.SelectLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectLanguage.FormattingEnabled = true;
            this.SelectLanguage.Location = new System.Drawing.Point(21, 43);
            this.SelectLanguage.Name = "SelectLanguage";
            this.SelectLanguage.Size = new System.Drawing.Size(161, 21);
            this.SelectLanguage.TabIndex = 1;
            // 
            // LabelLanguage
            // 
            this.LabelLanguage.AutoSize = true;
            this.LabelLanguage.Location = new System.Drawing.Point(24, 20);
            this.LabelLanguage.Name = "LabelLanguage";
            this.LabelLanguage.Size = new System.Drawing.Size(35, 13);
            this.LabelLanguage.TabIndex = 0;
            this.LabelLanguage.Text = "Язык";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1060, 616);
            this.Controls.Add(this.GeneralPanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingsForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button SaveAndExitBtn;
        private System.Windows.Forms.Button ApplyBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Panel GeneralPanel;
        private System.Windows.Forms.ComboBox SelectLanguage;
        private System.Windows.Forms.Label LabelLanguage;
    }
}