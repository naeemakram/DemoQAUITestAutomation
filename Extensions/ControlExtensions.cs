using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace DemoQAUITestAutomation.Extensions
{
    public static class ControlExtensions
    {
        public static void WaitForControl(this IWebElement element, IWebDriver driver)
        {
            WebDriverWait waiter = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            waiter.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            waiter.Until(x => element);
        }
    }
}
