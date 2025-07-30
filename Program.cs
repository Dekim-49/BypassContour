using BypassTheCircuit;
using System;

namespace BypassContour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //for (double i = -1 ; i <=1 ; i += 0.1)
            //{
            //    Console.WriteLine(Math.Acos(i) * 180 / Math.PI + "    " + Math.Asin(i) * 180 / Math.PI);

            //}

            for (double i = 0 ; i <= 360 ; i += 2)
            {
                Console.WriteLine(i + "| " + Math.Cos(i / 180 * Math.PI) + "    " + Math.Sin(i / 180 * Math.PI));

            }

            // false - по часовой
            // true - против часовой

            Node tree = Generator.Example();
            IDrawer drawer = new DrawerConsole();
            Solution.GetSolution(tree);
            drawer.Draw(tree);   
        }
    }
}
