using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Automation.Core.Selenium.APIHandler.JsonAccounts;
using Automation.Core.Selenium.APIHandler.Model;
using Automation.Core.Selenium.Base;
using Automation.Core.Selenium.Config;
using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Automation.Core.Selenium.APIHandler
{
    public class DataLoader
    {
        private static readonly ILog logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    
        private static List<string> id;

        public static void LoadData()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                {"Accept", "Application/json"},
                {"Content-Type", "Application/json"}
            };
            RestClientHelper restClientHelper = new RestClientHelper();
            var response = restClientHelper.PerformPostRequest(Settings.ApiUrl, headers, null,
                DataFormat.Json, Attributes.AccountCredentials);
            if (response.IsSuccessful)
            {
                Console.WriteLine("Post status code => " + response.StatusCode);
                Console.WriteLine("Post content => " + response.Content);
                //logger.Info("Call successful");
                JObject jObject = JObject.Parse(response.Content);
                var list = jObject.SelectTokens("$..id").Select(t => t.Value<string>()).ToList();
                id = list;
            }
            else
            {
                Console.WriteLine("Call failed" + " " + response.StatusCode);
                Console.WriteLine("Job content" + " " + response.Content);
                logger.Error("Call not made");
            }
        }

        public static void DeleteData()
        {
            RestClientHelper restClientHelper = new RestClientHelper();
            var client = new RestClient($"https://emeaqa.my.salesforce.com/services/data/v50.0/tooling/executeAnonymous?anonymousBody=QaUtility.deleteAccounts(new List<Id>{{'{id[0]}', '{id[1]}','{id[2]}'}});");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", restClientHelper.bearer_token);
            //request.AddHeader("Cookie", "BrowserId=NFK9nB9ZEeuEzAcLDJa4FQ");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            Console.WriteLine(response.StatusCode);
        }

        public static void DeletePortalApplications()
        {
            RestClientHelper restClientHelper = new RestClientHelper();
            var client = new RestClient("https://emeaqa.my.salesforce.com/services/data/v50.0/tooling/executeAnonymous?anonymousBody=QaUtility.clearPortalApplications(new List<Id>{'0054K000002GtsC'});");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", restClientHelper.bearer_token);
            //request.AddHeader("Cookie", "BrowserId=NFK9nB9ZEeuEzAcLDJa4FQ");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            Console.WriteLine(response.StatusCode);
        }
    }
}
