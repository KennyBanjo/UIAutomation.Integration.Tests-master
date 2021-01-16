 using System;
using System.Collections.Generic;
using System.Text;
using Automation.Core.Selenium.APIHandler;
using TechTalk.SpecFlow;

namespace UIAutomation.Integration.Tests.Hooks
{
    [Binding]
    class AfterScenarioHook
    {
        [AfterScenario(@"StandardDB")]
        public void CleanStandardDB()
        {
            DataLoader.DeleteData();
        }

        [AfterScenario(@"PortalDB")]
        public void CleanPortalDB()
        {
            DataLoader.DeletePortalApplications();
        }
    }
}
