
namespace dotnetStats.RegressionModels
{
    using Accord.Math;
    public abstract class RegressionAbstractClass : IRegressionInterface
{
    public virtual double[][] X { get; }
    public virtual double[] Y { get; }
    protected virtual int NCols { get; }
    protected virtual int NRows { get; }

        public RegressionAbstractClass(double[][] x, double[] y)
    {
            X = x;
            NRows = X.Length;
            NCols = X[0].Length;
            Y = y;
    }
}
}
