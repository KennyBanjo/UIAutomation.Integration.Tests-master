using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Core.Selenium.Base;
using Automation.Core.Selenium.HelperClass;
using Automation.Core.Selenium.ExtensionMethods;
using Integration.UIAutomation.Tests.PageObjectPages.GenericObjects;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Integration.UIAutomation.Tests.PageObjectPages
{
    public class ContactPage: BasePage
    {
        private GenericPage GenericPage => new GenericPage();

        [FindsBy(How = How.XPath, Using = "//a[@title='New']")]
        private IWebElement NewButton;

        [FindsBy(How = How.CssSelector, Using = ".firstName")]
        private IWebElement FirstNameField;

        [FindsBy(How = How.CssSelector, Using = ".lastName")]
        private IWebElement lastNameField;

        [FindsBy(How = How.CssSelector, Using = "[title = 'Search Relationships']")]
        private IWebElement RelationshipSearch;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'GREGGS PLC')]")]
        private IWebElement GreggsRelationship;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Individual')]")]
        private IWebElement RecordType;

        [FindsBy(How = How.CssSelector, Using = "[title = 'Save']")]
        private IWebElement SaveBtn;

        private IWebElement Contact => GenericPage.GetButtonByxPath("Contacts").GetElement();
        public ContactPage AddAContact()
        {
            GenericPage.GetButtonByxPath("Contacts").WaitUntilElementIsDisplayed();
            GenericPage.GetButtonByxPath("Contacts").ClickByJsExecutor();
            GenericPage.GetButtonByxPath("New").WaitUntilElementIsDisplayed();
            GenericPage.GetButtonByxPath("New").ClickByJsExecutor();
            GenericPage.GetTextFieldByxPath("First Name").WaitUntilElementIsDisplayed();
            GenericPage.GetTextFieldByxPath("First Name").EnterText("John");
            GenericPage.GetTextFieldByxPath("Last Name").EnterText("Cena");
            GenericPage.GetTextFieldByxPath("Search Relationships").Click();
            GenericPage.GetLabelByText("GREGGS PLC").WaitUntilElementIsDisplayed();
            GenericPage.GetLabelByText("GREGGS PLC").Click();
            GenericPage.GetButtonByxPath("Save").Click();


            //Contact.WaitUntilElementVisible();
            //GenericHelper.JsClick(Contact);
            //NewButton.WaitUntilElementVisible();
            //GenericHelper.JsClick(NewButton);
            //FirstNameField.WaitUntilElementVisible();
            //FirstNameField.SendKeys("Shane");
            //lastNameField.SendKeys("Ward");
            //GenericHelper.JsClick(RelationshipSearch);
            //GreggsRelationship.WaitUntilElementVisible();
            //GenericHelper.JsClick(GreggsRelationship);
            //GenericHelper.JsClick(SaveBtn);
            return new ContactPage();
        }
    }
}
