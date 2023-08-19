Feature: CommissionCycle

-add Comission Cycle

Background: 
Given Smith has launched the intrepid application
	And Smith entered the following login details 
	     | UserNameField  | PasswordField  |
		 | NewUserTest  | P@ssword12 |
	     
	And Smith clicked login button
	And smith clicked on the CommissionCycle Menu



	@Add
Scenario: Successfully  Add CommissionCycle with all valid inputs

And Smith entered the folllowng CommissionCycle date details
 | coverageStartDate | coverageEndDate | startDate  | endDate    |
 | faker_Coveragestartdate        |         faker_Coverageenddate        | faker_startdate |faker_enddate |
 When [Smith clicks on the Add button ON CommissionCycle add screen]
 Then [Smith should see the Added CommissionCycle  grid results]

# 	@Add
#Scenario: Add CommissionCycle with missing Start date required field
#
#And Smith entered the folllowng CommissionCycle date details
# | coverageStartDate | coverageEndDate | startDate  | endDate    |
# | faker_Coveragestartdate        |         faker_Coverageenddate        |  |faker_enddate  |
# When [Smith clicks on the Add button ON CommissionCycle add screen]
# Then [Smith should see the start date  required field validation error]

  	@Add
Scenario: Add CommissionCycle with missing End date required field

And Smith entered the folllowng CommissionCycle date details
 | coverageStartDate | coverageEndDate | startDate  | endDate    |
 | faker_Coveragestartdate        |         faker_Coverageenddate        | faker_startdate | |
 When [Smith clicks on the Add button ON CommissionCycle add screen]
 Then [Smith should see the Endate  date  required field validation error]

 

 Scenario:Add CommissionCycle with invalid input
And Smith entered the folllowng CommissionCycle date details
 | coverageStartDate | coverageEndDate | startDate  | endDate    |
 | 01/11/0000       |         01/11/0000        | 01/11/0000 |faker_enddate |
 When [Smith clicks on the Add button ON CommissionCycle add screen]
 Then [Smith should see invalid dates validation  errors]

 Scenario: Successfully  Add CommissionCycle with all requireds fields only

And Smith entered the folllowng CommissionCycle date details
 | coverageStartDate | coverageEndDate | startDate  | endDate    |
 |        |               | faker_startdate |faker_enddate |
 When [Smith clicks on the Add button ON CommissionCycle add screen]
 Then [Smith should see the Added CommissionCycle  grid results]
