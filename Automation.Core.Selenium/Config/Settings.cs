using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Core.Selenium.Config
{
    public static class Settings
    {
        public static string Url { get; set; }
        public static string  Username { get; set; }
        public static string Password  { get; set; }
        public static string ApiUrl { get; set; }
        public static bool _fileCreated = false;
        public static bool FileCreated
        {
            get
            {
                return _fileCreated;
            }
            set
            {
                _fileCreated = value;
            }
        }
    }
}
