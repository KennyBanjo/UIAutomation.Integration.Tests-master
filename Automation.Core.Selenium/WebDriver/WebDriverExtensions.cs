using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ILog = log4net.ILog;

namespace Automation.Core.Selenium.WebDriver
{
    public static class WebDriverExtensions
    {
        private static readonly ILog
            _logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void WaitForAjax(this IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var jsExecutor = driver as IJavaScriptExecutor;
            wait.Until(d =>
                (bool) jsExecutor.ExecuteScript("return (jQuery != 'undefined') ? jQuery.active == 0)" + ""));
        }
    }
}
