using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Core.Selenium.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Automation.Core.Selenium.PageObjectPages
{
    public class RelationshipsPage:BasePage
    {
        [FindsBy(How = How.CssSelector, Using = "[data-id = 'Account']")]
        private IWebElement RelationshipTab;

        [FindsBy(How = How.CssSelector, Using = "[title = 'Ernst & Young LLP']")]
        private IWebElement AccountName;

        [FindsBy(How = How.CssSelector, Using = "[title = 'Run Verifications']")]
        private IWebElement RunVerification;
    }
}
