Feature: Adjustment
-Adjustment search
-add Adjustment

Background: 
Given Smith has launched the intrepid application
	And Smith entered the following login details 
	     | UserNameField  | PasswordField  |
		 | NewUserTest  | P@ssword12 |
	     
	And Smith clicked login button
	And smith clicked on the Adjustment Menu

@Search
Scenario: Search Adjustment by entering All fields
	And Smith entered the following Search adjustment details 
	     | AdjustmentMode | AdjCycleStartDate | AdjCycleEndtDate | InvestmentBanker | AdjustmentCode |
	     | Dynamic        | 11/23/2023	        |      06/01/2026	            | Andersen, Autumn| GRID  |
	When [Smith clicks Search Adjustment button]
	Then [Smith should see the search Adjustment grid  results]

	Scenario: Search Adjustment by InvestmentBanker and AdjustmentCode
Given Smith entered the following Search adjustment details
| AdjustmentMode | AdjCycleStartDate | AdjCycleEndtDate | InvestmentBanker | AdjustmentCode |
| | | | Andersen, Autumn | GRID |
When [Smith clicks Search Adjustment button]
Then [Smith should see the search Adjustment grid  results]

Scenario: Search Adjustment by AdjustmentCycleDate and InvestmentBanker
Given Smith entered the following Search adjustment details
| AdjustmentMode | AdjCycleStartDate | AdjCycleEndtDate | InvestmentBanker | AdjustmentCode |
| |11/23/2023	 | 06/01/2026| Andersen, Autumn | |
When [Smith clicks Search Adjustment button]
Then [Smith should see the search Adjustment grid  results]

Scenario: Search Adjustment by AdjustmentMode and InvestmentBanker
Given Smith entered the following Search adjustment details
| AdjustmentMode | AdjCycleStartDate | AdjCycleEndtDate | InvestmentBanker | AdjustmentCode |
| Dynamic | | | Andersen, Autumn | |
When [Smith clicks Search Adjustment button]
Then [Smith should see the search Adjustment grid  results]

Scenario: Search Adjustment by AdjustmentMode, AdjustmentCycleDate and InvestmentBanker
Given Smith entered the following Search adjustment details
| AdjustmentMode | AdjCycleStartDate | AdjCycleEndtDate | InvestmentBanker | AdjustmentCode |
|Dynamic | 11/23/2023 | 06/01/2026 | Andersen, Autumn | |
When [Smith clicks Search Adjustment button]
Then [Smith should see the search Adjustment grid  results]


Scenario: Search Adjustment by AdjustmentCode and AdjustmentCycleDate
Given Smith entered the following Search adjustment details
| AdjustmentMode | AdjCycleStartDate | AdjCycleEndtDate | InvestmentBanker | AdjustmentCode |
| |05/11/2023 |01/11/2026| | GRID |
When [Smith clicks Search Adjustment button]
Then [Smith should see the search Adjustment grid  results]



Scenario: Search Adjustment by AdjustmentMode, InvestmentBanker and AdjustmentCode
Given Smith entered the following Search adjustment details
| AdjustmentMode | AdjCycleStartDate | AdjCycleEndtDate | InvestmentBanker | AdjustmentCode |
| Dynamic | | | Andersen, Autumn  | GRID |
When [Smith clicks Search Adjustment button]
Then [Smith should see the search Adjustment grid  results]


Scenario: Search Adjustment by AdjustmentCycleDate, InvestmentBanker and AdjustmentCode
Given Smith entered the following Search adjustment details
| AdjustmentMode | AdjCycleStartDate | AdjCycleEndtDate | InvestmentBanker | AdjustmentCode |
| | 05/11/2023 | 01/11/2026 | Andersen, Autumn  |GRID |

When [Smith clicks Search Adjustment button]
Then [Smith should see the search Adjustment grid  results]



Scenario: Search Adjustment with no filter
And Smith entered the following Search adjustment details 
	     | AdjustmentMode | AdjCycleStartDate | AdjCycleEndtDate | InvestmentBanker | AdjustmentCode |
	     |         |        |                 |    |      |
When [Smith clicks Search Adjustment button]
Then [Smith should see the search Adjustment grid  results]

	@Search
Scenario: Search Adjustment by AdjustmentMode and AdjustmentCycleDate
	And Smith entered the following Search adjustment details 
	     | AdjustmentMode | AdjCycleStartDate | AdjCycleEndtDate | InvestmentBanker | AdjustmentCode |
	     | Dynamic        | 05/07/2023        |      02/28/2026             |  |  |
	When [Smith clicks Search Adjustment button]
	Then [Smith should see the search Adjustment grid  results]

	@Edit
