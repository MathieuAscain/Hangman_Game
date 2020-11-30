namespace Hangman_Game
{
    partial class Hangman
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hangman));
            this.search = new System.Windows.Forms.GroupBox();
            this.txtWord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpTestLetters = new System.Windows.Forms.GroupBox();
            this.comboLetters = new System.Windows.Forms.ComboBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.lblLetters = new System.Windows.Forms.Label();
            this.lblVictory = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnReplay = new System.Windows.Forms.Button();
            this.search.SuspendLayout();
            this.grpTestLetters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // search
            // 
            this.search.Controls.Add(this.txtWord);
            this.search.Controls.Add(this.label1);
            this.search.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search.Location = new System.Drawing.Point(38, 22);
            this.search.Margin = new System.Windows.Forms.Padding(4);
            this.search.Name = "search";
            this.search.Padding = new System.Windows.Forms.Padding(4);
            this.search.Size = new System.Drawing.Size(340, 107);
            this.search.TabIndex = 0;
            this.search.TabStop = false;
            this.search.Text = "Search for a word";
            // 
            // txtWord
            // 
            this.txtWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWord.Location = new System.Drawing.Point(27, 43);
            this.txtWord.Margin = new System.Windows.Forms.Padding(4);
            this.txtWord.Name = "txtWord";
            this.txtWord.Size = new System.Drawing.Size(277, 45);
            this.txtWord.TabIndex = 1;
            this.txtWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWord_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 92);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 24);
            this.label1.TabIndex = 0;
            // 
            // grpTestLetters
            // 
            this.grpTestLetters.Controls.Add(this.comboLetters);
            this.grpTestLetters.Controls.Add(this.btnTest);
            this.grpTestLetters.Location = new System.Drawing.Point(42, 141);
            this.grpTestLetters.Name = "grpTestLetters";
            this.grpTestLetters.Size = new System.Drawing.Size(340, 121);
            this.grpTestLetters.TabIndex = 1;
            this.grpTestLetters.TabStop = false;
            this.grpTestLetters.Text = "Letters tested";
            // 
            // comboLetters
            // 
            this.comboLetters.FormattingEnabled = true;
            this.comboLetters.Location = new System.Drawing.Point(67, 51);
            this.comboLetters.Name = "comboLetters";
            this.comboLetters.Size = new System.Drawing.Size(84, 30);
            this.comboLetters.TabIndex = 1;
            this.comboLetters.SelectedIndexChanged += new System.EventHandler(this.comboLetters_SelectedIndexChanged);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(176, 43);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(77, 45);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "TEST";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lblLetters
            // 
            this.lblLetters.AutoSize = true;
            this.lblLetters.Location = new System.Drawing.Point(34, 292);
            this.lblLetters.Name = "lblLetters";
            this.lblLetters.Size = new System.Drawing.Size(366, 24);
            this.lblLetters.TabIndex = 2;
            this.lblLetters.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            // 
            // lblVictory
            // 
            this.lblVictory.AutoSize = true;
            this.lblVictory.Location = new System.Drawing.Point(50, 349);
            this.lblVictory.Name = "lblVictory";
            this.lblVictory.Size = new System.Drawing.Size(104, 24);
            this.lblVictory.TabIndex = 3;
            this.lblVictory.Text = "You won !";
            // 
            // pictureBox
            // 
            this.pictureBox.ErrorImage = null;
            this.pictureBox.Image = global::Hangman_Game.Properties.Resources.pendu0;
            this.pictureBox.InitialImage = global::Hangman_Game.Properties.Resources.pendu1;
            this.pictureBox.Location = new System.Drawing.Point(406, 22);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(315, 383);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            // 
            // btnReplay
            // 
            this.btnReplay.Image = ((System.Drawing.Image)(resources.GetObject("btnReplay.Image")));
            this.btnReplay.Location = new System.Drawing.Point(237, 331);
            this.btnReplay.Name = "btnReplay";
            this.btnReplay.Size = new System.Drawing.Size(96, 91);
            this.btnReplay.TabIndex = 5;
            this.btnReplay.UseVisualStyleBackColor = true;
            this.btnReplay.Click += new System.EventHandler(this.btnReplay_Click);
            // 
            // Hangman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 452);
            this.Controls.Add(this.btnReplay);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.lblVictory);
            this.Controls.Add(this.lblLetters);
            this.Controls.Add(this.grpTestLetters);
            this.Controls.Add(this.search);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Hangman";
            this.Text = "Hangman game";
            this.Load += new System.EventHandler(this.Hangman_Load);
            this.search.ResumeLayout(false);
            this.search.PerformLayout();
            this.grpTestLetters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWord;
        private System.Windows.Forms.GroupBox grpTestLetters;
        private System.Windows.Forms.ComboBox comboLetters;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lblLetters;
        private System.Windows.Forms.Label lblVictory;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btnReplay;
    }
}

