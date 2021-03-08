using NUnit.Framework;
using Records.Pages;
using Records.Utilities;
using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;


namespace Records
{   
    [TestFixture]
    class Program :CommonDriver
    {
        [OneTimeSetUp]
        public void Login()
        {
            // login page obj and login steps
            LoginPage loginObj = new LoginPage();
            loginObj.LoginSteps(driver);

            // home page object and navigate step
            HomePage homeObj = new HomePage();
            homeObj.NavigateToTM(driver);
        }

        [Test]
        public void CreateTMTest()
        {

            //TM page object and create
            TMPage tmObj = new TMPage();
            tmObj.CreateTM(driver);
        }

        [Test]
        public void EditTMTest()
        {
            //TM page object and edit        
            TMPage tmObj = new TMPage();
            tmObj.EditTM(driver);
        }

        [Test]
        public void DeleteTMTest()
        {
            //TM page object and delete
            TMPage tmObj = new TMPage();
            tmObj.DeleteTM(driver);
        }

        [OneTimeTearDown]
        public void FinalSteps()
        {
            driver.Quit();
        }

    }
}
