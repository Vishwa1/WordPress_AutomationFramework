﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace WordPressAutomation
{
    public static class LoginPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl("https://wordpress.com/wp-login.php");
            
        }

        public static LoginCommand LoginAs(string userName)
        {
            return new LoginCommand(userName);
        }

    }

    public class LoginCommand
    {
        private readonly string userName;
        private string password;

        public LoginCommand(string userName)
        {
            this.userName = userName;
        }

        public LoginCommand WithPassword(string password)
        {
 	        this.password = password;
            return this;
        }   

        public void Login()
        {
            var loginInput = Driver.Instance.FindElement(By.Id("user_login"));
            var passwordInput = Driver.Instance.FindElement(By.Id("user_pass"));
            loginInput.SendKeys(userName);
            passwordInput.SendKeys(password);
            var loginButton = Driver.Instance.FindElement(By.Id("wp-submit"));
            loginButton.Click();

        }


    }
}
