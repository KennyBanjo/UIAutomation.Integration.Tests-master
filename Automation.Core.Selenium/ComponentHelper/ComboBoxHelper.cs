using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Core.Selenium.Base;
using Automation.Core.Selenium.WebDriver.WebElementObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Automation.Core.Selenium.ComponentHelper
{
    public class ComboBoxHelper:BasePage
    {
        public static void SelectElementWithWait(By locator, int index)
        {
            WebDriverWait wait = new WebDriverWait(DriverContext.WebDriver, TimeSpan.FromSeconds(30));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            SelectElement select = new SelectElement(element);
            select.SelectByIndex(index);
        }
    }
}
