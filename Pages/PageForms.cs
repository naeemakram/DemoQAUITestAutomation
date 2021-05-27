using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQAUITestAutomation
{
    class PageForms
    {
        IWebDriver _driver; 
        public PageForms(IWebDriver driver)
        {
            _driver = driver; 
        }

        public PagePractice OpenPracticeForm()
        {
            WebDriverWait waiter = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            waiter.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));

            var practiceForm = waiter.Until(x => x.FindElement(By.XPath("//span[contains(text(), 'Practice Form')]")));

            practiceForm.Click();

            return new PagePractice(_driver); 
        }

    }
}
