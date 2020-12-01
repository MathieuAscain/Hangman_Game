using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hangman_Game
{
    public partial class Hangman : Form
    {
        int hangingStepPicture = 1;
        int stepsToWin;
        public Hangman()
        {
            InitializeComponent();
        }

        private void Hangman_Load(object sender, EventArgs e)
        {
            PrepareEntryMessage();
        }

        private void PrepareEntryMessage()
        {
            lblVictory.Text = "";
            EntryMessage.Enabled = true;
            MyLetters.Enabled = false;
            EntryMessage.Text = "";
            CreateAllLetters();
            EntryMessage.Focus();
            lblVictory.Hide();
            pictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject("pendu0");
            hangingStepPicture = 1;
        }

        private void CreateAllLetters()
        {
            for(int k = 0; k < 26; k++)
            {
                Button letter = new Button();
                MyLetters.Controls.Add(letter);
                letter.Location = new Point(10, 20 + 10 * k);
                letter.Text = ((char)('A' + k)).ToString();
                letter.Click += new EventHandler(Letters_Click);
            }
        }

        private void Letters_Click(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            temp.Enabled = false;
            char letter = char.Parse(temp.Text);
            int index = 0;
            bool hangThePlayer = true;
            while (index != -1)
            {
                index = SearchForLetterIndex(letter, index);
                if (index != -1)
                {
                    hangThePlayer = false;
                    stepsToWin--;
                    char ch = ShowTheCharacter(index);
                    ReplaceUnderscore(EntryMessage.Text, index, ch);
                    // search if any additional occurence of the same letter
                    index += 1;
                }
            }

            if (hangThePlayer)
            {
                HangingThePlayer();
            }

            // end of the game, victory
            if (stepsToWin == 0)
            {
                End("You won !");
            }
        }

        private void EntryMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!EntryMessage.Text.Equals("") && WordIsCorrect(EntryMessage.Text))
                {
                    MyLetters.Enabled = true;
                    stepsToWin = EntryMessage.Text.Length;
                    lblVictory.Text = EntryMessage.Text.ToUpper();
                    HideEntryMessage(lblVictory.Text);
                }
                else
                {
                    MessageBox.Show("The word can only contains characters without any accent or space");
                    EntryMessage.Text = "";
                    EntryMessage.Focus();
                }
            }
        }

        private bool WordIsCorrect(string myWord)
        {
            myWord = myWord.ToUpper();
            bool correct = true;
            for(int k = 0; k < myWord.Length; k++)
            {
                if(myWord[k] < 'A' || myWord[k] > 'Z')
                {
                    correct = false;
                }
            }
            return correct;
        }

        private void HideEntryMessage(string message)
        {
            string myString = "";
            foreach(char ch in message)
            {
                myString += "-";
            }
            EntryMessage.Text = myString;
            EntryMessage.Enabled = false;
        }

       
        private int SearchForLetterIndex(char letter, int index)
        {
            int newIndex = lblVictory.Text.IndexOf(letter, index);
            return newIndex;
        }
 
        private char ShowTheCharacter(int index)
        {
            char ch = char.Parse(lblVictory.Text.Substring(index, 1));
            return ch;
        }
 
        private void ReplaceUnderscore(string message, int index, char ch)
        {
            string s = message;
            char[] array = s.ToCharArray();
            array[index] = ch;
            s = new string(array);
            EntryMessage.Text = s;
        }

        private void HangingThePlayer()
        {
            pictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(WhichPicture());
            hangingStepPicture++;
        }

        private string WhichPicture()
        {
            string myPicture = "";
            switch(hangingStepPicture)
            {
                case 1:
                    myPicture = "pendu1";
                    break;
                case 2:
                    myPicture = "pendu2";
                    break;
                case 3:
                    myPicture = "pendu3";
                    break;
                case 4:
                    myPicture = "pendu4";
                    break;
                case 5:
                    myPicture = "pendu5";
                    break;
                case 6:
                   myPicture = "pendu6";
                   break;
                case 7:
                    myPicture = "pendu7";
                    break;
                case 8:
                    myPicture = "pendu8";
                    break;
                case 9:
                    myPicture = "pendu9";
                    break;
                case 10:
                    myPicture = "pendu10";
                    End("You lost !");
                    break;
            }

            return myPicture;
        }

        private void End(string message)
        {
            EntryMessage.Text = lblVictory.Text;
            lblVictory.Text = message;
            MyLetters.Enabled = false;
            EntryMessage.Enabled = false;
            lblVictory.Show();
        }

        private void btnReplay_Click(object sender, EventArgs e)
        {
            pictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject("pendu0");
            PrepareEntryMessage();
        }
    }
}
