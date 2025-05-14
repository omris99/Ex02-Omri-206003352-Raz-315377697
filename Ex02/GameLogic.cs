using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class GameLogic
    {
        public SecretWord SecretWord { get; private set; } = new SecretWord();

        public int? MaximalNumberOfGuesses { get; set; }

        public void RevealSecretWord()
        {
            SecretWord.Unhide();
        }

        public Guess ProccesGuessAndGiveFeedback(String i_UserInputGuess)
        {
            Guess guess = new Guess();
            bool isPerfectGuess;

            guess.UserGuess = i_UserInputGuess;
            guess.GuessFeedBack = SecretWord.CompareGuessToSecretWord(i_UserInputGuess, out isPerfectGuess);
            guess.IsPerfectGuess = isPerfectGuess;

            return guess;
        }

        public void ResetMembers()
        {
            GenerateSecretWord();
            MaximalNumberOfGuesses = null;
        }

        public void GenerateSecretWord()
        {
            SecretWord.Generate();
        }
    }
}
