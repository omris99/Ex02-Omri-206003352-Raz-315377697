using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex02;

//TODO:
//1. TO THINK ABOUT ACCESS MODIFIERS OF CLASSES
//2. isVictory in GameManager -- Omri! 
//3. check if user want to exit -- Raz V
//4. UI SHIT (LIKE FORMAT GUESSES TO FIT IN TABLE, OR LOST MESSAGE) -- OMRI
//5. make struct SecretWord with bool m_isHidden, Word {get;set;}, Generate() - nullable
//6. maybe to make class Board? Board.AddGuessToView(), Board.Print()....

namespace Ex02
{
    internal class Program
    {
        public static void Main()
        {
            Game game = new Game();
            game.RunGame();
        }
    }
}

