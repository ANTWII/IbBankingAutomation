Feature: Deals
-Deal search
-add Deal
-Receive revenue
-Deal records
--Deal retainer
Background: 
Given Smith has launched the intrepid application
	And Smith entered the following login details 
	     | UserNameField  | PasswordField  |
	      | NewUserTest  | P@ssword12 |
	     
	And Smith clicked login button
	And smith clicked on the Deals Menu

@Search
Scenario: Search Deal by Deal Type ,Deal Status ,Industry,Investment Banker
	And Smith entered the following Search deal details 
	     | DealType        | DealStatus | Industry                | InvestmentBanker |
	     | Mergers & Acquisitions – Sell Side | Open       | Restaurant Group | Allen, Latasha  |
	When [Smith cliks Search]
	Then [Smith should see the search deal grid has records]

	@Search
Scenario: Search Deal with no filter
	And Smith entered the following Search deal details 
	     | DealType        | DealStatus | Industry                | InvestmentBanker |
	     | |        |  |   |
	When [Smith cliks Search]
	Then [Smith should see the search deal grid has records]

	@Search
Scenario: Search Deal by Deal Type and Deal Status Only
	And Smith entered the following Search deal details 
	     | DealType        | DealStatus | Industry                | InvestmentBanker |
	     |Mergers & Acquisitions – Sell Side | Open       |  |  |
	    
	When [Smith cliks Search]
	Then [Smith should see the search deal grid has records]




	@Search
Scenario: Search Deal by Deal Type and Industry only
	And Smith entered the following Search deal details 
	     | DealType        | DealStatus | Industry                | InvestmentBanker |
	     | Mergers & Acquisitions – Sell Side |    |Restaurant Group |  |
	     
	When [Smith cliks Search]
	Then [Smith should see the search deal grid has records]

	 


	 @Search
Scenario: Search Deal by Deal Type and Investment Banker only
	And Smith entered the following Search deal details 
	     | DealType        | DealStatus | Industry                | InvestmentBanker |
	     | Mergers & Acquisitions – Sell Side |     | | Allen, Latasha  |
	When [Smith cliks Search]
	Then [Smith should see the search deal grid has records]


	@Search
Scenario: Search Deal by Deal Status and Industry only
	And Smith entered the following Search deal details 
	     | DealType        | DealStatus | Industry                | InvestmentBanker |
	     | | Open       |Restaurant Group |   |
	When [Smith cliks Search]
	Then [Smith should see the search deal grid has records]


	@Search
Scenario:  Search Deal by Deal Status and Investment Banker only
	And Smith entered the following Search deal details 
	     | DealType        | DealStatus | Industry                | InvestmentBanker |
	     |  | Open       | | 	Allen, Latasha  |
	When [Smith cliks Search]
	Then [Smith should see the search deal grid has records]


	
@Search
Scenario: Search Deal by Industry and Investment Banker only
	And Smith entered the following Search deal details 
	     | DealType        | DealStatus | Industry                | InvestmentBanker |
	     |  |       | 	Restaurant Group | Allen, Latasha |
	When [Smith cliks Search]
	Then [Smith should see the search deal grid has records]

@Add
Scenario: Add Deal add all fields without investment banker and revenuue
And Smith clicked on the Add Deal Button
And Smith entered the folllowng Add deal details
 | DealType                           | DealStatus | ClientName             | ActualDealAmount | ActuaCommissionRate | Industry                | Address         | PhoneNumber | OriginationDate |
 | Mergers & Acquisitions – Sell Side | Open       | faker_ClientName |      |  | Restaurant Group | faker_Address | faker_PhoneNumber  | faker_OriginationDate     |
 When [Smith clicks on save button On Deals add screen]
	Then [Smith should see the search deal grid has records]





	@Add
Scenario: Add Deal with Required fields Only
And Smith clicked on the Add Deal Button
And Smith entered the folllowng Add deal details
 | DealType                           | DealStatus | ClientName             | ActualDealAmount | ActuaCommissionRate | Industry                | Address         | PhoneNumber | OriginationDate |
 | Mergers & Acquisitions – Sell Side | Open       | faker_ClientName |       |  |  |  |   |     |       
 When [Smith clicks on save button On Deals add screen]
	Then [Smith should see the search deal grid has records]


		@Add
Scenario: Add Deal without Deal type
And Smith clicked on the Add Deal Button
And Smith entered the folllowng Add deal details
 | DealType                           | DealStatus | ClientName             | ActualDealAmount | ActuaCommissionRate | Industry                | Address         | PhoneNumber | OriginationDate |
 |  | Open       | faker_ClientName|       |  |  |  |   |     |       
 When [Smith clicks on save button On Deals add screen]
	Then Smith should see a popup which says deal type is required

Scenario: Add Deal without Deal status
And Smith clicked on the Add Deal Button
And Smith entered the folllowng Add deal details
 | DealType                           | DealStatus | ClientName             | ActualDealAmount | ActuaCommissionRate | Industry                | Address         | PhoneNumber | OriginationDate | 
 | Mergers & Acquisitions – Sell Side |        | faker_ClientName |       |  |  |  |   |     |       
 When [Smith clicks on save button On Deals add screen]
	Then Smith should see a popup which says deal Status is required

		@Add
