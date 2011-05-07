Feature: Shopping Cart
	In order to test the shopping cart of the site
	I will try to checkout with various amounts of items in the cart

Scenario: Checkout without any items and not logged in
	Given I have browsed the site
	When I press Cart button
	Then I should be redirected to the login when i click on checkout
	

	
	
	
