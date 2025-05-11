using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class UserInterface
    {
        private List<Guess> m_ListOfGuessesMadeSoFar;
        private string m_UserInput;
        private readonly int r_TableRightSideWidth = 9;
        private readonly int r_TableLeftSideWidth = 7;

        private string padWordWithSpacesInTheEnd(String i_Word, int i_DesiredWordLength)
        {
            StringBuilder paddedWord = new StringBuilder();
            int numberOfSpacesToAdd = i_DesiredWordLength - i_Word.Length;

            paddedWord.Append(i_Word);
            for(int i = 0; i < numberOfSpacesToAdd; i++)
            {
                paddedWord.Append(" ");
            }

            return paddedWord.ToString();

        }
        private void printTableRow(String i_RightSideWord = "", String i_LeftSideWord = "")
        {
            String paddedRightSideWord = padWordWithSpacesInTheEnd(i_RightSideWord, r_TableRightSideWidth);
            String paddedLeftSideWord = padWordWithSpacesInTheEnd(i_LeftSideWord, r_TableLeftSideWidth);
            
            Console.WriteLine("¦{0}¦{1}¦", paddedRightSideWord, paddedLeftSideWord);
            Console.WriteLine("¦=========¦=======¦");
        }

        public int GetMaximalNumberOfGuessesFromUser()
        {
            int maximalNumberOfGuessesFromUser;

            Console.WriteLine("Hello! Please enter desired maximal number of guesses (4-10): ");
            m_UserInput = Console.ReadLine();
            if(!(int.TryParse(m_UserInput, out maximalNumberOfGuessesFromUser)))
            {
                Console.WriteLine("Invalid Input! it isn't a number. Try Again: ");
            }
            else if(maximalNumberOfGuessesFromUser < 4 || maximalNumberOfGuessesFromUser > 10)
            {
                Console.WriteLine("Invalid Input! number isn't in the range (4-10). Try Again: ");
            }

            return maximalNumberOfGuessesFromUser;
        }
        //private bool checkUserInput(readonly int i_KindOfInput); //MAXIMAL NUMBER OF GUESSES, GUESS

        public void PrintScreen(int maximalNumberOfGuesses)
        {
            //DIVIDE TO STATES : FOR EXAMPLE STATE0 IS THE INITIAL SCREEN
            //STATE 0 : INITIAL SCREEN
            ConsoleUtils.Screen.Clear();
            Console.WriteLine($"Current board status:{Environment.NewLine}");
            printTableRow("Pins:", "Result:");
            printTableRow(" # # # #", " ");
            for (int i = 0; i < maximalNumberOfGuesses; i++)
            {
                printTableRow();
            }

        }
        public String GetGuessFromUser()
        {
            //The user give A-H input without repetitions and spaces.

            Console.WriteLine("Please type your next guess <A B C D> or 'Q' to quit");
            m_UserInput = Console.ReadLine();
            return m_UserInput;
        }

        //public bool CheckIfUserWantToQuitGame(String i_UserInput)
        //{
        //    //if Q so quit
        //}
    }
}
