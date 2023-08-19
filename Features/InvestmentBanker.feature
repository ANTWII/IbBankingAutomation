Feature: InvestentBanker
-InvestentBanker search
-add InvestentBanker

Background: 
Given Smith has launched the intrepid application
	And Smith entered the following login details 
	  | UserNameField  | PasswordField  |
		 | NewUserTest  | P@ssword12 |
	     
	And Smith clicked login button
	And smith clicked on the InvestentBanker Menu

@Search
Scenario: Search InvestentBanker by IBanker Role ,IBanker Status ,Lname,Fname,SSN
	And Smith entered the following Search Investment Banker details 
	     | IBRole | IBLastName |IBFirstName |IBSSN    | IBStatus |
	     |Vice President|Beahan|Smith	|45788|Active|
	When [Smith cliks Search on Investment banker]
	Then [Smith should see investment banker grid search results]

Scenario: Search Investment Banker by IBanker Role only
And Smith entered the following Search Investment Banker details
 | IBRole | IBLastName |IBFirstName |IBSSN    | IBStatus |
	     |Vice President|||||
When [Smith cliks Search on Investment banker]
Then [Smith should see investment banker grid search results]

Scenario: Search Investment Banker by IBanker Status only
And Smith entered the following Search Investment Banker details
| IBRole | IBLastName |IBFirstName |IBSSN    | IBStatus |
	     |||||Active|
When [Smith cliks Search on Investment banker]
Then [Smith should see investment banker grid search results]

Scenario: Search Investment Banker by IBanker Last Name only
And Smith entered the following Search Investment Banker details
| IBRole | IBLastName |IBFirstName |IBSSN    | IBStatus |
	     ||Beahan||||
When [Smith cliks Search on Investment banker]
Then [Smith should see investment banker grid search results]


Scenario: Search Investment Banker by IBanker SSN only
And Smith entered the following Search Investment Banker details
| IBRole | IBLastName |IBFirstName |IBSSN    | IBStatus |
	     ||||45788||
When [Smith cliks Search on Investment banker]
Then [Smith should see investment banker grid search results]

Scenario: Search Investment Banker by IBanker Role and IBStatus
And Smith entered the following Search Investment Banker details
 | IBRole | IBLastName |IBFirstName |IBSSN    | IBStatus |
	     |Vice President||	||Active|
When [Smith cliks Search on Investment banker]
Then [Smith should see investment banker grid search results]

Scenario: Search Investment Banker by IBFirstName and IBLastName
And Smith entered the following Search Investment Banker details
 | IBRole | IBLastName |IBFirstName |IBSSN    | IBStatus |
	     ||Beahan|Smith	|||
When [Smith cliks Search on Investment banker]
Then [Smith should see investment banker grid search results]

Scenario: Search Investment Banker by IBanker Role, IBLastName and IBSSN
And Smith entered the following Search Investment Banker details
 | IBRole | IBLastName |IBFirstName |IBSSN    | IBStatus |
	     |Vice President|Beahan|	|45788||
When [Smith cliks Search on Investment banker]
Then [Smith should see investment banker grid search results]

Scenario: Search Investment Banker by IBFirstName, IBLastName and IBStatus
And Smith entered the following Search Investment Banker details
 | IBRole | IBLastName |IBFirstName |IBSSN    | IBStatus |
	     ||Beahan|Smith	||Active|
When [Smith cliks Search on Investment banker]
Then [Smith should see investment banker grid search results]

Scenario: Search Investment Banker by IBanker Role, IBFirstName and IBStatus
And Smith entered the following Search Investment Banker details
 | IBRole | IBLastName |IBFirstName |IBSSN    | IBStatus |
	     |Vice President||Smith	||Active|
When [Smith cliks Search on Investment banker]
Then [Smith should see investment banker grid search results]


