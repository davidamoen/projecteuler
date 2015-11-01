using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ProjectEuler;
using System.Collections.Generic;
using ProjectEuler.Problems;

namespace Tests
{
    [TestClass]
    public class ProblemTests
    {
        [TestMethod]
        public void Test_Eight()
        {

            var number = Eight.GetNumber();

            Assert.AreEqual(1000, number.Count);
            Assert.AreEqual(7, number[0]);
            Assert.AreEqual(0, number[number.Count -1]);

            Assert.AreEqual(5832, Eight.GetLargestProduct(4));


        }

    }
}
