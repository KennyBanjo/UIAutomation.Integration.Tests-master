using System;
using Automation.Core.Selenium.Base;
using Automation.Core.Selenium.Config;
using Integration.UIAutomation.Tests.PageObjectPages;
using Integration.UIAutomation.Tests.PageObjectPages.GenericObjects;
using Microsoft.Extensions.Configuration;
using Should;
using TechTalk.SpecFlow;

namespace Integration.UIAutomation.Tests.StepDefinitions
{
    [Binding]
    public class LoginSteps : BasePage
    {
        private GenericPage GenericPage => new GenericPage();
        private readonly IConfiguration _configuration;



        [Given(@"I have navigated to the application url")]
        public void GivenIHaveNavigatedToTheApplicationUrl()
        {
            DriverContext.WebDriver.Url = Settings.Url;
        }

        [When(@"I login as system administrator")]
        public void WhenILoginAsSystemAdministrator()
        {
            GenericPage.GetTextFieldByxPath("username").WaitUntilElementIsDisplayed();
            GenericPage.GetTextFieldByxPath("username").IsDisplayed().ShouldBeTrue("Username field is not displayed");
            GenericPage.GetTextFieldByxPath("username").EnterText(Settings.Username);
            GenericPage.GetTextFieldByxPath("password").EnterText(Settings.Password);
            GenericPage.GetButtonByxPath("Login").Click();
        }

        [Then(@"I should be on the homepage")]
         public void ThenIShouldBeOnTheHomepage()
        {
           GenericPage.GetTabByXPath("Home").WaitUntilElementIsDisplayed();
           GenericPage.GetTabByXPath("Home").IsDisplayed().ShouldBeTrue("Homepage is not displayed");
        }
        
    }
}
