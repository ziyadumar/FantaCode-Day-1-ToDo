using System;
using System.Threading.Tasks;
using DogAPI.Repository;

namespace DogAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calling Dog API.");

            Program.DoOp().GetAwaiter().GetResult();
        }

        public static ConsoleColor GetRandomColor() {
            var rn = new Random();
            var i = rn.Next(10);

            switch(i) {
                case 1:
                    return ConsoleColor.Red;
                case 2:
                    return ConsoleColor.Blue;
                case 0:
                    return ConsoleColor.Yellow;
                case 3:
                    return ConsoleColor.Green;
                case 4:
                    return ConsoleColor.Cyan;
                case 5:
                    return ConsoleColor.DarkBlue;
                case 6:
                    return ConsoleColor.DarkMagenta;
                case 7:
                    return ConsoleColor.DarkGreen;
                case 8:
                    return ConsoleColor.DarkCyan;
                case 9:
                    return ConsoleColor.Black;
                default:
                    return ConsoleColor.DarkRed;
            }
        }

        public static async Task DoOp() {
            var da = new DogRepository();
            var list = await da.GetBreedList();

            foreach(var s in list) {
                Console.ForegroundColor = Program.GetRandomColor();
                Console.WriteLine(s);
            }

            Console.ReadLine();
        }
    }
}
