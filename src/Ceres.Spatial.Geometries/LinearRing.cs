namespace Ceres.Spatial.Geometries
{
    using System;
    using System.Collections.Generic;

    public class LinearRing : LineString
    {
        protected LinearRing(int srid, IReadOnlyList<Point> points) : base(srid, points)
        {
            if (!this.IsRing) throw new ArgumentException(nameof(points));
        }

        public override string GeometryType { get; } = "LINEARRING";
    }
}
