namespace Ceres.Spatial.Geometries
{
    public class Line : LineString
    {
        protected Line(int srid, Point start, Point end)
            : base(srid, new[] { start, end })
        {
        }

        public override string GeometryType { get; } = "LINE";
    }
}
