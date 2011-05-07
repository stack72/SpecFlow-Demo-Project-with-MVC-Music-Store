Feature: HomePage Loading All Required Parts
	I want to check for the existence of these panels on the page

Scenario: Fresh Off The Grill
	Given I go directly to the home page
	Then I should see the fresh off the grill results

Scenario: Promotion Panel
	Given I go directly to the home page
	Then I should see the promotion panel
