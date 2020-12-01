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
            this.EntryMessage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblVictory = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnReplay = new System.Windows.Forms.Button();
            this.MyLetters = new System.Windows.Forms.GroupBox();
            this.search.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // search
            // 
            this.search.Controls.Add(this.EntryMessage);
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
            // EntryMessage
            // 
            this.EntryMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EntryMessage.Location = new System.Drawing.Point(27, 43);
            this.EntryMessage.Margin = new System.Windows.Forms.Padding(4);
            this.EntryMessage.Name = "EntryMessage";
            this.EntryMessage.Size = new System.Drawing.Size(277, 45);
            this.EntryMessage.TabIndex = 1;
            this.EntryMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EntryMessage_KeyPress);
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
            // MyLetters
            // 
            this.MyLetters.Location = new System.Drawing.Point(38, 141);
            this.MyLetters.Name = "MyLetters";
            this.MyLetters.Size = new System.Drawing.Size(340, 162);
            this.MyLetters.TabIndex = 6;
            this.MyLetters.TabStop = false;
            this.MyLetters.Text = "Letters selection";
            // 
            // Hangman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 452);
            this.Controls.Add(this.MyLetters);
            this.Controls.Add(this.btnReplay);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.lblVictory);
            this.Controls.Add(this.search);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Hangman";
            this.Text = "Hangman game";
            this.Load += new System.EventHandler(this.Hangman_Load);
            this.search.ResumeLayout(false);
            this.search.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox EntryMessage;
        private System.Windows.Forms.Label lblVictory;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btnReplay;
        private System.Windows.Forms.GroupBox MyLetters;
    }
}

