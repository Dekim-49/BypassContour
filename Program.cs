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

    /*
    Изначально направление задаётся при определении сегмента. 

    Направление сегмента высчитывается исходя из соседа.

    А потом сравнивается с тем, является это внутренним или внешним контуром.
    И если сравнение не прошло, то направление меняется на то, которое соответствует всему контуру.
    -----
    А В ЧЕМ проблема тогда сразу от сравнения какой это слой давать направления, а не делать лишние вычисления?
     */


}
