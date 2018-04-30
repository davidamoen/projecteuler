using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ProjectEuler;
using System.Collections.Generic;
using ProjectEuler.Problems;
using ProjectEuler.Models;

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

        [TestMethod]
        public void Test_Triangle_Contains_Origin()
        {
            var tri = new Triangle
            {
                A = new Coordinate(-340, 495),
                B = new Coordinate(-153, -910),
                C = new Coordinate(835, -947)
            };

            var result1 = PointInTriangle(new Coordinate(0, 0), new Coordinate(-340, 495), new Coordinate(-153, -910), new Coordinate(835, -947));

            var result2 = PointInTriangle(new Coordinate(0, 0), new Coordinate(-175, 41), new Coordinate(-421, -714), new Coordinate(574, -645));


            var AB = new Line(tri.A, tri.B);
            var AC = new Line(tri.A, tri.C);
            var BC = new Line(tri.B, tri.C);

            var tri2 = new Triangle
            {
                A = new Coordinate(-175, 41),
                B = new Coordinate(-421, -714),
                C = new Coordinate(574, -645)
            };

            var AB2 = new Line(tri2.A, tri2.B);
            var AC2 = new Line(tri2.A, tri2.C);
            var BC2 = new Line(tri2.B, tri2.C);
        }

        private double sign(Coordinate c1, Coordinate c2, Coordinate c3)
        {
            return (c1.X - c3.X) * (c2.Y - c3.Y) - (c2.X - c3.X) * (c1.Y - c3.Y);
        }

        private bool PointInTriangle(Coordinate pt, Coordinate v1, Coordinate v2, Coordinate v3)
        {
            var b1 = sign(pt, v1, v2) < 0.0f;
            var b2 = sign(pt, v2, v3) < 0.0f;
            var b3 = sign(pt, v3, v1) < 0.0f;

            return ((b1 == b2) && (b2 == b3));
        }
    }
}
