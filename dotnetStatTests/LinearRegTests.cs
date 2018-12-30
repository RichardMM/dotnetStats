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

            LinReg model = new LinReg(TestX, TestY);
            double[] estimates = model.Fit();
            foreach(double el in estimates)
            {
                Console.Write(el + "\n");
            }
            Assert.AreEqual(TestX[0].Length, estimates.Length);
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

            LinReg model = new LinReg(TestX, TestY);
            double[] estimates = model.Fit();
            double[] TrueRes = new[] { 1.11242699480196,
                                       0.039030702408277,
                                       - 0.0119325883353133,
                                        0.114322210670513 };
            ApproxEqual EqualApproximately = TestUtils.ApproximatelyEqual;
            estimates.Should().Equal(estimates, (left, right) => EqualApproximately(left, right, 0.001));
        }

    }

}
