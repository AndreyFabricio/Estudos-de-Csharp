using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Member
    {
        // member - private fields
        private string memberName, jobTitle;
        private int salary;

        // member - public fields
        public int age;

        // member - property - exposes jobTitle safely
        public string JobTitle {
            get
            {
                return jobTitle;
            }
            set
            {
                jobTitle = value;
            }
        }

        // public member method - can be called from other classes
        public void Introducing (bool isFriend)
        {
            if (isFriend) SharingPrivateInfo();
            else
                Console.WriteLine("Hi, my name is {0}, and my job title " +
                    "is {1}. I'm {2} years old.", memberName, jobTitle, age);
        }

        private void SharingPrivateInfo()
        {
            Console.WriteLine("My salary is ${0}", salary);
        }

        // member constuctor
        public Member()
        {
            age = 30;
            memberName = "Andy";
            salary = 60000;
            jobTitle = "Developer";
            Console.WriteLine("Object Created.");
        }

        // member finalizer or destructor
        // 1 per class
        ~Member()
        {
            // cleanup statements
            Console.WriteLine("Desconstruction of Member object");
            Debug.Write("Desconstruction of Member object");
        }

    }
}
