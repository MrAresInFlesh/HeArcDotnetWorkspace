using System;
using System.Collections.Generic;

namespace exercice4
{
    class Program
    {
        static void Main(string[] args)
        {
            RndN rndN = new RndN();
            int size = 20;

            List<int> sea = new List<int>();
            for(int i = 0; i <= 20; i++) sea.Add(rndN.GetRandom(0, 99));

            int[] tab = new int[size];
            for(int i = 0; i < 20; i++) tab[i] = rndN.GetRandom(0,99);

            Console.WriteLine("\nSources : ");
            foreach(int n in sea) Console.Write("| " + n + " ");
            
            List<int> listNPair = new List<int>();
            List<int> listNImpair = new List<int>();

            (listNPair, listNImpair) = Moise(sea);
            Console.WriteLine("|\n\nDisplay Even number : ");
            foreach(int n in listNPair) Console.Write("| " + n + " ");
            
            Console.WriteLine("|\n\nDisplay Odd number : ");
            foreach(int n in listNImpair) Console.Write("| " + n + " ");
            Console.WriteLine("|\n");

            Console.WriteLine("\nTab[] : ");
            foreach(int n in tab) Console.Write("| " + n + " ");

            int[] tabpair = new int[] {};
            int[] tabimpair = new int[] {};

            (tabpair, tabimpair) = PairImpair(tab);
            Console.WriteLine("|\n\nDisplay Even number tab[] : ");
            foreach(int n in tabpair) Console.Write("| " + n + " ");
            
            Console.WriteLine("|\n\nDisplay Odd number tab[] : ");
            foreach(int n in tabimpair) Console.Write("| " + n + " ");
            Console.WriteLine("|\n");
        }

        public static (int[], int[]) PairImpair(int[] source)
        {
            int[] lpair = new int[source.Length];
            int[] limpair = new int[source.Length];

            for(int e = 0; e < source.Length; e++)
            {
                if (source[e] % 2 == 0) lpair[e] = source[e];
                else limpair[e] = source[e];
            }
            return (lpair, limpair);
        }

        public static (List<int>, List<int>) Moise(List<int> source)
        {
            List<int> lpair = new List<int>();
            List<int> limpair = new List<int>();

            foreach(int e in source)
            {
                if (e % 2 == 0) lpair.Add(e);
                else limpair.Add(e);
            }
            return (lpair, limpair);
        }
    }

    public class RndN
    {
        private Random rnd = new Random();
        public int GetRandom(int limInf, int limSup)
        {
            return rnd.Next(limInf, limSup);
        }
    }
}
