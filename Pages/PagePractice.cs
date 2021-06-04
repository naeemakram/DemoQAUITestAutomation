using DemoQAUITestAutomation.Extensions;
using DemoQAUITestAutomation.Pages;
using DemoQAUITestAutomation.Pages.Maps;
using DemoQAUITestAutomation.Values;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace DemoQAUITestAutomation
{
    class PagePractice: PageGeneral
    {

        MapPractice _mapPractice;
       
        public PagePractice(IWebDriver driver): base(driver)
        {            
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

        public enum FormGender { Male, Female, Other };

        public PagePractice SetGender(FormGender genderToSet)
        {
            var genderDivs = Driver.FindElements(By.XPath("//input[@name='gender']/parent::div"));

            string radioValue = string.Empty;
            foreach (var genderDiv in genderDivs)
            {
                var genderRadioElement = genderDiv.FindElement(By.Name("gender"));
                radioValue = genderRadioElement.GetAttribute("Value");
               
                if (Enum.Parse(typeof(FormGender), radioValue).Equals(genderToSet))
                {
                    genderDiv.Click();// parent container receives click event
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

        public bool IsCloseFormSubmittedPageShow()
        {
            WebDriverWait waiter = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

            return waiter.Until(x => x.FindElement(By.XPath("//*[@id='closeLargeModal']"))).Displayed;
        }

        public PagePractice CloseFormSubmittedPage()
        {
            var closeButton = _driver.FindElement(By.XPath("//*[@id='closeLargeModal']"));
            closeButton.Click();
            return this;
        }

        public bool DidFormValidationFail()
        {
            var form = _driver.FindElement(By.Id("userForm"));
            var classValue = form.GetAttribute("class");

            return classValue.Trim().Equals("was-validated");
        }


        public string GetGenderValue()
        {
            string returnValue = string.Empty;
            var genderDivs = Driver.FindElements(By.XPath("//input[@name='gender']/parent::div"));

            foreach (var genderDiv in genderDivs)
            {
                var radioGender = genderDiv.FindElement(By.Name("gender"));                

                if (radioGender.Selected)
                {
                    returnValue = radioGender.GetAttribute("Value");
                }
            }

            return returnValue;
        }

    }
}
