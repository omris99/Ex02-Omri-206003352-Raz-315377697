using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class GameManager
    {
        public SecretWord SecretWord { get; private set; } = new SecretWord();

        public int MaximalNumberOfGuesses { get; set; }

        public bool IsVictory(string i_UserGuess)
        {
            return SecretWord.CheckIfGuessIsCorrect(i_UserGuess);
        }

        public void RevealSecretWord()
        {
            SecretWord.Unhide();
        }

        public Guess ProccesGuessAndGiveFeedback(String i_UserInputGuess)
        {
            Guess guess = new Guess();

            guess.UserGuess = i_UserInputGuess;
            guess.GuessFeedBack = SecretWord.CompareGuessToSecretWord(i_UserInputGuess);

            return guess;
        }

        public void ResetMembers()
        {
            GenerateSecretWord();
            MaximalNumberOfGuesses = -1; //HAVE TO CHANGE IT
        }

        public void GenerateSecretWord()
        {
            SecretWord.Generate();
        }
    }
}
