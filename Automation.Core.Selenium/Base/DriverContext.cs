﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Automation.Core.Selenium.Base
{
    public class DriverContext
    {
        //This driver is to be used globally
        private static IWebDriver _driver;

        public static IWebDriver WebDriver { get; set; }
        public static IWebDriver Driver { get; set; }

        public static Browser Browser { get; set; }

    }
}
