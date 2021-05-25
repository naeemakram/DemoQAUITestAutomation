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
            PageHome homePage = new PageHome(_driver);

            var formsPage = homePage.OpenHomePage(_url).
                OpenForms();

            var practiceForm = formsPage.OpenPracticeForm();

            practiceForm.WaitForPracticeFormToLoad();

            practiceForm.SetFirstName("First Value").
                SetLastName("Last Value").
                SetMobileNumber("03331234567").
                SetGenderMale().
                SubmitForm().
                CloseFormSubmittedPage();

        }

        [Test]
        public void Case2Test()
        {
            PageHome homePage = new PageHome(_driver);

            var formsPage = homePage.OpenHomePage(_url).
                OpenForms();

            var practiceForm = formsPage.OpenPracticeForm();

            practiceForm.WaitForPracticeFormToLoad();

            practiceForm.
                SubmitForm();

            var didValidationFail = practiceForm.DidFormValidationFail();

            Assert.That(didValidationFail, Is.True);
        }
    }
}