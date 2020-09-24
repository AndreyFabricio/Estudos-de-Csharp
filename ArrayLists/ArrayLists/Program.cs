using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayLists
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declaring an Arraylist with undefined amount of objects
            ArrayList myArrayList = new ArrayList();
            // Declaring an Arraylist with defined amount of objects
            ArrayList myArrayList2 = new ArrayList(100);

            // Storing objects in the Arraylist
            myArrayList.Add(30);
            myArrayList.Add("String");
            myArrayList.Add(13.13);
            myArrayList.Add("Another String");
            myArrayList.Add('A');
            myArrayList.Add(666);
            myArrayList.Add("String");
            myArrayList.Add(99);
            myArrayList.Add(111);

            // Delete the first element with the specific value from the arraylist
            myArrayList.Remove("String");
            myArrayList.Remove("String");
            myArrayList.Remove("String");

            // Delete element at specific position
            myArrayList.RemoveAt(0);

            Console.WriteLine("The arraylist has {0} elements", myArrayList.Count);

            double sum = 0;

            foreach(object obj in myArrayList)
            {
                if(obj is int)
                {
                    sum += Convert.ToDouble(obj);
                } else if (obj is double)
                {
                    sum += (double)obj;
                } else if (obj is string)
                {
                    Console.WriteLine(obj);
                }
            }

            Console.WriteLine("The sum of the objects is: {0}", sum);

            Console.ReadKey();
        }
    }
}
