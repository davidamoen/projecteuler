﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ProjectEuler;
using System.Collections.Generic;
using ProjectEuler.Problems;
using System.Numerics;

namespace Tests
{
    [TestClass]
    public class HelperTests
    {

        [TestMethod]
        public void Test_IsPrime()
        {

            Assert.IsTrue(Helpers.IsPrime(1));

            Assert.IsTrue(Helpers.IsPrime(2));

            Assert.IsTrue(Helpers.IsPrime(7));

            Assert.IsFalse(Helpers.IsPrime(6));

            Assert.IsFalse(Helpers.IsPrime(51));

            Assert.IsTrue(Helpers.IsPrime(1109));

            Assert.IsTrue(Helpers.IsPrime(1301081));

        }

        [TestMethod]
        public void Test_GetPrimeFactors()
        {

            var test1 = Helpers.GetPrimeFactors(10);
            Assert.AreEqual(2, test1.Count);

            var test2 = Helpers.GetPrimeFactors(100);
            Assert.AreEqual(4, test2.Count);


            var test3 = Helpers.GetPrimeFactors(5000);
            Assert.AreEqual(7, test3.Count);

            var test4 = Helpers.GetPrimeFactors(123456789);
            Assert.AreEqual(4, test4.Count);



        }

        [TestMethod]
        public void Test_IsPalindrome()
        {

            Assert.IsTrue(Helpers.IsPalindrome(101));

            Assert.IsTrue(Helpers.IsPalindrome(2552));

            Assert.IsFalse(Helpers.IsPalindrome(500));

            Assert.IsFalse(Helpers.IsPalindrome(10000000000000));

            Assert.IsTrue(Helpers.IsPalindrome(5222222222222222225));

        }


        [TestMethod]
        public void Test_IsMultipleOfAllNumbers()
        {

            var list1 = new List<int>();
            for (var i = 1; i <= 10; i++)
            {
                list1.Add(i);
            }

            Assert.IsTrue(Helpers.IsMultipleOfAllNumbers(2520, list1));


            var list2 = new List<int> { 1, 2, 3,4, 5};
            Assert.IsFalse(Helpers.IsMultipleOfAllNumbers(5, list2));

        }

        [TestMethod]
        public void Test_GetNextPrime()
        {
            Assert.AreEqual(251, Helpers.GetNextPrime(241));

            Assert.AreEqual(3691, Helpers.GetNextPrime(3677));

            Assert.AreEqual(9973, Helpers.GetNextPrime(9967));

        }

        [TestMethod]
        public void Test_GetNthPrime()
        {
            Assert.AreEqual(13, Helpers.GetNthPrime(6));

            Assert.AreEqual(97, Helpers.GetNthPrime(25));

            Assert.AreEqual(3989, Helpers.GetNthPrime(550));
        }

        [TestMethod]
        public void Test_GetProduct()
        {
            var list1 = new List<int> { 1, 2, 3};
            Assert.AreEqual(6, Helpers.GetProduct(list1));

            var list2 = new List<int> { 9, 9, 8, 9 };
            Assert.AreEqual(5832, Helpers.GetProduct(list2));
        }

        [TestMethod]
        public void Test_IsPythagoreanTriplet()
        {
            var t1 = new Triplet { A = 3, B = 4, C = 5 };
            Assert.IsTrue(Helpers.IsPythagoreanTriplet(t1));

            var t2 = new Triplet { A = 3, B = 4, C = 10 };
            Assert.IsFalse(Helpers.IsPythagoreanTriplet(t2));

            var t3 = new Triplet { A = 5, B = 12, C = 13 };
            Assert.IsTrue(Helpers.IsPythagoreanTriplet(t3));

            var t4 = new Triplet { A = 31, B = 480, C = 481 };
            Assert.IsTrue(Helpers.IsPythagoreanTriplet(t4));
        }

        [TestMethod]
        public void Test_FindSumofPrimesBelowN()
        {
            Assert.AreEqual(17, Helpers.FindSumofPrimesBelowN(10));

        }


        [TestMethod]
        public void Test_GetFactorsOfN()
        {

            Assert.AreEqual(1, Helpers.GetFactorsOfN(1).Count);
            Assert.AreEqual(2, Helpers.GetFactorsOfN(3).Count);
            Assert.AreEqual(4, Helpers.GetFactorsOfN(6).Count);
            Assert.AreEqual(4, Helpers.GetFactorsOfN(10).Count);
            Assert.AreEqual(4, Helpers.GetFactorsOfN(15).Count);
            Assert.AreEqual(4, Helpers.GetFactorsOfN(21).Count);
            Assert.AreEqual(6, Helpers.GetFactorsOfN(28).Count);

        }

        [TestMethod]
        public void Test_GetCollatzSequence()
        {
            var seq = Helpers.GetCollatzSequence(13);

            Assert.AreEqual(10, seq.Count);
            Assert.AreEqual(13, seq[0]);
            Assert.AreEqual(40, seq[1]);
            Assert.AreEqual(20, seq[2]);
            Assert.AreEqual(10, seq[3]);
            Assert.AreEqual(5, seq[4]);
            Assert.AreEqual(16, seq[5]);
            Assert.AreEqual(8, seq[6]);
            Assert.AreEqual(4, seq[7]);
            Assert.AreEqual(2, seq[8]);
            Assert.AreEqual(1, seq[9]);
        }

        [TestMethod]
        public void Test_GetFactorial()
        {
            Assert.AreEqual(1, Helpers.GetFactorial(1));
            Assert.AreEqual(2, Helpers.GetFactorial(2));
            Assert.AreEqual(6, Helpers.GetFactorial(3));
            Assert.AreEqual(3628800, Helpers.GetFactorial(10));
        }

        [TestMethod]
        public void Test_GetLatticePaths()
        {

            Assert.AreEqual(6, Helpers.GetLatticePaths(2, 2));
            Assert.AreEqual(10, Helpers.GetLatticePaths(3, 2));

        }

        [TestMethod]
        public void Test_GetN2Power()
        {
            Assert.AreEqual(1, Helpers.GetN2Power(2, 0));
            Assert.AreEqual(2, Helpers.GetN2Power(2, 1));
            Assert.AreEqual(16, Helpers.GetN2Power(2, 4));
            Assert.AreEqual(1024, Helpers.GetN2Power(2, 10));
            Assert.AreEqual(32768, Helpers.GetN2Power(2, 15));
            Assert.AreEqual(4294967296, Helpers.GetN2Power(2, 32));
        }

        [TestMethod]
        public void Test_GetSumOfDigits()
        {
            Assert.AreEqual(26, Helpers.GetSumOfDigits(32768));
        }

    }
}
