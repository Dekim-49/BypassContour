using System.Collections.Generic;

namespace BypassContour
{
    public class Generator
    {
        //(int, int) minSizeContour;
        //int countLayers;
        //int maxCountContours;

        //Node tree;

        //public Generator((int, int) minSizeContour, int countLayers, int countContours)
        //{
        //    this.minSizeContour = minSizeContour;
        //    this.countLayers = countLayers;
        //    this.maxCountContours = countContours;
        //}

        //// Рекурсивный метод, рисующий вложенные прямоугольники
        //private void DrawRandomRectangles(Graphics g, ref Rectangle rect, int depth)
        //{
        //    if (depth <= 0 || rect.Width < 10 || rect.Height < 10)
        //        return;

        //    Brush brush = new SolidBrush(Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)));
        //    Pen pen = new Pen(brush.Color, 2);
        //    g.DrawRectangle(pen, rect);

        //    // Уменьшаем размеры текущего прямоугольника
        //    int offsetX = random.Next(rect.Width / 4, rect.Width / 2);
        //    int offsetY = random.Next(rect.Height / 4, rect.Height / 2);
        //    Rectangle childRect = new Rectangle(
        //        rect.X + offsetX,
        //        rect.Y + offsetY,
        //        Math.Max(10, rect.Width - 2 * offsetX),
        //        Math.Max(10, rect.Height - 2 * offsetY));

        //    // Рекуративно повторяем процесс для внутреннего прямоугольника
        //    DrawRandomRectangles(g, ref childRect, depth - 1);
        //}

        //public void CreateTree(int numberLayer)
        //{
        //    if (numberLayer == 0)
        //    {
        //        return;
        //    }
        //    Random r = new Random();
        //    List<Node> childs = new List<Node>();
        //    int countChildren = r.Next(maxCountContours);
        //    for (int i = 0 ; i < countChildren; i++)
        //    {

