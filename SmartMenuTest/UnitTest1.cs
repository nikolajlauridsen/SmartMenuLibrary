using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartMenuLibrary;

namespace SmartMenuTest {
    [TestClass]
    public class UnitTest1 {
        SmartMenu menu;

        [TestInitialize]
        public void CreateNewTranslator() {
            menu = new SmartMenu(null);  // Bindings are never actually called so there's no reason to create a Binding object.
            
            menu.LoadMenu("MenuSpec.txt");
        }

        [TestMethod]
        public void TestTitle() {
            Assert.AreEqual("My fancy menu!", menu.GetTitle());
        }

        [TestMethod]
        public void TestDesc() {
            Assert.AreEqual("Press menu number or 0 to exit:", menu.GetDesc());
        }

        [TestMethod]
        public void TestMenuDimensions() {
            String[,] points = menu.GetPoints();
            Assert.AreEqual(4, points.GetLength(0));
            Assert.AreEqual(2, points.GetLength(1));
        }

        [TestMethod]
        public void TestPointIDs() {
            String[,] points = menu.GetPoints();
            Assert.AreEqual("this", points[0, 1]);
            Assert.AreEqual("that", points[1, 1]);
            Assert.AreEqual("something", points[2, 1]);
            Assert.AreEqual("another", points[3, 1]);
        }

        [TestMethod]
        public void TestPointTitles() {
            String[,] points = menu.GetPoints();
            Assert.AreEqual("Do This", points[0, 0]);
            Assert.AreEqual("Do That", points[1, 0]);
            Assert.AreEqual("Do Something", points[2, 0]);
            Assert.AreEqual("Get the answer to Life, the Universe and Everything", points[3, 0]);
        }
    }
}
