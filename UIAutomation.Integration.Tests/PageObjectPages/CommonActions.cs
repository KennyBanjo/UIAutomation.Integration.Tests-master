using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Core.Selenium.Base;
using Integration.UIAutomation.Tests.PageObjectPages.GenericObjects;
using MongoDB.Driver;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Should;

namespace Integration.UIAutomation.Tests.PageObjectPages
{
    public class CommonActions:BasePage
    {
        private GenericPage GenericPage => new GenericPage();

        public void ClickSalesForceTab(string elementName)
        {
            GenericPage.GetTabByXPath(elementName).WaitUntilElementIsDisplayed();
            GenericPage.GetTabByXPath(elementName).IsDisplayed().ShouldBeTrue($"{elementName} is not displayed");
            GenericPage.GetTabByXPath(elementName).ClickByJsExecutor();
        }
    }
}
