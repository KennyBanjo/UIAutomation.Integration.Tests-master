using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Core.Selenium.APIHandler.Model
{
    public class Result
    {
        public string referenceId { get; set; }
        public string id { get; set; }
        //public  List<Result> results { get; set; }
    }

    public class Root
    {
        public bool hasErrors { get; set; }
        public List<Result> results { get; set; }
        
        
    }
}
