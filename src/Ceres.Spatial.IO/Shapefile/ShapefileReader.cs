namespace Ceres.Spatial.IO.Shapefile
{
    using System;
    using System.IO;

    using Ceres.Spatial.Geometries;

    public class ShapefileReader : IFeatureReader
    {
        private const int fileCode = 9994;
        private readonly Stream shapeFileStream;
        private bool isOpen;

        public int FileLength { get; private set; }

        public int Version { get; private set; }

        public ShapeType ShapeType { get; private set; }

        public BoundingBox BoundingBox { get; private set; }

        public ShapefileReader(Stream shapeFileStream)
        {
            this.shapeFileStream = shapeFileStream;
        }

        public bool Next()
        {
            if (!this.isOpen)
            {
                this.Open();
            }

            return this.shapeFileStream.Position < this.FileLength;
        }

        private void Open()
        {
            this.ReadHeader();

            this.isOpen = true;
        }

        private void ReadHeader()
        {
            if (ReadInt(false) != fileCode) throw new InvalidDataException();
            this.shapeFileStream.Seek(20, SeekOrigin.Current);
            this.FileLength = ReadInt(false) * 2;
            this.Version = ReadInt(true);
            this.ShapeType = (ShapeType)ReadInt(true);
            this.BoundingBox = new BoundingBox
            {
                MinX = ReadDouble(true),
                MinY = ReadDouble(true),
                MaxX = ReadDouble(true),
                MaxY = ReadDouble(true),
                MinZ = ReadDouble(true),
                MaxZ = ReadDouble(true),
                MinM = ReadDouble(true),
                MaxM = ReadDouble(true)
            };
        }

        private int ReadInt(bool isLittleEndian)
        {
            const int length = sizeof(int);
            var buffer = new byte[length];
            var readBytes = this.shapeFileStream.Read(buffer, 0, length);
            if (readBytes != length) throw new Exception();
            if (BitConverter.IsLittleEndian != isLittleEndian)
            {
                Array.Reverse(buffer);
            }
            return BitConverter.ToInt32(buffer, 0);
        }

        private double ReadDouble(bool isLittleEndian)
        {
            const int length = sizeof(double);
            var buffer = new byte[length];
            var readBytes = this.shapeFileStream.Read(buffer, 0, length);
            if (readBytes != length) throw new Exception();
            if (BitConverter.IsLittleEndian != isLittleEndian)
            {
                Array.Reverse(buffer);
            }
            return BitConverter.ToDouble(buffer, 0);
        }

        private enum Endian
        {
            Little,
            Big
        }

        public Feature Read()
        {
            if (!this.isOpen) throw new Exception();

            // record header
            var recordNumber = ReadInt(false);
            var contentLength = ReadInt(false) * 2;

            // record content
            var shapeType = (ShapeType)ReadInt(true);
            if (shapeType != ShapeType.NullShape || shapeType != this.ShapeType)
                throw new Exception();

            var geom = shapeType switch
            {
                ShapeType.NullShape => Point.MakeEmpty(0),
                ShapeType.Point => ReadPoint(),
                _ => throw new Exception()
            };

            return new Feature(geom);
        }

        private Point ReadPoint()
        {
            return new Point(0, ReadDouble(true), ReadDouble(true));
        }
    }
}
