namespace SnakeGame
{
    partial class GameArea
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
            this.lblGameOver = new System.Windows.Forms.Label();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.panelExit = new System.Windows.Forms.Panel();
            this.btnHighScores = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblTask = new System.Windows.Forms.Label();
            this.lblLevelTask = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.panelHiScores = new System.Windows.Forms.Panel();
            this.panelRestart = new System.Windows.Forms.Panel();
            this.panelPause = new System.Windows.Forms.Panel();
            this.panelSettings.SuspendLayout();
            this.panelExit.SuspendLayout();
            this.panelHiScores.SuspendLayout();
            this.panelRestart.SuspendLayout();
            this.panelPause.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGameOver
            // 
            this.lblGameOver.AutoSize = true;
            this.lblGameOver.BackColor = System.Drawing.Color.Purple;
            this.lblGameOver.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameOver.ForeColor = System.Drawing.Color.White;
            this.lblGameOver.Location = new System.Drawing.Point(86, 201);
            this.lblGameOver.Name = "lblGameOver";
            this.lblGameOver.Size = new System.Drawing.Size(417, 77);
            this.lblGameOver.TabIndex = 0;
            this.lblGameOver.Text = "GAME OVER";
            this.lblGameOver.Visible = false;
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.panelPause);
            this.panelSettings.Controls.Add(this.panelRestart);
            this.panelSettings.Controls.Add(this.panelHiScores);
            this.panelSettings.Controls.Add(this.panelExit);
            this.panelSettings.Controls.Add(this.lblScore);
            this.panelSettings.Controls.Add(this.lblTask);
            this.panelSettings.Controls.Add(this.lblLevelTask);
            this.panelSettings.Controls.Add(this.lblLevel);
            this.panelSettings.Location = new System.Drawing.Point(372, 28);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(200, 500);
            this.panelSettings.TabIndex = 1;
            // 
            // panelExit
            // 
            this.panelExit.Controls.Add(this.btnExit);
            this.panelExit.Location = new System.Drawing.Point(27, 430);
            this.panelExit.Name = "panelExit";
            this.panelExit.Size = new System.Drawing.Size(138, 38);
            this.panelExit.TabIndex = 8;
            // 
            // btnHighScores
            // 
            this.btnHighScores.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHighScores.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnHighScores.Location = new System.Drawing.Point(6, 4);
            this.btnHighScores.Name = "btnHighScores";
            this.btnHighScores.Size = new System.Drawing.Size(124, 31);
            this.btnHighScores.TabIndex = 7;
            this.btnHighScores.Text = "Highscores";
            this.btnHighScores.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnExit.Location = new System.Drawing.Point(6, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(124, 31);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnRestart
            // 
            this.btnRestart.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestart.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnRestart.Location = new System.Drawing.Point(6, 7);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(124, 31);
            this.btnRestart.TabIndex = 5;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            // 
            // btnPause
            // 
            this.btnPause.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnPause.Location = new System.Drawing.Point(6, 5);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(124, 31);
            this.btnPause.TabIndex = 4;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(12, 141);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(86, 23);
            this.lblScore.TabIndex = 3;
            this.lblScore.Text = "Score : 0";
            // 
            // lblTask
            // 
            this.lblTask.AutoSize = true;
            this.lblTask.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTask.Location = new System.Drawing.Point(12, 92);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(154, 23);
            this.lblTask.TabIndex = 2;
            this.lblTask.Text = "Reach 200 points";
            // 
            // lblLevelTask
            // 
            this.lblLevelTask.AutoSize = true;
            this.lblLevelTask.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevelTask.Location = new System.Drawing.Point(12, 69);
            this.lblLevelTask.Name = "lblLevelTask";
            this.lblLevelTask.Size = new System.Drawing.Size(104, 23);
            this.lblLevelTask.TabIndex = 1;
            this.lblLevelTask.Text = "Level task :";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevel.Location = new System.Drawing.Point(51, 26);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(95, 25);
            this.lblLevel.TabIndex = 0;
            this.lblLevel.Text = "LEVEL 1";
            // 
            // panelHiScores
            // 
            this.panelHiScores.Controls.Add(this.btnHighScores);
            this.panelHiScores.Location = new System.Drawing.Point(27, 389);
            this.panelHiScores.Name = "panelHiScores";
            this.panelHiScores.Size = new System.Drawing.Size(138, 38);
            this.panelHiScores.TabIndex = 10;
            // 
            // panelRestart
            // 
            this.panelRestart.Controls.Add(this.btnRestart);
            this.panelRestart.Location = new System.Drawing.Point(27, 348);
            this.panelRestart.Name = "panelRestart";
            this.panelRestart.Size = new System.Drawing.Size(138, 38);
            this.panelRestart.TabIndex = 11;
            // 
            // panelPause
            // 
            this.panelPause.Controls.Add(this.btnPause);
            this.panelPause.Location = new System.Drawing.Point(27, 307);
            this.panelPause.Name = "panelPause";
            this.panelPause.Size = new System.Drawing.Size(138, 38);
            this.panelPause.TabIndex = 12;
            // 
            // GameArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.lblGameOver);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameArea";
            this.Text = "Snake";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Game_KeyDown);
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.panelExit.ResumeLayout(false);
            this.panelHiScores.ResumeLayout(false);
            this.panelRestart.ResumeLayout(false);
            this.panelPause.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGameOver;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Button btnHighScores;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblTask;
        private System.Windows.Forms.Label lblLevelTask;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Panel panelExit;
        private System.Windows.Forms.Panel panelPause;
        private System.Windows.Forms.Panel panelRestart;
        private System.Windows.Forms.Panel panelHiScores;
    }
}

