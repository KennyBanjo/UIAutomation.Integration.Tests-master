using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Core.Selenium.WebDriver.WebElementObjects;
using Automation.Core.Selenium.WebDriver.WebElementObjects.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Automation.Core.Selenium.WebDriver.WebDriver.WebElementObjects.WebElements
{
    public class ButtonDropDown: WebElementObjectBase, IDropDown, IWebElementObject
    {
        private const string ButtonLocator = "[type = 'button']";
        public void Select(string ItemToSelect)
        {
            //Wait for it to drop down
            WaitForElement(ByLocator);
            //find and click on the required item
            var dropdownItem = GetElement().FindElement(ByLocator);
            dropdownItem.Click();
        }

        public IList<IWebElement> ReturnAllOptions()
        {
            GetElement();
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElements(By.CssSelector("li")).Count > 0);
            return GetElement().FindElements(By.CssSelector("li"));
        }

        public string ReturnSelectedItem()
        {
            var selectedItems = GetElement().FindElement(ByLocator).Text;
            return selectedItems;
        }
    }
}
