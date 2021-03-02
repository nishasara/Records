
using Records.Pages;
using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;


namespace Records
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            // login page obj and login steps
            LoginPage loginObj = new LoginPage();
            loginObj.LoginSteps(driver);

            // home page object and navigate step
            HomePage homeObj = new HomePage();
            homeObj.NavigateToTM(driver);

            // TM page object and create step
            TMPage tmObj = new TMPage();
            tmObj.CreateTM(driver);
            tmObj.EditTM(driver);
            tmObj.DeleteTM(driver);

            Thread.Sleep(500);

        }
    }
}
