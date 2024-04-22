Feature: CompareLaunches

Compare launches provided

Scenario Outline: Compare launches
    Given I login with the following credentials
        | username | password |
        | default  | 1q2w3e   |
    And I go to the launches page
    When I select the following launches
        | options |
        | <launches> |
    And I perform the comparison action
    Then I should see the comparison result

Examples:
    | launches |
    | [1, 2]   |
    | [1, 2, 5]|
    | [1, 5]   |
    | [2, 6]   |
    | [1, 6]   |

