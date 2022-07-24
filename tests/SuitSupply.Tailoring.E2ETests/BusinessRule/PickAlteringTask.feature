Feature: Pick Altering Task

In order to Pick Altering Task
As a Tailor
I want to Pick the Altering Task


@PickAlteringTask
@FlushDB
Scenario: Pick altering task when the order comes to Tailor's altering task List
	Given Mehrdad as a Tailor with <tailorNumber>
	And AlteringTask with <alteringTaskNumber>  is Waiting for Pick 
	When Mehrdad has a request for Picking the AlteringTask
	Then Mehrdad should see the AlteringTask as Picked

Examples:
	| tailorNumber | alteringTaskNumber  | 
	| "10001"      |  "20001"            | 
	| "10002"      |  "20002"            | 
	| "10003"      |  "20003"            | 



Scenario: Get the AlteringTask is not available error
	Given Mehrdad as a Tailor with <tailorNumber>
	And AlteringTask with <alteringTaskNumber>  is Picked by another Tailor
	When Mehrdad has a request for Picking the AlteringTask
	Then Mehrdad gets "The AlteringTask is not available." error

Examples:
	| tailorNumber | alteringTaskNumber  | 
	| "10001"      |  "20001"            | 
	| "10002"      |  "20002"            | 
	| "10003"      |  "20003"            | 

