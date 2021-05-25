using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace DemoQAUITestAutomation
{
    internal class ValueGeneral
    {
        private IWebDriver _driver;
        public IWebDriver Driver
        {
            get
            {
                return _driver;
            }
        }
        public ValueGeneral(IWebDriver driver)
        {
            _driver = driver;
        }

        public virtual IWebElement Control { get; }

        internal void WaitForControl()
        {
            WebDriverWait waiter = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            waiter.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            waiter.Until(x => Control);
        }
    }
}