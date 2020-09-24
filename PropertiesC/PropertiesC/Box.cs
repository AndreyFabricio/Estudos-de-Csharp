using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesC
{
    class Box
    {
        // Member variables
        private int lenght, height, widht, volume;

        // private int widht, volume;        

        public int Lenght { get; set; }
        public int Height { get; set; }

        public int Widht {
            get
            {
                return widht;
            }
            set
            {
                if (value < 0)
                    value = -value;
                    // throw new Exception("Size invalid");
                widht = value;
            }
        }

        public Box(int lenght, int height, int widht)
        {
            this.lenght = lenght;
            this.height = height;
            this.widht = widht;
        }

        public int Volume
        {
            get => height * widht * lenght;
            set => volume = value;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Lenght is {0} and height is {1} and widht is {2} " +
                "so the volume is {3}.", lenght, height, widht, Volume);
        }
    }
}
