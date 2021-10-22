Feature: CreateCompany
	Create Company 

@mytag
Scenario: Create a new Company
	Given Login to Titan Url And enter user name and password
	And Search for test Company And click on Add new Company
	When Enter all the Company mandatory field and save it
	When Take the company reference number and Add contact 
	Then Take the contact ID