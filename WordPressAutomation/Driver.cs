using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPressAutomation
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }
                
        public static void Initialize()
        {
            Instance = new FirefoxDriver();
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            Instance.Manage().Window.Maximize(); // to maximize the windows
        }

        public static void Close()
        {
            Instance.Close();
        }
    }
}
