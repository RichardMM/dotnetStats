namespace dotnetStats.GeneralisedLinearModels
{
    using dotnetStats.GeneralisedLinearModels.Links;

    public interface ILikelihoodInterface
    {
        double Phi { get; }
        int N { get; }

        int P { get; }

        double[][] X { get; }
        double[] Y { get; }


        ILinkInterface LinkFunction { get; set; }

        double APhi();

        double BTheta(double theta);

        double CPhi(double Y);

        double LoglikelihoodAddend(double[] x, double y, double[] Beta);

        double Loglikelihood(double[] beta);

        double[] LlDerivativeAddend(double[] x, double y, double[] beta);

        double[] LLDerivative(double[] beta);
    }
}
