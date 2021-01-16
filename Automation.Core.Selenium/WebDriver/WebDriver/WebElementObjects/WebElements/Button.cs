using System;
using System.Threading;
using Automation.Core.Selenium.Base;
using Automation.Core.Selenium.WebDriver.WebElementObjects.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Automation.Core.Selenium.WebDriver.WebElementObjects.WebElements
{
    public class Button:WebElementObjectBase, IClickable
    {
        public void Click()
        {
            //Wait until the button is there
            WaitForElement();
            //perform the click
            var action = new Actions(Driver);
            action.MoveToElement(GetElement()).Click().Perform();
        }

        public void JsClick(IWebElement element)
        {
            var jsExecutor = DriverContext.WebDriver as IJavaScriptExecutor;
            jsExecutor.ExecuteScript("arguments[0].click();", element);
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

        public override string GetText()
        {
            return GetElement().Text;
        }


        public void RightClick()
        {
            var actions = new Actions(Driver);
            actions.MoveToElement(GetElement());
            actions.ContextClick(GetElement()).Build().Perform();
        }
    }
}