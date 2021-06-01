using OpenQA.Selenium;

namespace DemoQAUITestAutomation
{
    class PageHome
    {
        IWebDriver _driver;
        public PageHome(IWebDriver driver)
        {
            _driver = driver;
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
