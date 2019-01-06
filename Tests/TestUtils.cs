using System;

namespace dotnetStatTests
{
    public delegate bool ApproxEqual(double expected, double actual, double variance);

    public static class TestUtils
    {
        public static bool ApproximatelyEqual(double expected, double actual, double variance)
        {
            double diff = Math.Abs(expected - actual);
            if (diff > variance)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
