using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetStats.RegressionModels
{
    class RegResults
    {
        public double[] Beta { get; }
        public double[][] CovarianceMatrix { get; }
    }
}
