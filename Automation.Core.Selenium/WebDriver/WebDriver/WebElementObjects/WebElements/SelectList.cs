using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Core.Selenium.WebDriver.WebElementObjects;
using Automation.Core.Selenium.WebDriver.WebElementObjects.Interfaces;
using OpenQA.Selenium;

namespace Automation.Core.Selenium.WebDriver.WebDriver.WebElementObjects.WebElements
{
    public class SelectList:WebElementObjectBase, IDropDown
    {
        public void Select(string ItemToSelect)
        {
            Driver.WaitForAjax();
            //GetElement().FindElement(By.CssSelector("")).First(x => x.Text == ItemToSelect).Click();
        }

        public IList<IWebElement> ReturnAllOptions()
        {
            throw new NotImplementedException();
        }

        public string ReturnSelectedItem()
        {
            throw new NotImplementedException();
        }
    }
}
