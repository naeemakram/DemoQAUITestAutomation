using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQAUITestAutomation
{
    class ValueLastName:ValueGeneral
    {
        public ValueLastName(IWebDriver _driver):base(_driver)
        {

        }
        public override IWebElement Control
        {
            get
            {
                return Driver.FindElement(By.Id("lastName"));
            }
        }    

        public string GetLastNameValue()
        {            
            return Control.Text;
        }

        public void SetLastNameValue(string value)
        {
            Control.SendKeys(value);
        }
    }
}
