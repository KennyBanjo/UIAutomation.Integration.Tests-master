using Automation.Core.Selenium.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Selenium.Essentials;
using Automation.Core.Selenium.ExtensionMethods;
using Should;
using System;
using System.Collections.Generic;
using System.Text;

namespace UIAutomation.Integration.Tests.PageObjectPages
{
    public class EquifaxPage:BasePage
    {
        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'ERROR : Business EQUUK Credit')]")]
        private readonly IWebElement ErrorTitle;

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'A company registration number has not been supplied')]")]
        private readonly IWebElement ErrorMessage;

        public void DisplayErrorMessage(string error, string errorMsg)
        {
            ErrorTitle.WaitUntilElementCssDisplayed(DriverContext.WebDriver);
            ErrorTitle.IsDisplayed().ShouldBeTrue("Error title is not displayed");
            ErrorTitle.Text.ShouldEqual("ERROR : Business EQUUK Credit");
            ErrorMessage.IsDisplayed().ShouldBeTrue("Error message isnot displayed");
            ErrorMessage.Text.ShouldEqual("A company registration number has not been supplied");
        }
    }
}
