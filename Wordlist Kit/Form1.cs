using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PA_4_Gelyana_Vara
{
    public partial class Form1 : Form
    {
        String[] dictionary = Properties.Resources.WordList.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);

        public Form1()
        {

            InitializeComponent();
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

 
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.BeginUpdate();
            listBox1.Items.Clear();
            foreach (string word in dictionary)
                listBox1.Items.Add(word);
            listBox1.EndUpdate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string rhyme = textBox1.Text;  //grabs text inputted from text box
            int count = 0;
            listBox1.Items.Clear();
            listBox1.BeginUpdate();
            foreach (string word in dictionary)
            {
                if (word.EndsWith(rhyme))
                {
                    listBox1.Items.Add(word);
                }
            }
            listBox1.EndUpdate();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string scrabble = textBox1.Text;
            string tempWord;
            int containsScrabble = 0;
            int wordIndex = 0;


            //The outter foreach loop takes in each line of words one by one from the List 
            //individually and stores them in the variable 'words' which also stores them in 
            //'tempWord'. The inner foreach loop will check through all letters in the string 
            //'scrabble' against the words in 'tempword' from the text file to find words that 
            //can be made from the string of characters. 
            listBox1.Items.Clear();
            listBox1.BeginUpdate();
            foreach (string words in dictionary)
            {
                tempWord = words;
                foreach (char letter in scrabble)
                {

                    //If the Word from the text file contains a letter from the 'scrabble' string,
                    //'containsScrabble' will act as a counter for the amount of letters that match.
                    // Also if the letter matches it will be deleted from 'tempword'. This takes care 
                    // of a letter being counted twice in a word.  
                    if (tempWord.Contains(letter))
                    {
                        containsScrabble = containsScrabble + 1;
                        wordIndex = tempWord.IndexOf(letter);
                        tempWord = tempWord.Remove(wordIndex, 1);
                    }
                }

                //A word will only be printed if the 'word' length is equal to the amount 
                //of letters matched counted by 'containsScrabble' and the word length is greater 
                //than 3. This makes sure that the the entire 'word' is created from the 
                //'scrabble' letters.

                if (containsScrabble == words.Length && (words.Length >= 3))
                {
                    listBox1.Items.Add(words);
                }

                //Resets counter
                containsScrabble = 0;

            }
            listBox1.EndUpdate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string morphWord;
            string tempWord;
            int containsMorphWord = 0;

            //The while loop takes in each line of words from the text file individually 
            //and stores them in the variable 'word' which will iterate through
            //the wordlist. The foreach loop runs through each letter in the string
            //'morphword' to find words that disagree by one letter.
            listBox1.Items.Clear();
            listBox1.BeginUpdate();
            morphWord = textBox1.Text;
            foreach (string words in dictionary)
            {
                //If the morphWord length does not equal the word lenth we can 
                //skip the word.
                if (morphWord.Length == words.Length)
                {
                    tempWord = words;

                    foreach (char letter in morphWord)
                    {
                        if (tempWord.StartsWith(letter.ToString()))
                        {
                            containsMorphWord = containsMorphWord + 1;
                        }

                        //Each letter is removed after being checked to ensure it is not counted twice
                        tempWord = tempWord.Remove(0, 1);
                    }

                    //If 'containsMorphWord' counter is equal to the 'word'- 1 then the 'word' disagrees by one letter
                    //from the morphWord therefore it is printed to the console.
                    if ((containsMorphWord == (words.Length - 1)))
                    {
                        listBox1.Items.Add(words);
                    }
                }

                //Reset counter
                containsMorphWord = 0;
            }
            listBox1.EndUpdate();
        }
    }
}
