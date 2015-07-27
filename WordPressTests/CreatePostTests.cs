using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordPressAutomation;


namespace WordPressTests
{
    [TestClass]
    public class CreatePostTests
    {
        [TestInitialize]
        public void init()
        {
            Driver.Initialize();
        }

        [TestMethod]
        public void Can_Create_A_Basic_Post()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("vishwajeet_vibhute@yahoo.com").WithPassword("ShriGanesh123").Login();

            NewPostPage.GoTo();
            NewPostPage.CreatePost("POST TITLE 1")
                .withBody("This is a post created by Vish, its post body.")
                .Publish();

            NewPostPage.GoToNewPost();

            Assert.AreEqual(PostPage.Title, "POST TITLE 1", "Title did not match new post");

         }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        } 
        
    }
}
