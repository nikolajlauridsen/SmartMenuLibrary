using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartMenuLibrary;

namespace SmartMenuTest {
    [TestClass]
    public class UnitTest1 {
        SmartMenu menu;

        [TestInitialize] //runs before every test method - sets up a "clean" translator
        public void CreateNewTranslator() {
            menu = new SmartMenu();
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
    }
}
