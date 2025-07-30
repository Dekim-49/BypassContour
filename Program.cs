using BypassTheCircuit;

namespace BypassContour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // false - по часовой
            // true - против часовой

            Node tree = Generator.Example();
            IDrawer drawer = new DrawerConsole();
            Solution.GetSolution(tree);
            drawer.Draw(tree);   
        }
    }
}
