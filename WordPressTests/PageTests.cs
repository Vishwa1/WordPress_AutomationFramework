using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordPressAutomation; // Don't Forget to add this reference

namespace WordPressTests
{
    [TestClass]
    public class PageTests : WordpressTest
    {
        [TestMethod]
        public void Can_Edit_A_Page()
        {
            ListPostPage.GoTo(PostType.Page);
            ListPostPage.SelectPost("About");
            
            Assert.IsTrue(NewPostPage.IsInEditMode(), "Wasn't in edit mode");

            Assert.AreEqual("About", NewPostPage.Title, "Title did not match");
        }
    }
}
