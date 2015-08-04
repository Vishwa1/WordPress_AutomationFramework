using System;
using OpenQA.Selenium;
using System.Threading;

namespace WordPressAutomation
{
    public class NewPostPage
    {

        public static void GoTo()
        {
            //Refactor: General Menu Navigation
            LeftNavigation.Posts.AddNew.Select();
        }

        public static CreatePostCommand CreatePost(string title)
        {
            return new CreatePostCommand(title);
        }

        public static void GoToNewPost()
        {
            var message = Driver.Instance.FindElement(By.Id("message"));
            var newPostLink = message.FindElements(By.TagName("a"))[0];
            newPostLink.Click();

        }

        public static bool IsInEditMode()
        {
            //return Driver.Instance.FindElement(By.Id("icon-edit-pages")) != null;
            return Driver.Instance.FindElement(By.TagName("h2")) != null;
        }

        public static string Title
        {
            get
            {
                var title = Driver.Instance.FindElement(By.Id("title"));
                if (title != null)
                    return title.GetAttribute("value"); // GetAttribute has been used here to get the text from Edit Pages. The text is in InputBox so have to use GetAttribute 
                //otherwise you cant retrieve the text
                return string.Empty;
            }

        }
    }

    public class CreatePostCommand
    {
        private string title;
        private string body;

        public CreatePostCommand(string title)
        {
            this.title = title;
        }

        public CreatePostCommand withBody(string body)
        {
            this.body = body;
            return this;
        }

        public void Publish()
        {
            Driver.Instance.FindElement(By.Id("title")).SendKeys(title);
            Driver.Instance.SwitchTo().Frame("content_ifr");
            Driver.Instance.SwitchTo().ActiveElement().SendKeys(body);
            Driver.Instance.SwitchTo().DefaultContent();

            Thread.Sleep(1000);

            Driver.Instance.FindElement(By.Id("publish")).Click();
        }
    }
}
