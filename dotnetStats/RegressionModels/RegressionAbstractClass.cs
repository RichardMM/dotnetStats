
namespace dotnetStats.RegressionModels
{
    using Accord.Math;
    public abstract class RegressionAbstractClass : IRegressionInterface
{
    public virtual double[][] X { get; }
    public virtual double[] Y { get; }
    protected virtual int NCols { get; }
    protected virtual int NRows { get; }

        /// <summary>
        /// Initializes the dependent and independednt variables of a regression model.
        /// </summary>
        /// <param name="x">The design matrix. Should be jagged with each inner array referring to a new reocrd.</param>
        /// <param name="y">The dependent variable. A one dimensional array.</param>
        public RegressionAbstractClass(double[][] x, double[] y)
    {
            X = x;
            NRows = X.Length;
            NCols = X[0].Length;
            Y = y;
    }

        /// <summary>
        /// Fits the model.
        /// </summary>
        /// <returns>RegResults Object</returns>
        public abstract RegResults Fit();
}
}
