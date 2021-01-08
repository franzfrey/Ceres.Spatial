namespace Ceres.Spatial.Geometries
{
    using System.Collections.Generic;

    public class MultiLineString : MultiCurve
    {
        public MultiLineString(int srid, IReadOnlyList<LineString> lineStrings) : base(srid, lineStrings)
        {
        }
    }
}
