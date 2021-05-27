using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQAUITestAutomation
{
    class ValueFirstName:ValueGeneral
    {
        public ValueFirstName(IWebDriver _driver):base(_driver)
        {

        }

        public override IWebElement Control
        {
            get
            {
                return Driver.FindElement(By.Id("firstName"));
            }
        }
        
        public string GetFirstNameValue()
        {            
            return Control.Text;
        }

        public void SetFirstNameValue(string value)
        {
            Control.SendKeys(value);
        }        
    }
}
