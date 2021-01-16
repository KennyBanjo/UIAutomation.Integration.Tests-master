using Newtonsoft.Json;


namespace Automation.Core.Selenium.Config
{
    [JsonObject("testSettings")]
    public class TestSettings
    {
        [JsonProperty("Url")]
        public string Url { get; set; }

        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("ApiUrl")]
        public string ApiUrl { get; set; }
    }
}
