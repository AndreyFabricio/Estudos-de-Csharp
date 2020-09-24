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
            int[] nums = new int[10];

            for(int i = 0; i < 10; i++)
            {
                nums[i] = i * 2 + 3;
                Console.WriteLine("Element {0} = {1}", i, nums[i]);
            }
            Console.WriteLine("");

            int count = 0;

            foreach(int k in nums)
            {
                Console.WriteLine("Element {0} = {1}", count, k);
                count++;
            }

            string[] friendz = { "Ana Carolina", "Ana Paula", "Paulo", "Luciana", "Rafael" };

            foreach (string l in friendz)
            {
                Console.WriteLine("Hello, Hello, Hello {0}!", l);
            }
            
            Console.ReadKey();
        }
    }
}
