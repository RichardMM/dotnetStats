namespace dotnetStats.GeneralisedLinearModels.Links
{
    using System;
    using Accord.Math;
    public class LogitLink : ILinkInterface
    {
        public double Link(double mu)
        {
            return Math.Log(mu / (1 - mu));
        }

        public double Mean(double[] Beta, double[] x)
        {
            return 1 / (1 + Math.Exp(-Beta.Dot(x)));
        }

        public double MeanDerivative(double[] Beta, double[] x)
        {
            return (1 / Beta.Dot(x)) + (1 / (1 - Beta.Dot(x)));
        }

        public double Theta(double mu)
        {
            return this.Link(mu);
        }
    }
}
