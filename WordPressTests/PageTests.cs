using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordPressAutomation; // Don't Forget to add this reference

namespace WordPressTests
{
    [TestClass]
    public class PageTests
    {
        [TestInitialize]
        public void init()
        {
            Driver.Initialize();
        }

        [TestMethod]
        public void Can_Edit_A_Page()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("vishwajeet_vibhute@yahoo.com").WithPassword("ShriGanesh123").Login();

            ListPostPage.GoTo(PostType.Page);
            ListPostPage.SelectPost("About");


            Assert.IsTrue(NewPostPage.IsInEditMode(), "Wasn't in edit mode");

            Assert.AreEqual("About", NewPostPage.Title, "Title did not match");

        }


        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        } 
    }
}
