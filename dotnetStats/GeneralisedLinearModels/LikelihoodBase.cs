namespace dotnetStats.GeneralisedLinearModels
{
    using Accord.Math;
    using System;
    using dotnetStats.GeneralisedLinearModels.Links;

    public abstract class LikelihoodBase : ILikelihoodInterface
    {
        public virtual double Phi => throw new NotImplementedException();

        public double[][] X { get; }

        public double[] Y { get; }

        public int N { get; }

        public int P { get; }

        //TODO: see of this can be estimated using the phi parameter
        private double YVariance { get; }

        public ILinkInterface LinkFunction { get; set; }

        public LikelihoodBase(double[][] x, double[] y)
        {
            X = x;
            Y = y;

            N = y.Length;
            P = x[0].Length;

            double mean = y.Sum() / N;

            YVariance = y.Add(-mean).Sum()/(N-1);
        }

        public virtual double APhi()
        {
            throw new NotImplementedException();
        }

        public virtual double BTheta(double theta)
        {
            throw new NotImplementedException();
        }

        public virtual double CPhi(double Y)
        {
            throw new NotImplementedException();
        }

        public double[] LLDerivative(double[] beta)
        {
            double[] derrArray = LlDerivativeAddend(X[0], Y[0], beta);
           

            for (int i = 1; i < N; i++)
            {
                derrArray = derrArray.Add(LlDerivativeAddend(X[i], Y[i], beta));
            }

            return derrArray;
        }

        public double[] LlDerivativeAddend(double[] x, double y, double[] beta)
        {
            int ParamCount = beta.Length;
            double[] resultArray = new double[ParamCount];

            double LinkMeanDerivative = LinkFunction.MeanDerivative(beta,x);

            for (int j = 0; j < P; j++)
            {
                double numerator = (y - LinkFunction.Mean(beta, x))*x[j]* LinkMeanDerivative;
                
                resultArray[j] = numerator / YVariance;
            }

            return resultArray;
            
        }

        public double Loglikelihood(double[] beta)
        {
            double sum = 0;
            for (int i = 0; i < Y.Length; i++)
            {
       
                sum = sum + LoglikelihoodAddend(X[i], Y[i], beta: beta);
            }
            return sum;
        }

        public virtual double LoglikelihoodAddend(double[] x, double y, double[] beta)
        {
            double theta = LinkFunction.Theta(LinkFunction.Mean(beta, x));
            return (( theta* y - BTheta(theta)) / APhi()) + CPhi(y);
        }
    }
}
