namespace BypassContour
{
    public static class Solution
    {
        public static Node GetSolution(Node tree)
        {
            //то направление, которое должно быть
            bool rightDirection = true;
            //обход по внешнему контуру (рамке)
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

            SyncContourDirection(node.GetContour());
            if (node.GetContour().Segments[0].Direction != dir)
            {
                SetRightDirection(node.GetContour());
            }
        }

        private static bool HaveChilds(Node node)
        {
            if (node.GetChilds() == null) return false;
            return true;
        }

        private static void SetRightDirection(Contour contour)
        {
            foreach (Segment s in contour.Segments)
            {
                s.SwapDeriction();
                s.SwapPoints();
            }
        }

        private static void SyncContourDirection(Contour contour)
        {
            for (int i = 0 ; i < contour.Segments.Count ; i++)
            {
                int j = i == contour.Segments.Count - 1 ? 0 : i + 1;

                RegularSegmentsCoords(contour.Segments[i], contour.Segments[j]);
                bool dirSegment = VectorMultiply(contour.Segments[i], contour.Segments[j]) > 0;

                if (contour.Segments[i].Direction != dirSegment)
                {
                    contour.Segments[i].SwapDeriction();
                }
            }
        }

        /// <summary>
        /// Упорядочивает координаты отрзеков
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        private static void RegularSegmentsCoords(Segment first, Segment second)
        {
            if (first.Pt1 == second.Pt1)
            {
                (first.Pt1, first.Pt2) = (first.Pt2, first.Pt1);
            }
            else if (first.Pt1 == second.Pt2)
            {
                (first.Pt1, first.Pt2) = (first.Pt2, first.Pt1);
                (second.Pt1, second.Pt2) = (second.Pt2, second.Pt1);
            }
            else if (first.Pt2 == second.Pt2)
            {
                (second.Pt1, second.Pt2) = (second.Pt2, second.Pt1);
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
    }
}
