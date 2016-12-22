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
using OpenQA.Selenium.Remote;
using System.Diagnostics;

namespace wikipediaTest
{
    class wikipediaHelper
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

        public void enterSearchString(IWebDriver driver, String searchString)
        {
            IWebElement searchBox = driver.FindElement(By.Id("searchInput"));
            searchBox.SendKeys(searchString);
            driver.FindElement(By.CssSelector("button.pure-button.pure-button-primary-progressive")).Click();
        }

        public void clickPrinciplesDiagram(IWebDriver driver)
        {
            driver.FindElement(By.CssSelector("img[alt='Continuous Delivery process diagram.svg']")).Click();
        }

        public void closePrinciplesDiagram(IWebDriver driver)
        {
            driver.FindElement(By.ClassName("mw-mmv-close")).Click();
        }

        public void selectLinkTextOnPage(IWebDriver driver, String linkText)
        {
            driver.FindElement(By.LinkText(linkText)).Click();
        }

        public void validateHeaderInList(IWebDriver driver)
        {

            IList<IWebElement> listContents = driver.FindElements(By.ClassName("toctext"));
            IList<IWebElement> newList = new List<IWebElement>();

            foreach (IWebElement element in listContents)
            {

                if (element.Text.Equals("Education") || element.Text.Equals("Certification"))
                {
                    newList.Add(element);
                }
            }

            Assert.True(newList.Count == 2);

        }
    }

    }


