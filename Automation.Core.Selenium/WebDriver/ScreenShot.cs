using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Automation.Core.Selenium.Base;
using log4net;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Tracing;

namespace Automation.Core.Selenium.WebDriver
{
    public class ScreenShot
    {
        private static readonly ILog
            _logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static  ScenarioContext _scenarioContext;

        public  ScreenShot(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public static void TakeScreenShot(IWebDriver driver)
        {
            try
            {
                var fileNameBase = string.Format("error_{0}_{1}", _scenarioContext.ScenarioInfo.Title.ToIdentifier(),
                    DateTime.Now.ToString("yy-MMM-dd ddd"));
                var artifactDirectory = Path.Combine(GetCurrentExecutingDirectory(), "testresults");

                if (!Directory.Exists(artifactDirectory))
                {
                    Directory.CreateDirectory(artifactDirectory);
                }

                var pageSource = driver.PageSource;
                var sourceFilePath = Path.Combine(artifactDirectory, fileNameBase + "_source.html");
                File.WriteAllText(sourceFilePath,pageSource, Encoding.UTF8);

                Console.WriteLine("Page source: {0}", new Uri(sourceFilePath));
                _logger.InfoFormat("Page source {0}", new Uri(sourceFilePath));

                var takeScreenShot = driver as ITakesScreenshot;
                if (takeScreenShot != null)
                {
                    var screenShot = takeScreenShot.GetScreenshot();
                    var screenShotFilePath = Path.Combine(artifactDirectory, fileNameBase + "_screenshot.png");
                    screenShot.SaveAsFile(screenShotFilePath, ScreenshotImageFormat.Png);

                    Console.WriteLine("Screenshot: {0}", new Uri(screenShotFilePath));
                    _logger.InfoFormat("ScreenShot: {0}", new Uri(screenShotFilePath));

                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }

        public static string GetCurrentExecutingDirectory()
        {
            string filePath = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            return Path.GetDirectoryName(filePath);
        }
    }
}
