Feature: Login
	In order to test the login functionality of the site
	I will try and log in as administrator

Scenario: Login as admin to MvcStore
	Given I have filled out all required information
	When I press Log In
	Then I should be redirected to the full list of record entries

Scenario: Failed Login as admin to MvcStore 
	Given I have filled out all required information incorrectly
	When I press Log In
	Then I should be shown a message to show login was unsuccessful
