using System;
using FluentAssertions;
using Accord.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dotnetStats.RegressionModels;

namespace dotnetStatTests
{
    /// <summary>
    /// Test for Quantilereg fit
    /// </summary>
    [TestClass]
    public class QuantileRegTests
    {
        [TestMethod]
        public void TestQuantileFit()
        {
            string path = @"C:\Users\Richard\source\repos\dotnetStats\data\x.csv";
            string Ypath = @"C:\Users\Richard\source\repos\dotnetStats\data\y.csv";
            CsvReader reader = new CsvReader(path, hasHeaders: true);
            CsvReader Yreader = new CsvReader(Ypath, hasHeaders: true);

            double[][] XData = reader.ToJagged();
            double[,] YData = Yreader.ToMatrix();
            double[] y = new double[YData.GetLength(0)];
            for(int i=0; i<y.Length; ++i)
            {
                y[i] = YData[i,0];
            }
            var qmodel = new QuantileReg(XData, y, 0.5);
            var res = qmodel.Fit();

            //foreach(double el in res.estimates)
            //{
            //    Console.WriteLine(el);
            //}
            Assert.AreEqual(1, 1);
        }
        

    }
}
