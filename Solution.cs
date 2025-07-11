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
            foreach (Segment segment in contour.Segments)
            {
                if (segment.Direction != dir)
                    segment.SwapDeriction();
            }
        }
    }


}
