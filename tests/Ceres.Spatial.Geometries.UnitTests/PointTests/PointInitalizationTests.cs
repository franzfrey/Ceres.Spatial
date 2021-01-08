namespace Ceres.Spatial.Geometries.UnitTests.PointTests
{

    using NUnit.Framework;

    [TestFixture]
    public class PointInitalizationTests
    {
        [Test]
        public void Initialize2dPoint()
        {
            var point = new Point(0, 10, 20);

            Assert.That(point.X, Is.EqualTo(10));
            Assert.That(point.Y, Is.EqualTo(20));
            Assert.That(point.Z, Is.Null);
            Assert.That(point.M, Is.Null);
        }

        [Test]
        public void Initialize3dPoint()
        {
            var point = new Point(0, 10, 20, 30);

            Assert.That(point.X, Is.EqualTo(10));
            Assert.That(point.Y, Is.EqualTo(20));
            Assert.That(point.Z, Is.EqualTo(30));
            Assert.That(point.M, Is.Null);
        }

        [Test]
        public void InitializeMeasured2dPoint()
        {
            var point = new Point(0, 10, 20, null, 50);

            Assert.That(point.X, Is.EqualTo(10));
            Assert.That(point.Y, Is.EqualTo(20));
            Assert.That(point.Z, Is.Null);
            Assert.That(point.M, Is.EqualTo(50));
        }

        [Test]
        public void InitializeMeasured3dPoint()
        {
            var point = new Point(0, 10, 20, 30, 50);

            Assert.That(point.X, Is.EqualTo(10));
            Assert.That(point.Y, Is.EqualTo(20));
            Assert.That(point.Z, Is.EqualTo(30));
            Assert.That(point.M, Is.EqualTo(50));
        }

        [Test]
        public void InitializeEmptyPoint()
        {
            Point emptyPoint = Point.MakeEmpty(0);

            Assert.That(emptyPoint.IsEmpty, Is.True);
        }
    }
}
