using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WordPressAutomation
{
    public class DashboardPage
    {

        public static bool IsAt 
        {
            get 
            {
                // Refactor: Can we create a generalized isAt for all pages?
                var h2s = Driver.Instance.FindElements(By.TagName("h2"));
                if (h2s.Count > 0)
                    return h2s[0].Text == "Dashboard";
                 return false;
                
            }
        }
    }
}
