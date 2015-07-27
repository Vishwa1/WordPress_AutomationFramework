using WordPressAutomation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordPressTests
{
    public class WordpressTest
    {
        [TestInitialize]
        public void init()
        {
            Driver.Initialize();
            LoginPage.GoTo();
            LoginPage.LoginAs("vishwajeet_vibhute@yahoo.com").WithPassword("ShriGanesh123").Login();
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        } 


    }
}
