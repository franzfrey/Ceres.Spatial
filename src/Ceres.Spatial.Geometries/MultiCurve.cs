namespace Ceres.Spatial.Geometries
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class MultiCurve
        : GeometryCollection,
          IReadOnlyList<Curve>
    {
        protected MultiCurve(int srid, IReadOnlyList<Curve> curves)
            : base(srid, curves)
        {
        }

        Curve IReadOnlyList<Curve>.this[int index] => base[index] as Curve;

        public bool IsClosed => ((IReadOnlyList<Curve>)this).All(curve => curve.IsClosed);

        public double Length => ((IReadOnlyList<Curve>)this).Sum(curve => curve.Length);

        IEnumerator<Curve> IEnumerable<Curve>.GetEnumerator()
        {
            return this.OfType<Curve>().GetEnumerator();
        }
    }
}
