using System;
using System.Text.RegularExpressions;

namespace RageQuit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input");

            string input = Console.ReadLine();
            string pattern = @"(?<text>\D+)(?<repeat>\d)";
            string temp="";
            int uniqueSymbols = 0;

            Regex regex = new Regex(pattern);
            
            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                string text = match.Groups[1].Value;
                for(int i = 0; i < text.Length; i++)
                {
                    if (temp.Contains(text[i]) == false)
                    {  
                        string temp2 = text[i].ToString();
                        if (temp.Contains(temp2.ToUpper()) == false)
                        {
                            uniqueSymbols++;
                            temp += text[i];
                        }
                        
                    }
                }
            }

            Console.WriteLine("Unique symbols used: {0}", uniqueSymbols);

            foreach (Match match in matches)
            {
                int times = int.Parse(match.Groups[2].Value);
                string text = match.Groups[1].Value;
                for(int i = 0; i < times; i++)
                {
                    Console.Write(text.ToUpper());
                }
            }
        }
    }
}