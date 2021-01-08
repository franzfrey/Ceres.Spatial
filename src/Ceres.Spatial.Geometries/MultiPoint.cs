using System.Collections.Generic;

namespace Ceres.Spatial.Geometries
{
    public class MultiPoint
        : GeometryCollection
    {
        public MultiPoint(int srid, IReadOnlyList<Point> points)
            : base(srid, points)
        {
        }
    }
}