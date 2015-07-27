using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WordPressAutomation
{
    public class ListPostPage
    {

        public static void GoTo(PostType postType)
        {
            switch (postType)
            {
                case PostType.Page: 
                    Driver.Instance.FindElement(By.Id("menu-pages")).Click();
                    Driver.Instance.FindElement(By.LinkText("All Pages")).Click();
                    break;
            }
        }

        public static void SelectPost(string title)
        {
            var newPostLink = Driver.Instance.FindElement(By.LinkText("About"));
            newPostLink.Click();
        }
    }

    public enum PostType
    {
        Page
    }
}
