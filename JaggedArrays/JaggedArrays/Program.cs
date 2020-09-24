using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare Jagged Array
            int[][] jagged = new int[3][];

            jagged[0] = new int[5];
            jagged[1] = new int[3];
            jagged[2] = new int[2];

            jagged[0] = new int[] { 1, 2, 3, 4, 5 };
            jagged[1] = new int[] { 1, 2, 3 };
            jagged[2] = new int[] { 11, 22 };

            // Alternative way of doing this
            int[][] jagged2 = new int[][]
            {
                new int[] { 1, 2, 3, 4, 5 },
                new int[] { 1, 2, 3 }
            };

            Console.WriteLine("The item in the middle of the first roll is: {0}", jagged2[0][2]);

            for(int i = 0; i < jagged2.Length; i++)
            {
                Console.WriteLine("Element {0}", i);

                for (int j = 0; j < jagged2[i].Length; j++)
                {
                    Console.WriteLine(" {0} ", jagged2[i][j]);                    
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
