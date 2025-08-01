namespace BypassContour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // false - по часовой
            // true - против часовой

            Node tree = Generator.Example();
            //IDrawer drawerDo = new DrawerBitmap(tree, "di_DO");
            //IDrawer drawerConsol = new DrawerConsole();
            //drawerDo.Draw(tree);
            //drawerConsol.Draw(tree);
            //Console.WriteLine("--------");
            //IDrawer drawerPosle = new DrawerBitmap(tree, "di_Posle");
            Solution.GetSolution(tree);
            //drawerPosle.Draw(tree);   
            //drawerConsol.Draw(tree);
        }
    }
}
