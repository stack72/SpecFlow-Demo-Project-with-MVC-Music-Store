Feature: Registration Scenarios
	In order to test that the site registration is working

	
Scenario: Successful registration
	Given I have gone to the login page
	When I click on the Register link
		And I enter some correct user details
	Then I will be successfully registered

Scenario: Unsuccessful registration due to password length
	Given I have gone to the login page
	When I click on the Register link
		And I enter user details with a password thats too short
	Then I will not have been able to register due to password being too short

Scenario: Unsuccessful registration due to password complexity
	Given I have gone to the login page
	When I click on the Register link
		And I enter user details with a password thats not complex enough
	Then I will not have been able to register due to wrong password value 
