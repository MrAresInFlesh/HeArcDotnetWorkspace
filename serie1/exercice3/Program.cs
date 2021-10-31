using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace exercice3
{
    class Program
    {
        static void Main(string[] args)
        {
            string output = "";
            List<string> list = new List<string>();
            try
            {
                // Open the text file using a stream reader.
                using (var sr = new StreamReader("Mesures.txt"))
                {
                    // Read the stream as a string, and write the string to the console.
                    output = sr.ReadToEnd();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            output = output.Replace(System.Environment.NewLine, ", ");

            // very ugly but it works.

            char[] cs = output.ToCharArray();
            foreach(char c in cs)
                list.Add(c.ToString());

            int counter = 0;

            foreach(string s in list)
            {
                counter++;
                if (counter%50 == 0) Console.WriteLine();
                else Console.Write(s);
            }
        }
    }
}
