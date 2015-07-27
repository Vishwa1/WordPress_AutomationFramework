using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordPressAutomation; // Don't Forget to add this reference

namespace WordPressTests
{
    [TestClass]
    public class LoginTests : WordpressTest
    {
        [TestMethod]
        public void Admin_User_Can_Login()
        {
           Assert.IsTrue(DashboardPage.IsAt, "Failed to Login");
        }
    }
}
