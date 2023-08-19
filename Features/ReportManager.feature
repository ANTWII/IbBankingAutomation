Feature: ReportManager

A short summary of the feature

Background: 
Given Smith has launched the intrepid application
	And Smith entered the following login details 
	     | UserNameField  | PasswordField  |
	      | NewUserTest  | P@ssword12 |
	     
	And Smith clicked login button
	And Smith has navigated to the Report Manager page


@COMMISSION
@BankerMonthlyStatement
Scenario Outline: Generate a Banker Monthly Statement report
Given Smith is on the Report Manager page
When Smith selects the "<ReportGroup>" report folder
  And Smith clicks on the "<ReportType>" report link
And Smith enters the following criteria on BankerMonthlyStatement report:"< CycleDate>" "<bankerList >"
And Smith clicks on the Run report button
Then the report should load and display I22 Investment Banking
Examples:
| CycleDate         | bankerList      | ReportGroup | ReportType |
| May 2023 (Open)   | Allen, Latasha []  |    COMMISSION         |Banker Monthly Statement  |
| Apr 2023 (Closed)   | Barnes, Eugene []  |    COMMISSION         |Banker Monthly Statement  |
| Mar 2023 (Closed) | Edwards, Wendy [] |    COMMISSION         |Banker Monthly Statement  |
| Feb 2023 (Closed) | Abbott, Steven [] |    COMMISSION         |Banker Monthly Statement  |
| Jan 2023 (Closed) | Acevedo, Damien []|    COMMISSION         |Banker Monthly Statement  |





#@BlotterReport
#@CancelationLogReport
#Scenario Outline: Generate a cancelation report
#Given Smith is on the Report Manager page
#When Smith selects the "<ReportGroup>" report folder
#  And Smith clicks on the "<ReportType>" report link
#And Smith enters the following criteria on cancelation report:"< StartDate>" "< EndDate >" "<Productmode>""<BankList >"
#And Smith clicks on the Run report button
#Then the report should load and display I22 Investment Banking
#Examples:
#| StartDate  | EndDate    | Productmode                    | BankList                    | ReportGroup |ReportType  |
#| 01/10/2023 | 02/02/2023 | Variable Annuity               | I22 Investment Bankers [1]  |BLOTTER  |Cancellation Log |
#| 12/07/2022 | 01/11/2023 | Fixed Annuity and Equity Index | I22 Investment Bankers [1]  | BLOTTER |Cancellation Log |
#| 08/30/2021 | 03/24/2023 | Life Insurance                 | I22 Investment Bankers [1] | BLOTTER | Cancellation Log |
#| 05/11/2021 | 01/13/2022 | Security                       | I22 Investment Bankers [1]  | BLOTTER | Cancellation Log |
#


#@BlotterReport
#@TransactionBlotterReport
#Scenario Outline: Generate a Transaction Blotter Report 
#Given Smith is on the Report Manager page
#When Smith selects the "<ReportGroup>" report folder
#And Smith clicks on the "<ReportType>" report link
#And Smith enters the following criteria on transaction blotter:"< StartDate>" "< EndDate >" "<ProductType>""<BankList >""<AgentList>" "<DateType>""<AccountType>""<TradeType>""<DatafeedList>""<BranchList>"
#And Smith clicks on the Run report button
#Then the report should load and display I22 Investment Banking
#Examples:
#| StartDate  | EndDate    | ProductType                 | BankList                   | ReportGroup | ReportType                 | AgentList         | DateType         | AccountType    | TradeType | DatafeedList         | BranchList                                   |
#| 01/10/2023 | 02/02/2023 | Generic Cash or Equivalents | I22 Investment Bankers [1] | BLOTTER     | Transaction Blotter Report | Acevedo, Damien []|Paid Date         |Committee       |Trailer    |Pershing - ACAM Fund  |#1 Federal Credit Union [01004490]            |
#| 12/07/2022 | 01/11/2023 | Variable Annuity            | I22 Investment Bankers [1] | BLOTTER     | Transaction Blotter Report | Baird, Jaime []   |Written/Trade Date|Church/Nonprofit|Insurance  |Pershing - GACT       |121 Financial Credit Union [00910226]         |
#| 08/30/2021 | 03/24/2023 | Corporate Units Bonds       | I22 Investment Bankers [1] | BLOTTER     | Transaction Blotter Report | Ball, Clifton []   |Entry Date        |Fiduciary       |Security   |Pershing -EBSF        |1st Choice Credit Union [01000902]            |
#| 05/11/2021 | 01/13/2022 | Preferred Stock             | I22 Investment Bankers [1] | BLOTTER     | Transaction Blotter Report | Owens, Sheryl []      |Written/Trade Date|Administrator   |Annuity    |Pershing - ACAM Fund  |100 A CANCO EMP Credit Union Ogden [14300330] |