using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Text;
using Automation.Core.Selenium.HelperClass;
using Integration.UIAutomation.Tests.PageObjectPages.GenericObjects;
using TechTalk.SpecFlow;

namespace UIAutomation.Integration.Tests.StepDefinitions
{
    [Binding]
    class HomePageSteps
    {
        private static GenericPage GenericPage => new GenericPage();

        [When(@"I click File menu and Logout from the site")]
        public static void WhenIClickTheProfileAndLogoutFromTheSite()
        {
            GenericPage.GetButtonByxPath("User").Click();
            GenericPage.GetButtonByLinkText("/secur/logout.jsp").WaitUntilElementIsDisplayed();
            GenericPage.GetButtonByLinkText("/secur/logout.jsp").Click();
            LogHelper.Info("Log out completed");
        }
    }
}
