using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQAUITestAutomation.Pages
{
    public class PageGeneral
    {
        protected IWebDriver _driver;
        public IWebDriver Driver
        {
            get
            {
                return _driver;
            }
        }
        public PageGeneral(IWebDriver driver)
        {
            _driver = driver;
        }

    }
}
