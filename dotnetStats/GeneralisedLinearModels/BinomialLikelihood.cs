
namespace dotnetStats.GeneralisedLinearModels
{
    using System;
    using dotnetStats.Utilities;
    using Accord.Math.Optimization;
    using System.Collections.Generic;
    using dotnetStats.GeneralisedLinearModels.Links;

    public class BinomialLikelihood : LikelihoodBase
    {
        public override double Phi => throw new NotImplementedException();

        public BinomialLikelihood(double[][] x, double[] y, ILinkInterface link) :base(x,y)
        {
            LinkFunction = link;
        }

        public override double APhi()
        {
            return Y.Length;
        }

        public override double BTheta(double theta)
        {
            return Math.Log(1+Math.Exp(theta));
        }

        public override double CPhi(double y)
        {
            int product;
            
            product = (int)(y*N);

            return Math.Log(N.Factorial() / product.Factorial());
        }
        public double[] Fit()
        {
            var f = new NonlinearObjectiveFunction(this.P,
                function: (x) => this.Loglikelihood(x),
                gradient: (x) => this.LLDerivative(x)
                );

            double[] cons = new double[P];
            for (int i = 0; i < this.P; i++)
            {
                cons[i] = 0;
            }
            var constraints = new List<NonlinearConstraint>
            {
                new NonlinearConstraint(f,

                function: (x) => 0,
                gradient: (x) => cons,

                shouldBe: ConstraintType.EqualTo, value: 0
            )
            };
            var solver = new AugmentedLagrangian(f,constraints);
            solver.Maximize();
            return solver.Solution;
        }
    }

}
