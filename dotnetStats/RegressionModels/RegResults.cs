using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetStats.RegressionModels
{
    public class RegResults
    {
        public double[][] X { get; }
        public double[] Y { get; }
        public double[] Beta { get; }
        public double[][] CovarianceMatrix { get; }

        public RegResults(double[][] x, double[] y, double[] parameters)
        {
            X = x;
            Y = y;
            Beta = parameters;
        }
    }
}
