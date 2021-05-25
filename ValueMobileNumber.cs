using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQAUITestAutomation
{
    class ValueMobileNumber:ValueGeneral
    {
        public ValueMobileNumber(IWebDriver _driver) : base(_driver)
        {
        }
        public override IWebElement Control
        {
            get
            {
                return Driver.FindElement(By.Id("userNumber"));
            }
        }

        public string GetMobileValue()
        {
            return Control.Text;
        }

        public void SetMobileValue(string value)
        {
            Control.SendKeys(value);
        }

    }    
}
