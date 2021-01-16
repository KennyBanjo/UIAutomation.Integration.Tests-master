Feature: Onfido
	Activate and deactivate plug-in configuration

@regression @TEST_QAR-7813 @sanity
Scenario: User can activate nfido plug-in configuration
	Given I have navigated to the application url
	When I login as system administrator
	Then I should be on the homepage
	When I click the 'appLauncher' button
	And I search for 'ncino administration' in the 'Search apps and items...' textfield
	Then I should see the 'Quick Links' tab
	When I click on the 'Quick Links' button
	And I click the configure button under system configuration row '2' column '2'
	When I click the 'nCino Onfido (Global)' plug-in checkbox to activate
	And I wait '5000' ms
	Then the 'nCino Onfido (Global)' plug-in checkbox should be selected
	When I click the 'nCino Onfido (Global)' plug-in checkbox to deactivate 
	Then the 'nCino Onfido (Global)' plug-in checkbox should be de-selected
