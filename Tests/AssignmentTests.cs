using DemoQAUITestAutomation.Values;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace DemoQAUITestAutomation
{
    [TestFixture]
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
            //arrange
            Student studentForm = 
                Student.Create("Naeem", "Malik", "03331234567", PagePractice.FormGender.Male); 

            PageHome homePage = new PageHome(_driver);
            
            var formsPage = homePage.OpenHomePage(_url).
                OpenForms();

            var practiceForm = formsPage.OpenPracticeForm();

            practiceForm.WaitForPracticeFormToLoad();
            
            //act
            practiceForm.SetStudentData(studentForm).
                SubmitForm().
                
            //assert
                AssertCloseFormSubmittedPageShow().
                CloseFormSubmittedPage();
        }

        [Test]
        public void Case2Test()
        {
            //arrange
            PageHome homePage = new PageHome(_driver);

            var formsPage = homePage.OpenHomePage(_url).
                OpenForms();

            //act
            var practiceForm = formsPage.OpenPracticeForm();

            practiceForm.WaitForPracticeFormToLoad();

            practiceForm.
                SubmitForm();

            //assert
            practiceForm.AssertFormValidationFail();
            
        }
        [TearDown]
        public void Cleanup()
        {
            if (_driver != null)
            {
                _driver.Quit();
            }
        }
    }
}