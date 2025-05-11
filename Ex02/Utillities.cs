using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class Utillities
    {
        public static bool CheckIfLetterExistInString(String i_String, char i_Letter)
        {
            bool isLetterExistInString = false;

            foreach(char letter in i_String)
            {
                if (letter == i_Letter)
                {
                    isLetterExistInString = true;
                    break;
                }
            }

            return isLetterExistInString;
        }
    }
}
