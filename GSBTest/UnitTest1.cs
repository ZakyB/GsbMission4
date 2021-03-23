using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TP_adoNet;

namespace GSBTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetMois()
        {
            GestionDate obj1 = new GestionDate();
            Assert.AreEqual("202103", obj1.getMois());
        }
        [TestMethod]
        public void TestGetMoisPrecedant()
        {
            GestionDate obj1 = new GestionDate();
            Assert.AreEqual("202102", obj1.getMoisPrecedant(obj1.getMois()));
        }
        [TestMethod]
        public void TestGetMoisSuivant()
        {
            GestionDate obj1 = new GestionDate();
            Assert.AreEqual("202201", obj1.getMoisSuivant("202112"));
        }

        [TestMethod]
        public void TestJour()
        {
            GestionDate obj1 = new GestionDate();
            Assert.AreEqual(23, obj1.getJour());
        }
        [TestMethod]
        public void TestGetMoisSuivantFalse()
        {
            GestionDate obj1 = new GestionDate();
            Assert.AreNotEqual("202213", obj1.getMoisSuivant("202112"));
        }
    }
}
