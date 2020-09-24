using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an object of my class
            // An instance of human
            Human andrey = new Human("Andrey", "Santos", "Brown", 30);
            // Call methods of the class
            andrey.IntroduceMyself();

            Human john = new Human("John", "Smith", "Brown");
            john.IntroduceMyself();

            Human basicHuman = new Human();

            Console.ReadKey();
        }
    }
}
