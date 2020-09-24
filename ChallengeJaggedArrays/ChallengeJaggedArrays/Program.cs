using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeJaggedArrays
{
    class Program
    {
        static void Main(string[] args)
        {

            string[][] persons = new string[][]
            {
                new string[] {"Arlion", "Jonathan", "Albert"},
                new string[] {"Agnes", "Mathias", "Milena"},
                new string[] {"Brandon", "Spoiler", "Spoiler"}
            };

            for(int i = 0; i < persons.Length; i++)
            {
                Console.WriteLine("Hi, my name is {0}. ", persons[i][0]);
                Console.WriteLine("My family members are {0} and {1}.", persons[i][1], persons[i][2]);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
