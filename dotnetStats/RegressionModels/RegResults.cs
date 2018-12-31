using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetStats.RegressionModels
{
    public class RegResults
    {
        public double[] Beta { get; }
        public double[][] CovarianceMatrix { get; }
        public double[] estimates {get;}

        public RegResults(double[][] x, double[] y, double[] parameters)
        {

        }
    }
}
