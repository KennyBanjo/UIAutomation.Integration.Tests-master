using Automation.Core.Selenium.Base;
using System;
using TechTalk.SpecFlow;
using UIAutomation.Integration.Tests.PageObjectPages;

namespace UIAutomation.Integration.Tests.StepDefinitions
{
    [Binding]
    public class DueDilStepDefinitions:BasePage
    {
        [Then(@"the billing address changes to '(.*)'")]
        public void ThenTheBillingAddressChangesTo(string element)
        {
            CurrentPage = GetInstance<DueDilPage>();
            CurrentPage.As<DueDilPage>().VerifyAddressChange(element);
        }
    }
}
