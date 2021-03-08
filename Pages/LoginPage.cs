using NUnit.Framework;
using OpenQA.Selenium;
using Records.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Records.Pages
{
    class LoginPage
    {
        public void LoginSteps(IWebDriver driver)
        {
            //System.Threading.Thread.Sleep(20000);
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
            driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(1500);
            try
            {
                Wait.ElementPresent(driver, "Id", "UserName");
                // identify username textbox and input username
                IWebElement username = driver.FindElement(By.Id("UserName"));
                username.SendKeys("hari");

                // identify password textbox and input password
                IWebElement password = driver.FindElement(By.Id("Password"));
                password.SendKeys("123123");

                // identify login buton and click on the login button
                IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
                loginButton.Click();
            } catch(Exception e)
            {
                Assert.Fail("The test failed at the login page", e.Message);
            }
            // verify home page
            IWebElement helloHari = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));
            if (helloHari.Text == "Hello hari!")

            {
                Console.WriteLine("Test Passed, Logged-in successfully");
            }
            else
            {
                Console.WriteLine("Test Failed, Login failed");
            }

        }
    }
}
