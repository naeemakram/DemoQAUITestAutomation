using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace DemoQAUITestAutomation
{
    public class AssignmentTests
    {
        public const string _url = "https://demoqa.com/";
        IWebDriver _driver; 
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();            
        }

        [Test]
        public void Case1Test()
        {
            _driver.Navigate().GoToUrl(_url);
            _driver.FindElement(By.XPath("//h5[contains(text(), 'Forms')]/parent::div/parent::div/parent::div")).Click();

            

            WebDriverWait waiter = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            waiter.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));

            var practiceForm = waiter.Until(x => x.FindElement(By.XPath("//span[contains(text(), 'Practice Form')]")));

            practiceForm.Click();

            var firstName = waiter.Until(x => x.FindElement(By.Id("firstName")));
            var lastName = _driver.FindElement(By.Id("lastName"));
            var mobileNumber = _driver.FindElement(By.Id("userNumber"));


            firstName.SendKeys("Blah");
            lastName.SendKeys("Blah");
            mobileNumber.SendKeys("0123456789");
            var radioMale = _driver.FindElement(By.XPath("//input[@id='gender-radio-1']/parent::div"));
            radioMale.Click();
            
            lastName.Submit();

            var closeButton = waiter.Until(x => x.FindElement(By.XPath("//*[@id='closeLargeModal']")));

            closeButton.Click();

        }

        [Test]
        public void Case2Test()
        {
            _driver.Navigate().GoToUrl(_url);
            _driver.FindElement(By.XPath("//h5[contains(text(), 'Forms')]/parent::div/parent::div/parent::div")).Click();



            WebDriverWait waiter = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            waiter.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));

            var practiceForm = waiter.Until(x => x.FindElement(By.XPath("//span[contains(text(), 'Practice Form')]")));

            practiceForm.Click();

            var firstName = waiter.Until(x => x.FindElement(By.Id("firstName")));            
            

            firstName.Submit();

            _driver.Quit();
        }

    }
}