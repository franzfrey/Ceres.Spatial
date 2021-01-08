using Ceres.Spatial.Geometries;

namespace Ceres.Spatial.IO
{
    public interface IFeatureReader
    {
        bool Next();
        Feature Read();
    }
}
