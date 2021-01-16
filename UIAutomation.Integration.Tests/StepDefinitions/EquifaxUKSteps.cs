using System;
using System.Reflection;
using System.Threading;
using Automation.Core.Selenium.Base;
using Integration.UIAutomation.Tests.PageObjectPages;
using Integration.UIAutomation.Tests.PageObjectPages.GenericObjects;
using log4net;
using OpenQA.Selenium;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using Should;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;
using UIAutomation.Integration.Tests.PageObjectPages;

namespace Integration.UIAutomation.Tests.StepDefinitions
{
    [Binding]
    public class EquifaxUKSteps : BasePage
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        WebDriverWait Wait => new WebDriverWait(DriverContext.WebDriver, TimeSpan.FromSeconds(30));
        private static GenericPage GenericPage => new GenericPage();

        [When(@"I click on the '(.*)' tab")]
        public void WhenIClickOnTheTab(string tabName)
        {
            Thread.Sleep(2000);
            GenericPage.GetTabByXPath(tabName).WaitUntilElementIsDisplayed();
            GenericPage.GetTabByXPath(tabName).IsDisplayed().ShouldBeTrue($"{tabName} is not displayed");
            GenericPage.GetTabByXPath(tabName).ClickByJsExecutor();
        }

        [When(@"I search for '(.*)' in the '(.*)' textfield")]
        public void WhenISearchForInTheTextfield(string searchItem, string searchField)
        {
            Thread.Sleep(2000);
            GenericPage.GetTextFieldByxPath(searchField).WaitUntilElementIsDisplayed();
            GenericPage.GetTextFieldByxPath(searchField).IsDisplayed().ShouldBeTrue($"{searchField} is not displayed");
            GenericPage.GetTextFieldByxPath(searchField).JsEnterText(searchItem);
            GenericPage.GetTextFieldByxPath(searchField).Enter();
        }

        [When(@"I click on '(.*)'")]
        public void WhenIClickOn(string elementName)
        {
            Thread.Sleep(2000);
            GenericPage.GetLabelByXPath(elementName).IsDisplayed().ShouldBeTrue($"{elementName} is not displayed");
            GenericPage.GetLabelByXPath(elementName).ClickByJsExecutor();
        }

        [When(@"I click on the '(.*)' button")]
        public void WhenIClickOnTheButton(string elementName)
        {
            Thread.Sleep(2000);
            GenericPage.GetButtonByXPathText(elementName).WaitUntilElementIsDisplayed();
            GenericPage.GetButtonByXPathText(elementName).ClickByJsExecutor();
        }

        [When(@"I click the '(.*)' button")]
        public void WhenIClickTheButton(string buttonName)
        {
            //Thread.Sleep(3000);
            GenericPage.GetButtonByClass(buttonName).WaitUntilElementIsDisplayed();
            GenericPage.GetButtonByClass(buttonName).Click();
        }

        [Then(@"I should see '(.*)'")]
        public void ThenIShouldSeeInTheResult(string elementName)
        {
            Thread.Sleep(2000);
            GenericPage.GetLabelByXPath(elementName).WaitUntilElementIsDisplayed();
            GenericPage.GetLabelByXPath(elementName).IsDisplayed().ShouldBeTrue($"{elementName} is not displayed");
        }

        [Then(@"I should see '(.*)' under report")]
        public void ThenIShouldSeeUnderReport(string elementName)
        {
            Thread.Sleep(2000);
            GenericPage.GetFrameByXPath("accessibility title").WaitUntilElementIsDisplayed();
            GenericPage.GetFrameByXPath("accessibility title").SwitchToFrame();
            GenericPage.GetTableRowDataByXPath(3).WaitUntilElementIsDisplayed();
            GenericPage.GetTableRowDataByXPath(3).IsDisplayed().ShouldBeTrue("Report type is not displayed");
            GenericPage.GetTableRowDataByXPath(3).GetText().ShouldEqual(elementName);
        }

        //[Then(@"I click on the '(.*)' button")]
        //public void ThenIClickOnTheButton(string p0)
        //{
            
        //}


        [When(@"I click the checkbox")]
        public void WhenIClickTheCheckbox()
        {
            GenericPage.GetTableRowDataByXPath(1).Click();
        }

        [Then(@"the modal '(.*)' should be displayed")]
        public void ThenTheModalShouldBeDisplayed(string modalName)
        {
            Thread.Sleep(2000); 
            GenericPage.GetModalNameByXPath(modalName).WaitUntilElementIsDisplayed();
            GenericPage.GetModalNameByXPath(modalName).IsDisplayed().ShouldBeTrue($"{modalName} is not displayed");
        }

        [When(@"I click the '(.*)' modal button")]
        public void WhenIClickTheModalButton(string buttonName)
        {
            Thread.Sleep(2000);
            GenericPage.GetModalButtonByXPath(buttonName).WaitUntilElementIsDisplayed();
            GenericPage.GetModalButtonByXPath(buttonName).IsDisplayed().ShouldBeTrue($"{buttonName}");
            GenericPage.GetModalButtonByXPath(buttonName).Click();
        }

        [Then(@"the status should display '(.*)'")]
        public void ThenTheStatusShouldRead(string element)
        {
            GenericPage.GetTableRowDataByXPath(2).WaitUntilTextIsVisible(element);
            var status = GenericPage.GetTableRowDataByXPath(2).GetText();
            status.ShouldEqual(element);
        }


        [Then(@"the status should read '(.*)' or '(.*)' or (.*)")]
        public void ThenTheStatusShouldReadOR(string status1, string status2, string status3)
        {
            
            GenericPage.GetTableRowDataByXPath(2).WaitUntilTextIsVisible("IN FILE");
            var status = GenericPage.GetTableRowDataByXPath(2).GetText();
         
            if (status == status1)
            {
                GenericPage.GetTableRowDataByXPath(2).GetText().ShouldEqual("IN FILE");
            }
            else if (status == status2)
            {
                GenericPage.GetTableRowDataByXPath(2).GetText().ShouldEqual("NEEDS REVIEW");
            }
            else if (status == status3)
            {
                GenericPage.GetTableRowDataByXPath(2).GetText().ShouldEqual("PASS");
            }
        }

        [Then(@"the report date should equal today's date")]
        public void ThenTheReportDateShouldEqualTodaysDate()
        {
            var currentDate = DateTime.Now.ToString("dd/MM/yyyy");
            GenericPage.GetTableRowDataByXPath(5).GetText().ShouldEqual(currentDate);
        }

        [Then(@"the '(.*)' column should display '(.*)'")]
        public void ThenTheColumnShouldDisplay(string column, string text)
        {
            GenericPage.GetTableHeadsByXPath(6).GetText().ShouldEqual($"{column}");
            GenericPage.GetTableRowDataByXPath(6).IsDisplayed().ShouldBeTrue($"{text} is not displayed");
            GenericPage.GetTableRowDataByXPath(6).GetText().ShouldEqual(text);
        }

        [Then(@"An '(.*)' should appear with the message '(.*)'")]
        public void ThenAnShouldAppearWithTheMessage(string error, string errorMsg)
        {
            CurrentPage = GetInstance<EquifaxPage>();
            CurrentPage.As<EquifaxPage>().DisplayErrorMessage(error, errorMsg);
        }
    }
}

