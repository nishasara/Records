using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;

namespace Records.Pages
{
    class HomePage
    {
        public void NavigateToTM(IWebDriver driver)
        {
            //Go to Administration and click on it
            Thread.Sleep(1000);
            IWebElement adminDropDown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            adminDropDown.Click();
            Thread.Sleep(1000);

            //Navigate to Time and Materials page from Administration
            IWebElement timeMat = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            timeMat.Click();
            Thread.Sleep(1000);
        }
    }
}
