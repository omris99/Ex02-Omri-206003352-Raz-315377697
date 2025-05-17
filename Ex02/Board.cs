using System;
using System.Collections.Generic;
using System.Text;

namespace Ex02
{
    internal class Board
    {
        private readonly int r_BoardLeftSideWidth = 8;
        private readonly String r_BoardLeftSideHeader = "Pins:";
        private readonly int r_BoardRightSideWidth = 9;
        private readonly String r_BoardRightSideHeader = "Result:";
        public SecretWord m_SecretWord = new SecretWord();
        private List<Guess> m_GuessHistoryToViewOnBoard = new List<Guess>();

        private enum eBoardSide
        {
            Left,
            Right
        };

        public int CountOfGuessRowsOnBoard { get; set; }

        public void AddGuessToGuessesList(Guess i_Guess)
        {
            i_Guess = styleGuessBeforeDisplay(i_Guess);
            m_GuessHistoryToViewOnBoard.Add(i_Guess);
        }

        public void Print()
        {
            int countOfGuessesMadeSoFar = m_GuessHistoryToViewOnBoard.Count;

            ConsoleUtils.Screen.Clear();
            Console.WriteLine($"Current board status:{Environment.NewLine}");
            printBoardRow(r_BoardLeftSideHeader, r_BoardRightSideHeader);
            printBoardRow(styleStringBeforeDisplay(m_SecretWord.Word, eBoardSide.Left));
            for(int i = 0; i < countOfGuessesMadeSoFar; i++)
            {
                Guess currentGuess = m_GuessHistoryToViewOnBoard[i];
                printBoardRow(currentGuess.UserGuess, currentGuess.GuessFeedBack);
            }

            for(int i = 0; i < (CountOfGuessRowsOnBoard - countOfGuessesMadeSoFar); i++)
            {
                printBoardRow();
            }

            Console.WriteLine();
        }

        private string padWordWithSpacesInTheEnd(String i_Word, int i_DesiredWordLengthAfterPadding)
        {
            StringBuilder paddedWord = new StringBuilder();
            int numberOfSpacesToAdd = i_DesiredWordLengthAfterPadding - i_Word.Length;

            paddedWord.Append(i_Word);
            for(int i = 0; i < numberOfSpacesToAdd; i++)
            {
                paddedWord.Append(" ");
            }

            return paddedWord.ToString();
        }

        private void printBoardRow(String i_RightSideWord = "", String i_LeftSideWord = "")
        {
            String paddedRightSideWord = padWordWithSpacesInTheEnd(i_RightSideWord, r_BoardRightSideWidth);
            String paddedLeftSideWord = padWordWithSpacesInTheEnd(i_LeftSideWord, r_BoardLeftSideWidth);

            Console.WriteLine("¦{0}¦{1}¦", paddedRightSideWord, paddedLeftSideWord);
            Console.Write("¦");
            for(int i = 0; i < r_BoardRightSideWidth; i++)
            {
                Console.Write("=");
            }

            Console.Write("¦");
            for(int i = 0; i < r_BoardLeftSideWidth; i++)
            {
                Console.Write("=");
            }

            Console.WriteLine("¦");
        }

        private String styleStringBeforeDisplay(String i_StringToStyle,
            eBoardSide i_DesiredBoardSideToDisplayString)
        {
            StringBuilder desingedString = new StringBuilder();

            if(i_DesiredBoardSideToDisplayString == eBoardSide.Left)
            {
                foreach(char letter in i_StringToStyle)
                {
                    desingedString.Append(' ');
                    desingedString.Append(letter);
                }
            }
            else if(i_DesiredBoardSideToDisplayString == eBoardSide.Right)
            {
                foreach(char letter in i_StringToStyle)
                {
                    desingedString.Append(letter);
                    desingedString.Append(' ');
                }
            }

            return desingedString.ToString();
        }

        private Guess styleGuessBeforeDisplay(Guess i_Guess)
        {
            Guess desginedGuess = new Guess();

            desginedGuess.UserGuess = styleStringBeforeDisplay
                (i_Guess.UserGuess, eBoardSide.Left);
            desginedGuess.GuessFeedBack = styleStringBeforeDisplay
                (i_Guess.GuessFeedBack, eBoardSide.Right);

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
