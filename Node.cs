using System.Collections.Generic;

namespace BypassContour
{
    public class Node
    {
        System.Collections.Generic.List<Node> childs;
        Contour contour;
        public Node(List<Node> childs, Contour contour)
        {
            this.childs = childs;
            this.contour = contour;
        }
        public Node(Contour contour)
        {
            this.contour = contour;
        }
        public List<Node> GetChilds()
        {
            if (childs != null) return childs;
            return null;
        }
        public Contour GetContour()
        {
            return contour;
        }
    }


}
