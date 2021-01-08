namespace Ceres.Spatial.Geometries
{
    public interface IReferenceSystem
    {
        int Dimension { get; }

        string[] AxisNames { get; }
    }
}
