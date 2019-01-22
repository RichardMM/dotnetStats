using System;
using Accord.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dotnetStats.GeneralisedLinearModels;
using dotnetStats.GeneralisedLinearModels.Links;

namespace dotnetStatTests
{
    [TestClass]
    public class LogitTest
    {
        [TestMethod]
        public void BinomialGLMTest()
        {
            string path = @"data/glm/logit_x.csv";
            string Ypath = @"data/glm/logit_y.csv";
            CsvReader reader = new CsvReader(path, hasHeaders: true);
            CsvReader Yreader = new CsvReader(Ypath, hasHeaders: true);

            double[][] XData = reader.ToJagged();
            double[,] YData = Yreader.ToMatrix();
            double[] y = new double[YData.GetLength(0)];
            for (int i = 0; i < y.Length; ++i)
            {
                y[i] = YData[i, 0];
            }

            ILinkInterface link = new LogitLink();
            var qmodel = new BinomialLikelihood(XData, y, link);
            var res = qmodel.Fit();
            Assert.AreEqual(res.Length, XData[0].Length);
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
            
        }
    }
}
