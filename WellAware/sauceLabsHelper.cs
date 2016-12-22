
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using OpenQA.Selenium.Interactions;
using System.Threading;
using NUnit.Framework;


namespace WellAware
{
    class sauceLabsHelper
    {
        public IWebDriver defineBrowser(String runTestLocation, IWebDriver driver, String browser)
        {
            if (runTestLocation != "local")
            {
                if (browser.Equals("FirefoxDriver"))
                {
                    driver = new RemoteWebDriver(new Uri(runTestLocation), DesiredCapabilities.Firefox(), TimeSpan.FromSeconds(180));
                }

                if (browser.Equals("ChromeDriver"))
                {
                    driver = new RemoteWebDriver(new Uri(runTestLocation), DesiredCapabilities.Chrome(), TimeSpan.FromMinutes(3));
                }
            }
            else
                driver = new ChromeDriver();
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));

            return driver;
        }

        public void clickAPIButton(IWebDriver driver, String type)
        {   
            IWebElement apiButton = driver.FindElement(By.ClassName("api-button"));
            apiButton.Click();
        }

        public void selectDevice(IWebDriver driver, String device)
        {
            IWebElement deviceTypeDropDownButton = driver.FindElement(By.XPath("//button[contains(.,'Select a device')]"));
            deviceTypeDropDownButton.Click();
            driver.FindElement(By.ClassName("list-element")).Click();
        }

        public void selectOperatingSystem(IWebDriver driver, String operatingSystem)
        {
            IWebElement operatingSystemDropDownButton = driver.FindElement(By.XPath("//button[contains(.,'Select an operating system')]"));
            operatingSystemDropDownButton.Click();
            driver.FindElement(By.CssSelector(".el-icon."+operatingSystem)).Click();
        }

        public void selectBrowserType(IWebDriver driver, String browser)
        {
            IWebElement browserDropDownButton = driver.FindElement(By.XPath("//button[contains(.,'Select a browser')]"));
            browserDropDownButton.Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText(browser)).Click();
        }

        public void selectBrowserVersion(IWebDriver driver, String version)
        {
            IWebElement browserVersion = driver.FindElement(By.XPath("//div[@id='firefox']/div[2]/div[4]/div/span[2]/span"));
            browserVersion.Click();
        }

        public void selectAdvancedConfigButton(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//h4[contains(.,'Show Advanced Configuration')]")).Click();
        }

        public void clickRecordVideoAdvancedConfig(IWebDriver driver, String status)
        {
            driver.FindElement(By.Id("box1")).Click();
        }

        public void takeScreenShot(IWebDriver driver, String fileName)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile("C:/temp/"+fileName, System.Drawing.Imaging.ImageFormat.Png);
        }

        public void selectlanguageCodeTabCopyCode(IWebDriver driver, String language)
        {
            driver.FindElement(By.CssSelector("a[href*='#tab-"+language+"']")).Click();
        }

        public void selectResolution(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//button[contains(.,'Select a resolution')]")).Click();
            driver.FindElement(By.Id("resolution")).Click();
        }

        public void validateCopyCodeCorrect(IWebDriver driver, String code)
        {
            IWebElement bodyTag = driver.FindElement(By.TagName("body"));
            Assert.IsTrue(bodyTag.Text.Contains("caps = Selenium::WebDriver::Remote::Capabilities.firefox()\r\ncaps['platform'] = 'Linux'\r\ncaps['version'] = '28.0'\r\ncaps['recordVideo'] = false"));
        }
    }
}
