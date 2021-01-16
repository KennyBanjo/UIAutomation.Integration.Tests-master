@QAR-7811
Feature: EquifaxUK
	User should be able to run a full credit report to make a decision on a customer

@regression @StandardDB @TEST_QAR-7807 @sanity
Scenario: Run Business credit verification
	Given I have navigated to the application url
	When I login as system administrator
	Then I should be on the homepage
	When I click on the 'Relationships' tab
	And I search for '(EQUUK) IMAGINATION TECHNOLOGIES LIMITED' in the 'Account-search-input' textfield
	Then I should see '(EQUUK) IMAGINATION TECHNOLOGIES LIMITED'
	When I click on '(EQUUK) IMAGINATION TECHNOLOGIES LIMITED'
	And I click on the 'Run Verifications' button
	Then I should see 'Business EQUUK Credit' under report
	When I click the checkbox
	And I click on the 'runSelectedReports()' button
	Then the status should read 'IN FILE' or 'NEEDS REVIEW' or 'PASS'
	And the report date should equal today's date
	And the 'ACTIONS' column should display 'View Report'
	
@regression @StandardDB @TEST_QAR-7808
Scenario: Run Individual credit verification
	Given I have navigated to the application url
	When I login as system administrator
	Then I should be on the homepage
	When I click on the 'Relationships' tab
	And I search for '(EQUUK) VERENAISI HAYTER' in the 'Account-search-input' textfield
	Then I should see '(EQUUK) VERENAISI HAYTER'
	When I click on '(EQUUK) VERENAISI HAYTER'
	And I click on the 'Run Verifications' button
	Then I should see 'Soft EQUUK Credit' under report
	Then the status should display 'OPEN'
	When I click the checkbox
	And I click on the 'runSelectedReports()' button
	Then the status should display 'PASS'
	And the report date should equal today's date
	And the 'ACTIONS' column should display 'View Report'

@regression @StandardDB @TEST_QAR-7807
Scenario: Run verification without CompanyId
	Given I have navigated to the application url
	When I login as system administrator
	Then I should be on the homepage
	When I click on the 'Relationships' tab
	And I search for '(EQUUK) PAXTON ACCESS LIMITED' in the 'Account-search-input' textfield
	Then I should see '(EQUUK) PAXTON ACCESS LIMITED'
	When I click on '(EQUUK) PAXTON ACCESS LIMITED'
	And I click on the 'Run Verifications' button
	Then I should see 'Business EQUUK Credit' under report
	When I click the checkbox
	And I click on the 'runSelectedReports()' button
	And I wait '5000' ms
	Then the report date should equal today's date
	Then the status should display 'ERROR'
	Then An 'ERROR : Business EQUUK Credit' should appear with the message 'A company registration number has not been supplied'