using System;
using System.Runtime.InteropServices;
using Automation.Core.Selenium.APIHandler;
using Automation.Core.Selenium.Base;
using Automation.Core.Selenium.PageObjectPages;
using Integration.UIAutomation.Tests.PageObjectPages.GenericObjects;
using RestSharp;
using Should;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UIAutomation.Integration.Tests.PageObjectPages;
using UIAutomation.Integration.Tests.TableEntities;

namespace UIAutomation.Integration.Tests.StepDefinitions
{
    [Binding]
    public class CompaniesHouseStepDefinitions: BasePage
    {
        private GenericPage GenericPage => new GenericPage();

        [When(@"I click on the business look-up '(.*)' button")]
        public void WhenIClickOnTheBusinessLook_UpButton(string buttonName)
        {
            CurrentPage = GetInstance<CompaniesHousePage>();
            CurrentPage.As<CompaniesHousePage>().ClickCompaniesHouseContinueBtn(buttonName);
        }

        [Then(@"I should see the following information")]
        public void ThenIShouldSeeTheFollowingInformation(Table table)
        {
            var field = table.CreateInstance<BusinessLookUp>();
            GenericPage.GetLabelByText(field.CompanyAddress).GetText().ShouldEqual(field.VerifyAddress);
            GenericPage.GetLabelByText(field.CompanyId).GetText().ShouldEqual(field.CompanyId);
            GenericPage.GetLabelByText(field.TypeDescription).GetText().ShouldEqual(field.TypeDescription);
        }

        [Then(@"the application should carry over the following fields")]
        public void ThenTheApplicationShouldCarryOverTheFollowingFields(Table table)
        {
            GenericPage.GetCBILSTextfieldByCss("Name").WaitUntilElementIsDisplayed();
            var fields = table.CreateInstance<CBILSBusinessLookUp>();
            GenericPage.GetCBILSTextfieldByCss("Name").GetText().ShouldEqual(fields.LegalBusinessName);
            GenericPage.GetCBILSTextfieldByCss("BillingStreet").GetText().ShouldEqual(fields.BillingStreet);
            GenericPage.GetCBILSTextfieldByCss("BillingCity").GetText().ShouldEqual(fields.BillingCity);
            GenericPage.GetCBILSTextfieldByCss("BillingPostalCode").GetText().ShouldEqual(fields.PostalCode);
        }

        [Then(@"the heading should be '(.*)'")]
        public void ThenTheHeadingShouldBe(string elementName)
        {
            CurrentPage = GetInstance<CompaniesHousePage>();
            CurrentPage.As<CompaniesHousePage>().VerifyCompany(elementName);
        }

         [Then(@"the heading should now be '(.*)'")]
        public void ThenTheHeadingShouldNowBe(string elementName)
        {
            CurrentPage = GetInstance<CompaniesHousePage>();
            CurrentPage.As<CompaniesHousePage>().VerifyCompanyID(elementName);
        }

        [Then(@"the relationship name should be changed to '(.*)'")]
        public void ThenTheRelationshipNameShouldBeChangedTo(string name)
        {
            CurrentPage = GetInstance<CompaniesHousePage>();
            CurrentPage.As<CompaniesHousePage>().VerifyRelationshipName(name);
        }

        [Then(@"the relationship name should now be changed to '(.*)'")]
        public void ThenTheRelationshipNameShouldNowBeChangedTo(string name)
        {
            CurrentPage = GetInstance<CompaniesHousePage>();
            CurrentPage.As<CompaniesHousePage>().VerifyRelationshipNameForIDSearch(name);
        }

        [When(@"I click the search result save button")]
        public void WhenIClickTheSearchResultSaveButton()
        {
            CurrentPage = GetInstance<CompaniesHousePage>();
            CurrentPage.As<CompaniesHousePage>().ClickSaveButton();
        }

        [When(@"I click on the '(.*)' label")]
        public void WhenIClickOnTheLabel(string labelName)
        {
            GenericPage.GetLabelByXPath(labelName).WaitUntilElementIsDisplayed();
            GenericPage.GetLabelByXPath(labelName).IsDisplayed().ShouldBeTrue($"{labelName} is not displayed");
            GenericPage.GetLabelByXPath(labelName).ClickByJsExecutor();
        }

        [When(@"I click the CBILS Apply button")]
        public void WhenIClickTheCBILSApplyButton()
        {
            CurrentPage = GetInstance<CompaniesHousePage>();
            CurrentPage.As<CompaniesHousePage>().ClickApplyButton();
        }

        [Then(@"I should see the '(.*)' search page")]
        public void ThenIShouldSeeTheSearchPage(string elementName)
        {
            GenericPage.GetLabelByText(elementName).WaitUntilElementIsDisplayed();
            GenericPage.GetLabelByText(elementName).IsDisplayed().ShouldBeTrue($"{elementName} is not displayed");
        }

        [When(@"I select Paxton Access Limited")]
        public void WhenISelectPaxtonAccessLimited()
        {
            CurrentPage = GetInstance<CompaniesHousePage>();
            CurrentPage.As<CompaniesHousePage>().SelectPaxtonAccessLtd();
        }

        [When(@"I select Eccentric investment LLP")]
        public void WhenISelectPEccentricinvestmentLLP()
        {
            CurrentPage = GetInstance<CompaniesHousePage>();
            CurrentPage.As<CompaniesHousePage>().SelectEccentricInvestment();
        }

        [When(@"I click the CBILS Add New button")]
        public void WhenIClickTheCBILSAddNewButton()
        {
            CurrentPage = GetInstance<CompaniesHousePage>();
            CurrentPage.As<CompaniesHousePage>().ClickAddNew();
        }

        [When(@"I enter '(.*)' in the company search field")]
        public void WhenIEnterInTheCompanySearchField(string elementName)
        {
            CurrentPage = GetInstance<CompaniesHousePage>();
            CurrentPage.As<CompaniesHousePage>().SearchForCompany(elementName);
        }

        [Then(@"I should see the following fields")]
        public void ThenIShouldSeeTheFollowingFields(Table table)
        {
            CurrentPage = GetInstance<CompaniesHousePage>();
            CurrentPage.As<CompaniesHousePage>().VerifyFields(table);
        }

    }
}
