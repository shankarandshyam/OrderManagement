using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order_Management.Controllers;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var controller = new OrderController();
            var response = controller.DisplayAllOrders();
            Assert.IsTrue(response.Count > 1);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var controller = new OrderController();
            var response = controller.DisplayAllOrders();
            Assert.IsNotNull(response);
        }
    }
}
