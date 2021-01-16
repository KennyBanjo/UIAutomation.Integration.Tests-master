using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Automation.Core.Selenium.Config;
using Automation.Core.Selenium.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SeleniumExtras.PageObjects;

namespace Automation.Core.Selenium.Base
{
    public class BaseClass
    {
        private IWebDriver _driver;
    
        public BasePage  CurrentPage { get; set; }

        protected TPage GetInstance<TPage>() where TPage : BasePage, new()
        {
            TPage PageInstance = new TPage();
            {
                _driver = DriverContext.WebDriver;
            }
            PageFactory.InitElements(DriverContext.WebDriver, PageInstance);
            return PageInstance;
        }

        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage) this;
        }
    }
}
