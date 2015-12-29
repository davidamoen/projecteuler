using System;
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
        public void Test_GetProperDivisorsOfN()
        {

            Assert.AreEqual(11, Helpers.GetProperDivisorsOfN(220).Count);
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

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Test_ConvertN2BritishUsage()
        {

            Assert.AreEqual("one", Helpers.ConvertN2BritishUsage(1));
            Assert.AreEqual("ten", Helpers.ConvertN2BritishUsage(10));
            Assert.AreEqual("five", Helpers.ConvertN2BritishUsage(5));
            Assert.AreEqual("fifteen", Helpers.ConvertN2BritishUsage(15));
            Assert.AreEqual("twenty-five", Helpers.ConvertN2BritishUsage(25));
            Assert.AreEqual("forty", Helpers.ConvertN2BritishUsage(40));
            Assert.AreEqual("one hundred", Helpers.ConvertN2BritishUsage(100));
            Assert.AreEqual("one hundred and five", Helpers.ConvertN2BritishUsage(105));
            Assert.AreEqual("one hundred and forty-five", Helpers.ConvertN2BritishUsage(145));
            Assert.AreEqual("three hundred and forty-two", Helpers.ConvertN2BritishUsage(342));
            Assert.AreEqual("one hundred and fifteen", Helpers.ConvertN2BritishUsage(115));
            Assert.AreEqual("five hundred and thirty-five", Helpers.ConvertN2BritishUsage(535));
            Assert.AreEqual("five hundred and thirteen", Helpers.ConvertN2BritishUsage(513));
            Assert.AreEqual("eight hundred and ninety-nine", Helpers.ConvertN2BritishUsage(899));
            Assert.AreEqual("nine hundred and ninety-nine", Helpers.ConvertN2BritishUsage(999));
            Assert.AreEqual("one thousand", Helpers.ConvertN2BritishUsage(1000));

            Assert.AreEqual(23, Helpers.GetNumberLetterCountforN(342));
            Assert.AreEqual(20, Helpers.GetNumberLetterCountforN(115));

        }

        [TestMethod]
        public void Test_GetMaxPathSum()
        {
            var grid = new List<List<long>>();

            grid.Add(new List<long>() { 3 });
            grid.Add(new List<long>() { 7, 4 });
            grid.Add(new List<long>() { 2, 4, 6 });
            grid.Add(new List<long>() { 8, 5, 9, 3 });

            Assert.AreEqual(23, Helpers.GetMaximumPathSum(grid));

        }

        [TestMethod]
        public void Test_AmicableD()
        {

            Assert.AreEqual(284, Helpers.AmicableD(220));

            Assert.AreEqual(220, Helpers.AmicableD(284));

        }

        [TestMethod]
        public void Test_GetAmicablePair()
        {

            Assert.AreEqual(284, Helpers.GetAmicablePair(220).b);

            Assert.AreEqual(1210, Helpers.GetAmicablePair(1184).b);

            Assert.AreEqual(2924, Helpers.GetAmicablePair(2620).b);

            Assert.AreEqual(5564, Helpers.GetAmicablePair(5020).b);

            Assert.AreEqual(0, Helpers.GetAmicablePair(100).b);

        }

        [TestMethod]
        public void Test_GetLetterScore()
        {

            Assert.AreEqual(1, Helpers.GetLetterScore("A"));
            Assert.AreEqual(2, Helpers.GetLetterScore("B"));
            Assert.AreEqual(3, Helpers.GetLetterScore("C"));
            Assert.AreEqual(4, Helpers.GetLetterScore("D"));
            Assert.AreEqual(5, Helpers.GetLetterScore("E"));
            Assert.AreEqual(6, Helpers.GetLetterScore("F"));
            Assert.AreEqual(7, Helpers.GetLetterScore("G"));
            Assert.AreEqual(8, Helpers.GetLetterScore("H"));
            Assert.AreEqual(9, Helpers.GetLetterScore("I"));
            Assert.AreEqual(10, Helpers.GetLetterScore("J"));
            Assert.AreEqual(11, Helpers.GetLetterScore("K"));
            Assert.AreEqual(12, Helpers.GetLetterScore("L"));
            Assert.AreEqual(13, Helpers.GetLetterScore("M"));
            Assert.AreEqual(14, Helpers.GetLetterScore("N"));
            Assert.AreEqual(15, Helpers.GetLetterScore("O"));
            Assert.AreEqual(16, Helpers.GetLetterScore("P"));
            Assert.AreEqual(17, Helpers.GetLetterScore("Q"));
            Assert.AreEqual(18, Helpers.GetLetterScore("R"));
            Assert.AreEqual(19, Helpers.GetLetterScore("S"));
            Assert.AreEqual(20, Helpers.GetLetterScore("T"));
            Assert.AreEqual(21, Helpers.GetLetterScore("U"));
            Assert.AreEqual(22, Helpers.GetLetterScore("V"));
            Assert.AreEqual(23, Helpers.GetLetterScore("W"));
            Assert.AreEqual(24, Helpers.GetLetterScore("X"));
            Assert.AreEqual(25, Helpers.GetLetterScore("Y"));
            Assert.AreEqual(26, Helpers.GetLetterScore("Z"));
        }

        [TestMethod]
        public void Test_GetWordScore()
        {
            Assert.AreEqual(53, Helpers.GetWordScore("COLIN"));
        }

        [TestMethod]
        public void Test_GetPositionInStringList()
        {
            var list = Helpers.GetNameListFor22();

            Assert.AreEqual(938, Helpers.GetPositionInStringList("COLIN", list));
        }

        [TestMethod]
        public void Test_IsAbundant()
        {
            Assert.IsTrue(Helpers.IsAbundant(12));
            Assert.IsTrue(Helpers.IsAbundant(18));
            Assert.IsTrue(Helpers.IsAbundant(72));
            Assert.IsTrue(Helpers.IsAbundant(120));
            Assert.IsFalse(Helpers.IsAbundant(15));
            Assert.IsFalse(Helpers.IsAbundant(95));
        }

        [TestMethod]
        public void Test_GetAbundantNumbersBelowN()
        {
            Assert.AreEqual(2, Helpers.GetAbundantNumbersBelowN(20).Count);
            Assert.AreEqual(4, Helpers.GetAbundantNumbersBelowN(30).Count);
            Assert.AreEqual(21, Helpers.GetAbundantNumbersBelowN(100).Count);
        }

        [TestMethod]
        public void Test_GetLexigraphicPermutations()
        {
            var digits = "0,1,2";
            var perms = Helpers.GetLexigraphicPermutations(digits);
            Assert.AreEqual(6, perms.Count);
            Assert.AreEqual("012", perms[0]);
            Assert.AreEqual("021", perms[1]);
            Assert.AreEqual("102", perms[2]);
            Assert.AreEqual("120", perms[3]);
            Assert.AreEqual("201", perms[4]);
            Assert.AreEqual("210", perms[5]);

            digits = "1,2,3,4";
            perms = Helpers.GetLexigraphicPermutations(digits);
            Assert.AreEqual(24, perms.Count);
            Assert.IsTrue(perms.Contains("3124"));
        }

        [TestMethod]
        public void Test_FindDecimalsAsStringForD()
        {
            Assert.AreEqual("142857142", Helpers.FindDecimalsAsStringForD(7).Substring(0,9));

            Assert.AreEqual("555555555", Helpers.FindDecimalsAsStringForD(18).Substring(0, 9));

            Assert.AreEqual("123456790", Helpers.FindDecimalsAsStringForD(81).Substring(0, 9));

            
        }

        [TestMethod]
        public void Test_FindRecurringCycle()
        {

            Assert.AreEqual("3", Helpers.FindRecurringCycle("33333333"));
            Assert.AreEqual("6", Helpers.FindRecurringCycle("166666666"));
            Assert.AreEqual("1", Helpers.FindRecurringCycle("111111111111111"));
            Assert.AreEqual("142857", Helpers.FindRecurringCycle("142857142857142857142857142857142857142857"));

        }

        [TestMethod]
        public void Test_GetQuadraticPrimes()
        {
            Assert.AreEqual(40, Helpers.GetQuadraticPrimes(1, 41).Count);
            Assert.AreEqual(80, Helpers.GetQuadraticPrimes(-79, 1601).Count);    
        }

        [TestMethod]
        public void Test_GetNumberSpriralGrid()
        {

            var g1 = Helpers.GetNumberSpriralGrid(3);
            Assert.AreEqual(3, g1.Count);
            
            Assert.AreEqual(1, g1[1][1]);
            Assert.AreEqual(2, g1[2][1]);
            Assert.AreEqual(3, g1[2][2]);
            Assert.AreEqual(4, g1[1][2]);
            Assert.AreEqual(5, g1[0][2]);
            Assert.AreEqual(6, g1[0][1]);
            Assert.AreEqual(7, g1[0][0]);
            Assert.AreEqual(8, g1[1][0]);
            Assert.AreEqual(9, g1[2][0]);

            var g2 = Helpers.GetNumberSpriralGrid(5);
            Assert.AreEqual(1, g2[2][2]);
            Assert.AreEqual(2, g2[3][2]);
            Assert.AreEqual(3, g2[3][3]);
            Assert.AreEqual(4, g2[2][3]);
            Assert.AreEqual(5, g2[1][3]);
            Assert.AreEqual(6, g2[1][2]);
            Assert.AreEqual(7, g2[1][1]);
            Assert.AreEqual(8, g2[2][1]);
            Assert.AreEqual(9, g2[3][1]);
            Assert.AreEqual(10, g2[4][1]);
            Assert.AreEqual(11, g2[4][2]);
            Assert.AreEqual(12, g2[4][3]);
            Assert.AreEqual(13, g2[4][4]);
            Assert.AreEqual(14, g2[3][4]);
            Assert.AreEqual(15, g2[2][4]);
            Assert.AreEqual(16, g2[1][4]);
            Assert.AreEqual(17, g2[0][4]);
            Assert.AreEqual(18, g2[0][3]);
            Assert.AreEqual(19, g2[0][2]);
            Assert.AreEqual(20, g2[0][1]);
            Assert.AreEqual(21, g2[0][0]);
            Assert.AreEqual(22, g2[1][0]);
            Assert.AreEqual(23, g2[2][0]);
            Assert.AreEqual(24, g2[3][0]);
            Assert.AreEqual(25, g2[4][0]);

        }

        [TestMethod]
        public void Test_GetNumberSpiralDiagonalSum()
        {
            var grid = Helpers.GetNumberSpriralGrid(5);
            Assert.AreEqual(101, Helpers.GetNumberSpiralDiagonalSum(grid));
        }

        [TestMethod]
        public void Test_GetDigits2Powers()
        {

            var list = Helpers.GetDigits2Powers(4);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(1634, list[0]);
            Assert.AreEqual(8208, list[1]);
            Assert.AreEqual(9474, list[2]);


        }

    }
}
