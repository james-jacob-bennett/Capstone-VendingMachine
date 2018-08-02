using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Helpers
{
    public class GetFilePath
    {
        public static string UserEnteredFilePath(string question)
        {
            string result = "";
            bool isGoodPath = false;
            while(!isGoodPath)
            {


                try
                {
                    Console.WriteLine(question);
                    string filePath = Console.ReadLine();
                    if (!Path.IsPathRooted(filePath))
                    {
                        filePath = Path.Combine(Environment.CurrentDirectory, filePath);
                    }
                    isGoodPath = true;
                    result = filePath;
                }
                catch (IOException e)
                {
                    Console.WriteLine("Error reading file");
                    Console.WriteLine(e.Message);
                    isGoodPath = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unknown Error, Dont Suck");
                    Console.WriteLine(e.Message);
                    isGoodPath = false;
                }

            }
            return result;
        }


    }
}
