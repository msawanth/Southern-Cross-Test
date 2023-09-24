Feature: Registration

Scenario: Register a valid user
	Given I am in registration page
	Given I enter user details
	| Username        | FirstName | LastName | Password      | ConfirmPassword |
	| BuggyValidator  | random    | random   | MyPassword!@3 | MyPassword!@3   |
	When I click on the register button
	Then Registration successful message is displayed
	Then I should be able to login with the registered details

Scenario: Validate an existing user
	Given I am in registration page
	Given I enter user details
	| Username	| FirstName | LastName | Password      | ConfirmPassword |
	| Alexa     | random    | random   | MyPassword!@3 | MyPassword!@3   |
	When I click on the register button
	Then I should see user exists error message

Scenario: Register with invalid password
	Given I am in registration page
	Given I enter user details
	| Username        | FirstName | LastName | Password      | ConfirmPassword |
	| BuggyValidator  | random    | random   | MyPass | MyPass   |
	When I click on the register button
	Then I should see invalid password error