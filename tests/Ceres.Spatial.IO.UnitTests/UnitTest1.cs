namespace Ceres.Spatial.IO.UnitTests
{
    using System.Collections.Generic;
    using System.IO;

    using Ceres.Spatial.Geometries;
    using Ceres.Spatial.IO.Shapefile;
    using Ceres.Spatial.IO.UnitTests.Properties;

    using NUnit.Framework;

    public class Tests
    {
        [Test]
        public void ReadThreePoints()
        {
            var shapeFileStream = new MemoryStream(Resources.test_shp);
            var features = new List<Feature>();

            var reader = new ShapefileReader(shapeFileStream);

            while (reader.Next())
            {
                features.Add(reader.Read());
            }

            Assert.That(reader.FileLength, Is.EqualTo(184));
            Assert.That(reader.Version, Is.EqualTo(1000));
            Assert.That(reader.ShapeType, Is.EqualTo(ShapeType.Point));
            Assert.That(features, Has.Count.EqualTo(3));
        }
    }
}