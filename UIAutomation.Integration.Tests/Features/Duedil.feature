Feature: DueDil
	User can perform business lookup


@regression @StandardDB @TEST_QAR-7812 @sanity
Scenario: Perform business lookup with DueDil
	Given I have navigated to the application url
	When I login as system administrator
	Then I should be on the homepage
	When I click on the 'Relationships' tab
	And  I search for '(EQUUK) IMAGINATION TECHNOLOGIES LIMITED' in the 'Account-search-input' textfield
	Then I should see '(EQUUK) IMAGINATION TECHNOLOGIES LIMITED'
	When I click on '(EQUUK) IMAGINATION TECHNOLOGIES LIMITED'
	And  I click on the 'Business Lookup' tab
	And  I click the 'providerSelect' dropdown
	And  I select 'DueDil (UK)' from the dropdown list
	And I search for 'ncino global' in the 'company-name' textfield
	And I click on the 'save-button' button
	When I click the 'Ncino Global Ltd' radio button
	And I click on the business look-up 'Continue' button
	Then the modal 'Save Business' should be displayed
	And the heading should be 'Ncino Global Ltd'
	Then I should see the following information
	| CompanyId | CompanyAddress                                                       | TypeDescription					| VerifyAddress                                                      |
	| 10718055  | Floor 11, Whitefriars Lewins Mead, Bristol, BS1 2NT				   | Private limited with share capital | Floor 11, Whitefriars Lewins Mead, Bristol, BS1 2NT				  |
	When I click the search result save button
	Then the billing address changes to 'Floor 11, Whitefriars Lewins Mead Bristol, Avon BS1 2NT'