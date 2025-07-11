using BypassContour;
using System.Drawing;
namespace BypassTheCircuit
{
    public class DrawerBitmap : IDrawer
    {
        string path = @"C:\Users\ASUS\Desktop\dir";
        Graphics g;
        Bitmap bitmap;
        Pen pen_Clockwise = new Pen(Color.Red, 5);
        Pen pen_Counterclockwise = new Pen(Color.Blue, 5);  

        int size = 100;

        int arrowWidth = 7;

        public DrawerBitmap(Node tree)
        {
            bitmap = new Bitmap(GetSizeFrame(tree).Item1 * size, GetSizeFrame(tree).Item2 * size);
            g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
        }
        public void Draw(Node tree)
        {   
            if (tree.GetChilds() != null)
            {
                foreach (Node node in tree.GetChilds())
                {
                    Draw(node);
                }
            }
            foreach (Segment s in tree.GetContour().Segments)
            {
                if (s.Direction)
                {
                    DrawSegment(s, pen_Counterclockwise);
                }
                else DrawSegment(s, pen_Clockwise);

            }
            bitmap.Save(path + ".png");
        }
        private (int, int) GetSizeFrame(Node tree)
        {
            int minX = -1, maxX = -1, minY = -1, maxY = -1;
            foreach (Segment s in tree.GetContour().Segments)
            {
                if (minX == -1)
                {
                    (maxX, maxY) = (s.Pt1.X, s.Pt1.Y);
                    (minX, minY) = (s.Pt1.X, s.Pt1.Y);
                }
                if (minX > s.Pt1.X) minX = s.Pt1.X;
                if (minX > s.Pt2.X) minX = s.Pt2.X;
                if (maxX < s.Pt1.X) maxX = s.Pt1.X;
                if (maxX < s.Pt2.X) maxX = s.Pt2.X;

                if (minY > s.Pt1.Y) minY = s.Pt1.Y;
                if (minY > s.Pt2.Y) minY = s.Pt2.Y;
                if (maxY < s.Pt1.Y) maxY = s.Pt1.Y;
                if (maxY < s.Pt2.Y) maxY = s.Pt2.Y;
            }
            return (maxX - minX, maxY - minY);
        }
        private void CalculatePositionOfArrow(Segment segment)
        {
            (int, int) pointArrow1, pointArrow2, pointArrowCenter;
            if (segment.Pt1.X == segment.Pt2.X)
            {
                pointArrow1 = (segment.Pt1.X * size - arrowWidth, (int)( segment.Pt1.Y * size + segment.Pt2.Y * size ) / 2);
                pointArrow2 = (segment.Pt1.X * size + arrowWidth, (int)( segment.Pt1.Y * size + segment.Pt2.Y * size ) / 2);
                
                if (segment.Direction)
                {
                    pointArrowCenter = (segment.Pt1.X * size, (int)( segment.Pt1.Y * size + segment.Pt2.Y * size ) / 2 + 2 * arrowWidth);
                }
                else
                {
                    pointArrowCenter = (segment.Pt1.X * size, (int)( segment.Pt1.Y * size + segment.Pt2.Y * size ) / 2 - 2 * arrowWidth);
                }
            }
            else
            {
                pointArrow1 = ((int)(segment.Pt1.X * size + segment.Pt2.X * size ) / 2, segment.Pt1.Y * size + arrowWidth);
                pointArrow2 = ((int)( segment.Pt1.X * size + segment.Pt2.X * size ) / 2, segment.Pt1.Y * size - arrowWidth);

                if (segment.Direction)
                {
                    pointArrowCenter = ((int)( segment.Pt1.X * size + segment.Pt2.X * size ) / 2 - 2 * arrowWidth, segment.Pt1.Y * size);
                }
                else
                {
                    pointArrowCenter = ((int)( segment.Pt1.X * size + segment.Pt2.X * size ) / 2 + 2 * arrowWidth, segment.Pt1.Y * size);
                }
            }
            DrawSegment(segment, pointArrow1, pointArrow2, pointArrowCenter, new Pen(Color.Red, 3));
        }
        private void DrawSegment(Segment s, (int, int) pointArrow1, (int, int) pointArrow2, (int, int) pointArrowCenter, Pen pen)
        {
            g.DrawLine(pen, s.Pt1.X * size, s.Pt1.Y * size, s.Pt2.X * size, s.Pt2.Y * size);
            g.DrawLine(pen, pointArrow1.Item1, pointArrow1.Item2, pointArrowCenter.Item1, pointArrowCenter.Item2);
            g.DrawLine(pen, pointArrow2.Item1, pointArrow2.Item2, pointArrowCenter.Item1, pointArrowCenter.Item2);

        }
        private void DrawSegment(Segment s, Pen pen)
        {
            g.DrawLine(pen, s.Pt1.X * size, s.Pt1.Y * size, s.Pt2.X * size, s.Pt2.Y * size);

        }
    }

}
