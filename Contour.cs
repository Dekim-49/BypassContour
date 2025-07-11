using System.Collections.Generic;

namespace BypassContour
{
    public class Contour
    {
        List<Segment> segments;
        public Contour(List<Segment> segments)
        {
            this.segments = segments;
        }
        public List<Segment> Segments
        {
            get
            {
                return segments;
            }
        }
    }


}
