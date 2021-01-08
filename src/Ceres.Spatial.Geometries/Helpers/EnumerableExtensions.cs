namespace Ceres.Spatial.Geometries.Helpers
{
    using System.Collections.Generic;
    using System.Linq;

    internal static class EnumerableExtensions
    {
        public static bool SameSrid<T>(this IEnumerable<T> geometries)
            where T : Geometry
        {
            return geometries.Select(geom => geom.Srid).Distinct().Count() == 1;
        }
    }
}
