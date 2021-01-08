using System.Collections.Generic;

namespace Ceres.Spatial.Geometries.Algorithms
{
    internal class LineSegmentIntersection
    {
        private readonly List<LineSegment> segments;

        public LineSegmentIntersection(List<LineSegment> segments)
        {
            this.segments = segments;
        }

        public bool Any { get; }
    }
}