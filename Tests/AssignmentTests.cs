using DemoQAUITestAutomation.Values;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;
using DemoQAUITestAutomation.Tests;

namespace DemoQAUITestAutomation
{
    [TestFixture]
    public class AssignmentTests
    {
        PageHome _homePage;        
        

        [SetUp]
        public void Setup()
        {
            _homePage = new PageHome(new ChromeDriver());            
        }

        [Test]
        public void Case1Test()
        {
            //arrange
            Student studentForm =
                Student.Create(TestConfig.Instance.StudentFirstName,
                                TestConfig.Instance.StudentLastName,
                                TestConfig.Instance.StudentMobileNumber,
                                PagePractice.FormGender.Male);

            

            var formsPage = _homePage.OpenHomePage(TestConfig.Instance.URL).
                OpenForms();

            var practiceForm = formsPage.OpenPracticeForm();

            practiceForm.WaitForPracticeFormToLoad();

            //act
            practiceForm.SetStudentData(studentForm).
                SubmitForm();
            System.Threading.Thread.Sleep(5000);
            //assert
            Assert.That(practiceForm.IsCloseFormSubmittedPageShow(), Is.True);

        }

        [Test]
        public void Case2Test()
        {
            //arrange            

            var formsPage = _homePage.OpenHomePage(TestConfig.Instance.URL).
                OpenForms();

            //act
            var practiceForm = formsPage.OpenPracticeForm();

            practiceForm.WaitForPracticeFormToLoad();

            practiceForm.
                SubmitForm();

            //assert
            Assert.That(practiceForm.DidFormValidationFail(), Is.True);

        }
        [TearDown]
        public void Cleanup()
        {
            if (_homePage.Driver != null)
            {
                _homePage.Driver.Quit();
            }
        }
    }
}