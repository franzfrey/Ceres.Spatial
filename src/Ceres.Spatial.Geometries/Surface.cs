namespace Ceres.Spatial.Geometries
{
    public abstract class Surface : Geometry
    {
        protected Surface(int srid) : base(srid) { }

        public override int Dimension { get; } = 2;
    }
}
