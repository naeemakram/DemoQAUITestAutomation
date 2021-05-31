using DemoQAUITestAutomation.Extensions;
using DemoQAUITestAutomation.Pages.Maps;
using DemoQAUITestAutomation.Values;
using NUnit.Framework;
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
        MapPractice _mapPractice; 

        public IWebDriver Driver
        {
            get
            {
                return _driver;
            }
        }
        public PagePractice(IWebDriver driver)
        {
            _driver = driver;
            _mapPractice = new MapPractice(_driver);
        }

        public PagePractice WaitForPracticeFormToLoad()
        {
            
            _mapPractice.GetFirstName().WaitForControl(_driver);

            return this;
        }

        public PagePractice SetFirstName(string valFirstName)
        {
            
            _mapPractice.GetFirstName().SendKeys(valFirstName);
            return this;          
        }

        public PagePractice SetLastName(string valLastName)
        {            
            _mapPractice.GetLastName().SendKeys(valLastName);
            return this;
        }

        public PagePractice SetMobileNumber(string valMobileNumber)
        {            
            _mapPractice.GetMobileNumber().SendKeys(valMobileNumber);
            return this;
        }

        public enum FormGender { Male, Female, Other};

        public PagePractice SetGender(FormGender gender)
        {            
            var genderRadios = Driver.FindElements(By.XPath("//input[@name='gender']/parent::div"));

            string radioValue = string.Empty;
            foreach (var d in genderRadios)
            {
                var radio = d.FindElement(By.Name("gender"));
                radioValue = radio.GetAttribute("Value");
                string output = $"Radio text: {radioValue} - {radio.Selected}";
                Console.WriteLine(output);
                
                if (Enum.Parse(typeof(FormGender), radioValue).Equals(gender))
                {
                    d.Click();// parent container receives click event
                }
            }
            
            return this;
        }
        
        public PagePractice SetStudentData(Student valueToSet)
        {
            this.SetFirstName(valueToSet.First).
                SetLastName(valueToSet.Last).
                SetMobileNumber(valueToSet.Mobile).
                SetGender(valueToSet.Gender);

            return this;
        }

        public PagePractice SubmitForm()
        {
            _mapPractice.GetLastName().Submit();
            return this;
        }

        public PagePractice AssertCloseFormSubmittedPageShow()
        {
            WebDriverWait waiter = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            var closeButton = waiter.Until(x => x.FindElement(By.XPath("//*[@id='closeLargeModal']")));
            Assert.That(closeButton.Displayed, Is.True);
            return this;
        }

        public PagePractice CloseFormSubmittedPage()
        {
            var closeButton = _driver.FindElement(By.XPath("//*[@id='closeLargeModal']"));
            closeButton.Click();
            return this;
        }

        public PagePractice AssertFormValidationFail()
        {
            var form = _driver.FindElement(By.Id("userForm"));
            var classValue = form.GetAttribute("class");
            

            Console.WriteLine($"was validated: {classValue}");
            
            Assert.That(classValue.Trim(), Is.EqualTo("was-validated"));

            return this;
        }
               

        public string GetGenderValue()
        {
            var genderRadios = Driver.FindElements(By.XPath("//input[@name='gender']/parent::div"));

            string returnValue = string.Empty;
            string radioValue = string.Empty;

            foreach (var d in genderRadios)
            {
                var radio = d.FindElement(By.Name("gender"));
                radioValue = radio.GetAttribute("Value");

                if (radio.Selected)
                {
                    returnValue = radioValue;
                }
            }

            return returnValue;
        }

    }
}
