using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hangman_Game
{
    /// <summary>
    /// Game loop to set-up the game
    /// </summary>
    public partial class Hangman : Form
    {
        /// <summary>
        /// global variables
        ///     hangingStepPicture : add a new picture if the input is wrong
        ///     stepToWin          : counts the number of steps remaining before claiming victory
        ///     letters_clicked    : array to know which objets have been clicked during the game
        ///     nbrOfClicked       : number of clicks peformed to iterate over the objets clicked
        /// </summary>
        int hangingStepPicture = 1;
        int stepsToWin;
        Button[] letters_clicked = new Button[15];
        int nbrOfClicks = 0;


        /// <summary>
        /// constructor
        /// </summary>
        public Hangman()
        {
            InitializeComponent();
        }

        /// <summary>
        /// set-up the game once the Form is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hangman_Load(object sender, EventArgs e)
        {
            PrepareEntryMessage();
        }

        /// <summary>
        /// set-up the entry message which will be hidden
        /// </summary>
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
        /// <summary>
        /// creation of the letter objects
        /// </summary>
        private void CreateAllLetters()
        {
            int INITIAL_POS_X_AXIS = 5;
            int INITIAL_POS_Y_AXIS = 25;
            int STEP = 5;
            int SIZE = 30;

            for(int k = 0; k < 26; k++)
            {
                Button letter = new Button();
                MyLetters.Controls.Add(letter);
                letter.Size = new Size(SIZE, SIZE);
                letter.Enabled = true;

                if (INITIAL_POS_X_AXIS + SIZE + STEP > MyLetters.Width)
                {
                    INITIAL_POS_X_AXIS = 5;
                    INITIAL_POS_Y_AXIS += SIZE + STEP;
                }
                
                letter.Location = new Point(INITIAL_POS_X_AXIS, INITIAL_POS_Y_AXIS);
                letter.Text = ((char)('A' + k)).ToString();
                letter.Click += new EventHandler(Letters_Click);
                INITIAL_POS_X_AXIS += SIZE + STEP;
            }
        }
        /// <summary>
        /// 5 steps :
        ///      step 1 : catch up the letter (char) from the letter (button)
        ///      step 2 : seaching for all the occurences of this letter is the selected word
        ///      step 3 : replace the underscore(s) by the character
        ///      step 4 : make appearing a new picture to hang the player if the letter not in the word
        ///      step 5 : call 'victory' message if needed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Letters_Click(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            letters_clicked[nbrOfClicks] = temp;
            nbrOfClicks++;
            temp.Enabled = false;
            char letter = char.Parse(temp.Text);
            int index = 0;
            bool hangThePlayer = true;
            
            do
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
            } while (index != -1);

            if (hangThePlayer)
            {
                HangingThePlayer();
            }

            if (stepsToWin == 0)
            {
                End("You won !");
            }
        }

        /// <summary>
        /// It will analyze once ENTER is pressed if the message is valid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EntryMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                EntryMessage.Text = EntryMessage.Text.ToUpper();
                if (!EntryMessage.Text.Equals("") && WordIsCorrect(EntryMessage.Text))
                {
                    MyLetters.Enabled = true;
                    stepsToWin = EntryMessage.Text.Length;
                    lblVictory.Text = EntryMessage.Text;
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

        /// <summary>
        /// control if the message entered is correct
        /// </summary>
        /// <param name="myWord">it takes the </param>
        /// <returns>returns the boolean correct</returns>
        private bool WordIsCorrect(string myWord)
        {
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

        /// <summary>
        /// Hide the EntryMessage by underscores
        /// </summary>
        /// <param name="message"></param>
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

       /// <summary>
       /// search for the index corresponding to a given char
       /// </summary>
       /// <param name="letter">letter to be found in the string</param>
       /// <param name="index">position where the search starts</param>
       /// <returns>The index where the char is or -1 if none of them are present in the string</returns>
        private int SearchForLetterIndex(char letter, int index)
        {
            int newIndex = lblVictory.Text.IndexOf(letter, index);
            return newIndex;
        }
 
        /// <summary>
        /// Get the char corresponding to the index previously found
        /// </summary>
        /// <param name="index"></param>
        /// <returns>the char to be shown to the player</returns>
        private char ShowTheCharacter(int index)
        {
            char ch = char.Parse(lblVictory.Text.Substring(index, 1));
            return ch;
        }
 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">Message with underscores in the label</param>
        /// <param name="index">Position where to change the letter</param>
        /// <param name="ch">Character to substitute to the underscore</param>
        private void ReplaceUnderscore(string message, int index, char ch)
        {
            char[] array = message.ToCharArray();
            array[index] = ch;
            message = new string(array);
            EntryMessage.Text = message;
        }

        /// <summary>
        /// Add a new hanging picture if wrong click
        /// </summary>
        private void HangingThePlayer()
        {
            pictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(WhichPicture());
            hangingStepPicture++;
        }

        /// <summary>
        /// select the corresponding picture and call the ending game
        /// </summary>
        /// <returns>the corresponding picture to be shown in the picture box</returns>
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
        /// <summary>
        /// Block all the Form for not activating further buttons
        /// Show the final message
        /// </summary>
        /// <param name="message">Message to guess which was stored in the label Victory</param>
        private void End(string message)
        {
            EntryMessage.Text = lblVictory.Text;
            lblVictory.Text = message;
            MyLetters.Enabled = false;
            EntryMessage.Enabled = false;
            lblVictory.Show();
        }

        /// <summary>
        /// Reset the game and initialize the number of clicks to 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReplay_Click(object sender, EventArgs e)
        {
            pictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject("pendu0");
            PrepareEntryMessage();
            ShowThePreviousClick();
            nbrOfClicks = 0;
        }

        /// <summary>
        /// Reactivate only the objects which have been previously clicked
        /// </summary>
        private void ShowThePreviousClick()
        {
            for(int k = 0; k < nbrOfClicks; k++)
            {
                letters_clicked[k].Enabled = true;
            }
        }
    }
}
