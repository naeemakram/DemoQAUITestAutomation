using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQAUITestAutomation.Pages.Maps
{
    class MapPractice
    {
        private IWebDriver _driver;
        public IWebDriver Driver => _driver;

        public MapPractice(IWebDriver driver)
        {
            _driver = driver;
        }
        public IWebElement GetLastName()
        {
            return Driver.FindElement(By.Id("lastName"));
        }

        public IWebElement GetMobileNumber()
        {
            return Driver.FindElement(By.Id("userNumber"));
        }

        public IWebElement GetFirstName()
        {
            return Driver.FindElement(By.Id("firstName"));
        }
    }
}
