using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Automation.Core.Selenium.APIHandler;
using Automation.Core.Selenium.Base;
using TechTalk.SpecFlow;

namespace Integration.UIAutomation.Tests.Hooks
{
    [Binding]
    public class BeforeScenarioHooks:BasePage
    {
        [BeforeScenario(@"StandardDB")]
        public void SetStandardDB()
        {
            DataLoader.LoadData();
        }
    }
}
