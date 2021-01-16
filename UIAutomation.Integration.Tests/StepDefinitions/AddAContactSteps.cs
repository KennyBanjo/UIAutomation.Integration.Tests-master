using System;
using System.Threading;
using Automation.Core.Selenium.Base;
using Integration.UIAutomation.Tests.PageObjectPages;
using TechTalk.SpecFlow;

namespace Integration.UIAutomation.Tests.StepDefinitions
{
    [Binding]
    public class AddAContactSteps:BasePage
    {
        [When(@"I wait '(.*)' ms")]
        public void WhenIWaitMs(int ms)
        { 
            Thread.Sleep(ms);
        }
        
        [When(@"I add a new contact")]
        public void WhenIAddANewContact()
        {
            CurrentPage = GetInstance<ContactPage>();
            CurrentPage.As<ContactPage>().AddAContact();
        }
    }
}
