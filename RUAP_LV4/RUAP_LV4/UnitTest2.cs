using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class IzracunShippinga
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheIzracunShippingaTest()
        {
            driver.Navigate().GoToUrl("https://demowebshop.tricentis.com/");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Categories'])[2]/following::a[1]")).Click();
            driver.FindElement(By.XPath("//input[@value='Add to cart']")).Click();
            driver.FindElement(By.XPath("//li[@id='topcartlink']/a/span")).Click();
            driver.FindElement(By.Id("CountryId")).Click();
            new SelectElement(driver.FindElement(By.Id("CountryId"))).SelectByText("United States");
            driver.FindElement(By.Id("StateProvinceId")).Click();
            new SelectElement(driver.FindElement(By.Id("StateProvinceId"))).SelectByText("Alabama");
            driver.FindElement(By.Id("ZipPostalCode")).Click();
            driver.FindElement(By.Id("ZipPostalCode")).Clear();
            driver.FindElement(By.Id("ZipPostalCode")).SendKeys("35242");
            driver.FindElement(By.Name("estimateshipping")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
