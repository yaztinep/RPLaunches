Feature: SortByValue

Show the Launches sort by value

Scenario: Launch sort by value
	Given I login with the following credentials
	| username | password |
	| default  | 1q2w3e   |
	And I go to the launches page
	When I filter by value 
	| value  |
	| Launch name |
	| Total       |
	| Product Bug |
	| Passed      |
	| Failed      |  

	Then I should see the launches based on the value

