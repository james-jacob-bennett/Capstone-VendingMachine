using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class CheckInput
    {
        public static bool YesOrNo(string input)
        {
            bool result = false;
            bool isYorN = false;
            
            while (!isYorN)
            {
                input.ToLower();
                if (input == "y")
                {
                    result = true;
                    isYorN = true;
                }
                else if (input == "n")
                {
                    result = false;
                    isYorN = true;
                }
                else
                {
                    Console.WriteLine("Please enter y or n");
                }
            }

            return result;
        }

        public static int PickAnIntegerInRange(int numberOfOptions)
        {
            int resultFinal = 0;
            int resultUnchecked = 0;
            bool isInt = false;
            bool isInRange = false;
            //int rangeLoopCounter = 0;
            string input = "";

            while (!isInRange)
            {
                isInt = false;
                while (!isInt)
                {
                    input = Console.ReadLine();

                    if (int.TryParse(input, out resultUnchecked))
                    {
                        isInt = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter an integer");
                    }
                }

                if (resultUnchecked > 0 && resultUnchecked <= numberOfOptions)
                {
                    isInRange = true;
                    resultFinal = resultUnchecked;
                }
                else
                {
                    Console.WriteLine("Please Enter a value within range");
                    //rangeLoopCounter++;
                }
            }

            return resultFinal;
        }

        public static int PickAnInteger(string message)
        {
            int result = 0;
            bool isInt = false;

            Console.WriteLine(message);
            while (!isInt)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out result))
                {
                    isInt = true;
                }
                else
                {
                    Console.WriteLine("Please enter an integer");
                }
            }
            return result;
        }


        public static int StringToInteger(string toConvert, string errorMessage)
        {
            int result = 0;
            bool isInt = false;

            Console.WriteLine(errorMessage);
            while (!isInt)
            {
                
                if (int.TryParse(toConvert, out result))
                {
                    isInt = true;
                }
                else
                {
                    Console.WriteLine(errorMessage);
                }
            }
            return result;
        }




        public static double PickADouble(string message)
        {
            double result = 0;
            bool isInt = false;

            Console.WriteLine(message);
            while (!isInt)
            {
                string input = Console.ReadLine();

                if (double.TryParse(input, out result))
                {
                    isInt = true;
                }
                else
                {
                    Console.WriteLine("Please enter a decimal value");
                }
            }
            return result;
        }

        public static double StringToDouble(string input, string message) //CODE REVIEW: THIS IS USELESS IT IS THE SAME AS PARSE
        {
            double result = 0;
            
            {

                if (double.TryParse(input, out result))
                {
                }
                else
                {
                    throw new Exception(message);
                }
            }
            return result;
        }
    }
}
