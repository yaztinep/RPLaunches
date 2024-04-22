Feature: LaunchViewByBuildNumber

Show the selected Launch view by build number provided

Scenario: Launch selected view by build number
	Given I login with the following credentials
	| username | password |
	| default  | 1q2w3e   |
	And I go to the launches page
	When I filter by build attribute 
	| buildNumber  |
	| Launch name |
	| Total       |
	| Product Bug |
	| Passed      |
	| Failed      |  
	And I select the view
	| viewValue      |
	| 3.21.2.5.30    |
	| 3.21.16.46.36  |
	| 3.21.16.46.51  |
	| 3.21.2.5.25    |
	| 3.21.2.5.21")] |
	Then I should see the view based on the build number
