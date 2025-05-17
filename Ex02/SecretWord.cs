using System;
using System.Collections.Generic;
using System.Text;

namespace Ex02
{
    internal class SecretWord
    {
        String m_Word = String.Empty;
        private readonly int r_SecretWordLength = 4;
        bool m_isHidden = true;

        public String Word
        {
            get
            {
                if(m_isHidden)
                {
                    return "####";
                }
                else
                {
                    return m_Word;
                }
            }

            set
            {
                Console.WriteLine("Can't set Secret Word.");
            }
        }

        public void Generate()
        {
            Random random = new Random();
            char currentLetter;
            StringBuilder secretWord = new StringBuilder();
            Dictionary<char, bool> usedLetters = new Dictionary<char, bool>();

            for(int i = 0; i < r_SecretWordLength; i++)
            {
                currentLetter = (char)random.Next('A', 'H' + 1);
                if(usedLetters.ContainsKey(currentLetter))
                {
                    i--;
                }
                else
                {
                    secretWord.Append(currentLetter);
                    usedLetters.Add(currentLetter, true);
                }
            }

            m_isHidden = true;
            m_Word = secretWord.ToString();
        }

        public String CompareGuessToSecretWord(String i_UserInputGuess, out bool o_IsPerfectGuess)
        {
            StringBuilder vString = new StringBuilder();
            StringBuilder xString = new StringBuilder();
            StringBuilder feedBack = new StringBuilder();

            for (int i = 0; i < r_SecretWordLength; i++)
            {
                if (i_UserInputGuess[i] == m_Word[i])
                {
                    vString.Append('V');
                }
                else if (checkIfLetterExistInString(m_Word, i_UserInputGuess[i]))
                {
                    xString.Append('X');
                }
            }

            o_IsPerfectGuess = vString.Length == r_SecretWordLength;
            feedBack.Append(vString);
            feedBack.Append(xString);

            return feedBack.ToString();
        }

        public int FixedLength()
        {
            return r_SecretWordLength;
        }

        public void Unhide()
        {
            m_isHidden = false;
        }

        private bool checkIfLetterExistInString(String i_String, char i_Letter)
        {
            bool isLetterExistInString = false;

            foreach(char letter in i_String)
            {
                if(letter == i_Letter)
                {
                    isLetterExistInString = true;
                    break;
                }
            }

            return isLetterExistInString;
        }
    }
}
