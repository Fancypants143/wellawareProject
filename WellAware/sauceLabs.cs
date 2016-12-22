
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
using helperForClasses;



namespace WellAware
{
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(FirefoxDriver))]

    public class sauceLabs<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        private string browser = typeof(TWebDriver).Name;
        private static sauceLabsHelper helperClass = new sauceLabsHelper();
        private static classHelper getBrowser = new classHelper();
      
        private IWebDriver driver;
        private String url = ConfigurationManager.AppSettings["envURL"];
        private String expectedCode = ConfigurationManager.AppSettings["expectedCode"];
        private String runTestLocation = ConfigurationManager.AppSettings["runTestLocation"];

        [SetUp]
        public void beforeMethod()
        {   
            driver = getBrowser.defineBrowser(runTestLocation, driver, browser);
            driver.Navigate().GoToUrl(url);
        }

        [TestCase(Description = "Test Scenario 1")]
        public void validateTestScenario1()
        {
            helperClass.clickAPIButton(driver, "Selenium");
            helperClass.selectDevice(driver, "PC");
            helperClass.selectOperatingSystem(driver, "linux");
            helperClass.selectBrowserType(driver, "Firefox");
            helperClass.selectBrowserVersion(driver, "28.0");
            helperClass.selectAdvancedConfigButton(driver);
            Thread.Sleep(5000);
            helperClass.clickRecordVideoAdvancedConfig(driver, "unchecked");
            helperClass.selectResolution(driver);
            helperClass.takeScreenShot(driver, "Screenshot.png");
            helperClass.selectlanguageCodeTabCopyCode(driver, "ruby");
            helperClass.validateCopyCodeCorrect(driver, expectedCode);        
        }

        [TearDown]
        public void tearDown()
        {
            driver.Quit();
        }
    }
}
