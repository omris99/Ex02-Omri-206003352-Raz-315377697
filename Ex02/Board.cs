using System;
using System.Collections.Generic;
using System.Text;

namespace Ex02
{
    internal class Board
    {
        private readonly int r_LeftSideWidth = 8;
        private readonly String r_LeftSideHeader = "Pins:";
        private readonly int r_RightSideWidth = 9;
        private readonly String r_RightSideHeader = "Result:";
        public SecretWord m_SecretWord = new SecretWord();

        private enum eBoardSide
        {
            Left,
            Right
        };

        public int CountOfGuessRows { get; set; }

        public void Print(List<Guess> i_GuessesList)
        {
            int countOfGuessesMadeSoFar;

            if(i_GuessesList == null)
            {
                countOfGuessesMadeSoFar = 0;
            }
            else
            {
                countOfGuessesMadeSoFar = i_GuessesList.Count;
            }

            ConsoleUtils.Screen.Clear();
            Console.WriteLine($"Current board status:{Environment.NewLine}");
            printBoardRow(r_LeftSideHeader, r_RightSideHeader);
            printBoardRow(styleStringBeforeDisplay(m_SecretWord.Word, eBoardSide.Left));
            for(int i = 0; i < countOfGuessesMadeSoFar; i++)
            {
                Guess currentGuessToPrint = styleGuessBeforeDisplay(i_GuessesList[i]);
                printBoardRow(currentGuessToPrint.UserGuess, currentGuessToPrint.FeedBack);
            }

            for(int i = 0; i < (CountOfGuessRows - countOfGuessesMadeSoFar); i++)
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
            String paddedRightSideWord = padWordWithSpacesInTheEnd(i_RightSideWord, r_RightSideWidth);
            String paddedLeftSideWord = padWordWithSpacesInTheEnd(i_LeftSideWord, r_LeftSideWidth);

            Console.WriteLine("¦{0}¦{1}¦", paddedRightSideWord, paddedLeftSideWord);
            Console.Write("¦");
            for(int i = 0; i < r_RightSideWidth; i++)
            {
                Console.Write("=");
            }

            Console.Write("¦");
            for(int i = 0; i < r_LeftSideWidth; i++)
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
            desginedGuess.FeedBack = styleStringBeforeDisplay
                (i_Guess.FeedBack, eBoardSide.Right);

            return desginedGuess;
        }

        public void SetReferenceToSecretWord(SecretWord i_SecretWord)
        {
            m_SecretWord = i_SecretWord;
        }
    }
}
