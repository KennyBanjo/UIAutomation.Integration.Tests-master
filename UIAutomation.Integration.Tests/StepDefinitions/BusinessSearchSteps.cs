using System;
using Automation.Core.Selenium.Base;
using Automation.Core.Selenium.PageObjectPages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Integration.UIAutomation.Tests.StepDefinitions
{
    [Binding]
    public class BusinessSearchSteps:BasePage
    {
        
        [Given(@"I navigate to the self registration portal")]
        public void GivenINavigateToTheSelfRegistrationPortal()
        {
            DriverContext.WebDriver.Url =
                "https://psomaster-16e7f3e3362-1751cd447b3.force.com/nPORTAL__SelfRegistration?product=a0u3g000000bmSzAAI";
        }
        
        [When(@"I enter the following details")]
        public void WhenIEnterTheFollowingDetails(Table table)
        {
            CurrentPage = GetInstance<SelfRegistrationPage>();
            CurrentPage.As<SelfRegistrationPage>().EnterUserDetails(table);
        }
        
        [When(@"I click the continue button")]
        public void WhenIClickTheContinueButton()
        {
            CurrentPage = GetInstance<SelfRegistrationPage>();
            CurrentPage.As<SelfRegistrationPage>().ClickContinue();
        }
        
        [When(@"I enter the loan amount as (.*)")]
        public void WhenIEnterTheLoanAmountAs(string amount)
        {
            CurrentPage = GetInstance<SelfRegistrationPage>();
            CurrentPage.As<SelfRegistrationPage>().EnterLoanAmount(amount);
        }
        
        [When(@"I enter the loan purpose as '(.*)'")]
        public void WhenIEnterTheLoanPurposeAs(string purpose)
        {
            CurrentPage = GetInstance<SelfRegistrationPage>();
            CurrentPage.As<SelfRegistrationPage>().EnterLoanPurpose(purpose);
        }
        
        [When(@"I click the next button")]
        public void WhenIClickTheNextButton()
        {
            CurrentPage = GetInstance<SelfRegistrationPage>();
            CurrentPage.As<SelfRegistrationPage>().ClickNext();
        }
        
        [When(@"I enter '(.*)' in the company name field")]
        public void WhenIEnterInTheCompanyNameField(string companyName)
        {
            CurrentPage = GetInstance<SelfRegistrationPage>();
            CurrentPage.As<SelfRegistrationPage>().EnterCompanyName(companyName);
        }
        
        [When(@"I select NCINO APAC PTY LTD")]
        public void WhenISelectNCINOAPACPTYLTD()
        {
            CurrentPage = GetInstance<SelfRegistrationPage>();
            CurrentPage.As<SelfRegistrationPage>().SelectFirstResult();
        }
        
        [Then(@"I should see the eligibility page")]
        public void ThenIShouldSeeTheEligibilityPage()
        {
            CurrentPage = GetInstance<SelfRegistrationPage>();
            CurrentPage.As<SelfRegistrationPage>().DisplayEligibilityPage();
        }
        
        [Then(@"I should see the ABR search page")]
        public void ThenIShouldSeeTheABRSearchPage()
        {
            CurrentPage = GetInstance<SelfRegistrationPage>();
            CurrentPage.As<SelfRegistrationPage>().DisplayABRSearch();
        }
        
        [Then(@"the following fields should be populated")]
        public void ThenTheFollowingFieldsShouldBePopulated(Table table)
        {
            CurrentPage = GetInstance<SelfRegistrationPage>();
            CurrentPage.As<SelfRegistrationPage>().VerifyFields(table);
        }
    }
}
