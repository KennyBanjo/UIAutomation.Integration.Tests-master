using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Automation.Core.Selenium.APIHandler;
using Automation.Core.Selenium.Base;
using Automation.Core.Selenium.HelperClass;
using Automation.Core.Selenium.WebDriver;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using BoDi;
using log4net;
using log4net.Config;
using NUnit.Framework.Internal;
using TechTalk.SpecFlow;
using UIAutomation.Integration.Tests.StepDefinitions;
using ExtentReports = AventStack.ExtentReports.ExtentReports;

namespace Integration.UIAutomation.Tests.Hooks
{
    [Binding]
    public class ScenarioHooks : BasePage
    {
        private static TestInitialiseHook testInitialiseHook = new TestInitialiseHook();
        //private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly ILog _logger = LogManager.GetLogger(typeof(ScenarioHooks));
        private static ExtentTest _scenario;
        private static FeatureContext _featureContext;
        private static ScenarioContext _scenarioContext;
        private static ExtentHtmlReporter _extentHtmlReporter;

        private static ExtentTest _featureName;
        private static ExtentReports _extentReports;

        public ScenarioHooks(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void CreateLogFile()
        {
            LogHelper.CreateLogFile();
        }

        [BeforeScenario]
        public void OutputScenario(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            LogHelper.Info(" " + "--------[BeforeScenario]---------");
            LogHelper.Info(" " + $"Feature: {featureContext.FeatureInfo.Title}");
            LogHelper.Info(" " + $"Scenario: {scenarioContext.ScenarioInfo.Title}");

        }

        /// <summary>
        /// Initializes the test report
        /// </summary>
        [BeforeTestRun]
        public static void InitialiseReport()
        {
            _extentHtmlReporter = new ExtentHtmlReporter(@"/circleci/UIAutomation.Integration.Tests/TestResults/Report.html");
            _extentHtmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(_extentHtmlReporter);
        }

        /// <summary>
        /// Flush report once test completes
        /// </summary>
        [AfterTestRun]
        public static void TearDownReport()
        {
            _extentReports.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeatureStarts(FeatureContext featureContext)
        {
            if (null != featureContext)
            {
                _featureName = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title, featureContext.FeatureInfo.Description);
            }
        }

        [BeforeScenario]
        public static void BeforeScenario(ScenarioContext scenarioContext)
        {
            if (null != scenarioContext)
            {
                _scenarioContext = scenarioContext;
                _scenario = _featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title, scenarioContext.ScenarioInfo.Description);
            }
           
        }

        [AfterStep]
        public void AfterEachStep()
        {
            ScenarioBlock scenarioBlock = _scenarioContext.CurrentScenarioBlock;
            switch (scenarioBlock)
            {
                case ScenarioBlock.Given:
                    CreateNode<Given>();
                    break;
                case ScenarioBlock.When:
                    CreateNode<When>();
                    break;
                case ScenarioBlock.Then:
                    CreateNode<Then>();
                    break;
                default:
                    CreateNode<And>();
                    break;
            }
        }

        [BeforeTestRun]
        public static void Initialise()
        {
            testInitialiseHook.InitialiseSettings();
        }

        [BeforeScenario(@"regression")]
        public void OpenBrowser()
        {
            
            BrowserHooks.OpenBrowser(Browser.BrowserType.ChromeHeadless);
            LogHelper.Info(" " + "Browser opened");
        }

        public void CreateNode<T>() where T : IGherkinFormatterModel
        {
            if (_scenarioContext.TestError != null)
            {
                string name = @"/circleci/UIAutomation.Integration.Tests/TestResults" + _scenarioContext.ScenarioInfo.Title.Replace(" ", "") +
                             ".png";
                GenericHelper.TakeScreenShot(name);
                _scenario.CreateNode<T>(_scenarioContext.StepContext.StepInfo.Text).Fail(
                    _scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.StackTrace).AddScreenCaptureFromPath(name);
            }
            else if (_scenarioContext.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
            {
                _scenario.CreateNode<T>(_scenarioContext.StepContext.StepInfo.Text)
                    .Skip("Step Definition Pending");
            }
            else
            {
                _scenario.CreateNode<T>(_scenarioContext.StepContext.StepInfo.Text).Pass("");
            }
        }

        [AfterScenario(@"regression")]
        public static void KillWebdriver(ScenarioContext scenarioContext)
        {
            LogHelper.Info("[AfterScenario] killing driver");
            if (_scenarioContext.TestError != null)
            { 
                string name = _scenarioContext.ScenarioInfo.Title.Replace(" ", "") + ".png";
               GenericHelper.TakeScreenShot(name);
               LogHelper.Error(_scenarioContext.TestError.Message);
               //LogOut();
            }
        }

        private static void LogOut()
        {
            HomePageSteps.WhenIClickTheProfileAndLogoutFromTheSite();
        }

        [AfterScenario(@"regression")]
        public void CloseBrowser()
        {
            //LogOut();
            Thread.Sleep(5000);
            DriverContext.WebDriver.Quit();
        }
    }
}
