using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Core.Selenium.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Automation.Core.Selenium.ExtensionMethods
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Waits for element to be visible for up to max 30 seconds.
        /// </summary>
        /// <param name="element"></param>
        public static void WaitUntilElementVisible(this IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(DriverContext.WebDriver, TimeSpan.FromSeconds(60));
            wait.Until(ElementIsVisible(element));
        }

        public static void SelectElement(this IWebElement element, int index)
        {
            element.WaitUntilElementVisible();
            var select = new SelectElement(element);
            select.SelectByIndex(index);
        }

        public static Func<IWebDriver, bool> ElementIsVisible(IWebElement element)
        {
            return (Driver) =>
            {
                try
                {
                    return element.IsDisplayed();
                }
                catch (Exception)
                {
                    return false;
                }
            };
        }

        public static void WaitUntilElementClickable(this IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(DriverContext.WebDriver, TimeSpan.FromSeconds(60));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        /// <summary>
        /// Returns true if element is displayed and false if not
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsDisplayed(this IWebElement element)
        {
            bool result;
            try
            {
                result = element.Displayed;
            }
            catch (NoSuchElementException)
            {

                result = false;
            }
            return result;
        }

        public static void EnterText(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}
