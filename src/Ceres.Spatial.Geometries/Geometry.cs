namespace Ceres.Spatial.Geometries
{
    public abstract class Geometry
    {
        protected Geometry(int srid)
        {
            Srid = srid;
        }

        public int Srid { get; }

        public int CoordinateDimension => ReferenceSystems.Find(Srid).Dimension;

        public abstract bool Is3D { get; }

        public abstract bool IsMeasured { get; }

        public abstract bool IsEmpty { get; }

        public abstract bool IsSimple { get; }

        public abstract Geometry Boundary { get; }

        public abstract int Dimension { get; }

        public abstract string GeometryType { get; }

        public Geometry Envelope { get; }
    }
}
