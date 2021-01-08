namespace Ceres.Spatial.Geometries
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Curve : Geometry, IReadOnlyList<Point>
    {
        private readonly List<Point> points;

        protected Curve(int srid, IReadOnlyList<Point> points)
            : base(srid)
        {
            this.points = points.ToList();
        }

        protected Curve(int srid) : this(srid, Array.Empty<Point>())
        {
        }

        public Point this[int index] => points[index];

        public override int Dimension { get; } = 1;

        public Point StartPoint => points[0];

        public Point EndPoint => points[^0];

        public bool IsClosed => StartPoint == EndPoint;

        public bool IsRing => IsSimple && IsClosed;

        public override Geometry Boundary =>
            IsClosed
            ? MakeEmpty()
            : new MultiPoint(Srid, new[] { StartPoint, EndPoint });

        public int Count => points.Count;

        public IEnumerator<Point> GetEnumerator()
        {
            return points.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public abstract double Length { get; }

        protected abstract Curve MakeEmpty();
    }
}
