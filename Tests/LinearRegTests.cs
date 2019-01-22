using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dotnetStats.RegressionModels;
using FluentAssertions;

namespace dotnetStatTests
{
    /// <summary>
    /// Test for correct number of estimates output
    /// </summary>
    [TestClass]
    public class LinearRegTests
    {
        [TestMethod]
        public void TestEstimates()
        {
            double[] TestY = new double[] { 1, 2.5, 3, 4, 5, 6 };
            double[][] TestX = new double[][] {
                new double[] {0, 1, 3, 4 },
                new double[] {1, 27.5, 0.3, 4 },
                new double[] {1, 34, 3.6, 4 },
                new double[] {4, 6.5, 300, 26 },
                new double[] {1, 2.5, 30, 28 },
                new double[] {1, 06, 3, 46 }
            };

            OLS model = new OLS(TestX, TestY);
            RegResults estimates = model.Fit();
            foreach(double el in estimates.Beta)
            {
                Console.Write(el + "\n");
            }
            Assert.AreEqual(TestX[0].Length, estimates.Beta.Length);
        }
        [TestMethod]
        public void TestEstimatesAccuracy()
        {
            double[] TestY = new double[] { 1, 2.5, 3, 4, 5, 6 };
            double[][] TestX = new double[][] {
                new double[] {0, 1, 3, 4 },
                new double[] {1, 27.5, 0.3, 4 },
                new double[] {1, 34, 3.6, 4 },
                new double[] {4, 6.5, 300, 26 },
                new double[] {1, 2.5, 30, 28 },
                new double[] {1, 06, 3, 46 }
            };

            OLS model = new OLS(TestX, TestY);
            RegResults estimates = model.Fit();
            double[] TrueRes = new[] { 1.11242699480196,
                                       0.039030702408277,
                                       - 0.0119325883353133,
                                        0.114322210670513 };
            ApproxEqual EqualApproximately = TestUtils.ApproximatelyEqual;
            estimates.Beta.Should().Equal(estimates.Beta, (left, right) => EqualApproximately(left, right, 0.001));
        }

    }

}
