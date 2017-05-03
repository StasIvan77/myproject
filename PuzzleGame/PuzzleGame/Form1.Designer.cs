namespace PuzzleGame
{
    partial class PuzzleGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public delegate void deleg(string S);
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
        public void Method(string s)
        {
            this.labelStatus.Text += s + "\r\n";
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonImageBrowse = new System.Windows.Forms.Button();
            this.textboxImagePath = new System.Windows.Forms.TextBox();
            this.groupboxPuzzle = new System.Windows.Forms.GroupBox();
            this.groupboxPlayMode = new System.Windows.Forms.GroupBox();
            this.buttonLevel4 = new System.Windows.Forms.Button();
            this.buttonLevel3 = new System.Windows.Forms.Button();
            this.buttonLevel2 = new System.Windows.Forms.Button();
            this.buttonLevel1 = new System.Windows.Forms.Button();
            this.groupboxStatus = new System.Windows.Forms.GroupBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonComputerTry = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupboxPlayMode.SuspendLayout();
            this.groupboxStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonImageBrowse);
            this.groupBox1.Controls.Add(this.textboxImagePath);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 50);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose Image";
            // 
            // buttonImageBrowse
            // 
            this.buttonImageBrowse.Location = new System.Drawing.Point(450, 17);
            this.buttonImageBrowse.Name = "buttonImageBrowse";
            this.buttonImageBrowse.Size = new System.Drawing.Size(73, 23);
            this.buttonImageBrowse.TabIndex = 1;
            this.buttonImageBrowse.Text = "...";
            this.buttonImageBrowse.UseVisualStyleBackColor = true;
            this.buttonImageBrowse.Click += new System.EventHandler(this.buttonImageBrowse_Click);
            // 
            // textboxImagePath
            // 
            this.textboxImagePath.Location = new System.Drawing.Point(6, 19);
            this.textboxImagePath.Name = "textboxImagePath";
            this.textboxImagePath.Size = new System.Drawing.Size(438, 20);
            this.textboxImagePath.TabIndex = 0;
            // 
            // groupboxPuzzle
            // 
            this.groupboxPuzzle.Location = new System.Drawing.Point(12, 68);
            this.groupboxPuzzle.Name = "groupboxPuzzle";
            this.groupboxPuzzle.Size = new System.Drawing.Size(444, 444);
            this.groupboxPuzzle.TabIndex = 1;
            this.groupboxPuzzle.TabStop = false;
            this.groupboxPuzzle.Text = "Puzzle";
            this.groupboxPuzzle.Visible = false;
            // 
            // groupboxPlayMode
            // 
            this.groupboxPlayMode.Controls.Add(this.buttonLevel4);
            this.groupboxPlayMode.Controls.Add(this.buttonLevel3);
            this.groupboxPlayMode.Controls.Add(this.buttonLevel2);
            this.groupboxPlayMode.Controls.Add(this.buttonLevel1);
            this.groupboxPlayMode.Location = new System.Drawing.Point(462, 68);
            this.groupboxPlayMode.Name = "groupboxPlayMode";
            this.groupboxPlayMode.Size = new System.Drawing.Size(80, 131);
            this.groupboxPlayMode.TabIndex = 2;
            this.groupboxPlayMode.TabStop = false;
            this.groupboxPlayMode.Text = "Play Mode";
            this.groupboxPlayMode.Visible = false;
            // 
            // buttonLevel4
            // 
            this.buttonLevel4.Location = new System.Drawing.Point(2, 105);
            this.buttonLevel4.Name = "buttonLevel4";
            this.buttonLevel4.Size = new System.Drawing.Size(75, 23);
            this.buttonLevel4.TabIndex = 3;
            this.buttonLevel4.Text = "Level 4";
            this.buttonLevel4.UseVisualStyleBackColor = true;
            this.buttonLevel4.Click += new System.EventHandler(this.buttonLevel4_Click);
            // 
            // buttonLevel3
            // 
            this.buttonLevel3.Location = new System.Drawing.Point(2, 76);
            this.buttonLevel3.Name = "buttonLevel3";
            this.buttonLevel3.Size = new System.Drawing.Size(75, 23);
            this.buttonLevel3.TabIndex = 2;
            this.buttonLevel3.Text = "Level 3";
            this.buttonLevel3.UseVisualStyleBackColor = true;
            this.buttonLevel3.Click += new System.EventHandler(this.buttonLevel3_Click);
            // 
            // buttonLevel2
            // 
            this.buttonLevel2.Location = new System.Drawing.Point(2, 47);
            this.buttonLevel2.Name = "buttonLevel2";
            this.buttonLevel2.Size = new System.Drawing.Size(75, 23);
            this.buttonLevel2.TabIndex = 1;
            this.buttonLevel2.Text = "Level 2";
            this.buttonLevel2.UseVisualStyleBackColor = true;
            this.buttonLevel2.Click += new System.EventHandler(this.buttonLevel2_Click);
            // 
            // buttonLevel1
            // 
            this.buttonLevel1.Location = new System.Drawing.Point(2, 19);
            this.buttonLevel1.Name = "buttonLevel1";
            this.buttonLevel1.Size = new System.Drawing.Size(75, 23);
            this.buttonLevel1.TabIndex = 0;
            this.buttonLevel1.Text = "Level 1";
            this.buttonLevel1.UseVisualStyleBackColor = true;
            this.buttonLevel1.Click += new System.EventHandler(this.buttonLevel1_Click);
            // 
            // groupboxStatus
            // 
            this.groupboxStatus.Controls.Add(this.labelStatus);
            this.groupboxStatus.Location = new System.Drawing.Point(464, 203);
            this.groupboxStatus.Name = "groupboxStatus";
            this.groupboxStatus.Size = new System.Drawing.Size(78, 85);
            this.groupboxStatus.TabIndex = 3;
            this.groupboxStatus.TabStop = false;
            this.groupboxStatus.Text = "Status";
            this.groupboxStatus.Visible = false;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(7, 20);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(24, 13);
            this.labelStatus.TabIndex = 0;
            this.labelStatus.Text = "Idle";
            // 
            // buttonComputerTry
            // 
            this.buttonComputerTry.Location = new System.Drawing.Point(464, 489);
            this.buttonComputerTry.Name = "buttonComputerTry";
            this.buttonComputerTry.Size = new System.Drawing.Size(75, 23);
            this.buttonComputerTry.TabIndex = 4;
            this.buttonComputerTry.Text = "Comp Auto";
            this.buttonComputerTry.UseVisualStyleBackColor = true;
            this.buttonComputerTry.Visible = false;
            this.buttonComputerTry.Click += new System.EventHandler(this.buttonComputerTry_Click);
            // 
            // PuzzleGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 521);
            this.Controls.Add(this.buttonComputerTry);
            this.Controls.Add(this.groupboxStatus);
            this.Controls.Add(this.groupboxPlayMode);
            this.Controls.Add(this.groupboxPuzzle);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "PuzzleGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Puzzle Game";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupboxPlayMode.ResumeLayout(false);
            this.groupboxStatus.ResumeLayout(false);
            this.groupboxStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textboxImagePath;
        private System.Windows.Forms.Button buttonImageBrowse;
        private System.Windows.Forms.GroupBox groupboxPuzzle;
        private System.Windows.Forms.GroupBox groupboxPlayMode;
        private System.Windows.Forms.Button buttonLevel2;
        private System.Windows.Forms.Button buttonLevel1;
        private System.Windows.Forms.Button buttonLevel4;
        private System.Windows.Forms.Button buttonLevel3;
        private System.Windows.Forms.GroupBox groupboxStatus;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonComputerTry;
    }
}

