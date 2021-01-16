using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Automation.Core.Selenium.Base;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using ILog = log4net.ILog;

namespace Automation.Core.Selenium.WebDriver.WebElementObjects
{
    public class WebElementObjectBase
    {
        private WebDriverWait Wait => new WebDriverWait(DriverContext.WebDriver, TimeSpan.FromSeconds(120));

        private static readonly ILog logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        

        public By ByLocator { get; set; }
        public string Locator { get; set; }
        public IWebDriver  Driver { get; set; }
        public IWebElement Element { get; set; }
        public string BindedDataAttribute { get; set; }
        public bool IsMandatory { get; set; }
        public string Url { get; set; }
        public string  ViewModelBinding { get; set; }
        public bool UseWaitAjax { get; set; }
        public IWebElement RootElement { get; set; }

        public bool ReturnIsMandatory()
        {
            return IsMandatory;
        }


        public string ReturnBindedDataAttribute()
        {
            return BindedDataAttribute;
        }

        public virtual IWebElement 
            GetElement()
        {
            return GetElement(10);
        }

        public virtual IWebElement GetElement(int seconds)
        {
            try
            {
                if (UseWaitAjax)
                {
                    Driver.WaitForAjax();
                }

                Element = RootElement != null
                    ? Wait.Until(d => RootElement.FindElement(ByLocator))
                    : Wait.Until(d => d.FindElement(ByLocator));
                return Element;
            }
            catch (StaleElementReferenceException)
            {
                return null;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
            catch (NoSuchWindowException)
            {
                return null;
            }
        }

        public bool IsDisplayed()
        {
            return IsDisplayed(ByLocator);
        }

        public bool IsDisplayed(By byLocator)
        {
            try
            {
                return Wait.Until(d =>
                {
                    try
                    {
                        return d.FindElement(ByLocator).Displayed;
                    }
                    catch (StaleElementReferenceException)
                    {
                        return d.FindElement(ByLocator).Displayed;
                    }
                    catch (NoSuchElementException)
                    {
                        return false;
                    }
                });
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (TimeoutException)
            {
                return false;
            }
        }

        public bool IsEnabled()
        {
            try
            {
                return GetElement().Enabled;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public void ClickByJsExecutor()
        {
            var jsExecutor = DriverContext.WebDriver as IJavaScriptExecutor;
            jsExecutor.ExecuteScript("arguments[0].click();", GetElement());
            try
            {
                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void WaitUntilElementIsDisplayed()
        {
            try
            {
                Wait.Until(ExpectedConditions.ElementIsVisible(ByLocator));
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
        }

        public void WaitUntilElementIsClickable()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(ByLocator));
        }
        public void WaitUntilTextIsVisible(string text)
        {
            Wait.Until(ExpectedConditions.TextToBePresentInElementLocated(ByLocator, text));
        }

        public void WaitForElementToDisappear()
        {
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(ByLocator));
        }

        public void WaitForElement()
        {
            WaitForElement(ByLocator);
        }
        public void WaitForElement(By byLocator)
        {
            if (IsDisplayed(byLocator) && IsEnabled()) return;
            {
                WaitUntilElementIsDisplayed();
                if (!IsEnabled())
                {
                    WaitUntilElementIsClickable();
                }
            }
        }

        public virtual string GetText()
        {
            WaitForElement();
            return GetElement().Text;
        }

        public virtual string GetErrorText()
        {
            WaitForElement(); 
            return GetElement().GetAttribute("");
        }

        public void DoubleClick()
        {
            WaitForElement();
            var action = new Actions(Driver);
            action.DoubleClick(GetElement());
            action.Perform();
        }

        public  void SelectElementWithWait( int index)
        {
            WebDriverWait wait = new WebDriverWait(DriverContext.WebDriver, TimeSpan.FromSeconds(30));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(ByLocator));
            SelectElement select = new SelectElement(element);
            select.SelectByIndex(index);
        }

    }
}
