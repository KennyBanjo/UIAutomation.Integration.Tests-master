using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Automation.Core.Selenium.APIHandler;
using Automation.Core.Selenium.Base;
using Automation.Core.Selenium.ExtensionMethods;
using Automation.Core.Selenium.PageObject;
using Automation.Core.Selenium.WebDriver.WebDriver.WebElementObjects.Attributes;
using Automation.Core.Selenium.WebDriver.WebDriver.WebElementObjects.WebElements;
using Automation.Core.Selenium.WebDriver.WebElementObjects.WebElements;
using Integration.UIAutomation.Tests.PageObjectPages.GenericObjects;
using MongoDB.Driver;
using OpenQA.Selenium;
using RestSharp;
using SeleniumExtras.PageObjects;
using Selenium.Essentials;
using Should;
using TechTalk.SpecFlow.Assist;
using UIAutomation.Integration.Tests.TableEntities;
using Table = TechTalk.SpecFlow.Table;

namespace UIAutomation.Integration.Tests.PageObjectPages
{
    class CompaniesHousePage: BasePage
    {
        GenericPage GenericPage => new GenericPage();
       
        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'NCINO GLOBAL LTD')]")]
        private IWebElement CompanyNameLabel;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'ECCENTRIC INVESTMENTS LLP')]")]
        private IWebElement CompanyNameByIDLabel;

        [FindsBy(How = How.XPath, Using = "//*[@name='primaryField']//*[contains(text(),'NCINO GLOBAL LTD')]")]
        private IWebElement RelationshipName;

        [FindsBy(How = How.XPath, Using = "//*[@name='primaryField']//*[contains(text(),'ECCENTRIC INVESTMENTS LLP')]")]
        private IWebElement RelationshipNameByIDLabel;

        private IWebElement CompanyName(string element)
        {
            return GenericPage.GetLabelByText(element).GetElement();
        }
       
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Save')]")]
        private IWebElement SaveButton;

        [FindsBy(How = How.XPath,
            Using = "//*[@href = '/nPortal__OnlineApplication?new=true&productId=a0u4K0000000Xz8QAE']")]
        private IWebElement CBILSApplyButton;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Add New')]")]
        private IWebElement AddNewBtn;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Start typing to search...']")]
        private IWebElement CompanySearchField;

        [FindsBy(How = How.CssSelector, Using = "[data-company-id= '01879474']")]
        private IWebElement PaxtonAccess;

        [FindsBy(How = How.CssSelector, Using = "[data-company-id= 'OC434012']")]
        private IWebElement ECCENTRICINVESTMENTSLLP;

        private GenericPage Genericpage => new GenericPage();

        public void ClickCompaniesHouseContinueBtn(string element)
        { 
            Genericpage.GetBusinessLookupButton(element).WaitUntilElementIsDisplayed();
            Genericpage.GetBusinessLookupButton(element).Click();
        }

        public void VerifyCompanyName(string companyName)
        {
           CompanyNameLabel.WaitUntilElementExists(DriverContext.WebDriver);
           CompanyNameLabel.Text.ShouldEqual(companyName);
        }

        public void VerifyCompanyID(string companyName)
        {
           CompanyNameByIDLabel.WaitUntilElementExists(DriverContext.WebDriver);
           CompanyNameByIDLabel.Text.ShouldEqual(companyName);
        }

        public void VerifyRelationshipName(string name)
        {
            RelationshipName.WaitUntilElementTextContains(DriverContext.WebDriver, name);
            RelationshipName.Text.ShouldEqual(name);
        }
        public void VerifyRelationshipNameForIDSearch(string name)
        {
            RelationshipNameByIDLabel.WaitUntilElementTextContains(DriverContext.WebDriver, name);
            RelationshipNameByIDLabel.Text.ShouldEqual(name);
        }

        public void ClickSaveButton()
        {
            SaveButton.WaitUntilElementIsClickable(DriverContext.WebDriver);
            SaveButton.Click();
        }

        public void ClickApplyButton()
        {
            CBILSApplyButton.WaitUntilElementIsClickable(DriverContext.WebDriver);
            CBILSApplyButton.IsDisplayed().ShouldBeTrue("Apply button is not displayed");
            CBILSApplyButton.Click();
        }

        public bool ClickAddNew()
        {
            bool result = false;
            var attempt = 0;
            GenericPage.LoadingIcon.WaitForElementToDisappear();
            AddNewBtn.WaitUntilElementClickable();
            AddNewBtn.IsDisplayed().ShouldBeTrue("Add new button is not displayed");
            while (attempt < 2)
            {
                try
                {
                    AddNewBtn.Click();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                attempt++;
            }
            return result;
        }

        public void SearchForCompany(string companyName)
        {
            CompanySearchField.WaitUntilElementCssDisplayed(DriverContext.WebDriver);
            CompanySearchField.IsDisplayed().ShouldBeTrue("Company field is not displayed");
            CompanySearchField.EnterText(companyName);
        }

        public void SelectPaxtonAccessLtd()
        {
            Thread.Sleep(2000);
            CompanySearchField.Click();
            PaxtonAccess.WaitUntilElementVisible();
            PaxtonAccess.IsDisplayed().ShouldBeTrue("Paxton Access Limited is not visible");
            PaxtonAccess.Click();
        }

        public void SelectEccentricInvestment()
        {
            Thread.Sleep(2000);
            CompanySearchField.Click();
            ECCENTRICINVESTMENTSLLP.WaitUntilElementVisible();
            ECCENTRICINVESTMENTSLLP.IsDisplayed().ShouldBeTrue("Paxton Access Limited is not visible");
            ECCENTRICINVESTMENTSLLP.Click();
        }

        public void VerifyFields(Table table)
        {
            Genericpage.GetCBILSTextfieldByCss("Name").WaitUntilElementIsDisplayed();
            var fields = table.CreateInstance<CBILSBusinessLookUp>();
            Genericpage.GetCBILSTextfieldByCss("Name").GetText().ShouldEqual(fields.RelationshipName);
            Genericpage.GetCBILSTextfieldByCss("BillingStreet").GetText().ShouldEqual(fields.BillingStreet);
            Genericpage.GetCBILSTextfieldByCss("BillingCity").GetText().ShouldEqual(fields.BillingCity);
            Genericpage.GetCBILSTextfieldByCss("BillingPostalCode").GetText().ShouldEqual(fields.PostalCode);
        }

        public void VerifyCompany(string companyName)
        {

            CompanyName(companyName).WaitUntilElementExists(DriverContext.WebDriver);
            CompanyName(companyName).Text.ShouldEqual(companyName);
        }

    }
}
