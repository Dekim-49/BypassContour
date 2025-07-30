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
            set
            {
                pt1 = value;
            }
        }

        public Point Pt2
        {
            get
            {
                return pt2;
            }
            set
            {
                pt2 = value;
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
