namespace BypassContour
{
    public class Segment
    {
        Point pt1;
        Point pt2;
        bool direction;
        public Segment(Point pt1, Point pt2, bool direction)
        {
            this.pt1 = pt1;
            this.pt2 = pt2;
            this.direction = direction;
        }

        public Point Pt1
        {
            get
            {
                return pt1;
            }
        }

        public Point Pt2
        {
            get
            {
                return pt2;
            }
        }

        public bool Direction
        {
            get
            {
                return direction;
            }
        }
        public void SwapDeriction()
        {
            direction = !direction;
        }

    }


}
