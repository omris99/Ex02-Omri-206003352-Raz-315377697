using System;
using System.Collections.Generic;

namespace Ex02
{
    internal class GameLogic
    {
        public List<Guess> Guesses { get; private set; } = new List<Guess>();

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
            guess.FeedBack = SecretWord.CompareGuessToSecretWord(i_UserInputGuess, out isPerfectGuess);
            guess.IsPerfectGuess = isPerfectGuess;

            return guess;
        }

        public void ResetMembers()
        {
            GenerateSecretWord();
            MaximalNumberOfGuesses = null;
            Guesses.Clear();
        }

        public void GenerateSecretWord()
        {
            SecretWord.Generate();
        }

        public void AddGuessToList(Guess i_Guess)
        {
            Guesses.Add(i_Guess);
        }
    }
}
