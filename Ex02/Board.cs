using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class Board
    {
        private readonly int r_TableRightSideWidth = 9;
        private readonly int r_TableLeftSideWidth = 8;
        private const int k_BoardResultSide = 0;
        private const int k_BoardPinsSide = 1;
        public SecretWord m_SecretWord = new SecretWord();
        private List<Guess> m_GuessHistoryToViewOnBoard = new List<Guess>();

        public int CountOfGuessRowsOnBoard { get; set; }

        public void AddGuessToGuessesList(Guess i_Guess)
        {
            i_Guess = designViewStyleOfGuessInBoard(i_Guess);
            m_GuessHistoryToViewOnBoard.Add(i_Guess);
        }

        public void Print()
        {
            int countOfGuessesMadeSoFar = m_GuessHistoryToViewOnBoard.Count;

            ConsoleUtils.Screen.Clear();
            Console.WriteLine($"Current board status:{Environment.NewLine}");
            printBoardRow("Pins:", "Result:");
            printBoardRow(styleStringBeforeDisplay(m_SecretWord.Word, k_BoardPinsSide));
            for (int i = 0; i < countOfGuessesMadeSoFar; i++)
            {
                Guess currentGuess = m_GuessHistoryToViewOnBoard[i];
                printBoardRow(currentGuess.UserGuess, currentGuess.GuessFeedBack);
            }

            for (int i = 0; i < (CountOfGuessRowsOnBoard - countOfGuessesMadeSoFar); i++)
            {
                printBoardRow();
            }

            Console.WriteLine();
        }

        private string padWordWithSpacesInTheEnd(String i_Word, int i_DesiredWordWithSpacesLength)
        {
            StringBuilder paddedWord = new StringBuilder();
            int numberOfSpacesToAdd = i_DesiredWordWithSpacesLength - i_Word.Length;

            paddedWord.Append(i_Word);
            for (int i = 0; i < numberOfSpacesToAdd; i++)
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
            for (int i = 0; i < r_TableRightSideWidth; i++)
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

        private String styleStringBeforeDisplay(String i_StringToStyle, int i_StringContent)
        {
            StringBuilder desingedString = new StringBuilder();

            if (i_StringContent == k_BoardPinsSide)
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
        private Guess designViewStyleOfGuessInBoard(Guess i_Guess)
        {
            Guess desginedGuess = new Guess();

            desginedGuess.UserGuess = styleStringBeforeDisplay
                (i_Guess.UserGuess, k_BoardPinsSide);
            desginedGuess.GuessFeedBack = styleStringBeforeDisplay
                (i_Guess.GuessFeedBack, k_BoardResultSide);

            return desginedGuess;
        }

        public void Reset()
        {
            m_GuessHistoryToViewOnBoard.Clear();
        }

        public void SetReferenceToSecretWord(SecretWord i_SecretWord)
        {
            m_SecretWord = i_SecretWord;
        }
    }
}