Scenario: Search Investment Banker by IBanker Role, IBLastName and IBStatus
And Smith entered the following Search Investment Banker details
 | IBRole | IBLastName |IBFirstName |IBSSN    | IBStatus |
	     |Vice President|Beahan|	||Active|
When [Smith cliks Search on Investment banker]
Then [Smith should see investment banker grid search results]

Scenario: Search Investment Banker by IBFirstName, IBSSN and IBStatus
And Smith entered the following Search Investment Banker details
 | IBRole | IBLastName |IBFirstName |IBSSN    | IBStatus |
	     |||Smith	|45788|Active|
When [Smith cliks Search on Investment banker]
Then [Smith should see investment banker grid search results]

Scenario: Search Investment Banker by IBLastName, IBSSN and IBStatus
And Smith entered the following Search Investment Banker details
 | IBRole | IBLastName |IBFirstName |IBSSN    | IBStatus |
	     ||Beahan|	|45788|Active|
When [Smith cliks Search on Investment banker]
Then [Smith should see investment banker grid search results]

Scenario: Search Investment Banker by IBanker Role, IBFirstName, IBLastName and IBSSN
And Smith entered the following Search Investment Banker details
 | IBRole | IBLastName |IBFirstName |IBSSN    | IBStatus |
	     |Vice President|Beahan|Smith	|45788||
When [Smith cliks Search on Investment banker]
Then [Smith should see investment banker grid search results]







	@Add
Scenario: Add all fields on Investment Banker 
And Smith clicked on the Add InvestmentBanker Button
And Smith entered the folllowng Add InvestmentBanker details
 | IBStatus | IBLastName | IBEmail               | IBrole                    | IBFname | IBMiddleName | IBNickName | IBDOB     | IBHireDate | IBTerminatedDate | IBEmployeeNum | IBHomePhone | IBWorkPhone | IBFax        | IBCellNumber | IBAddress            | IBSSN     | IBCity        | IBState  | IBZip | Supervisor |
 | Active   | faker_LastName    | faker_Email| Vice President| faker_FirstName   | faker_MiddleName        | faker_NickName   | faker_DOB | faker_HireDate  | faker_TerminatedDate       | faker_EmployeeNum    | faker_HomePhone  | faker_WorkPhone  | faker_Fax |faker_CellNmber   | faker_Address | faker_SSN | faker_City | faker_State | faker_ZIP | Andersen, Autumn|
 When [Smith clicks on the save button ON InvesmentBanker add screen]
 	Then [Smith should see investment banker grid search results]

	
		@Add
Scenario:Add Investment Banker with invalid Email
And Smith clicked on the Add InvestmentBanker Button
And Smith entered the folllowng Add InvestmentBanker details
 | IBStatus | IBLastName | IBEmail               | IBrole                    | IBFname | IBMiddleName | IBNickName | IBDOB     | IBHireDate | IBTerminatedDate | IBEmployeeNum | IBHomePhone | IBWorkPhone | IBFax        | IBCellNumber | IBAddress            | IBSSN     | IBCity        | IBState  | IBZip | Supervisor |
 | Active   | faker_LastName    | @ggmail.com| Vice President| faker_FirstName   | faker_MiddleName        | faker_NickName   | faker_DOB | faker_HireDate  | faker_TerminatedDate       | faker_EmployeeNum    | faker_HomePhone  | faker_WorkPhone  | faker_Fax |faker_CellNmber   | faker_Address | faker_SSN | faker_City | faker_State | faker_ZIP | Andersen, Autumn|
 When [Smith clicks on the save button ON InvesmentBanker add screen]
 	Then Smith should see an error message indicating that the email address is invalid

	Scenario:Add Investment Banker without Lastname
