using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Automation.Core.Selenium.APIHandler.JsonAccounts;
using Automation.Core.Selenium.APIHandler.Model;
using Integration.UIAutomation.Tests.TableEntities;
using log4net;
using Newtonsoft.Json;
using RestSharp;

namespace Automation.Core.Selenium.APIHandler
{
    public class RestClientHelper
    {
        private static readonly ILog logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public string bearer_token;
        private string postToken = "https://login.salesforce.com/services/oauth2/token?";
        private string postUrl = "https://emeaqa.my.salesforce.com/services/data/v50.0/composite/tree/Account/";

        public RestClientHelper()
        {
            GetToken();
        }
        private IRestClient GetRestClient()
        {
            IRestClient restClient = new RestClient();
            return restClient;
        }

        public IRestRequest GetRestRequest(string url, Dictionary<string, string> headers, Method method, object body,
            DataFormat dataformat, string param)
        {
            IRestRequest restRequest = new RestRequest()
            {
                Method = method,
                Resource = url
            };

            if (headers != null)
            {
                foreach (var key in headers.Keys)
                {
                    restRequest.AddHeader(key, headers[key]);
                    restRequest.AddHeader("Authorization", bearer_token);
                }
            }
            else
            {
                restRequest.AddHeader("Authorization", bearer_token);
            }

            if (method == Method.POST || method == Method.PUT || method == Method.DELETE)
            {
                restRequest.AddParameter("application/json", $"{param}", ParameterType.RequestBody);
            }

            if (body != null)
            {
                restRequest.RequestFormat = dataformat;
                restRequest.AddBody(body);
            }

            return restRequest;
        }

        private IRestResponse SendRequest(IRestRequest restRequest)
        {
            IRestClient restClient = new RestClient();
            IRestResponse restResponse = restClient.Execute(restRequest);
            return restResponse;
        }

        private IRestResponse<T> SendRequest<T>(IRestRequest restRequest) where T : new()
        {
            IRestClient restClient = new RestClient();
            IRestResponse<T> restResponse = restClient.Execute<T>(restRequest);
            return restResponse;
        }

        public IRestResponse PerformGetRequest(string url, Dictionary<string, string> headers)
        {
            IRestRequest restRequest = GetRestRequest(url, headers, Method.GET, null, DataFormat.None, null);
            IRestResponse restResponse = SendRequest(restRequest);
            return restResponse;
        }

        public IRestResponse<T> PerformGetRequest<T>(string url, Dictionary<string, string> headers) where T : new()
        {
            IRestRequest restRequest = GetRestRequest(url, headers, Method.GET, null, DataFormat.None, null);
            IRestResponse<T> restResponse = SendRequest<T>(restRequest);
            return restResponse;
        }

        public IRestResponse PerformPostRequest(string url, Dictionary<string, string> headers, object body, DataFormat dataFormat, string param)
        {
            IRestRequest restRequest =  GetRestRequest(url, headers, Method.POST, body, dataFormat, param);
            IRestResponse restResponse = SendRequest(restRequest);
            return restResponse;
        }

        public IRestResponse<T> PerformPostRequest<T>(string url, Dictionary<string, string> headers, object body,
            DataFormat dataFormat, string param) where T : new()
        {
            IRestRequest restRequest = GetRestRequest(url, headers, Method.POST, body, dataFormat, param);
            IRestResponse<T> restResponse = SendRequest<T>(restRequest);
            return restResponse;
        }

        public IRestResponse PerformPutRequest(string url, Dictionary<string, string> headers, object body,
            DataFormat dataFormat, string param)
        {
            IRestRequest restRequest = GetRestRequest(url, headers, Method.PUT, body, dataFormat, param);
            IRestResponse restResponse = SendRequest(restRequest);
            return restResponse;
        }

        public IRestResponse<T> PerformPutRequest<T>(string url, Dictionary<string, string> headers, object body,
            DataFormat dataFormat, string param) where T : new()
        {
            IRestRequest restRequest = GetRestRequest(url, headers, Method.PUT, body, dataFormat, param);
            IRestResponse<T> restResponse = SendRequest<T>(restRequest);
            return restResponse;
        }

        public IRestResponse PerformDeleteRequest(string url, string param)
        {
            IRestRequest restRequest = GetRestRequest(url, null, Method.DELETE, null, DataFormat.None, param);
            IRestResponse restResponse = SendRequest(restRequest);
            return restResponse;
        }

        public void GetToken()
        {
            var client = new RestClient(postToken);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddParameter("grant_type", "password");
            request.AddParameter("username", "admin@emea.int");
            request.AddParameter("password", "87VPDpE8F8ag");
            request.AddParameter("client_id",
                "3MVG9sh10GGnD4DvifPk9RHCjYdpewgaSDIqZBqM4tQrpwb1oSn0xGf56kiskPG0q2_ly_KIIxEn09GGAukYi");
            request.AddParameter("client_secret", "6D4293569E4876AF94F874595B5F98EF8BBAC070C04E00A4F6FF5BE5577F9093");
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                logger.Info(response.ContentType);
                logger.Info(response.StatusCode);
                logger.Info(response.Content);
                bearer_token = "Bearer" + " " + JsonConvert.DeserializeObject<TokenResponse>(response.Content).access_token;
            }
        }

       

        //public Attributes UserModel()
        //{
        //    Attributes attribute = new Attributes();
        //    attribute.type = "Account";
        //    attribute.referenceId = "AccountRef20";
        //}
    }
}
