﻿// Accord Unit Tests
// The Accord.NET Framework
// http://accord.googlecode.com
//
// Copyright © César Souza, 2009-2012
// cesarsouza at gmail.com
//
//    This library is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 2.1 of the License, or (at your option) any later version.
//
//    This library is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public
//    License along with this library; if not, write to the Free Software
//    Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
//

namespace Accord.Tests.Vision
{
    using Accord.Vision.Detection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Threading;
    using Accord.Vision.Detection.Cascades;

    /// <summary>
    ///This is a test class for HaarCascadeTest and is intended
    ///to contain all HaarCascadeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class HaarCascadeTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Clone
        ///</summary>
        [TestMethod()]
        public void CloneTest()
        {
            HaarCascade expected = new FaceHaarCascade();
            HaarCascade actual = (HaarCascade)expected.Clone();

            Assert.AreNotEqual(expected, actual);

            Assert.AreEqual(expected.HasTiltedFeatures, actual.HasTiltedFeatures);
            Assert.AreEqual(expected.Height, actual.Height);
            Assert.AreEqual(expected.Width, actual.Width);

            Assert.AreNotEqual(expected.Stages, actual.Stages);
            Assert.AreEqual(expected.Stages.Length, actual.Stages.Length);

            for (int i = 0; i < expected.Stages.Length; i++)
                equals(expected.Stages[i], actual.Stages[i]);
        }

        private void equals(HaarCascadeStage expected, HaarCascadeStage actual)
        {
            Assert.AreNotEqual(expected, actual);

            Assert.AreEqual(expected.NextIndex, actual.NextIndex);
            Assert.AreEqual(expected.ParentIndex, actual.ParentIndex);
            Assert.AreEqual(expected.Threshold, actual.Threshold);

            Assert.AreNotEqual(expected.Trees, actual.Trees);
            Assert.AreEqual(expected.Trees.Length, actual.Trees.Length);

            for (int i = 0; i < expected.Trees.Length; i++)
            {
                Assert.AreNotEqual(expected.Trees[i], actual.Trees[i]);
                Assert.AreEqual(expected.Trees[i].Length, actual.Trees[i].Length);

                for (int j = 0; j < expected.Trees[i].Length; j++)
                    equals(expected.Trees[i][j], actual.Trees[i][j]);
            }
        }

        private void equals(HaarFeatureNode expected, HaarFeatureNode actual)
        {
            Assert.AreNotEqual(expected, actual);

            Assert.AreEqual(expected.LeftNodeIndex, actual.LeftNodeIndex);
            Assert.AreEqual(expected.LeftValue, actual.LeftValue);
            Assert.AreEqual(expected.RightNodeIndex, actual.RightNodeIndex);
            Assert.AreEqual(expected.RightValue, actual.RightValue);
            Assert.AreEqual(expected.Threshold, actual.Threshold);

            equals(expected.Feature, actual.Feature);
        }

        private void equals(HaarFeature expected, HaarFeature actual)
        {
            Assert.AreNotEqual(expected, actual);

            Assert.AreEqual(expected.Tilted, actual.Tilted);
            Assert.AreNotEqual(expected.Rectangles, actual.Rectangles);
            Assert.AreEqual(expected.Rectangles.Length, actual.Rectangles.Length);

            for (int i = 0; i < expected.Rectangles.Length; i++)
                equals(expected.Rectangles[i], actual.Rectangles[i]);
        }

        private void equals(HaarRectangle expected, HaarRectangle actual)
        {
            Assert.AreNotEqual(expected, actual);
            Assert.AreEqual(expected.X, actual.X);
            Assert.AreEqual(expected.Y, actual.Y);
            Assert.AreEqual(expected.Weight, actual.Weight);
            Assert.AreEqual(expected.Width, actual.Width);
            Assert.AreEqual(expected.Height, actual.Height);
        }

      
    }
}
