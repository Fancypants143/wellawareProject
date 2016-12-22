
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Threading;
using NUnit.Framework;
using System.Configuration;
using OpenQA.Selenium.Interactions;
using System.Linq;
using System.Collections.Generic;
using helperForClasses;

namespace wikipediaTest
{
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(FirefoxDriver))]

    public class wikipediaTest<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        private IWebDriver driver;
        private string browser = typeof(TWebDriver).Name;
        wikipediaHelper helper = new wikipediaHelper();
        classHelper getBrowser = new classHelper();
        private String url = ConfigurationManager.AppSettings["envURL"];
        private String expectedCode = ConfigurationManager.AppSettings["expectedCode"];
        private String runTestLocation = ConfigurationManager.AppSettings["runTestLocation"];

        [SetUp]
        public void beforeMethod()
        {
            driver = getBrowser.defineBrowser(runTestLocation, driver, browser);
            driver.Navigate().GoToUrl(url);
        }

        [TestCase(Description = "Test Scenario 2")]
        public void wikipediaTestScenario2()
        {
            helper.enterSearchString(driver, "continuous delivery");
            helper.clickPrinciplesDiagram(driver);
            helper.closePrinciplesDiagram(driver);
            helper.selectLinkTextOnPage(driver, "software engineering");
            helper.validateHeaderInList(driver);
         }
 
        [TearDown]
        public void tearDown()
        {
            driver.Quit();
        }

    }


}
