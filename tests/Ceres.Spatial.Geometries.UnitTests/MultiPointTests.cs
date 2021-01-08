namespace Ceres.Spatial.Geometries.UnitTests
{
    using System;
    using System.Linq;

    using NUnit.Framework;

    [TestFixture]
    public class MultiPointTest
    {
        [Test]
        public void t1()
        {
            var mp = new MultiPoint(0, new[] { new Point(0, 1, 2) });
            var gc = (GeometryCollection)mp;

            var p1 = mp[0] switch { Point p => p, _ => throw new InvalidOperationException() };
            var g1 = gc.First();
        }
    }
}
