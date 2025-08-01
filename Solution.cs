using System;

/*вначале обход всего конутра с выравниванием кто куда идёт
 потом сравнение одного сегмента с диром дерева. если равно - ок, если нет - выровнять весь контур*/

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
                SetRightDirection(node.GetContour(), dir);
            }
        }

        private static bool HaveChilds(Node node)
        {
            if (node.GetChilds() == null) return false;
            return true;
        }



        private static void SetRightDirection(Contour contour, bool dir)
        {
            //вначате выровнять весь контур
            //Потом сравнить один отрзок из контура 

            foreach (Segment s in contour.Segments)
            {
                s.SwapDeriction();
                s.SwapPoints();

            }

            //------------------------------------


           // VectorMultySolution(contour, dir);
            //AngleSolution( contour,  dir)
        }

        private static void SyncContourDirection(Contour contour)
        {
            for (int i = 0; i < contour.Segments.Count; i++)
            {
                int j = i == contour.Segments.Count - 1 ? 0 : i + 1;

                RegularSegmentsCoords(contour.Segments[i], contour.Segments[j]);
                bool dirSegment = VectorMultiply(contour.Segments[i], contour.Segments[j]) > 0 ;

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

       
        /// <summary>
        /// Решение через скалярное произведение 
        /// Не работает из-за того что косинус не показывает тупые углы.
        /// </summary>
        /// <param name="contour"></param>
        /// <param name="dir"></param>
        private static void AngleSolution(Contour contour, bool dir)
        {
            for (int i = 0 ; i < contour.Segments.Count ; i++)
            {
                int j = i == contour.Segments.Count - 1 ? 0 : i + 1;
                Point firstVector = new Point(contour.Segments[i].Pt2.X - contour.Segments[i].Pt1.X, contour.Segments[i].Pt2.Y - contour.Segments[i].Pt1.Y);
                Point secondVector = new Point(contour.Segments[j].Pt2.X - contour.Segments[j].Pt1.X, contour.Segments[j].Pt2.Y - contour.Segments[j].Pt1.Y);
                double lenFirstVec = Math.Sqrt(Math.Pow(firstVector.X, 2) + Math.Pow(firstVector.Y, 2));
                double lenSecondVec = Math.Sqrt(Math.Pow(secondVector.X, 2) + Math.Pow(secondVector.Y, 2));
                double scalarMulty = ( firstVector.X * secondVector.X ) + ( firstVector.Y * secondVector.Y );

                double cosAngle = scalarMulty / ( lenFirstVec * lenSecondVec );
                Console.WriteLine(Math.Acos(cosAngle) / Math.PI * 180);

                /*Он не показывает тупой угол, тут нужно искать синус*/
            }
        }




        /// <summary>
        /// Решение через векторное призведение направленных векторов.
        /// Считается что первая координата отрезка - старт, вторая - конец.
        /// Работает не до конца, надо разобраться с отрезками разных направленностей.
        /// </summary>
        /// <param name="contour"></param>
        /// <param name="dir"></param>
        private static void VectorMultySolution(Contour contour, bool dir)
        {
            for (int i = 0 ; i < contour.Segments.Count ; i++)
            {
                int j = i == contour.Segments.Count - 1 ? 0 : i + 1;

                bool dirSegment = VectorMultiply(contour.Segments[i], contour.Segments[j]) > 0 ? true : false;


                if (dir != dirSegment)
                {
                    (contour.Segments[i].Pt1, contour.Segments[i].Pt2) = (contour.Segments[i].Pt2, contour.Segments[i].Pt1);
                }
                if (dir != contour.Segments[i].Direction)
                {
                    contour.Segments[i].SwapDeriction();
                }


                //if (dirSegment != dir)
                //{
                //    if (contour.Segments[i].Direction != dir)
                //    {
                //        contour.Segments[i].SwapDeriction();
                //        (contour.Segments[i].Pt1, contour.Segments[i].Pt2) = (contour.Segments[i].Pt2, contour.Segments[i].Pt1);
                //    }
                //}
                //else if (dirSegment != contour.Segments[i].Direction)
                //{
                //    contour.Segments[i].SwapDeriction();
                //    //(contour.Segments[i].Pt1, contour.Segments[i].Pt2) = (contour.Segments[i].Pt2, contour.Segments[i].Pt1);
                //}

                //if (dirSegment != contour.Segments[j].Direction)
                //{
                //    contour.Segments[j].SwapDeriction();
                //    (contour.Segments[j].Pt1, contour.Segments[j].Pt2) = (contour.Segments[j].Pt2, contour.Segments[j].Pt1);
                //}




                //if (contour.Segments[j].Direction != dir)
                //{
                //    contour.Segments[j].SwapDeriction();
                //    (contour.Segments[j].Pt1, contour.Segments[j].Pt2) = (contour.Segments[j].Pt2, contour.Segments[j].Pt1);
                //}
                //зачем нам вначале искать напрадление по углам, а потом менять это направление подстать нужному направлению всего конутра по индексу дерева?
                // почему нельзя заменить сразу все направления под направление по индексу дерева?

            }
        }



        
        private static bool GetDirFromVectorMultiply(int mult, Segment segment)
        {
            if (mult < 0) return false;
            else if (mult > 0) return true;
            else throw new Exception("The segments are collinear");

        }
    }
}