Scenario: Add Deal without Client Name
And Smith clicked on the Add Deal Button
And Smith entered the folllowng Add deal details
 | DealType                           | DealStatus | ClientName             | ActualDealAmount | ActuaCommissionRate | Industry                | Address         | PhoneNumber | OriginationDate |
 |Mergers & Acquisitions – Sell Side  | Open       |  |       |  |  |  |   |     |       
 When [Smith clicks on save button On Deals add screen]
	Then Smith should see a popup which says client name is required


	@Add
Scenario: Add Deal with invalid origination Date
And Smith clicked on the Add Deal Button
And Smith entered the folllowng Add deal details
 | DealType                           | DealStatus | ClientName             | ActualDealAmount | ActuaCommissionRate | Industry                | Address         | PhoneNumber | OriginationDate |
  | Mergers & Acquisitions – Sell Side | Open       | faker_ClientName |     |  | Restaurant Group | faker_Address | faker_PhoneNumber  | Dat2344-20    |

 When [Smith clicks on save button On Deals add screen]
	Then Smith should see an error which origination dates are invalid


	@Add
Scenario: Add Deal add all fields Including investment banker and retainers
And Smith clicked on the Add Deal Button
And Smith entered the folllowng Add deal details
 | DealType                           | DealStatus | ClientName             | ActualDealAmount | ActuaCommissionRate | Industry                | Address         | PhoneNumber | OriginationDate |
 | Mergers & Acquisitions – Sell Side | Open       | faker_ClientName |        |  | Restaurant Group | faker_Address | faker_PhoneNumber  | faker_OriginationDate     |
 And Smith entered the folllowng Deal-investment Banker  details
 | InvestmentBanker | OriginationPercentage       | StandardPayout       |CapAmount  |
 | Allen, Latasha   | faker_OriginationPercentage | faker_StandardPayout | faker_CapAmount |
 When [Smith clicks on save Investment banker  button On Deals add screen]
 Then [Smith should see the Added investment bannker  grid results]
 When smith clicks on the retainer tab
 And Smith entered the folllowng Deal-Revenue details
 | RevenueType    | RevenueSource |CheckWireNumber|Amount  |SettlementDate  |
 |Engagement Fee  |Check    | faker_CheckWireNumber |faker_Amount   | faker_SettlementDate  |
 When [Smith clicks on save Retainer  button On Deals add screen]
 Then [Smith should see the Added Revenue  grid results]
 When [Smith clicks on save button On Deals add screen]
	Then [Smith should see the search deal grid has records]



 @Add
Scenario: Add Deal with  investment banker Without revenue
And Smith clicked on the Add Deal Button
And Smith entered the folllowng Add deal details
 | DealType                           | DealStatus | ClientName             | ActualDealAmount | ActuaCommissionRate | Industry                | Address         | PhoneNumber | OriginationDate |
 | Mergers & Acquisitions – Sell Side | Open       | faker_ClientName |        |  | Restaurant Group | faker_Address | faker_PhoneNumber  | faker_OriginationDate     |
 And Smith entered the folllowng Deal-investment Banker  details
 | InvestmentBanker | OriginationPercentage       | StandardPayout       | CapAmount |
 | Abbott, Steven   | faker_OriginationPercentage | faker_StandardPayout |   faker_CapAmount        |
 When [Smith clicks on save Investment banker  button On Deals add screen]
 Then [Smith should see the Added investment bannker  grid results]

 When [Smith clicks on save button On Deals add screen]
	Then [Smith should see the search deal grid has records]



	 @Add
Scenario: Add Deal With  Revenue , without investment banker
And Smith clicked on the Add Deal Button
And Smith entered the folllowng Add deal details
 | DealType                           | DealStatus | ClientName             | ActualDealAmount | ActuaCommissionRate | Industry                | Address         | PhoneNumber | OriginationDate |
 | Mergers & Acquisitions – Sell Side | Open       | faker_ClientName |        |  | Restaurant Group | faker_Address | faker_PhoneNumber  | faker_OriginationDate     |
 When smith clicks on the retainer tab
And Smith entered the folllowng Deal-Revenue details
 | RevenueType    | RevenueSource |CheckWireNumber|Amount  |SettlementDate  |
 |Engagement Fee  |Check    | faker_CheckWireNumber |faker_Amount   | faker_SettlementDate  |
 When [Smith clicks on save Retainer  button On Deals add screen]
 Then [Smith should see the Added Revenue  grid results]

 When [Smith clicks on save button On Deals add screen]
	Then [Smith should see the search deal grid has records]

#Scenario Outline: Add a deal with actual commission amount calculation
#And Smith clicked on the Add Deal Button
#When Smith enters "<deal_amount>" as the actual deal amount
#And Smith enters "<commission_rate>" as the actual commission rate
#Then I see the actual commission amount calculated as "<commission_amount>"
#And I see that the actual commission amount textbox is readonly by default.
#
#Examples:
#| deal_amount | commission_rate | commission_amount |
#| 1897000 | 13 | 246610.00|
#| 200 | 5 | 10.00 |
#| 500 | 20 | 100.00 |