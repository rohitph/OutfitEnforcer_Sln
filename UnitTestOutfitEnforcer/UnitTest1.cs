using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibOutfitEnforcer;
namespace UnitTestOutfitEnforcer
{
    [TestClass]
    public class UnitTest1
    {
        private IExecute obj = new ExecuteProgram();
        private TestLogger objLogger = new TestLogger();
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(obj.Execute("HOT 8, 6, 4, 2, 1, 7", objLogger.Log), "Removing PJs, shorts, t-shirt, sun visor, sandals, leaving house",true);

        }
        [TestMethod]
        public void TestMethod2()
        {

            Assert.AreEqual(obj.Execute("COLD 8, 6, 3, 4, 2, 5, 1, 7", objLogger.Log), "Removing PJs, pants, socks, shirt, hat, jacket, boots, leaving house", true);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(obj.Execute("HOT 8, 6, 6", objLogger.Log), "Removing PJs, shorts, fail", true);

        }
        [TestMethod]
        public void TestMethod4()
        {
            Assert.AreEqual(obj.Execute("HOT 8, 6, 3", objLogger.Log), "Removing PJs, shorts, fail", true);

        }
        [TestMethod]
        public void TestMethod5()
        {
            Assert.AreEqual(obj.Execute("COLD 8, 6, 3, 4, 2, 5, 7", objLogger.Log), "Removing PJs, pants, socks, shirt, hat, jacket, fail", true);

        }
        [TestMethod]
        public void TestMethod6()
        {
            Assert.AreEqual(obj.Execute("COLD 6", objLogger.Log), "fail", true);

        }
        [TestMethod]
        public void TestMethod7() //Exception thrown and logged for incorrect temperature type
        {
            objLogger.m_bExceptionThrown = false;
            obj.Execute("COL 6", objLogger.Log);
            Assert.IsTrue(objLogger.m_bExceptionThrown);
            
        }
        [TestMethod]
        public void TestMethod8() //Exception thrown and logged for incorrect command
        {
            objLogger.m_bExceptionThrown = false;
            obj.Execute("HOT 8,11", objLogger.Log);
            Assert.IsTrue(objLogger.m_bExceptionThrown);

        }
        [TestMethod]
        public void TestMethod9() //Exception thrown and logged for non integer command
        {
            objLogger.m_bExceptionThrown = false;
            obj.Execute("HOT 8,ft,7", objLogger.Log);
            Assert.IsTrue(objLogger.m_bExceptionThrown);

        }
    }
    public class TestLogger
    {
        public bool m_bExceptionThrown;
        public TestLogger()
        {
        }
        public void Log(Exception ex)
        {
            m_bExceptionThrown = true;
        }
    }
}
