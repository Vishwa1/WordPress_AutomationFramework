using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordPressAutomation;


namespace WordPressTests.PostsTests
{
     [TestClass]
    public class AllPostsTests : WordpressTest
    {
        [TestMethod]
        public void Added_Posts_Show_Up()
        {
            // Go to post, get post count, store it
            ListPostPage.GoTo(PostType.Posts);
            ListPostPage.StoreCount();

            // Add a new post
            NewPostPage.GoTo();
            NewPostPage.CreatePost("Added Posts Show Up, title")
                .withBody("Added posts show up body is here, body")
                .Publish();

            //Go to posts, get new post count
            ListPostPage.GoTo(PostType.Posts);
            Assert.AreEqual(ListPostPage.PreviousPostsCount + 1, ListPostPage.CurrentPostsCount, "Count did not increase");

            //Check for the newly added post
            Assert.IsTrue(ListPostPage.DoesPostExistWithTitle("Added Posts Show Up, title"));

            //Trash the post
            //ListPostPage.TrashPost("Added Posts Show Up, title");
            //Assert.AreEqual(ListPostPage.PreviousPostsCount, ListPostPage.CurrentPostsCount, "Couldn't trash the post");
        }

        [TestMethod]
        public void Can_Search_Posts()
        {
            //Create a new post
            NewPostPage.GoTo();
            NewPostPage.CreatePost("Searching Post, Title")
                .withBody("Search post body, body")
                .Publish();

            //Go to list posts
            ListPostPage.GoTo(PostType.Posts);

            //Search for the post
            ListPostPage.SearchForPost("Searching Post, Title");

            //Check the search results
            Assert.IsTrue(ListPostPage.DoesPostExistWithTitle("Searching Post, Title"));

            //CleanUp (Trash post)
            ListPostPage.TrashPost("Searching Post, Title");

        }
    }
}
