using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Siyabonga Mahlalela

namespace Character_Frequencies_in__a_Message
{
    class Program
    {
		static void Main(string[] args)
		{			
			char cLetter = 'A';
			bool isCorrect;
			char[] cLetters = new char[26];
			int iNum;
			for (int i = 0; i < 26; i++)
			{
				cLetters[i] = cLetter;
				cLetter++;// Adding the characters from A to character 26.
			}

			do
			{
				Console.WriteLine("Enter a message: ");
				string sMessage = Console.ReadLine().ToUpper();

				isCorrect = int.TryParse(sMessage, out iNum);//Checks if user input can be converted from a string to a number
                if (isCorrect == false)// If the user input cannot be successfully converted to a string, the condition is true
                {
                    Console.WriteLine("\nLetter Frequencies: ");
                    Console.WriteLine();
                    int cLength = cLetters.Length;
                    Graph(sMessage, cLetters);
                }
                else if (isCorrect)
                {
                    Console.WriteLine("\n\nInvalid input. Press any key to start over.");
                    Console.ReadKey();
                    Console.Clear();
                }
				 
            } while (isCorrect);

			Console.WriteLine("\nPress any key to exit..."); 
			Console.ReadKey();
		}
		static void Graph(string _sMessage, char[] _cLetters)
		{
			for (int i = 0; i < _cLetters.Length; i++)//The loop is responsible for the 26 rows.
			{
				Console.Write(_cLetters[i]);//Printing the letter of the row
				for (int j = 0; j < _sMessage.Length; j++)// The loop is responsible for the columns and printing the stars depending on use of the letters.
				{
					if (_cLetters[i] == _sMessage[j])
					{
						Print(_sMessage, _sMessage[j]); 
					}
					else
					{
						Console.Write("");
					}
				}
				Console.WriteLine();
			}
		}
		static double Sum(string _sMessage, char _cLetter)
		{
			int dSum = 0;
			for (int i = 0; i < _sMessage.Length; i++)
			{
				if (_sMessage[i] == _cLetter)
				{
					dSum += 1;
				}
			}
			return dSum; // returns dSum which is a total of how much a letter has been used.
		}
		static void Print(string _sMessage, char _cLetter)
		{
			double dSum = Sum(_sMessage, _cLetter);
            if (dSum > 1)
            {
                dSum = (Math.Sqrt(dSum) / dSum);
            }
            for (int i = 0; i < dSum; i++)// Prints stars according to the sum
			{
				Console.Write(" *");
			}
		}
	}
}
