Feature: Home
-Home page


Scenario: Verify home page Eixts 
Given Smith has launched the intrepid application
	And Smith entered the following login details 
	     | UserNameField  | PasswordField  |
	         | NewUserTest  | P@ssword12 |
	     
	And Smith clicked login button
	Then Smith should see welcome Investment Banking Module 