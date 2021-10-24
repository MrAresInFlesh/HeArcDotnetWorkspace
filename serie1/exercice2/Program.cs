using System;

namespace exercice2
{
    
    class Program
    {
        ///Square root approx:
        /// X = (X + A/X)/2, withX1 = A

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a real positive number called A :\n");
            double number = System.Convert.ToDouble(Console.ReadLine());
            double sqrt = number;
            DateTime start = DateTime.Now;
            while ((sqrt-Math.Sqrt(number)) >= Math.Pow(10, -9))
            {
            Console.WriteLine("approximation de la racine carrée de " + number + " est " + sqrt);
            sqrt = (sqrt + number/sqrt)/2;
            }
            double error = (sqrt-Math.Sqrt(number));
            DateTime end = DateTime.Now;

            TimeSpan timeSpan = end - start;
            Console.WriteLine("Residual error between Math.Sqrt() and the formula : ", error);
            Console.WriteLine("Calculation time is {0} in [s]", timeSpan.TotalSeconds/1000);
            Console.WriteLine("Calculation time is {0} in [ms]", timeSpan.TotalSeconds);
        }
    }
}
