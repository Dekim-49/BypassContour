using BypassContour;
using System;
namespace BypassTheCircuit
{
    internal class DrawerConsole : IDrawer
    {
        public void Draw(Node tree)
        {
            if (tree.GetChilds() != null)
            {
                foreach (Node node in tree.GetChilds())
                {
                    Draw(node);
                }
            }
            Console.WriteLine("Segment - ");
            foreach (Segment s in tree.GetContour().Segments)
            {
                Console.WriteLine($"({s.Pt1.X},{s.Pt1.Y}) - ({s.Pt2.X},{s.Pt2.Y}) : {s.Direction}");
            }
        }
    }

}