        //    }    
        //    //foreach (Segment s in tree.GetContour().Segments)
        //    //{
        //    //    Console.WriteLine($"({s.Pt1.X},{s.Pt1.Y}) - ({s.Pt2.X},{s.Pt2.Y}) : {s.Direction}");
        //    //}
        //}
        public static Node Example()
        {
            Point pFrame11 = new Point(0, 0);
            Point pFrame12 = new Point(10, 0);
            Point pFrame21 = new Point(0, 10);
            Point pFrame22 = new Point(10, 10);

            Point pSquare11 = new Point(1, 1);
            Point pSquare12 = new Point(4, 1);
            Point pSquare21 = new Point(1, 4);
            Point pSquare22 = new Point(4, 4);

            Point pSquare2_11 = new Point(2, 2);
            Point pSquare2_12 = new Point(3, 2);
            Point pSquare2_21 = new Point(2, 3);
            Point pSquare2_22 = new Point(3, 3);



            Point pSquare3_11 = new Point(1, 5);
            Point pSquare3_12 = new Point(10, 5);
            Point pSquare3_21 = new Point(1, 10);
            Point pSquare3_22 = new Point(10, 10);

            Point pSquare3_2_11 = new Point(2, 6);
            Point pSquare3_2_12 = new Point(9, 6);
            Point pSquare3_2_21 = new Point(2, 9);
            Point pSquare3_2_22 = new Point(9, 9);

            Point pSquare3_3_11 = new Point(3, 7);
            Point pSquare3_3_12 = new Point(8, 7);
            Point pSquare3_3_21 = new Point(3, 8);
            Point pSquare3_3_22 = new Point(8, 8);



            Segment sFrame11_12 = new Segment(pFrame11, pFrame12, false);
            Segment sFrame12_22 = new Segment(pFrame12, pFrame22, true);
            Segment sFrame22_21 = new Segment(pFrame22, pFrame21, false);
            Segment sFrame21_11 = new Segment(pFrame21, pFrame11, true);

            Segment sSquare11_12 = new Segment(pSquare11, pSquare12, false);
            Segment sSquare12_22 = new Segment(pSquare12, pSquare22, true);
            Segment sSquare22_21 = new Segment(pSquare22, pSquare21, false);
            Segment sSquare21_11 = new Segment(pSquare21, pSquare11, true);

            Segment sSquare2_11_12 = new Segment(pSquare2_11, pSquare2_12, true);
            Segment sSquare2_12_22 = new Segment(pSquare2_12, pSquare2_22, true);
            Segment sSquare2_22_21 = new Segment(pSquare2_22, pSquare2_21, true);
            Segment sSquare2_21_11 = new Segment(pSquare2_21, pSquare2_11, false);




            Segment sSquare3_11_12 = new Segment(pSquare3_11, pSquare3_12, true);
            Segment sSquare3_12_22 = new Segment(pSquare3_12, pSquare3_22, false);
            Segment sSquare3_22_21 = new Segment(pSquare3_22, pSquare3_21, true);
            Segment sSquare3_21_11 = new Segment(pSquare3_21, pSquare3_11, false);

            Segment sSquare3_2_11_12 = new Segment(pSquare3_2_11, pSquare3_2_12, true);
            Segment sSquare3_2_12_22 = new Segment(pSquare3_2_12, pSquare3_2_22, false);
            Segment sSquare3_2_22_21 = new Segment(pSquare3_2_22, pSquare3_2_21, true);
            Segment sSquare3_2_21_11 = new Segment(pSquare3_2_21, pSquare3_2_11, false);

            Segment sSquare3_3_11_12 = new Segment(pSquare3_3_11, pSquare3_3_12, true);
            Segment sSquare3_3_12_22 = new Segment(pSquare3_3_12, pSquare3_3_22, false);
            Segment sSquare3_3_22_21 = new Segment(pSquare3_3_22, pSquare3_3_21, true);
            Segment sSquare3_3_21_11 = new Segment(pSquare3_3_21, pSquare3_3_11, false);

            List<Segment> listFrame = new List<Segment>() { sFrame11_12, sFrame12_22, sFrame22_21, sFrame21_11 };
            List<Segment> listSquare = new List<Segment>() { sSquare11_12, sSquare12_22, sSquare22_21, sSquare21_11 };
            List<Segment> listSquare2_ = new List<Segment>() { sSquare2_11_12, sSquare2_12_22, sSquare2_22_21, sSquare2_21_11 };

            List<Segment> Square3_3_ = new List<Segment>() { sSquare3_3_11_12, sSquare3_3_12_22, sSquare3_3_22_21, sSquare3_3_21_11 };
            List<Segment> Square3_2_ = new List<Segment>() { sSquare3_2_11_12, sSquare3_2_12_22, sSquare3_2_22_21, sSquare3_2_21_11 };
            List<Segment> Square3 = new List<Segment>() { sSquare3_11_12, sSquare3_12_22, sSquare3_22_21, sSquare3_21_11 };

            Contour cFrame = new Contour(listFrame);
            Contour cSquare = new Contour(listSquare);
            Contour cSquare2 = new Contour(listSquare2_);

            Contour cSquare3_3_ = new Contour(Square3_3_);
            Contour cSquare3_2_ = new Contour(Square3_2_);
            Contour cSquare3 = new Contour(Square3);

            Node nSquare2 = new Node(cSquare2);
            Node nSquare = new Node(new List<Node>() { nSquare2 }, cSquare);

            Node nSquare3_3 = new Node(cSquare3_3_);
            Node nSquare3_2_ = new Node(new List<Node> { nSquare3_3 }, cSquare3_2_);
            Node nSquare3 = new Node( new List<Node> { nSquare3_2_ }, cSquare3);

            //Node nSquare = new Node(cSquare);
            Node tree = new Node(new List<Node>() { nSquare, nSquare3 }, cFrame);
            return tree;
        }
    }


}
