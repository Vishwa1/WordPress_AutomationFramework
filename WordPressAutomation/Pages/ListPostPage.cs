﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;



namespace WordPressAutomation
{
    public class ListPostPage
    {
        private static int lastCount;

        public static void GoTo(PostType postType)
        {
            switch (postType)
            {
                case PostType.Page:
                    //Refactor:
                    LeftNavigation.Pages.AllPages.Select();
                    break;

                case PostType.Posts:
                    LeftNavigation.Posts.AllPosts.Select();
                    break;
            }
        }

        public static void SelectPost(string title)
        {
            var newPostLink = Driver.Instance.FindElement(By.LinkText("About"));
            newPostLink.Click();
        }

        public static void StoreCount()
        {
            lastCount = GetPostCount();
        }

        private static int GetPostCount()
        {
            var countText = Driver.Instance.FindElement(By.ClassName("displaying-num")).Text;
            return int.Parse(countText.Split(' ')[0]);

        }

        public static int PreviousPostsCount
        {
            get
            { return lastCount; }
        }

        public static int CurrentPostsCount
        {
            get { return GetPostCount(); }

        }

        public static bool DoesPostExistWithTitle(string title)
        {
            return Driver.Instance.FindElements(By.LinkText(title)).Any();
        }

        public static void TrashPost(string title)
        {
            //var rows = Driver.Instance.FindElements(By.TagName("tr"));
            //foreach (var row in rows)
            //{
            //    IReadOnlyCollection<IWebElement> links = null;
            //    links = row.FindElements(By.LinkText(title));

            //    if (links.Count > 0)
            //    {
            //        Actions action = new Actions(Driver.Instance);
            //        action.MoveToElement(links[0]);
            //        action.Perform();
            //        row.FindElement(By.ClassName("submitdelete")).Click();
            //        return;
            //    }

            //}
        }

        public static void SearchForPost(string searchString)
        {
            var searchBox = Driver.Instance.FindElement(By.Id("post-search-input"));
            searchBox.SendKeys(searchString);

            var searchButton = Driver.Instance.FindElement(By.Id("search-submit"));
            searchButton.Click();
        }
    }


    public enum PostType
    {
        Page,
        Posts
    }
}
