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
                    //Refactor:
                    LeftNavigation.Pages.AllPages.Select();
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
