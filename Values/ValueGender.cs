using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQAUITestAutomation
{
    class ValueRadioGender:ValueGeneral
    {
        public ValueRadioGender(IWebDriver _driver):base(_driver)
        {

        }
        
        public string GetGenderValue()
        {
            var genderRadios = Driver.FindElements(By.XPath("//input[@name='gender']/parent::div"));

            string returnValue = string.Empty;
            string radioValue = string.Empty;

            foreach (var d in genderRadios)
            {
                var radio = d.FindElement(By.Name("gender"));
                radioValue = radio.GetAttribute("Value");                
                
                if (radio.Selected)
                {
                    returnValue = radioValue;
                }
            }

            return returnValue;
        }

        public void SetGenderValue(string value)
        {
            var genderRadios = Driver.FindElements(By.XPath("//input[@name='gender']/parent::div"));
            
            string radioValue = string.Empty;
            foreach (var d in genderRadios)
            {
                var radio = d.FindElement(By.Name("gender"));
                radioValue = radio.GetAttribute("Value");
                string output = $"Radio text: {radioValue} - {radio.Selected}";
                Console.WriteLine(output);
                if (radioValue == value)
                {
                    d.Click();// parent container receives click event
                }
            }            
        }
    }
}
