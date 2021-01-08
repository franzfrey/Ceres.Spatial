namespace Ceres.Spatial.Geometries
{
    public class Point : Geometry
    {
        public Point(int srid, double x, double y, double z)
            : this(srid, x, y, z, null)
        {
        }

        public Point(int srid, double x, double y)
            : this(srid, x, y, null, null)
        {
        }

        public Point(int srid, double x, double y, double? z, double? m)
            : base(srid)
        {
            X = x;
            Y = y;
            Z = z;
            M = m;
        }

        private Point(int srid)
            : this(srid, double.NaN, double.NaN, null, null)
        {
        }

        public double X { get; }

        public double Y { get; }

        public double? Z { get; }

        public double? M { get; }

        public override bool Is3D => Z.HasValue;

        public override bool IsMeasured => M.HasValue;

        public override bool IsEmpty => double.IsNaN(X) && double.IsNaN(Y);

        public override bool IsSimple => true;

        public override Geometry Boundary => new Point(Srid);

        public override int Dimension { get; } = 0;

        public override string GeometryType { get; } = "POINT";

        public static Point MakeEmpty(int srid)
        {
            return new Point(srid);
        }
    }
}
