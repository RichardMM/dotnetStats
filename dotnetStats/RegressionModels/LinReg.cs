namespace dotnetStats.RegressionModels
{
    using System;
    using Accord.Math;

    public class LinReg:RegressionAbstractClass
    {
        public LinReg(double[][] x, double[] y) : base(x, y) { }

        public double[] Fit()
        {
            double[][] x_trans = X.Transpose<double>();
            double[][] inv = x_trans.Dot(X).Inverse().Dot(x_trans);
            double[] res = inv.Dot(Y);
          
            return res;
        }
    }
}
