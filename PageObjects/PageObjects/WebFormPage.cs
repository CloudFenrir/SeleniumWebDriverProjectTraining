using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Reports;

namespace PageObjects.PageObjects
{
    public class WebFormPage
    {
        // Locators
        IWebElement textInputField => driver.FindElement(By.Id("my-text-id"));
        IWebElement submitButton => driver.FindElement(By.XPath("//button[text()='Submit']"));


        IWebDriver driver;

        public WebFormPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Methods
        public WebFormPage WriteToTextInput(String text)
        {
            ExtentReporting.LogInfo($"Write '{text}' to text area");

            textInputField.SendKeys(text);
            return this;
        }

        public TargetPage SubmitForm()
        {
            ExtentReporting.LogInfo("Click submit form button");
            submitButton.Click();
            return new TargetPage(driver);
        }
    }
}
