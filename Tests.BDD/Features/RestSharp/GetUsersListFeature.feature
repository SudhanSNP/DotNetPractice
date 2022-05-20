Feature: GetUsersListFeature

This feature is to get the list of Users from the given API
This will have the Name, Id, Email of multiple Users

@GetUsersAPITest
Scenario: Verify All Users Name
	Given The API clients are Initialized
	When The User names are retrieved from the Get API Request
	Then The following Names should present
	| Name    |
	| George  |
	| Janet   |
	| Emma    |
	| Eve     |
	| Charles |
	| Tracey  |
