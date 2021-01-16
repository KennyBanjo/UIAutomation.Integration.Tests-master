Feature: ExperianUK
	Activate and deactivate experian plug-in configuration

@regression @TEST_QAR-7809 @sanity
Scenario: User can activate experian plug-in configuration
	Given I have navigated to the application url
	When I login as system administrator
	Then I should be on the homepage
	When I click the 'appLauncher' button
	And I search for 'ncino administration' in the 'Search apps and items...' textfield
	Then I should see the 'Quick Links' tab
	When I click on the 'Quick Links' button
	And I click the configure button under system configuration row '2' column '2'
	When I click the 'nCino Experian (UK)' plug-in checkbox to activate
	And I wait '5000' ms
	Then the 'nCino Experian (UK)' plug-in checkbox should be selected
	When I click the 'nCino Experian (UK)' plug-in checkbox to deactivate 
	Then the 'nCino Experian (UK)' plug-in checkbox should be de-selected

# @regression @StandardDB @QAR-7803
# Scenario: Run Experian business Credit Verification
# 	Given I have navigated to the application url
# 	When I login as system administrator
# 	Then I should be on the homepage
# 	When I click on the 'Relationships' tab
# 	And I search for '(EXUK) IMAGINATION TECHNOLOGIES LIMITED' in the 'Account-search-input' textfield
# 	Then I should see '(EXUK) IMAGINATION TECHNOLOGIES LIMITED'
# 	When I click on '(EXUK) IMAGINATION TECHNOLOGIES LIMITED'
# 	And I click on the 'Run Verifications' button
# 	Then I should see 'Business EQUUK Credit' under report
# 	When I click the checkbox
# 	And I click on the 'runSelectedReports()' button
# 	Then the status should read 'IN FILE' or 'NEEDS REVIEW' or 'PASS'
# 	And the report date should equal today's date
# 	And the 'ACTIONS' column should display 'View Report'

# @regression @StandardDB @QAR-7804	
# Scenario: Run Experian Individual credit verification
# 	Given I have navigated to the application url
# 	When I login as system administrator
# 	Then I should be on the homepage
# 	When I click on the 'Relationships' tab
# 	And I search for '(EXUK) VERENAISI HAYTER' in the 'Account-search-input' textfield
# 	Then I should see '(EXUK) VERENAISI HAYTER'
# 	When I click on '(EXUK) VERENAISI HAYTER'
# 	And I click on the 'Run Verifications' button
# 	Then I should see 'Soft EQUUK Credit' under report
# 	Then the status should display 'OPEN'
# 	When I click the checkbox
# 	And I click on the 'runSelectedReports()' button
# 	Then the status should display 'PASS'
# 	And the report date should equal today's date
# 	And the 'ACTIONS' column should display 'View Report'