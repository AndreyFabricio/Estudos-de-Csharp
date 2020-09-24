using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    // This class is a blueprint for a datatype
    class Human
    {
        // Member variable
        private string firstName, lastName, eyeColor;
        private int age;

        // Default constructor
        public Human()
        {
            Console.WriteLine("Constructor called. Object created.");
        }
        
        // Parameterized constructor
        public Human(string firstName, string lastName, string eyeColor, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.eyeColor = eyeColor;
            this.age = age;
        }

        // Parameterized constructor
        public Human(string firstName, string lastName, string eyeColor)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.eyeColor = eyeColor;
        }

        // Parameterized constructor
        public Human(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public Human(string firstName)
        {
            this.firstName = firstName;
        }

        // Member method
        public void IntroduceMyself()
        {
            if (age != 0 && eyeColor != null && lastName != null && firstName != null)
                Console.WriteLine("Hi, I'm {0} {1}, my eyes are {2}, " +
                "and my age is {3}.", firstName, lastName, eyeColor, age);
            else if (eyeColor != null && lastName != null && firstName != null)
                Console.WriteLine("Hi, I'm {0} {1}, my eyes are {2}.", firstName, lastName, eyeColor);
            else if (lastName != null && firstName != null)
                Console.WriteLine("Hi, I'm {0} {1}.", firstName, lastName);
            else if (firstName != null)
                Console.WriteLine("Hi, I'm {0}.", firstName);

        }

    }
}
