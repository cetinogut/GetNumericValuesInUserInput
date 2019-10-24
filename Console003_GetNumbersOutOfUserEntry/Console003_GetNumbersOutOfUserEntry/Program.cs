using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console003_GetNumbersOutOfUserEntry
{
 //   “Any fool can know.The point is to understand.”
//      ― Albert Einstein
    class Program
    {
        //Task : We're interested in having the numbers in a user entry from the console..
        static void Main(string[] args)
        {
            string userSentence = GetUserInput();
            List<int> userNumbers = FindNumericsInSentence(userSentence);
            PrintToConsole(userNumbers);
            //PrintToConsole(FindNumericsInSentence(GetUserInput())); //this is a better way... 
            //You can comment out the 3 lines above and use this one alone.

            Console.ReadLine();
        }// end of main

        private static List<int> FindNumericsInSentence(string userInput)
        {
            string[] numbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            for (int j = 0; j <= 9; j++)
            {
                if (userInput.Contains(numbers[j])) // check user input with .Contains method of string
                {
                    Console.WriteLine($"Your sentence has number {numbers[j]}....");
                }
            } // end for j

            List<int> numbersInSentence = new List<int>(); // let's create a list of int for numbers in user input first.
            Console.Write("Number(s) in your entry: ");
            for (int i = 0; i < userInput.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (userInput.Substring(i, 1).Equals(numbers[j]))// compare each user character with numbers array and 
                                                                      //if the user input char is a number then add to the list below..
                    { 
                        numbersInSentence.Add(Convert.ToInt32(userInput.Substring(i, 1)));
                        Console.Write($" { userInput.Substring(i, 1)}, ");
                    }// end  for j
                }
            }// end for i
            Console.WriteLine();
            return numbersInSentence;
        }

        private static void PrintToConsole(List<int> numsInUserInput)
        {
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------");
            if (numsInUserInput.Count == 0)
            {
                Console.WriteLine("Your input does not have any numeric value!!!");
            }
            else
            {
                Console.Write("Summary of output : ");
                for (int i = 0; i < numsInUserInput.Count; i++)
                {
                    Console.Write(numsInUserInput[i] + ", ");
                }
            }
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine();
        }

        private static string GetUserInput()
        {
            Console.Write("Enter a sentence having numeric numbers in it...:");
            string userInput = Console.ReadLine().Trim(); // get the user input and trim it..
            if (!ValidateUserInput(userInput))
            {
                GetUserInput();
            }
            
            return userInput;
        }

        private static bool ValidateUserInput(string userEntry)
        {
            bool isValid = true;
            if (userEntry.Length == 0)
            {
                Console.WriteLine("Your entry does not have any character...This is not a valid entry..");
                isValid = false;
            }

            return isValid;
        }
    }// end of program
}// end of namespace
