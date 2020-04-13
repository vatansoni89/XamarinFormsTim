using System;

namespace PractiseProj
{
    class Program
    {
        private int num1=5,num2 =10;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            (new Program()).Add(10,20);

        }

        private void Add(int num1, int num2)
        {
           Console.WriteLine($"Local scope addition {num1+num2}");
           Console.WriteLine($"Class scope addition {this.num1+this.num2}");

            Console.ReadLine();
        }
    }
}
