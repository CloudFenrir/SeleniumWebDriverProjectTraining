using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWebDriverProject.Tests
{
    public class WaitsTests
    {
        [Test]
        public void ImplicitWaitTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
         
            var textArea = driver.FindElement(By.Id("my-text-id"));
            textArea.SendKeys(Guid.NewGuid().ToString());


            driver.Quit();
        }

        [Test]
        public void ExplicitWaitTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var condition1 = wait.Until(e => e.Title == "Web form");
            var condition2 = wait.Until(e => e.FindElement(By.Id("my-text-id")));
            var condition3 = wait.Until(e => e.FindElement(By.Id("my-text-id")).Displayed);

            var textArea = driver.FindElement(By.Id("my-text-id"));
            textArea.SendKeys(Guid.NewGuid().ToString());


            driver.Quit();
        }

        [Test]
        public void FluentWaitTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromSeconds(1)
            };

            wait.IgnoreExceptionTypes(typeof(HttpRequestException));

            var condition = wait.Until(e => e.Title == "Web form");

            var textArea = driver.FindElement(By.Id("my-text-id"));
            textArea.SendKeys(Guid.NewGuid().ToString());


            driver.Quit();
        }

    }
}