#   Scenario:  Successfully edit an existing Adjustment 
#And Smith clicked on the edit Adjustment Button
#And Smith entered the folllowng Add Adjustment details
#    | AdjustmentMode | AdjCycleStartDate | AdjCycleEndtDate | InvestmentBanker | AdjustmentCode | Amount     |Note  |
#    | Recurring        | 05/07/2022        | 02/28/2023       | Andersen, Autumn |GRID           | $2,0000.00 |Testing Add Adjustment  |
# When [Smith clicks on save button On Adjstment add screen]
#	Then [Smith should see the search Adjustment grid  results]

#	@view
#	Scenario:  Successfully view an existing Adjustment 
#And Smith clicked on the view Adjustment Button
#	Then [Smith should see the view Adjustment screen]


 #faker_amount
 #                   faker_note
 #                   faker_startdate
 #                   faker_enddate
   
   @Add
Scenario:  Add Adjustment add all fields-> setting adjustment mode to Recurring
And Smith clicked on the Add Adjustment Button
And Smith entered the folllowng Add Adjustment details
    | AdjustmentMode | AdjCycleStartDate | AdjCycleEndtDate | InvestmentBanker | AdjustmentCode | Amount     |Note  |
    | Recurring        |faker_startdate       |  faker_enddate       | Andersen, Autumn |GRID           | faker_amount |faker_note |
 When [Smith clicks on save button On Adjstment add screen]
	Then [Smith should see the search Adjustment grid  results]


	Scenario: Add Adjustment add all fields-> setting adjustment mode to Dynamic
And Smith clicked on the Add Adjustment Button
And Smith entered the folllowng Add Adjustment details
    | AdjustmentMode | AdjCycleStartDate | AdjCycleEndtDate | InvestmentBanker | AdjustmentCode | Amount     |Note  |
    | Dynamic        |faker_startdate| faker_enddate| Andersen, Autumn |GRID           | faker_amount|faker_note  |
 When [Smith clicks on save button On Adjstment add screen]
	Then [Smith should see the search Adjustment grid  results]


	
	Scenario: Add Adjustment add all fields-> setting adjustment mode to One Time
And Smith clicked on the Add Adjustment Button
And Smith entered the folllowng Add Adjustment details
    | AdjustmentMode | AdjCycleStartDate | AdjCycleEndtDate | InvestmentBanker | AdjustmentCode | Amount     |Note  |
    | Dynamic        | faker_startdate        | faker_enddate       | Andersen, Autumn |GRID           | faker_amount |faker_note  |
 When [Smith clicks on save button On Adjstment add screen]
	Then [Smith should see the search Adjustment grid  results]

Scenario:  Add required fields only on Add adjusttment
And Smith clicked on the Add Adjustment Button
And Smith entered the folllowng Add Adjustment details
    | AdjustmentMode | AdjCycleStartDate | AdjCycleEndtDate | InvestmentBanker | AdjustmentCode | Amount     |Note  |
    | Dynamic        |       |      | Andersen, Autumn |GRID           | | |
 When [Smith clicks on save button On Adjstment add screen]
	Then [Smith should see the search Adjustment grid  results]

Scenario: Add Adjustment with missing required fields
And Smith clicked on the Add Adjustment Button
And Smith entered the folllowng Add Adjustment details
    | AdjustmentMode | AdjCycleStartDate | AdjCycleEndtDate | InvestmentBanker | AdjustmentCode | Amount     |Note  |
    |        |  faker_startdate       | faker_enddate       |  |         | faker_amount |faker_note |
When [Smith clicks on save button On Adjstment add screen]
Then [Smith should see an error message indicating missing required fields]


Scenario: Add Adjustment add all required  fields and amount only
And Smith clicked on the Add Adjustment Button
And Smith entered the folllowng Add Adjustment details
    | AdjustmentMode | AdjCycleStartDate | AdjCycleEndtDate | InvestmentBanker | AdjustmentCode | Amount     |Note  |
    | Dynamic        |       |      | Andersen, Autumn |GRID           |faker_amount  | |
 When [Smith clicks on save button On Adjstment add screen]
	Then [Smith should see the search Adjustment grid  results]

	
Scenario: Add Adjustment with invalid date format
And Smith clicked on the Add Adjustment Button
And Smith entered the folllowng Add Adjustment details
| AdjustmentMode | AdjCycleStartDate | AdjCycleEndtDate | InvestmentBanker | AdjustmentCode | Amount |Note |
| Dynamic |Dat2344-20 | 02-28-Datew | Andersen, Autumn |GRID | faker_amount |faker_note |
When [Smith clicks on save button On Adjstment add screen]
Then [Smith should see an error message indicating invalid date format]





@AddAdustmentcode:

