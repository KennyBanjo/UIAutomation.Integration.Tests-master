using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Integration.UIAutomation.Tests.PageObjectPages.GenericObjects;
using Should;
using TechTalk.SpecFlow;

namespace UIAutomation.Integration.Tests.StepDefinitions
{
    [Binding]
    class GenericStepDefinition
    {
        private GenericPage GenericPage => new GenericPage();

        [Then(@"I should see the '(.*)' tab")]
        public void ThenIShouldSeeTheTab(string tabName)
        {
            GenericPage.GetFrameByXPath("accessibility title").WaitUntilElementIsDisplayed();
            GenericPage.GetFrameByXPath("accessibility title").IsDisplayed().ShouldBeTrue();
            GenericPage.GetFrameByXPath("accessibility title").SwitchToFrame();
            GenericPage.GetButtonByXPathText(tabName).IsDisplayed().ShouldBeTrue($"{tabName} is not displayed");
        }

        [When(@"I click the configure button under system configuration row '(.*)' column '(.*)'")]
        public void WhenIClickTheConfigureButtonUnderSystemConfigurationRowColumn(int row, int column)
        {
            GenericPage.GetSystemConfigTable(row, column).WaitUntilElementIsDisplayed();
            GenericPage.GetSystemConfigTable(row, column).IsDisplayed()
                .ShouldBeTrue("Configure button is not displayed");
            GenericPage.GetSystemConfigTable(row, column).ClickByJsExecutor();
        }

        [When(@"I click the '(.*)' plug-in checkbox to activate")]
        public void WhenIClickTheCheckboxToActivate(string pluginName)
        {
            GenericPage.GetFrameByXPath("accessibility title").WaitUntilElementIsDisplayed();
            GenericPage.GetFrameByXPath("accessibility title").SwitchToFrame();
            GenericPage.GetPluginCheckboxByXPath(pluginName).WaitUntilElementIsDisplayed();
            GenericPage.GetPluginCheckboxByXPath(pluginName).IsDisplayed()
                .ShouldBeTrue($"{pluginName} is not displayed");
            GenericPage.GetPluginCheckboxByXPath(pluginName).Check();
            GenericPage.GetLoadingBox("auraLoadingBox").WaitForElementToDisappear();
        }

        [Then(@"the '(.*)' plug-in checkbox should be selected")]
        public void ThenThePlug_InCheckboxShouldBeSelected(string pluginName)
        {
            GenericPage.GetLoadingBox("auraLoadingBox").WaitForElementToDisappear();
            GenericPage.GetPluginCheckboxByXPath(pluginName).Selected().ShouldBeTrue($"{pluginName} is not selected");
        }

        [When(@"I click the '(.*)' plug-in checkbox to deactivate")]
        public void WhenIClickThePlug_InCheckboxToDeactivate(string pluginName)
        {
            GenericPage.GetLoadingBox("auraLoadingBox").WaitForElementToDisappear();
            GenericPage.GetPluginCheckboxByXPath(pluginName).UnCheck();
        }

        [Then(@"the '(.*)' plug-in checkbox should be de-selected")]
        public void ThenThePlug_InCheckboxShouldBeDe_Selected(string pluginName)
        {
            GenericPage.GetLoadingBox("auraLoadingBox").WaitForElementToDisappear();
            GenericPage.GetPluginCheckboxByXPath(pluginName).Selected().ShouldBeFalse($"{pluginName} is selected");
        }

        [When(@"I click the '([^']*)' radio button")]
        public void WhenIClickTheRadioButton(string radioButton)
        {
            GenericPage.GetRadioButtonByXPath(radioButton).WaitUntilElementIsDisplayed();
            GenericPage.GetRadioButtonByXPath(radioButton).Click();
        }
    }
}
