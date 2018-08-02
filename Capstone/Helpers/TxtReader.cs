using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Helpers
{
    public class TxtReader
    {
        public static string ReadText(string filePath)
        {
            string result = "";
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    result += line;
                }
            }
            return result;
        }

        public static string[] ReadAndCut(string filePath)
        {
            List<string> resultList = new List<string>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    char[] splitSpace = { ' ' };
                    string[] wordArray = line.Split(splitSpace, StringSplitOptions.RemoveEmptyEntries);
                    resultList.AddRange(wordArray);
                }
            }
            return resultList.ToArray();
        }


        public static List<string> ReadAndCutLine(string filePath)
        {
            List<string> resultList = new List<string>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    resultList.Add(line);
                }
            }
            return resultList;
        }




        public static string[] ReadAndCutSentences(string filePath)
        {
            List<string> resultSentenceList = new List<string>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    char[] splitPunc = { '.', '!', '?' };
                    string[] wordArray = line.Split(splitPunc);
                    resultSentenceList.AddRange(wordArray);
                }
            }
            return resultSentenceList.ToArray();

        }
    }
}
