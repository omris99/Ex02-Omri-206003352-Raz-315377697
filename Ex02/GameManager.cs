using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class GameManager
    {
        private int m_MaximalNumberOfGuesses;
        private String m_SecretWord;
        //private Guess List priviousGuesses

        public void SetMaximalNumberOfGuesses(int i_MaximalNumberOfGuesses)
        {
            m_MaximalNumberOfGuesses = i_MaximalNumberOfGuesses;
        }

        public bool IsVictory()
        {
            //
        }

        public void GenerateSecretWord()
        {
            //generate secret word to guess
            //use NEXT method of Random library
        }

        public void checkGuess(String i_Guess)
        {
            //
        }

    }
}
