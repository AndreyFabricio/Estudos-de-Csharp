using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAsParameter
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] studentGrades = new int[] { 99, 100, 10, 20, 30, 40, 50, 60, 70, 80, 80 };
            int[] happiness = new int[] { 11, 22, 33, 44, 55 };

            Console.Write("The grades are:");

            foreach(int grade in studentGrades)
            {
                Console.Write(" {0} ", grade);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("The average grade of the students is: {0:0.00}", GetAverage(studentGrades));
            Console.WriteLine();
            Console.Write("Happy Values:");

            GetHappy(happiness);

            foreach (int happy in happiness)
            {
                Console.Write(" {0} ", happy);
            }

            Console.ReadKey();
        }

        static double GetAverage(int[] gradesArray)
        {
            int sum = 0;
            double average;

            for(int i = 0; i < gradesArray.Length; i++)
            {
                sum += gradesArray[i];
            }

            average = (double)sum / gradesArray.Length;
            return average;
        }

        static void GetHappy(int[] happyArray)
        {
            for(int i = 0; i < happyArray.Length; i++)
            {
                happyArray[i] += 2;
            }
        }

    }
}
