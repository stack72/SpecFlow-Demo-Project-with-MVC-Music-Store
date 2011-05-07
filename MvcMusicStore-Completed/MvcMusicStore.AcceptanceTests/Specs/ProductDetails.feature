Feature: View Product Details
	In order to test that the database returns details for a product
	I will select the product from the product

Scenario: Select a product and view its details
	Given I have hit the site
	When I have gone to the rock genre page
		And I select 'facelift'
	Then I should be shown the artist and the price
		And I should be offered a chance to add the purchase to the cart
		
Scenario: Select a product, view its details and add it to the cart
	Given I have hit the site
	When I have gone to the rock genre page
		And I select 'facelift'
	Then I should be shown the artist and the price
		And I should be shown the item in the cart when I click add to cart
	
	