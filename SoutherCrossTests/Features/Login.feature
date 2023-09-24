Feature: Login

Scenario: Login with valid credentials
	Given I am in home page
	Given I enter username BuggyValidator and password MyPassword!@3
	When I click login button
	Then I should be logged in

Scenario: Login with invalid credentials
	Given I am in home page
	Given I enter username thisisnotavalidregisteredusername and password sameasusername
	When I click login button
	Then I should see a invalid credential validation error