And Smith clicked on the Add InvestmentBanker Button
And Smith entered the folllowng Add InvestmentBanker details
 | IBStatus | IBLastName | IBEmail               | IBrole                    | IBFname | IBMiddleName | IBNickName | IBDOB     | IBHireDate | IBTerminatedDate | IBEmployeeNum | IBHomePhone | IBWorkPhone | IBFax        | IBCellNumber | IBAddress            | IBSSN     | IBCity        | IBState  | IBZip | Supervisor |
 | Active   |    | faker_Email| Vice President| faker_FirstName   | faker_MiddleName        | faker_NickName   | faker_DOB | faker_HireDate  | faker_TerminatedDate       | faker_EmployeeNum    | faker_HomePhone  | faker_WorkPhone  | faker_Fax |faker_CellNmber   | faker_Address | faker_SSN | faker_City | faker_State | faker_ZIP | Andersen, Autumn|
 When [Smith clicks on the save button ON InvesmentBanker add screen]
 	Then Smith should see an error message indicating that the Lastname is required

		Scenario:Add Investment Banker without status
And Smith clicked on the Add InvestmentBanker Button
And Smith entered the folllowng Add InvestmentBanker details
 | IBStatus | IBLastName | IBEmail               | IBrole                    | IBFname | IBMiddleName | IBNickName | IBDOB     | IBHireDate | IBTerminatedDate | IBEmployeeNum | IBHomePhone | IBWorkPhone | IBFax        | IBCellNumber | IBAddress            | IBSSN     | IBCity        | IBState  | IBZip | Supervisor |
 |    | faker_LastName    | faker_Email| Vice President| faker_FirstName   | faker_MiddleName        | faker_NickName   | faker_DOB | faker_HireDate  | faker_TerminatedDate       | faker_EmployeeNum    | faker_HomePhone  | faker_WorkPhone  | faker_Fax |faker_CellNmber   | faker_Address | faker_SSN | faker_City | faker_State | faker_ZIP | Andersen, Autumn|
 When [Smith clicks on the save button ON InvesmentBanker add screen]
 When [Smith clicks on the save button ON InvesmentBanker add screen]
 	Then Smith should see an error message indicating that status is required

	Scenario: Add Required fields only on Investment Banker 
And Smith clicked on the Add InvestmentBanker Button
And Smith entered the folllowng Add InvestmentBanker details
 | IBStatus | IBLastName     | IBEmail | IBrole | IBFname | IBMiddleName | IBNickName | IBDOB | IBHireDate | IBTerminatedDate | IBEmployeeNum | IBHomePhone | IBWorkPhone | IBFax | IBCellNumber | IBAddress | IBSSN | IBCity | IBState | IBZip | Supervisor |
 | Active   | faker_LastName | faker_Email        |        |         |              |            |       |            |                  |               |             |             |       |              |           |       |        |         |     faker_ZIP  |            |
 When [Smith clicks on the save button ON InvesmentBanker add screen]
 	Then [Smith should see investment banker grid search results]

Scenario:Add Investment Banker with Invalid :Date of birth,Hiredate,Teminated date
And Smith clicked on the Add InvestmentBanker Button
And Smith entered the folllowng Add InvestmentBanker details
| IBStatus | IBLastName | IBEmail               | IBrole                    | IBFname | IBMiddleName | IBNickName | IBDOB     | IBHireDate | IBTerminatedDate | IBEmployeeNum | IBHomePhone | IBWorkPhone | IBFax        | IBCellNumber | IBAddress            | IBSSN     | IBCity        | IBState  | IBZip | Supervisor |
 | Active   | faker_LastName    | 23568@ggmail.com| Vice President| faker_FirstName   | faker_MiddleName        | faker_NickName   | 233/533/2333 | 233/533/2333 | 233/533/2333       | faker_EmployeeNum    | faker_HomePhone  | faker_WorkPhone  | faker_Fax |faker_CellNmber   | faker_Address | faker_SSN | faker_City | faker_State | faker_ZIP | Andersen, Autumn|

 When [Smith clicks on the save button ON InvesmentBanker add screen]
 	Then Smith should see an error message indicating that the dates are invalid