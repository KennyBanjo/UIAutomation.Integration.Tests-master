using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Core.Selenium.Base;
using Automation.Core.Selenium.WebDriver.WebDriver.WebElementObjects.Attributes;
using Automation.Core.Selenium.WebDriver.WebElementObjects;
using OpenQA.Selenium;

namespace Automation.Core.Selenium.PageObject
{
    public class PageObjectBase
    {
        public PageObjectBase(IWebDriver driver, bool useWaitForAjax = true)
        {
            this.Driver = driver;
            this.InitialiseFields();
            this.WaitForAjax = useWaitForAjax;
        }

        public IWebDriver Driver { get; set; }
        public bool WaitForAjax { get; set; }
        protected string PageUrl { get; set; }

        public string BaseUrl;


        private void InitialiseFields()
        {
            var fields = this.GetType().GetFields();
            foreach (var field in fields)
            {
                var webElementLocatorAttribute =
                    FieldAttributeHelper<WebElementLocatorAttribute>.ReturnAttribute(field);
                var dataBindingAttribute = FieldAttributeHelper<DataBindingAttribute>.ReturnAttribute(field);
                var viewModelBindingAttribute = FieldAttributeHelper<ViewModelBindingAttribute>.ReturnAttribute(field);

                if (webElementLocatorAttribute.Count < 0) continue;

                var constructor = field.FieldType.GetConstructor(new Type[] { });
                var instance = constructor?.Invoke(new object[] { });
                if (instance is WebElementObjectBase)
                {
                    var controlBase = instance as WebElementObjectBase;
                    controlBase.ByLocator = webElementLocatorAttribute[0].ByLocator;
                    controlBase.Locator = webElementLocatorAttribute[0].Locator;
                    controlBase.Driver= this.Driver;
                    controlBase.UseWaitAjax = this.WaitForAjax;
                    controlBase.Url = this.BaseUrl +this.PageUrl;
                    controlBase.BindedDataAttribute =
                        dataBindingAttribute.Count <= 0 ? null : dataBindingAttribute[0].Value;
                    controlBase.ViewModelBinding =
                        viewModelBindingAttribute.Count <= 0 ? null : viewModelBindingAttribute[0].Value;
                }
                field.SetValue(this,instance);
            }
        }

    }
}
