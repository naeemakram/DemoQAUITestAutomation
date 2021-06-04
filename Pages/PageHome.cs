using DemoQAUITestAutomation.Pages;
using OpenQA.Selenium;

namespace DemoQAUITestAutomation
{
    class PageHome: PageGeneral
    {
        
        public PageHome(IWebDriver driver): base(driver)
        {            
        }

        public PageForms OpenForms()
        {
            _driver.FindElement(By.XPath("//h5[contains(text(), 'Forms')]/parent::div/parent::div/parent::div")).Click();
            return new PageForms(_driver);
        }

        public PageHome OpenHomePage(string url)
        {
            _driver.Navigate().GoToUrl(url);
            return this;
        }

    }
}
