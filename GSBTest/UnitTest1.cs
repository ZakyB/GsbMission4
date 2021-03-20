using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            Assert.AreEqual("202102", obj1.getMoisPrecedant("202103"));
        }
        [TestMethod]
        public void TestGetMoisSuivant()
        {
            GestionDate obj1 = new GestionDate();
            Assert.AreEqual("202201", obj1.getMoisSuivant("202112"));
        }
    }
}
