using System;

namespace Exercice1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nSerie 1 - Exercice 1 : \n");
            
            Console.WriteLine("\nInstanciating 2 Point3D, p1 and p2 : \n");

            Point3D p1 = new Point3D(1.2, 2.1, 3.4, "p1");
            Point3D p2 = new Point3D(4.1, 5.3, 6.7, "p2");

            Console.WriteLine(p1.ToString());
            Console.WriteLine(p2.ToString());

            Console.WriteLine("\nSwapping values of the 2 Point3D\n");

            (p1, p2) = Point3D.SwapPoints(p1, p2);

            Console.WriteLine(p1.ToString());
            Console.WriteLine(p2.ToString());
        }
    }
}
