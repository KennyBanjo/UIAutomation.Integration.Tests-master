using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Core.Selenium.APIHandler.JsonAccounts;

namespace Automation.Core.Selenium.APIHandler.JsonAccounts
{
    public class Attributes
    {
        public string type { get; set; }
        public string referenceId { get; set; }

        public  static string
            AccountCredentials = @"{
	""records"": [
		{
			""attributes"": {
				""type"": ""Account"",
				""referenceId"": ""ref1""
			},
			""Name"": ""(EQUUK) IMAGINATION TECHNOLOGIES LIMITED"",
			""Company_Number__c"": ""01306335""
		}, 
		{
			""attributes"": {
				""type"": ""Account"",
				""referenceId"": ""ref2""
			},
			""Name"": ""(EQUUK) PAXTON ACCESS LIMITED"",
			""Company_Number__c"": """"
		}, 
		{
			""attributes"": {
				""type"": ""Account"",
				""referenceId"": ""ref3""
			},
			""Name"": ""(EQUUK) VERENAISI HAYTER"",
			""Type"": ""Individual"", 
			""Contacts"": {
				""records"": [
					{
						""attributes"": {
							""type"": ""Contact"",
							""referenceId"": ""ref4""
						},
						""FirstName"": ""VERENAISI"",
						""LastName"": ""HAYTER"",
						""Birthdate"": ""1979-03-28"",
						""MailingStreet"": ""143 DOWNHAM ROAD"", 
						""Mailingcity"": ""ELY"", 
						""MailingPostalCode"": ""CB6 1AF"", 
						""LLC_BI__Primary_Contact__c"": true
					}
				]
			}
		}
	]
}";

       

    }

    public class Roots
    {
        public Attributes attributes { get; set; }
        public string Name { get; set; }
    }

}

