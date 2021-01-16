using System;
using Integration.UIAutomation.Tests.PageObjectPages.GenericObjects;
using Should;
using TechTalk.SpecFlow;

namespace UIAutomation.Integration.Tests.StepDefinitions
{
    [Binding]
    public class CompaniesHouseSteps
    {
        private GenericPage GenericPage => new GenericPage();

        [When(@"I click the '(.*)' dropdown")]
        public void WhenIClickTheDropdown(string elementName)
        {
            GenericPage.GetDropdownByXpath(elementName).WaitUntilElementIsDisplayed();
            GenericPage.GetDropdownByXpath(elementName).IsDisplayed().ShouldBeTrue($"{elementName} is not displayed");
            GenericPage.GetDropdownByXpath(elementName).ClickByJsExecutor();
        }

        [When(@"I select '(.*)' from the dropdown list")]
        public void WhenISelectFromTheDropdownList(string elementName)
        {
            GenericPage.GetDropdownByXpath(elementName).WaitUntilElementIsDisplayed();
            GenericPage.GetDropdownByXpath(elementName).IsDisplayed().ShouldBeTrue($"{elementName} is not displayed");
            GenericPage.GetDropdownByXpath(elementName).Select(elementName);
        }

    }
}
