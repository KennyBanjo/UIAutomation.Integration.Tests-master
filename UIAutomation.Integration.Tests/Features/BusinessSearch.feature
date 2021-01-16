Feature: BusinessSearch
	This tests the SIOC functionality of the Australian business search feature. 

@regression
Scenario: Search for a business.
	Given I navigate to the self registration portal
	When I enter the following details
	| FirstName | LastName    | Email                   | Mobile      |
	| Didier		| Drogba		  | didydrogie@gmail.com    | 07956827903 |
	And I click the continue button
	Then I should see the eligibility page
	
	When I enter the loan amount as '10000'
	And I enter the loan purpose as 'Business'
	And I click the next button
	Then I should see the ABR search page

	When I enter 'ncino' in the company name field
	And I select NCINO APAC PTY LTD
	Then the following fields should be populated
	| EntityName         | EntityType                 | BusinessLocationState | ABN         | ASICRegistration | BusinessPostcode |
	| NCINO APAC PTY LTD | Australian Private Company | NSW                   | 42622945493 | 622945493        | 2060             |