namespace Ceres.Spatial.Geometries
{
    public class Feature
    {
        public Feature(Geometry geom)
        {
            Geometry = geom;
        }

        public Geometry Geometry { get; }
    }
}
