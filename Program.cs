using BypassTheCircuit;
using System;

namespace BypassContour
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // false - по часовой
            // true - против часовой

            Node tree = Generator.Example();
            IDrawer drawerDo = new DrawerBitmap(tree, "di_DO");
            IDrawer drawerConsol = new DrawerConsole();
            drawerDo.Draw(tree);
            drawerConsol.Draw(tree);
            Console.WriteLine("--------");



            IDrawer drawerPosle = new DrawerBitmap(tree, "di_Posle");
            Solution.GetSolution(tree);
            drawerPosle.Draw(tree);   
            drawerConsol.Draw(tree);
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
