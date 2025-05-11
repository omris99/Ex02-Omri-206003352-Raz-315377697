using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class Guess
    {
        private String m_UserGuess;
        public String UserGuess {
            get
            {
                return m_UserGuess;
            }
            set
            {
                if(checkGuessValidation(value))
                {
                    m_UserGuess = value;
                }
                else
                {
                    m_UserGuess = null;
                }
            }
        }
        public String GuessFeedBack { get; set; }


        private bool checkGuessValidation(String i_UserGuessInput)
        {
            bool isValid = true;

            foreach(char c in i_UserGuessInput)
            {
                if(c < 'A' || c > 'H')
                {
                    isValid = false;
                    Console.WriteLine("Invalid!");
                    break;
                }
            }

            return isValid;
        }
    }
}
