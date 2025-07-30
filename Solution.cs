using System;
using System.Xml.Serialization;

namespace BypassContour
{
    public static class Solution
    {
        public static Node GetSolution(Node tree)
        {

            //то направление, которое должно быть
            bool rightDirection = true;
            //обход по внешнему контуру
            foreach (Node child in tree.GetChilds())
            {
                GetDirection(child, rightDirection);
            }
            return tree;

        }

        private static void GetDirection(Node node, bool dir)
        {
            if (HaveChilds(node))
            {
                foreach (Node child in node.GetChilds())
                {
                    GetDirection(child, !dir);
                }
            }
            SetRightDirection(node.GetContour(), dir);

        }

        private static bool HaveChilds(Node node)
        {
            if (node.GetChilds() == null) return false;
            return true;
        }
        private static void SetRightDirection(Contour contour, bool dir)
        {
            //foreach (Segment segment in contour.Segments)
            //{
            //    if (segment.Direction != dir)
            //        segment.SwapDeriction();
            //}

            //VectorMultySolution(contour, dir);



        }



        private static void AngleSolution(Contour contour, bool dir)
        {

        }





        private static void VectorMultySolution(Contour contour, bool dir)
        {
            for (int i = 0 ; i < contour.Segments.Count ; i++)
            {
                int j = i == contour.Segments.Count - 1 ? 0 : i + 1;

                if (VectorMultiply(contour.Segments[i], contour.Segments[j]) > 0)
                {

                }
            }
        }

        /// <summary>
        /// Вычисляет векторное произведение. Работает в системе координат компьютера (Ох - слева направо, Оу - сверху вниз)
        /// </summary>
        /// <param name="first">Первый сегмент</param>
        /// <param name="second">Второй сегмент</param>
        /// <returns>число, если отрицательное - по часовой, положительное - против часовой</returns>
        private static int VectorMultiply(Segment first, Segment second)
        {
            Point firstVector = new Point(first.Pt2.X - first.Pt1.X, first.Pt2.Y - first.Pt1.Y);
            Point secondVector = new Point(second.Pt2.X - second.Pt1.X, second.Pt2.Y - second.Pt1.Y);
            int vectorMultuply = ( firstVector.X * secondVector.Y ) - ( firstVector.Y * secondVector.X );
            return vectorMultuply * ( -1 );
        }
        private static bool GetDirFromVectorMultiply(int mult, Segment segment)
        {
            if (mult < 0) return false;
            else if (mult > 0) return true;
            else throw new Exception("The segments are collinear");

        }
    }
}
