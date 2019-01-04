namespace dotnetStats.RegressionModels
{
    using System;
    public interface IRegressionInterface
    {
        Double[][] X { get; }
        Double[] Y { get;}

        RegResults Fit();
    }
}
