using System;
using System.IO;
using Automation.Core.Selenium.Config;
using TechTalk.SpecFlow;

namespace Automation.Core.Selenium.HelperClass
{
    [Binding]
    public class LogHelper
    {
        //Global Declaration
        //private static string _logFileName = string.Format("{0:yyyymmddhhmmss}", DateTime.Now);
        private static string _logFileName = "logFile";
        private static StreamWriter _stream = null;


        //Create a file which can store the log informamtion
        
        public static void CreateLogFile()
        {
            string dir = @"/circleci/UIAutomation.Integration.Tests/TestResults/";
            if (Directory.Exists(dir))
            {
                Settings.FileCreated = true;
                _stream = File.AppendText(dir + _logFileName + ".log");
            }
            else
            {
                Settings.FileCreated = true;
                Directory.CreateDirectory(dir);
                _stream = File.AppendText(dir + _logFileName + ".log");
            }
        }

        //Create a methods to write test to the log file
        public static void Info(string logMessage)
        {
            _stream.Write("INFO {0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            _stream.WriteLine("{0}", logMessage);
            _stream.Flush();
        }

        
        public static void Error(string logMessage)
        {
            _stream.Write("ERROR {0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            _stream.WriteLine("{0}", logMessage);
            _stream.Flush();
        }

        public static void Warn(string logMessage)
        {
            _stream.Write("WARN {0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            _stream.WriteLine("{0}", logMessage);
            _stream.Flush();
        }

    }
}
