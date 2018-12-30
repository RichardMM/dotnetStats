
namespace dotnetStats.RegressionModels
{
    public abstract class RegressionAbstractClass : IRegressionInterface
{
    public double[][] X { get; }
    public double[] Y { get; }

    public RegressionAbstractClass(double[][] x, double[] y)
    {
        X = x;
        Y = y;
    }
}
}
