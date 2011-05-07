Feature: Store Browsing By Genre
	In order to test that the genre album lists renders correctly
	I want to c heck that the page has a number of albums on it

Scenario: Browsing By Genre
	Given I Go To the home page
	When I click the following link
		|Value|
		|Rock|
	Then the album results should be displayed on the screen

	
