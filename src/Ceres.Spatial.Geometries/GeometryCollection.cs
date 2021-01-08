namespace Ceres.Spatial.Geometries
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Ceres.Spatial.Geometries.Helpers;

    public class GeometryCollection
        : Geometry,
          IReadOnlyList<Geometry>
    {
        private readonly List<Geometry> geometries;

        public GeometryCollection(int srid, IReadOnlyList<Geometry> geometries)
            : base(srid)
        {
            if (!geometries.SameSrid())
            {
                throw new ArgumentException("", nameof(geometries));
            }

            this.geometries = geometries.ToList();
        }

        public Geometry this[int index] => geometries[index];

        public int Count => geometries.Count;

        public override bool Is3D => geometries.Any(geom => geom.Is3D);

        public override bool IsMeasured => geometries.Any(geom => geom.IsMeasured);

        public override bool IsEmpty => geometries.Count == 0;

        public override bool IsSimple { get; }

        public override Geometry Boundary { get; }

        public override int Dimension { get; }

        public override string GeometryType { get; } = "GEOMETRYCOLLECTION";

        public IEnumerator<Geometry> GetEnumerator()
        {
            return geometries.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
