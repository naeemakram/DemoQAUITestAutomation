using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQAUITestAutomation
{
    class PagePractice
    {
        IWebDriver _driver;
        public PagePractice(IWebDriver driver)
        {
            _driver = driver;
        }

        public PagePractice WaitForPracticeFormToLoad()
        {
            WebDriverWait waiter = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            waiter.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            waiter.Until(x => x.FindElement(By.Id("firstName")));
            return this;
        }

        public PagePractice SetFirstName(string valFirstName)
        {
            var inputFirstName = _driver.FindElement(By.Id("firstName"));

            inputFirstName.SendKeys(valFirstName);

            return this;          
        }

        public PagePractice SetLastName(string valLastName)
        {
            var inputLastName = _driver.FindElement(By.Id("lastName"));

            inputLastName.SendKeys(valLastName);

            return this;
        }

        public PagePractice SetMobileNumber(string valMobileNumber)
        {
            var inputMobileNumber = _driver.FindElement(By.Id("userNumber"));

            inputMobileNumber.SendKeys(valMobileNumber);

            return this;
        }

        public PagePractice SetGenderMale()
        {
            var radioMale = _driver.FindElement(By.XPath("//input[@id='gender-radio-1']/parent::div"));
            radioMale.Click();
            return this;
        }

        public PagePractice SetGenderFemale()
        {
            var radioMale = _driver.FindElement(By.XPath("//input[@id='gender-radio-2']/parent::div"));
            radioMale.Click();
            return this;
        }

        public PagePractice SetGenderOther()
        {
            var radioMale = _driver.FindElement(By.XPath("//input[@id='gender-radio-3']/parent::div"));
            radioMale.Click();
            return this;
        }

        public PagePractice SubmitForm()
        {
            _driver.FindElement(By.Id("lastName")).Submit();
            return this;
        }

        public PagePractice CloseFormSubmittedPage()
        {
            WebDriverWait waiter = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            var closeButton = waiter.Until(x => x.FindElement(By.XPath("//*[@id='closeLargeModal']")));
            closeButton.Click();

            return this;
        }

        public bool DidFormValidationFail()
        {
            var form = _driver.FindElement(By.Id("userForm"));
            var classValue = form.GetAttribute("class");
            

            Console.WriteLine($"was validated: {classValue}");

            return classValue.Trim().Equals("was-validated");
        }

    }
}