Scenario: Successfully add a new Adjustment Code with all valid inputs
And the user clicks the "Adjustment Codes" button
When the Adjustment Code popup screen appears
And the user clicks the "Add New" button
Then the "Add Adjustment Code" popup appears
And the user enters the following valid inputs:
| AdjustmentCode | AdjustmentDescription | Amount | Category | GLCode | CostCenter |
| faker_code| faker_descrip| faker_amount | faker_category | faker_glcode | faker_cost |
And clicks "Save" button
Then the new Adjustment Code is added to the grid 

Scenario:  add a new Adjustment Code with duplicate Adjustment Code
And the user clicks the "Adjustment Codes" button
When the Adjustment Code popup screen appears
And the user clicks the "Add New" button
Then the "Add Adjustment Code" popup appears
And the user enters the following valid inputs:
| AdjustmentCode | AdjustmentDescription | Amount | Category | GLCode | CostCenter |
| CA| faker_descrip| faker_amount | faker_category | faker_glcode | faker_cost |
And clicks "Save" button
Then display a popup indicicating Adjustment Code a duplicate

Scenario: Attempt to add a new Adjustment Code with missing required inputs
And the user clicks the "Adjustment Codes" button
When the Adjustment Code popup screen appears
And the user clicks the "Add New" button
Then the "Add Adjustment Code" popup appears
And the user enters the following valid inputs:
| AdjustmentCode | AdjustmentDescription | Amount | Category | GLCode | CostCenter |
| | faker_descrip| faker_amount | faker_category | faker_glcode | faker_cost |

And clicks "Save" button
Then the system displays an error message indicating that Adstment code  field is required



Scenario: Successfully add a new Adjustment Code with Required fields only
And the user clicks the "Adjustment Codes" button
When the Adjustment Code popup screen appears
And the user clicks the "Add New" button
Then the "Add Adjustment Code" popup appears
And the user enters the following valid inputs:
| AdjustmentCode | AdjustmentDescription | Amount | Category | GLCode | CostCenter |
| faker_code| | |  |  |  |
And clicks "Save" button
Then the new Adjustment Code is added to the grid 

Scenario: Attempt to add a new Adjustment Code with AdjustmentCode and AdjustmentDescription only
And the user clicks the "Adjustment Codes" button
When the Adjustment Code popup screen appears
And the user clicks the "Add New" button
Then the "Add Adjustment Code" popup appears
And the user enters the following valid inputs:
| AdjustmentCode | AdjustmentDescription | Amount | Category | GLCode | CostCenter |
| faker_code| faker_descrip| | |  |  |

And clicks "Save" button
Then the new Adjustment Code is added to the grid 

Scenario: Successfully add a new Adjustment Code with  AdjustmentCode and Amount only
And the user clicks the "Adjustment Codes" button
When the Adjustment Code popup screen appears
And the user clicks the "Add New" button
Then the "Add Adjustment Code" popup appears
And the user enters the following valid inputs:
| AdjustmentCode | AdjustmentDescription | Amount | Category | GLCode | CostCenter |
| faker_code| | faker_amount |  |  |  |
And clicks "Save" button
Then the new Adjustment Code is added to the grid 

Scenario: Successfully add a new Adjustment Code with  AdjustmentCode and Category only
And the user clicks the "Adjustment Codes" button
When the Adjustment Code popup screen appears
And the user clicks the "Add New" button
Then the "Add Adjustment Code" popup appears
And the user enters the following valid inputs:
| AdjustmentCode | AdjustmentDescription | Amount | Category | GLCode | CostCenter |
| faker_code| |  | faker_category |  |  |
And clicks "Save" button
Then the new Adjustment Code is added to the grid 

Scenario: Successfully add a new Adjustment Code with  AdjustmentCode and GL Code only
And the user clicks the "Adjustment Codes" button
When the Adjustment Code popup screen appears
And the user clicks the "Add New" button
Then the "Add Adjustment Code" popup appears
And the user enters the following valid inputs:
| AdjustmentCode | AdjustmentDescription | Amount | Category | GLCode | CostCenter |
| faker_code| |  |  | faker_glcode |  |
And clicks "Save" button
Then the new Adjustment Code is added to the grid 

Scenario: Successfully add a new Adjustment Code with  AdjustmentCode and Cost Center only
And the user clicks the "Adjustment Codes" button
When the Adjustment Code popup screen appears
And the user clicks the "Add New" button
Then the "Add Adjustment Code" popup appears
And the user enters the following valid inputs:
| AdjustmentCode | AdjustmentDescription | Amount | Category | GLCode | CostCenter |
| faker_code|  |  |  |  | faker_cost |
And clicks "Save" button
Then the new Adjustment Code is added to the grid 

