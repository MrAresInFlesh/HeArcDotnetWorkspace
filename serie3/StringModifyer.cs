using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace serie3
{
    static class StringModifyer
    {
        public static void Print(this List<String> list)
        {
            foreach (string s in list)
            {
                Console.WriteLine(s);
            }
        }

        public static string ReverseAddOne(this string s)
        {
            string s2 = "";
            for (int i = s.Length - 1; i >= 0; i--)
            {
                Console.Write(s[i]);
            }
            return s2;
        }

        public static List<String> TrimString(this List<String> list, string rem, string rep)
        {
            List<String> cpl = list;
            foreach (string s in cpl)
                s.Replace(rem, rep);
            return cpl;
        }
    }
}
