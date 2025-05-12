using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class UserInterface
    {
        private List<Guess> m_ListOfGuessesMadeSoFar = new List<Guess>();
        private string m_UserInput;
        private string m_SecretWord;
        private readonly int r_TableRightSideWidth = 9;
        private readonly int r_TableLeftSideWidth = 8;
        private int r_MinimumNumberOfGuessesAllowed = 4;
        private int r_MaximumNumberOfGuessesAllowed = 10;
        private const int k_BoardResultSide = 0;
        private const int k_BoardPinsSide = 1;

        public int CountOfGuessRowsOnBoard { get; set; }
        public String SecretWord
        { 
            get
            {
                return m_SecretWord;
            }
            set
            {
                m_SecretWord = designViewStyleOfStringToShowOnBoard(value, k_BoardPinsSide);
            }
        }

        private string padWordWithSpacesInTheEnd(String i_Word, int i_DesiredWordWithSpacesLength)
        {
            StringBuilder paddedWord = new StringBuilder();
            int numberOfSpacesToAdd = i_DesiredWordWithSpacesLength - i_Word.Length;

            paddedWord.Append(i_Word);
            for(int i = 0; i < numberOfSpacesToAdd; i++)
            {
                paddedWord.Append(" ");
            }

            return paddedWord.ToString();

        }
        private void printBoardRow(String i_RightSideWord = "", String i_LeftSideWord = "")
        {
            String paddedRightSideWord = padWordWithSpacesInTheEnd(i_RightSideWord, r_TableRightSideWidth);
            String paddedLeftSideWord = padWordWithSpacesInTheEnd(i_LeftSideWord, r_TableLeftSideWidth);
            
            Console.WriteLine("¦{0}¦{1}¦", paddedRightSideWord, paddedLeftSideWord);
            Console.Write("¦");
            for(int i = 0; i < r_TableRightSideWidth; i++)
            {
                Console.Write("=");
            }

            Console.Write("¦");
            for (int i = 0; i < r_TableLeftSideWidth; i++)
            {
                Console.Write("=");
            }

            Console.WriteLine("¦");
        }

        public int GetMaximalNumberOfGuessesFromUser()
        {
            int maximalNumberOfGuessesFromUser = 0;
            bool invalidInput = true;

            while(invalidInput)
            {
                Console.WriteLine("Hello! Please enter desired maximal number of guesses: ");
                m_UserInput = Console.ReadLine();
                if(!int.TryParse(m_UserInput, out maximalNumberOfGuessesFromUser))
                {
                    Console.WriteLine($"Invalid Input! it isn't a number.{Environment.NewLine}");
                }
                else if ((maximalNumberOfGuessesFromUser < r_MinimumNumberOfGuessesAllowed) ||
                    (maximalNumberOfGuessesFromUser > r_MaximumNumberOfGuessesAllowed))
                {
                    Console.WriteLine($"Invalid Input. Please Enter a number in range." +
                            $" ({r_MinimumNumberOfGuessesAllowed}-{r_MaximumNumberOfGuessesAllowed})" +
                            $"{Environment.NewLine}");
                }
                else
                {
                    invalidInput = false;
                }
            }

            return maximalNumberOfGuessesFromUser;
        }

        public void PrintBoard()
        {
            int countOfGuessesMadeSoFar = m_ListOfGuessesMadeSoFar.Count;

            ConsoleUtils.Screen.Clear();
            Console.WriteLine($"Current board status:{Environment.NewLine}");
            printBoardRow("Pins:", "Result:");
            if(countOfGuessesMadeSoFar == CountOfGuessRowsOnBoard)
            {
                printBoardRow(SecretWord);
            }
            else
            {
                printBoardRow(" # # # #");
            }

            for (int i = 0; i < countOfGuessesMadeSoFar; i++)
            {
                Guess currentGuess = m_ListOfGuessesMadeSoFar[i];
                printBoardRow(currentGuess.UserGuess, currentGuess.GuessFeedBack);
            }

            for (int i = 0; i < (CountOfGuessRowsOnBoard - countOfGuessesMadeSoFar); i++)
            {
                printBoardRow();
            }

            Console.WriteLine();
        }

        public String GetGuessFromUser()
        {
            //The user give A-H input without repetitions and spaces.

            Console.WriteLine("Please type your next guess <A B C D> or 'Q' to quit");
            m_UserInput = Console.ReadLine();
            return m_UserInput;
        }

        private Guess designViewStyleOfGuessInBoard(Guess i_Guess)
        {
            Guess desginedGuess = new Guess();

            desginedGuess.UserGuess = designViewStyleOfStringToShowOnBoard
                (i_Guess.UserGuess, k_BoardPinsSide);
            desginedGuess.GuessFeedBack = designViewStyleOfStringToShowOnBoard
                (i_Guess.GuessFeedBack, k_BoardResultSide);

            return desginedGuess;
        }

        private String designViewStyleOfStringToShowOnBoard(String i_StringToStyle, int i_StringContent)
        {
            StringBuilder desingedString = new StringBuilder();

            if(i_StringContent == k_BoardPinsSide)
            {
                foreach (char letter in i_StringToStyle)
                {
                    desingedString.Append(' ');
                    desingedString.Append(letter);
                }
            }
            else if (i_StringContent == k_BoardResultSide)
            {
                foreach (char letter in i_StringToStyle)
                {
                    desingedString.Append(letter);
                    desingedString.Append(' ');
                }
            }

            return desingedString.ToString();
        }

        public void AddGuessToGuessesList(Guess i_Guess)
        {
            i_Guess = designViewStyleOfGuessInBoard(i_Guess);
            m_ListOfGuessesMadeSoFar.Add(i_Guess);
        }

        public void PrintGoodByeScreen()
        {
            ConsoleUtils.Screen.Clear();
            Console.WriteLine("GOODBYE!");
        }

        public void PrintYouWonMessage()
        {
            Console.WriteLine($"You guessed after {m_ListOfGuessesMadeSoFar.Count} steps!");
        }
        public void PrintYouLostMessage()
        {
            PrintBoard();
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
                    if (m_UserInput == "Y")
                    {
                        isUserWantsToStartAnotherGame = true;
                    }
                    else if (m_UserInput == "N")
                    {
                        isUserWantsToStartAnotherGame = false;
                    }

                    invalidInput = false;
                }
            }

            return isUserWantsToStartAnotherGame;
        }

        public void ResetMembers()
        {
            m_ListOfGuessesMadeSoFar.Clear();
            m_UserInput = "";
            m_SecretWord = "";
        }
    }
}
