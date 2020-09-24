using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] array2DString = new string[3, 2] 
            { 
                { "One", "Two" }, 
                { "Three", "Four" }, 
                { "Five", "Six" }
            };

            array2DString[1, 1] = "Chicken";
            Console.WriteLine("The value is: {0}", array2DString[1, 1]);


            // 3D Array
            string[,,] array3D = new string[,,]
            {
                {
                    {"000", "001"},
                    {"010", "011"},
                    {"Hi there", "Whazzup?!?"}
                },
                {
                    {"100", "101"},
                    {"110", "111"},
                    {"So many entries", "But this is the last one"}
                }
            };

            int dimensions = array2DString.Rank;
            Console.WriteLine("The dimensions are: {0}", dimensions);

            Console.WriteLine("The value is: {0}", array3D[1,2,1]);
            Console.ReadKey();
        }
    }
}
