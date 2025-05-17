using System;
using System.Collections.Generic;

namespace Ex02
{
    internal class UserInterface
    {
        private string m_UserInput;
        private readonly int r_MinimumNumberOfGuessesAllowed = 4;
        private readonly int r_MaximumNumberOfGuessesAllowed = 10;
        private int m_SecretWordLength = 4;
        private int m_CountOfGuessesMadeSoFar;
        Board board = new Board();

        public int GetMaximalNumberOfGuessesFromUser()
        {
            int maximalNumberOfGuessesInput = 0;
            bool invalidInput = true;

            while(invalidInput)
            {
                Console.WriteLine($"Hello! Please enter desired maximal number of guesses " +
                    $"in range: <{r_MinimumNumberOfGuessesAllowed}-{r_MaximumNumberOfGuessesAllowed}>: ");
                m_UserInput = Console.ReadLine();
                if(!int.TryParse(m_UserInput, out maximalNumberOfGuessesInput))
                {
                    Console.WriteLine($"Invalid Input! it isn't a number.{Environment.NewLine}");
                }
                else if((maximalNumberOfGuessesInput < r_MinimumNumberOfGuessesAllowed)
                        || (maximalNumberOfGuessesInput > r_MaximumNumberOfGuessesAllowed))
                {
                    Console.WriteLine($"Invalid Input: Number is Out of range{Environment.NewLine}");
                }
                else
                {
                    invalidInput = false;
                }
            }

            board.CountOfGuessRowsOnBoard = maximalNumberOfGuessesInput;

            return maximalNumberOfGuessesInput;
        }

        public String GetGuessFromUser()
        {
            Console.WriteLine("Please type your next guess <A B C D> or 'Q' to quit");
            m_UserInput = Console.ReadLine();
            while(!checkGuessInputValidation(m_UserInput))
            {
                m_UserInput = Console.ReadLine();
            }

            m_CountOfGuessesMadeSoFar++;

            return m_UserInput;
        }

        public void PrintGoodByeScreen()
        {
            ConsoleUtils.Screen.Clear();
            Console.WriteLine($"Thank You For Playing!{Environment.NewLine}GOODBYE!");
        }

        public void PrintYouWonMessage()
        {
            board.Print();
            Console.WriteLine($"You guessed after {m_CountOfGuessesMadeSoFar} steps!");
        }

        public void PrintYouLostMessage()
        {
            board.Print();
            Console.WriteLine("No more guesses allowed. You Lost.");
        }

        public bool CheckIfUserWantToStartAnotherGame()
        {
            bool isUserWantsToStartAnotherGame = true;
            bool invalidInput = true;

            while(invalidInput)
            {
                Console.WriteLine("Would you like to start a new game? <Y/N>");
                m_UserInput = Console.ReadLine();
                if (m_UserInput != "Y" && m_UserInput != "N")
                {
                    Console.WriteLine("Invalid Input. Please awnser only <Y/N>");
                }
                else
                {
                    isUserWantsToStartAnotherGame = m_UserInput == "Y";
                    invalidInput = false;
                }
            }

            return isUserWantsToStartAnotherGame;
        }

        public void PrintBoard()
        {
            board.Print();
        }

        public void ResetMembers()
        {
            board.Reset();
            m_UserInput = String.Empty;
            m_CountOfGuessesMadeSoFar = 0;
        }

        public void AddGuessToBoardView(Guess i_Guess)
        {
            board.AddGuessToGuessesList(i_Guess);
        }

        private bool checkGuessInputValidation(String i_UserGuessInput)
        {
            bool isValid = true;
            
            if(i_UserGuessInput == "Q")
            {
                isValid = true;
            }
            else if (i_UserGuessInput.Length != m_SecretWordLength)
            {
                Console.WriteLine($"Invalid Input. length of guess should be {m_SecretWordLength}");
                isValid = false;
            }
            else
            {
                Dictionary<char, bool> lettersExistInUserGuess = new Dictionary<char, bool>();

                foreach (char letter in i_UserGuessInput)
                {
                    if ((letter < 'A' || letter > 'H') || (lettersExistInUserGuess.ContainsKey(letter)))
                    {
                        Console.WriteLine($"Invalid Input. guess should contain only letters in range <A-H>");
                        isValid = false;
                        break;
                    }

                    lettersExistInUserGuess.Add(letter, true);
                }
            }

            return isValid;
        }

        public void SetSecretWordInUi(SecretWord i_SecretWord)
        {
            m_SecretWordLength = i_SecretWord.FixedLength();
            board.SetReferenceToSecretWord(i_SecretWord);
        }
    }
}
