using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordPressAutomation; // Don't Forget to add this reference

namespace WordPressTests
{
    [TestClass]
    public class LoginTests
    {
        [TestInitialize]
        public void init()
        {
            Driver.Initialize();
        }
        
        [TestMethod]
        public void Admin_User_Can_Login()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("vishwajeet_vibhute@yahoo.com").WithPassword("ShriGanesh123").Login();
            Assert.IsTrue(DashboardPage.IsAt, "Failed to Login");
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        } 
        
         
    }
}
