Feature: LoginFeature
login to Investment Banking



	

Scenario: Perform Login to Investment Banking web Aplication Site
	Given Smith has launched the intrepid application
	And Smith entered the following login details 
	     | UserNameField  | PasswordField  |
		 | NewUserTest  | P@ssword12 |

	     
	And Smith clicked login button
	Then Smith should see home menu



Scenario: Perform Login to Investment Banking web Aplication Site with wrong username
	Given Smith has launched the intrepid application
	And Smith entered the following login details 
	     | UserNameField  | PasswordField  |
	     | Accra  | SharedPassword |
	     
	And Smith clicked login button
	Then Smith should see invalid user name error


Scenario: Perform Login to Investment Banking web Aplication Site with wrong Password
	Given Smith has launched the intrepid application
	And Smith entered the following login details 
	     | UserNameField  | PasswordField  |
	     | ghana  | SharedPassword88 |
	     
	And Smith clicked login button
	Then Smith should see invalid Password error


		
Scenario: Perform Forgot password to Investment Banking web Aplication Site 
	Given Smith has launched the intrepid application     
	And Smith clicked forgot password Link
	Then Smith should see the frgot password screeen