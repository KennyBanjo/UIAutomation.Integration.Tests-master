Feature: CompaniesHouse
	User can perform business lookup

@regression @StandardDB @TEST_QAR-7812 @sanity
Scenario: Perform business lookup on Companies House
	Given I have navigated to the application url
	When I login as system administrator
	Then I should be on the homepage
	When I click on the 'Relationships' tab
	And  I search for '(EQUUK) IMAGINATION TECHNOLOGIES LIMITED' in the 'Account-search-input' textfield
	Then I should see '(EQUUK) IMAGINATION TECHNOLOGIES LIMITED'
	When I click on '(EQUUK) IMAGINATION TECHNOLOGIES LIMITED'
	And  I click on the 'Business Lookup' tab
	And  I click the 'providerSelect' dropdown
	And  I select 'Companies House (GOV UK)' from the dropdown list
	And I search for 'ncino global' in the 'company-name' textfield
	And I click on the 'save-button' button
	When I click the 'NCINO GLOBAL LTD' radio button
	And I click on the business look-up 'Continue' button
	Then the modal 'Save Business' should be displayed
	And the heading should be 'NCINO GLOBAL LTD'
	Then I should see the following information
	| CompanyId | CompanyAddress                                                       | TypeDescription         | VerifyAddress                                                      |
	| 10718055  | Floor 11,  Whitefriars Lewins Mead, Bristol, United Kingdom, BS1 2NT | Private limited company | Floor 11, Whitefriars Lewins Mead, Bristol, United Kingdom, BS1 2NT |
	When I click the search result save button
	Then the relationship name should be changed to 'NCINO GLOBAL LTD'

@regression @StandardDB 
Scenario: Perform business lookup by ID on Companies House
	Given I have navigated to the application url
	When I login as system administrator
	Then I should be on the homepage
	When I click on the 'Relationships' tab
	And  I search for '(EQUUK) IMAGINATION TECHNOLOGIES LIMITED' in the 'Account-search-input' textfield
	Then I should see '(EQUUK) IMAGINATION TECHNOLOGIES LIMITED'
	When I click on '(EQUUK) IMAGINATION TECHNOLOGIES LIMITED'
	And  I click on the 'Business Lookup' tab
	And  I click the 'providerSelect' dropdown
	And  I select 'Companies House (GOV UK)' from the dropdown list
	And I search for 'OC434012' in the 'company-name' textfield
	And I click on the 'save-button' button
	When I click the 'ECCENTRIC INVESTMENTS LLP' radio button
	And I click on the business look-up 'Continue' button
	Then the modal 'Save Business' should be displayed
	And the heading should now be 'ECCENTRIC INVESTMENTS LLP'
	Then I should see the following information
	| CompanyId | CompanyAddress                                                                   | TypeDescription               | VerifyAddress                                                                    |
	| OC434012  | First Floor Winston House, 349 Regents Park Road, London, United Kingdom, N3 1DH | Limited liability partnership | First Floor Winston House, 349 Regents Park Road, London, United Kingdom, N3 1DH |
	When I click the search result save button
	Then the relationship name should now be changed to 'ECCENTRIC INVESTMENTS LLP'

@regression @PortalDB @TEST_QAR-7806
Scenario: Perform portal business lookup on companies house
	Given I have navigated to the application url
	When I login as system administrator
	Then I should be on the homepage
	When I click on the 'Contacts' tab
	And  I search for 'Alissa Quigley' in the 'Contact-search-input' textfield
	Then I should see 'Alissa Quigley'
	When I click on the 'Alissa Quigley' label
	And I click on the 'LoginToNetworkAsUser' button
	#And I wait '10000' ms
	And I click on the 'Marketplace' button
	And I click the CBILS Apply button
	Then I should see the eligibility page
	When I enter the loan amount as '10000'
	And I enter the loan purpose as 'Business'
	And I click the next button
	Then I should see the 'Your Business' search page
	#When I wait '10000' ms
	When I click the CBILS Add New button
	And I enter 'Paxton Access Ltd' in the company search field
	And I select Paxton Access Limited
	Then I should see the following fields
	| Relationship Name         | Billing Street					     | Billing City		   | Postal Code |
	| PAXTON ACCESS LIMITED		| Paxton House, Home Farm Road, Brighton | East Sussex         | BN1 9HU     |
	When I click the next button
	Then I should see 'Tell us about your business'
	Then the application should carry over the following fields
    | Legal Business Name       | Billing Street                         | Billing City        | Postal Code |
    | PAXTON ACCESS LIMITED	    | Paxton House, Home Farm Road, Brighton | East Sussex   	   | BN1 9HU       |


@regression @PortalDB @TEST_QAR-7806
Scenario: Perform portal ID business lookup on companies house
	Given I have navigated to the application url
	When I login as system administrator
	Then I should be on the homepage
	When I click on the 'Contacts' tab
	And  I search for 'Alissa Quigley' in the 'Contact-search-input' textfield
	Then I should see 'Alissa Quigley'
	When I click on the 'Alissa Quigley' label
	And I click on the 'LoginToNetworkAsUser' button
	#And I wait '10000' ms
	And I click on the 'Marketplace' button
	And I click the CBILS Apply button
	Then I should see the eligibility page
	When I enter the loan amount as '10000'
	And I enter the loan purpose as 'Business'
	And I click the next button
	Then I should see the 'Your Business' search page
	When I click the CBILS Add New button
	When I enter 'OC434012' in the company search field
	And I select Eccentric investment LLP
	Then I should see the following fields
	| Relationship Name         | Billing Street					    		  | Billing City		  | Postal Code |
	| ECCENTRIC INVESTMENTS LLP	|First Floor Winston House, 349 Regents Park Road | London         		  | N3 1DH      |
	When I click the next button
	Then I should see 'Tell us about your business'
	Then the application should carry over the following fields
    | Legal Business Name       | Billing Street                                   | Billing City | Postal Code  |
    | ECCENTRIC INVESTMENTS LLP | First Floor Winston House, 349 Regents Park Road | London  	   | N3 1DH      |
