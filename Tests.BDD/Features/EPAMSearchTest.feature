Feature: EPAMSearchTest
This feature is to test the EPAM Search Page.
We will be testing the result of a particular Search

@EPAMSkillSearchTest
Scenario Outline: Skillset in EPAM search
	Given I have entered the EPAM home page
	And I have navigated to the Search panel
	When I entered the SkillSet to search as <Skill>
	Then The record message of the search result should match the <Record>
	And Close the browser

Examples: 
	| Skill      | Record |
	| Automation | 385    |
	| RPA        | 80     |
