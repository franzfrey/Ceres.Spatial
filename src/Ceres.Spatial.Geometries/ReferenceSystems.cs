using System.Collections.Generic;

namespace Ceres.Spatial.Geometries
{
    public static class ReferenceSystems
    {
        private static readonly Dictionary<int, IReferenceSystem> systems = new();

        public static IReferenceSystem Find(int srid)
        {
            return systems.TryGetValue(srid, out var system)
                ? system
                : throw new KeyNotFoundException();
        }
    }
}
