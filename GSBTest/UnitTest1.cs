using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP_adoNet;

namespace GSBTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            GestionDate obj1 = new GestionDate();
            Assert.AreEqual("202103", obj1.getMois());
        }
    }
}
