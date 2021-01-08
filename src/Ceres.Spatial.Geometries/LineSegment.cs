namespace Ceres.Spatial.Geometries
{
    using System;

    internal class LineSegment
    {
        public LineSegment(Point start, Point end)
        {
            Start = start;
            End = end;
        }

        public double Length => Math.Sqrt(Math.Pow(DeltaX, 2) + Math.Pow(DeltaY, 2));

        private double DeltaY => End.Y - Start.Y;

        private double DeltaX => End.X - Start.X;

        public double Slope => DeltaY / DeltaX;

        public Point Start { get; }

        public Point End { get; }
    }

}
