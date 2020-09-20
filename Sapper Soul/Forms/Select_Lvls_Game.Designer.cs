namespace Sapper_Soul.Forms
{
    partial class Select_Lvls_Game
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
            this.SelectLevelLabel = new System.Windows.Forms.Label();
            this.OneLvl = new System.Windows.Forms.RadioButton();
            this.TwoLvl = new System.Windows.Forms.RadioButton();
            this.ThreeLvl = new System.Windows.Forms.RadioButton();
            this.StartGameBtn = new System.Windows.Forms.Button();
            this.CancelSelectLvlBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SelectLevelLabel
            // 
            this.SelectLevelLabel.AutoSize = true;
            this.SelectLevelLabel.Location = new System.Drawing.Point(123, 65);
            this.SelectLevelLabel.Name = "SelectLevelLabel";
            this.SelectLevelLabel.Size = new System.Drawing.Size(35, 13);
            this.SelectLevelLabel.TabIndex = 0;
            this.SelectLevelLabel.Text = "label1";
            // 
            // OneLvl
            // 
            this.OneLvl.AutoSize = true;
            this.OneLvl.Location = new System.Drawing.Point(126, 110);
            this.OneLvl.Name = "OneLvl";
            this.OneLvl.Size = new System.Drawing.Size(85, 17);
            this.OneLvl.TabIndex = 1;
            this.OneLvl.TabStop = true;
            this.OneLvl.Text = "radioButton1";
            this.OneLvl.UseVisualStyleBackColor = true;
            // 
            // TwoLvl
            // 
            this.TwoLvl.AutoSize = true;
            this.TwoLvl.Location = new System.Drawing.Point(126, 150);
            this.TwoLvl.Name = "TwoLvl";
            this.TwoLvl.Size = new System.Drawing.Size(85, 17);
            this.TwoLvl.TabIndex = 2;
            this.TwoLvl.TabStop = true;
            this.TwoLvl.Text = "radioButton2";
            this.TwoLvl.UseVisualStyleBackColor = true;
            // 
            // ThreeLvl
            // 
            this.ThreeLvl.AutoSize = true;
            this.ThreeLvl.Location = new System.Drawing.Point(126, 191);
            this.ThreeLvl.Name = "ThreeLvl";
            this.ThreeLvl.Size = new System.Drawing.Size(85, 17);
            this.ThreeLvl.TabIndex = 3;
            this.ThreeLvl.TabStop = true;
            this.ThreeLvl.Text = "radioButton3";
            this.ThreeLvl.UseVisualStyleBackColor = true;
            // 
            // StartGameBtn
            // 
            this.StartGameBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartGameBtn.Location = new System.Drawing.Point(137, 294);
            this.StartGameBtn.Name = "StartGameBtn";
            this.StartGameBtn.Size = new System.Drawing.Size(142, 44);
            this.StartGameBtn.TabIndex = 4;
            this.StartGameBtn.Text = "button1";
            this.StartGameBtn.UseVisualStyleBackColor = true;
            // 
            // CancelSelectLvlBtn
            // 
            this.CancelSelectLvlBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelSelectLvlBtn.Location = new System.Drawing.Point(402, 294);
            this.CancelSelectLvlBtn.Name = "CancelSelectLvlBtn";
            this.CancelSelectLvlBtn.Size = new System.Drawing.Size(142, 44);
            this.CancelSelectLvlBtn.TabIndex = 5;
            this.CancelSelectLvlBtn.Text = "button1";
            this.CancelSelectLvlBtn.UseVisualStyleBackColor = true;
            // 
            // Select_Lvls_Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(702, 386);
            this.Controls.Add(this.CancelSelectLvlBtn);
            this.Controls.Add(this.StartGameBtn);
            this.Controls.Add(this.ThreeLvl);
            this.Controls.Add(this.TwoLvl);
            this.Controls.Add(this.OneLvl);
            this.Controls.Add(this.SelectLevelLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Select_Lvls_Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select_Lvls_Game";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label SelectLevelLabel;
        private System.Windows.Forms.RadioButton OneLvl;
        private System.Windows.Forms.RadioButton TwoLvl;
        private System.Windows.Forms.RadioButton ThreeLvl;
        private System.Windows.Forms.Button StartGameBtn;
        private System.Windows.Forms.Button CancelSelectLvlBtn;
    }
}