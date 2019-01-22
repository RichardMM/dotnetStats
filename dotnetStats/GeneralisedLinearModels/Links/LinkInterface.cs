

namespace dotnetStats.GeneralisedLinearModels.Links
{
    //TODO: Define method overloads that don't require beta or X
    public interface ILinkInterface
    {
        /// <summary>
        /// Relates the link function to the mu parameter
        /// </summary>
        /// <param name="mu"></param>
        /// <returns></returns> 
        double Link(double mu);

        /// <summary>
        /// Provides relation of the link function back to the distribution
        /// Will make use of the mean
        /// 
        /// </summary>
        /// <param name="Beta"></param>
        /// <param name="X"></param>
        /// <returns></returns>
        double Mean(double[] Beta, double[] X);


       
        /// <summary>
        /// Derivative of the mean with respect to eta. Used in Loglikelihood derivative
        /// </summary>
        /// <param name="Beta">parameters to be estimated</param>
        /// <param name="X">X value where theta will be evaluated at</param>
        /// <returns></returns>
        double MeanDerivative(double[] Beta, double[] X);

        /// <summary>
        /// Returns thete parameter
        /// </summary>
        /// <param name="mu"></param>
        /// <returns></returns>
        double Theta(double mu);
    }
}
