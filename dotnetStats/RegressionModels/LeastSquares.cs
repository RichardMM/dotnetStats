namespace dotnetStats.RegressionModels
{
    using System;
    using Accord.Math;

    /// <summary>
    /// The Ordinary Least Squares Estimator
    /// </summary>
    public class OLS:RegressionAbstractClass
    {
        /// <inheritdoc />
        public OLS(double[][] x, double[] y) : base(x, y) { }

        public override RegResults Fit()
        {
            double[][] x_trans = X.Transpose<double>();
            double[][] inv = x_trans.Dot(X).Inverse().Dot(x_trans);
            double[] res = inv.Dot(Y);
          
            return new RegResults(X,Y,res);
        }
    }


    /// <summary>
    /// The Generalised Least Squares estimator.
    /// It estimates both GLS and WLS using a user provided Covariance Matrix
    /// </summary>
    public class GLS : OLS
    {
        /// <summary>
        /// The Error Variance Covariance Matrix after scaling
        /// </summary>
        public double[][] Weights { get; }

        /// <summary>
        /// Initializes the Generalised Least Squares model
        /// </summary>
        /// <param name="x">The Exogenous variables</param>
        /// <param name="y">The endogenous variables</param>
        /// <param name="weight">The variance covariance matrix</param>
        public GLS(double[][] x, double[] y, double[][] weight) : base(x, y) {}

        public override RegResults Fit()
        {
            double[][] x_trans = X.Transpose<double>();
            double[][] weightInverse = Weights.Inverse();
            double[][] inv = x_trans.Dot(weightInverse).Dot(X).Inverse().Dot(x_trans);
            double[] res = inv.Dot(weightInverse).Dot(Y);

            return new RegResults(X,Y,res);
        }
    }
}
