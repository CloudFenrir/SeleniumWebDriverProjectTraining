using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriverProject.Tests
{
    public class SeleniumTests
    {
        [Test]
        public void ChromeBrowserTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.selenium.dev/");
            Assert.That(driver.Title, Is.EqualTo("Selenium"));
            driver.Quit();
        }

        [Test]
        public void EdgeBrowserTest()
        {
            IWebDriver driver = new EdgeDriver();
            driver.Navigate().GoToUrl("https://www.selenium.dev/");
            Assert.That(driver.Title, Is.EqualTo("Selenium"));
            driver.Quit();
        }

        [Test]
        public void LocatorsTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.selenium.dev/");
            
            // class name
            var AboutSeleniumLinkClassName = driver.FindElement(By.ClassName("mt-2")).Displayed;
            Assert.That(AboutSeleniumLinkClassName, Is.EqualTo(true));

            // css selector
            var AboutSeleniumLinkCssSelector = driver.FindElement(By.CssSelector(".mt-2")).Displayed;
            Assert.That(AboutSeleniumLinkCssSelector, Is.EqualTo(true));

            // id
            var SeleniumLogoId = driver.FindElement(By.Id("Layer_1")).Displayed;
            Assert.That(SeleniumLogoId, Is.EqualTo(true));

            // id
            var DocumentationButtonXpath = driver.FindElement(By.XPath("//span[text()='Documentation']")).Displayed;
            Assert.That(DocumentationButtonXpath, Is.EqualTo(true));

            driver.Quit();
        }

    }
}
