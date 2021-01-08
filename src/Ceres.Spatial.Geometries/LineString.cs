namespace Ceres.Spatial.Geometries
{
    using System.Collections.Generic;
    using System.Linq;

    using Ceres.Spatial.Geometries.Algorithms;

    public class LineString : Curve
    {
        private readonly List<LineSegment> segments;

        protected LineString(int srid, IReadOnlyList<Point> points)
            : base(srid, points)
        {
            this.segments = BuildSegments();
        }

        private List<LineSegment> BuildSegments()
        {
            var segments = new List<LineSegment>();
            for (var idx = 0; idx <= Count - 2; idx++)
            {
                var segment = new LineSegment(this[idx], this[idx + 1]);
                segments.Add(segment);
            }
            return segments;
        }

        protected LineString(int srid)
            : base(srid)
        {
        }

        public override bool Is3D => this.Any(point => point.Is3D);

        public override bool IsMeasured => this.Any(point => point.IsMeasured);

        public override bool IsEmpty => this.Count == 0;

        public override bool IsSimple => new LineSegmentIntersection(segments).Any;

        public override string GeometryType { get; } = "LINESTRING";

        public override double Length => segments.Sum(segment => segment.Length);

        protected override Curve MakeEmpty()
        {
            return new LineString(Srid);
        }
    }

}
