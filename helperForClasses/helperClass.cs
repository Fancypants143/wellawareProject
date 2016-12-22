using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System.Diagnostics;
using System;
using System.IO;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace helperForClasses
{
    public class classHelper
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

    }
}
