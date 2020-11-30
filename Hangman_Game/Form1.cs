using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hangman_Game
{
    public partial class Hangman : Form
    {
        // counter to show the right picture to hang the player
        int wrongClick;
        // counter to check how many letters have been found to show victory
        int rightClick;
        /// <summary>
        /// Initialization of graphic objects
        /// </summary>
        public Hangman()
        {
            InitializeComponent();
        }

        /// <summary>
        /// game event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hangman_Load(object sender, EventArgs e)
        {
            // preparation of graphic objects for the phase 1 (word selection)
            PreparationPhase1();
        }
        /// <summary>
        /// method for the first phase of the game
        /// </summary>
        private void PreparationPhase1()
        {
            // unenable the groupbox for the phase 2 (letters proposal)
            grpTestLetters.Enabled = false;
            // clear the letters label
            lblLetters.Text = "";
            // clear the message
            lblVictory.Text = "";
            // activate, clear and focus on the word selection area
            txtWord.Enabled = true;
            txtWord.Text = "";
            txtWord.Focus();
            // set wrongClick to 1 to search for hanging pictures
            wrongClick = 1;
            // hide the result stored in the label victory
            lblVictory.Hide();
        }
        /// <summary>
        /// event when the first player as pressed ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            // if ENTER has been pressed
            if (e.KeyChar == (char)Keys.Enter)
            {
                // if the word to be find is not empty
                // and if the word to be find fulfill requirements
                if(!txtWord.Text.Equals("") && WordIsCorrect(txtWord.Text))
                {
                    // value the number of characters to be found
                    rightClick = txtWord.Text.Length;
                    // word to be find hidden in victory label
                    lblVictory.Text = txtWord.Text.ToUpper();
                    // replace all chars in the word by underscores
                    CharToUnderscore(lblVictory.Text);
                    // set the step 2 for the second player
                    PreparationPhase2();
                }
                else
                {
                    // the word selected is uncorrect, clear the area
                    MessageBox.Show("The word can only contains characters without any accent or space");
                    txtWord.Text = "";
                    txtWord.Focus();
                }
            }
        }
        /// <summary>
        /// check if the word selected is only made by letters
        /// </summary>
        /// <param name="myWord"></param>
        /// <returns>boolean value contained in 'correct' variable</returns>
        private bool WordIsCorrect(string myWord)
        {
            // transform the word selected to uppercase word
            myWord = myWord.ToUpper();
            bool correct = true;
            // iteration over all the length of the word
            for(int k = 0; k < myWord.Length; k++)
            {
                // check if each letter is within A and Z
                if(myWord[k] < 'A' || myWord[k] > 'Z')
                {
                    correct = false;
                }
            }
            // return true or false
            return correct;
        }

        /// <summary>
        /// change the initial message to underscores
        /// </summary>
        /// <param name="message"></param>
        private void CharToUnderscore(string message)
        {
            string myString = "";
            // iteration over all the length of the message
            foreach(char ch in message)
            {
                // concatenate underscore
                myString += "-";
            }

            // save the message to the textbox with underscores
            txtWord.Text = myString;
        }

        /// <summary>
        /// Preparation of phase 2 (searching for a word)
        /// </summary>
        private void PreparationPhase2()
        {
            // activate the area for the phase 2 (letters proposal)
            grpTestLetters.Enabled = true;
            //unactivate the area of the text containing the word
            txtWord.Enabled = false;
            // fill the combobox with the letters
            FillComboLetters();
            // focus on the test button
            btnTest.Focus();
        }

        /// <summary>
        /// fill the combobox with the alphabet letters
        /// </summary>
        private void FillComboLetters()
        {
            comboLetters.Items.Clear();
            for (int k = 0; k < 26; k++)
            {
                comboLetters.Items.Add((char)('A' + k));
            }
            comboLetters.SelectedIndex = 0;
        }

        /// <summary>
        /// event when a letter has been selected in the combo
        /// focus on the test button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboLetters_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnTest.Focus();
        }

        /// <summary>
        /// Clic event on the TEST button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                // recovery of the letter, show in the added letters list and delete from the combo
                char letter = char.Parse(comboLetters.SelectedItem.ToString());
                lblLetters.Text += letter;
                //search if letter selected in combobox is in the word
                // variable index used for the search sets to 0
                int index = 0;
                // control if needs to hang the player
                bool hangThePlayer = true;
                // while a same letter is still in the word, -1 returned if none
                while(index != -1)
                {
                    // search for the index position of the word
                    index = SearchForLetterIndex(letter, index);
                    // if the letter is in the word
                    if (index != -1)
                    {
                        // do not hang the player
                        hangThePlayer = false;
                        // one char less to be found
                        rightClick--;
                        // catch up the char at the corresponding index
                        char ch = ShowTheCharacter(index);
                        // show the letter in the textbox at the requested index
                        ReplaceUnderscore(txtWord.Text, index, ch);
                        // increment to search at the next position if another same letter still present
                        index += 1;
                    }
                }
                // if it needs to hang the player
                if(hangThePlayer)
                {
                    HangingThePlayer();
                }
                
                // remove the studied letter in the combobox
                comboLetters.Items.RemoveAt(comboLetters.SelectedIndex);
                // positionning again the combobox to the first index
                comboLetters.SelectedIndex = 0;

                // end of the game, victory
                if (rightClick == 0)
                {
                    End("You won !");
                }
            }

            catch
            {
                // case if an attemp to remove a letter while the combobox is empty
                // usually that is not the case as the word should come before
                grpTestLetters.Enabled = false;
            }
        }
        /// <summary>
        /// search for the index position of a given letter in the word given by player 1
        /// </summary>
        /// <param name="letter"></param>
        /// <param name="index"></param>
        /// <returns>index of the letter</returns>
        private int SearchForLetterIndex(char letter, int index)
        {
            int newIndex = lblVictory.Text.IndexOf(letter, index);
            return newIndex;
        }
        /// <summary>
        /// get the char corresponding to the letter at a given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>letter to be added in the textbox</returns>
        private char ShowTheCharacter(int index)
        {
            // get the substring (string) from a given index
            char ch = char.Parse(lblVictory.Text.Substring(index, 1));
            // return the letter parsed in char
            return ch;
        }
        /// <summary>
        /// replace underscore by the letter corresponding to a given index
        /// </summary>
        /// <param name="message"></param>
        /// <param name="index"></param>
        /// <param name="ch"></param>
        private void ReplaceUnderscore(string message, int index, char ch)
        {
            // building a char array to substitute at a given index an underscore by a given char
            string s = message;
            char[] array = s.ToCharArray();
            array[index] = ch;
            s = new string(array);
            // save the result in the textbox to be shown at the player 2
            txtWord.Text = s;
        }
        /// <summary>
        /// wrong click from the player
        /// it will research the corressponding picture the be shown in the pictureBox
        /// </summary>
        private void HangingThePlayer()
        {
            pictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(WhichPicture());
            // increment the number of wrong clicks for the next picture
            wrongClick++;
        }
        /// <summary>
        /// it will research the right picture to be sent to the function 'HangingThePlayer'
        /// </summary>
        /// <returns>the string corresponding to the name of the picture</returns>
        private string WhichPicture()
        {
            string myPicture = "";
            switch(wrongClick)
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
        /// <summary>
        /// end of the game, used for both losing or winning the game
        /// show to the terminal the final message
        /// </summary>
        /// <param name="message"></param>
        private void End(string message)
        {
            txtWord.Text = lblVictory.Text;
            grpTestLetters.Enabled = false;
            lblVictory.Text = message;
            lblVictory.Show();
        }

        /// <summary>
        /// Event on the replay button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReplay_Click(object sender, EventArgs e)
        {
            // preparation of graphic objects for the phase 1 (word selection)
            pictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject("pendu0");
            PreparationPhase1();
        }
    }
}
