using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class SecretWord
    {
        String m_Word = "";
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

            for (int i = 0; i < r_SecretWordLength; i++)
            {
                currentLetter = (char)random.Next('A', 'H' + 1);
                if (usedLetters.ContainsKey(currentLetter))
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

        public String CompareGuessToSecretWord(String i_UserInputGuess, out bool isPerfectGuess)
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
                else if (Utillities.CheckIfLetterExistInString(m_Word, i_UserInputGuess[i]))
                {
                    xString.Append('X');
                }
            }

            isPerfectGuess = vString.Length == r_SecretWordLength;
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
    }
}
