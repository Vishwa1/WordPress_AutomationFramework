using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordPressAutomation;


namespace WordPressTests
{
    [TestClass]
    public class CreatePostTests : WordpressTest
    {
        [TestMethod]
        public void Can_Create_A_Basic_Post()
        {
            NewPostPage.GoTo();
            NewPostPage.CreatePost("POST TITLE 1")
                .withBody("This is a post created by Vish, its post body.")
                .Publish();

            NewPostPage.GoToNewPost();

            Assert.AreEqual(PostPage.Title, "POST TITLE 1", "Title did not match new post");

         }
    }
}
