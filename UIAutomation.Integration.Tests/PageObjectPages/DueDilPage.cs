using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium;
using Automation.Core.Selenium.Base;
using Selenium.Essentials;
using Should;
using Integration.UIAutomation.Tests.PageObjectPages.GenericObjects;
using System.Threading;

namespace UIAutomation.Integration.Tests.PageObjectPages
{
    [Binding]

    public class DueDilPage:BasePage
    {
        public GenericPage GenericPage => new GenericPage();

        //[FindsBy(How = How.XPath, Using = "//span[contains(text(),'Ncino Global Ltd')]")]
        //private IWebElement CompanyNameLabel;

        [FindsBy(How = How.XPath, Using = "//lightning-formatted-text[contains(text(),'Floor 11, Whitefriars Lewins Mead Bristol, Avon BS')]")]
        private IWebElement DuedilCompanyAddress;

        private IWebElement CompanyName(string element)
        {
            return GenericPage.GetLabelByText(element).GetElement();
        }
        public void VerifyCompanyName(string companyName)
        {

            CompanyName(companyName).WaitUntilElementExists(DriverContext.WebDriver);
            CompanyName(companyName).Text.ShouldEqual(companyName);
        }

        public void VerifyAddressChange(string element)
        {
            DuedilCompanyAddress.WaitUntilElementCssDisplayed(DriverContext.WebDriver);
            DuedilCompanyAddress.Displayed.ShouldBeTrue("Billing address is not displayed");
            DuedilCompanyAddress.Text.ShouldEqual(element);
        }
    }
}
