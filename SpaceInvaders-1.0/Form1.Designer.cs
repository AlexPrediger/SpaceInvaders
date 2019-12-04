namespace SpaceInvaders_1._0
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AnimationTimer = new System.Windows.Forms.Timer(this.components);
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.ShotDelayTimer = new System.Windows.Forms.Timer(this.components);
            this.livesLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.startConditionLabel = new System.Windows.Forms.Label();
            this.gameOverLabel = new System.Windows.Forms.Label();
            this.scoredPointsLabel = new System.Windows.Forms.Label();
            this.readLabel = new System.Windows.Forms.Label();
            this.writeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AnimationTimer
            // 
            this.AnimationTimer.Tick += new System.EventHandler(this.AnimationTimer_Tick);
            // 
            // GameTimer
            // 
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // ShotDelayTimer
            // 
            this.ShotDelayTimer.Tick += new System.EventHandler(this.ShotDelayTimer_Tick);
            // 
            // livesLabel
            // 
            this.livesLabel.AutoSize = true;
            this.livesLabel.BackColor = System.Drawing.Color.Transparent;
            this.livesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.livesLabel.ForeColor = System.Drawing.Color.White;
            this.livesLabel.Location = new System.Drawing.Point(1085, 9);
            this.livesLabel.Name = "livesLabel";
            this.livesLabel.Size = new System.Drawing.Size(87, 25);
            this.livesLabel.TabIndex = 0;
            this.livesLabel.Text = "Lives: 3";
            this.livesLabel.Visible = false;
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.Color.White;
            this.scoreLabel.Location = new System.Drawing.Point(12, 9);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(96, 25);
            this.scoreLabel.TabIndex = 1;
            this.scoreLabel.Text = "Points: 0";
            this.scoreLabel.Visible = false;
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.Red;
            this.titleLabel.Location = new System.Drawing.Point(397, 20);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(333, 39);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "SPACE INVADERS";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startConditionLabel
            // 
            this.startConditionLabel.AutoSize = true;
            this.startConditionLabel.BackColor = System.Drawing.Color.Transparent;
            this.startConditionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startConditionLabel.ForeColor = System.Drawing.Color.Blue;
            this.startConditionLabel.Location = new System.Drawing.Point(410, 77);
            this.startConditionLabel.Name = "startConditionLabel";
            this.startConditionLabel.Size = new System.Drawing.Size(269, 39);
            this.startConditionLabel.TabIndex = 3;
            this.startConditionLabel.Text = "Press \'S\' to start";
            // 
            // gameOverLabel
            // 
            this.gameOverLabel.AutoSize = true;
            this.gameOverLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameOverLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameOverLabel.ForeColor = System.Drawing.Color.Red;
            this.gameOverLabel.Location = new System.Drawing.Point(410, 152);
            this.gameOverLabel.Name = "gameOverLabel";
            this.gameOverLabel.Size = new System.Drawing.Size(197, 39);
            this.gameOverLabel.TabIndex = 4;
            this.gameOverLabel.Text = "Game Over";
            this.gameOverLabel.Visible = false;
            // 
            // scoredPointsLabel
            // 
            this.scoredPointsLabel.AutoSize = true;
            this.scoredPointsLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoredPointsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoredPointsLabel.ForeColor = System.Drawing.Color.Blue;
            this.scoredPointsLabel.Location = new System.Drawing.Point(407, 211);
            this.scoredPointsLabel.Name = "scoredPointsLabel";
            this.scoredPointsLabel.Size = new System.Drawing.Size(273, 33);
            this.scoredPointsLabel.TabIndex = 5;
            this.scoredPointsLabel.Text = "You scored 0 points";
            // 
            // readLabel
            // 
            this.readLabel.AutoSize = true;
            this.readLabel.BackColor = System.Drawing.Color.Transparent;
            this.readLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.readLabel.ForeColor = System.Drawing.Color.Red;
            this.readLabel.Location = new System.Drawing.Point(414, 278);
            this.readLabel.Name = "readLabel";
            this.readLabel.Size = new System.Drawing.Size(360, 29);
            this.readLabel.TabIndex = 6;
            this.readLabel.Text = "Press \'r\' to read scores from disk";
            // 
            // writeLabel
            // 
            this.writeLabel.AutoSize = true;
            this.writeLabel.BackColor = System.Drawing.Color.Transparent;
            this.writeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.writeLabel.ForeColor = System.Drawing.Color.Red;
            this.writeLabel.Location = new System.Drawing.Point(414, 331);
            this.writeLabel.Name = "writeLabel";
            this.writeLabel.Size = new System.Drawing.Size(345, 29);
            this.writeLabel.TabIndex = 7;
            this.writeLabel.Text = "Press \'w\' to write scores to disk";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.writeLabel);
            this.Controls.Add(this.readLabel);
            this.Controls.Add(this.scoredPointsLabel);
            this.Controls.Add(this.gameOverLabel);
            this.Controls.Add(this.startConditionLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.livesLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer AnimationTimer;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Timer ShotDelayTimer;
        private System.Windows.Forms.Label livesLabel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label startConditionLabel;
        private System.Windows.Forms.Label gameOverLabel;
        private System.Windows.Forms.Label scoredPointsLabel;
        private System.Windows.Forms.Label readLabel;
        private System.Windows.Forms.Label writeLabel;
    }
}

