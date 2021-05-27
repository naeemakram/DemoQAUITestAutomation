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

            ValueFirstName firstName = new ValueFirstName(_driver);
            firstName.WaitForControl();
            return this;
        }

        public PagePractice SetFirstName(string valFirstName)
        {
            ValueFirstName firstName = new ValueFirstName(_driver);
            firstName.SetFirstNameValue(valFirstName);
            return this;          
        }

        public PagePractice SetLastName(string valLastName)
        {
            ValueLastName lastName = new ValueLastName(_driver);
            lastName.SetLastNameValue(valLastName);
            return this;
        }

        public PagePractice SetMobileNumber(string valMobileNumber)
        {
            ValueMobileNumber mobileNumber = new ValueMobileNumber(_driver);
            mobileNumber.SetMobileValue(valMobileNumber);
            return this;
        }

        public PagePractice SetGenderMale()
        {
            ValueRadioGender gender = new ValueRadioGender(_driver);
            gender.SetGenderValue("Male");

            System.Threading.Thread.Sleep(3000);
            return this;
        }

        public PagePractice SetGenderFemale()
        {            
            ValueRadioGender gender = new ValueRadioGender(_driver);
            gender.SetGenderValue("Female");
            return this;
        }

        public PagePractice SetGenderOther()
        {
            ValueRadioGender gender = new ValueRadioGender(_driver);
            gender.SetGenderValue("Other");
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
