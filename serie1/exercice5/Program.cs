using System;

namespace exercice5
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "Hello World";
            string s2 = "Hello World";
            string s3 = s1;

            Console.WriteLine("Equals, CompareTo, RefEquals for s1 to s2 : " + s1.Equals(s2) + " | " + s1.CompareTo(s2) + " | " + ReferenceEquals(s1, s2));
            Console.WriteLine("Equals, CompareTo, RefEquals for s1 to s3 : " + s1.Equals(s3) + " | " + s1.CompareTo(s3) + " | " + ReferenceEquals(s1, s3));

            Console.WriteLine("Equals, CompareTo, RefEquals for s2 to s1 : " + s2.Equals(s1) + " | " + s2.CompareTo(s1) + " | " + ReferenceEquals(s2, s1));
            Console.WriteLine("Equals, CompareTo, RefEquals for s2 to s3 : " + s2.Equals(s3) + " | " + s2.CompareTo(s3) + " | " + ReferenceEquals(s2, s3));

            Console.WriteLine("Equals, CompareTo, RefEquals for s3 to s1 : " + s3.Equals(s1) + " | " + s3.CompareTo(s1) + " | " + ReferenceEquals(s3, s1));
            Console.WriteLine("Equals, CompareTo, RefEquals for s3 to s2 : " + s3.Equals(s2) + " | " + s3.CompareTo(s1) + " | " + ReferenceEquals(s3, s1));

            s3 += '!';
            Console.WriteLine("[s3 += '!'] Equals, CompareTo, RefEquals for s3 to s1 : " + s3.Equals(s1) + " | " + s3.CompareTo(s1) + " | " + ReferenceEquals(s3, s1));
            Console.WriteLine("[s3 += '!'] Equals, CompareTo, RefEquals for s3 to s2 : " + s3.Equals(s2) + " | " + s3.CompareTo(s1) + " | " + ReferenceEquals(s3, s1));
        }
    }
}
