
using TechTalk.SpecFlow.Assist;
using NUnit.Framework;
using OpenQA.Selenium;
using InvestmentBankingAutomation.Pages;
using InvestmentBankingAutomation.Drivers;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace InvestmentBankingAutomation.StepDefinitions
{
    [Binding]
    public class DealsStepDefinitions
    {

        DealsPage newDeal;
        private DriverHelper _driverHelper;
        private readonly ScenarioContext _scenarioContext;

        public DealsStepDefinitions(DriverHelper driverHelper, ScenarioContext scenarioContext)
        {
            _driverHelper = driverHelper;

            newDeal = new DealsPage(_driverHelper.Driver);
            _scenarioContext = scenarioContext;

        }

        [Given(@"smith clicked on the Deals Menu")]
        public void GivenSmithClickedOnTheDealsMenu()
        {
            WebDriverWait Wait = new WebDriverWait(_driverHelper.Driver, TimeSpan.FromSeconds(80));

            Wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(newDeal.dealsMenu)));
     

            newDeal.ClickDealsMenu();
        }



        [Given(@"Smith entered the following Search deal details")]
        public void GivenSmithEnteredTheFollowingSearchDealDetails(Table table)
        {


            dynamic data = table.CreateDynamicSet();
            _scenarioContext["userData"] = data;

            foreach (var userData in data)
            {

                //newDeal.DealScreen(userData.DealType, userData.DealStatus, userData.Industry, userData.InvestmentBanker);
                newDeal.selectDealStatus_Search(userData.DealStatus);
                newDeal.selectDealType_Search(userData.DealType);
                newDeal.selectDealIndustry_Search(userData.Industry);
                newDeal.selectDealInvestmentBanker_Search(userData.InvestmentBanker);

            }

        }

       



        [When(@"\[Smith cliks Search]")]
        public void WhenSmithCliksSearch()
        {
            newDeal.ClickSearchButton();
        }




        

        
        [Then(@"\[Smith should see the search deal grid has records]")]
        public void ThenSmithShouldSeeTheSearchDealGridHasRecords()
        {
            dynamic actualData = _scenarioContext["userData"];


            foreach (var userData in actualData)
            {

                //   By editButtonLocator = By.XPath(newDeal.btnGridEdit);


                //DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driverHelper.Driver);

                //fluentWait.Timeout = TimeSpan.FromSeconds(60);

                //fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
                //fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
                //fluentWait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(newDeal.btnGridEdit)));




                ////WebDriverWait Wait = new WebDriverWait(_driverHelper.Driver, TimeSpan.FromSeconds(90));
                ////Wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
                ////Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(newDeal.btnGridEdit)));

                Thread.Sleep(6000);
                Assert.That(newDeal.DealsGridResultsDisplay, Is.True, "Deals Grid does not contain data");


            }
        }


        //Add Deals
        [Given(@"Smith clicked on the Add Deal Button")]
        public void GivenSmithClickedOnTheAddDealButton()
        {
            newDeal.ClickAddButton();
        }

        [Given(@"Smith entered the folllowng Add deal details")]
        public void GivenSmithEnteredTheFolllowngAddDealDetails(Table table)
        {
            dynamic data = table.CreateDynamicSet();
            _scenarioContext["userData"] = data;

            foreach (var userData in data)
            {
                // Enter the valid inputs in the form
                // Note: The data in this table is generated using .NET Faker
                if (userData.ClientName == "faker_ClientName") userData.ClientName = Faker.Name.FullName();
                else userData.ClientName = userData.ClientName;
                if (userData.ActualDealAmount == "faker_ActualDealAmount") userData.ActualDealAmount = string.Format("{0:C}", Faker.RandomNumber.Next(1000, 1000000));
               else userData.ActualDealAmount = userData.ActualDealAmount;
                double commRate = Faker.RandomNumber.Next(10, 100);               
                if (userData.ActuaCommissionRate == "faker_ActuaCommissionRate") userData.ActuaCommissionRate = string.Format("Value: {0:P2}", commRate/100);
                else userData.ActuaCommissionRate = userData.ActuaCommissionRate;
                if (userData.OriginationDate == "faker_OriginationDate") userData.OriginationDate = Faker.Finance.Maturity(1, 12).ToString("MM/dd/yyyy");
                else userData.OriginationDate = userData.OriginationDate;

                if (userData.PhoneNumber == "faker_PhoneNumber") userData.PhoneNumber = Faker.Phone.Number();
                else userData.PhoneNumber = userData.PhoneNumber;
                if (userData.Address == "faker_Address") userData.Address = Faker.Address.UsTerritory();
                else userData.Address = userData.Address;

                newDeal.selectDealStatus_Add(userData.DealStatus);
                newDeal.selectDealType_Add(userData.DealType);
                newDeal.selectDealIndustry_Add(userData.Industry);
                newDeal.enterClientName_Add(userData.ClientName);
                newDeal.enterActualDealAmount_Add(userData.ActualDealAmount);
                newDeal.enterActuaCommissionRate_Add(userData.ActuaCommissionRate);




                if (!string.IsNullOrEmpty(userData.OriginationDate)) newDeal.enterOriginationDate_Add(userData.OriginationDate);
               

                newDeal.enterPhoneNumber_Add(Convert.ToString(userData.PhoneNumber));
                newDeal.enterAddrress_Add(userData.Address);


            }
        }

        [When(@"\[Smith clicks on save button On Deals add screen]")]
        public void WhenSmithClicksOnTheSaveChangesButton()
        {

            newDeal.ClickDealSaveButton();

        }

        [Given(@"Smith entered the folllowng Deal-investment Banker  details")]
        public void GivenSmithEnteredTheFolllowngDeal_InvestmentBankerDetails(Table table)
        {
            newDeal.ClickADDIVBButton();

            dynamic data1 = table.CreateDynamicSet();

            foreach (var userData in data1)
            {
                // Enter the valid inputs in the form
                // Note: The data in this table is generated using .NET Faker
               

                double originationPercentage = Faker.RandomNumber.Next(10, 100);
                if (userData.OriginationPercentage == "faker_OriginationPercentage") userData.OriginationPercentage = string.Format("{0:P0}", originationPercentage / 100).Replace(" ", "");
                else userData.OriginationPercentage = userData.OriginationPercentage;

                double standardPayout = Faker.RandomNumber.Next(10, 100);
                if (userData.StandardPayout == "faker_StandardPayout") userData.StandardPayout = string.Format("{0:P0}", standardPayout / 100).Replace(" ", "");
                else userData.StandardPayout = userData.StandardPayout;
                if (userData.CapAmount == "faker_CapAmount") userData.CapAmount = string.Format("{0:C}", Faker.RandomNumber.Next(1000, 1000000));
                else userData.CapAmount = userData.CapAmount;
                newDeal.selectIVB_Add(userData.InvestmentBanker);
                newDeal.enterIOrigination_Add(userData.OriginationPercentage);
                newDeal.standardPayout(userData.StandardPayout);
                // create an array with 3 elements
                string[] IVB = new string[] { userData.OriginationPercentage, userData.StandardPayout, userData.InvestmentBanker }; 
                _scenarioContext["userData1"] = IVB;

            }
        }


        [When(@"\[Smith clicks on save Investment banker  button On Deals add screen]")]
        public void WhenSmithClicksOnSaveInvestmentBankerButtonOnDealsAddScreen()
        {
            newDeal.ClickIVBSaveButton();
        }

        



        [When(@"Smith entered the folllowng Deal-Revenue details")]
        public void WhenSmithEnteredTheFolllowngDeal_RevenueDetails(Table table)
        {
            newDeal.revenueTab();
            newDeal.ClickAddRevenueButton();

            dynamic data2 = table.CreateDynamicSet();

            foreach (var userData in data2)
            {
                // Enter the valid inputs in the form
                // Note: The data in this table is generated using .NET Faker


             //   double settlementDate = Faker.RandomNumber.Next(10, 100);
                //if (userData.SettlementDate == "faker_SettlementDate") userData.SettlementDate = Faker.Finance.Maturity(0, 0);
                if (userData.SettlementDate == "faker_SettlementDate") userData.SettlementDate = DateTime.Now.ToString("MM/dd/yyyy");
                else userData.SettlementDate = userData.SettlementDate;

              

                if (userData.Amount == "faker_Amount") userData.Amount = string.Format("{0:C}", Faker.RandomNumber.Next(1000, 1000000));
                else userData.Amount = userData.Amount;

                if (userData.CheckWireNumber == "faker_CheckWireNumber") userData.CheckWireNumber = Faker.RandomNumber.Next(1000, 1000000).ToString();
                else userData.CheckWireNumber = userData.CheckWireNumber;

                newDeal.selectRevenueType_Add(userData.RevenueType);
                newDeal.enterAmount_Add(userData.Amount);
                newDeal.selectRevenueSource_Add(userData.RevenueSource);
                newDeal.enterCheckWireNumbe_Add( userData.CheckWireNumber);
                userData.SettlementDate = Convert.ToString(userData.SettlementDate);
                if (!string.IsNullOrEmpty(userData.SettlementDate)) newDeal.enterSettlementDate_Add(userData.SettlementDate);
                string[] revenue = new string[] { userData.RevenueType, userData.Amount, userData.RevenueSource, userData.CheckWireNumber, userData.SettlementDate };
                _scenarioContext["userData2"] = revenue;


            }
        }

        [When(@"smith clicks on the retainer tab")]
        public void WhenSmithClicksOnTheRetainerTab()
        {
            newDeal.revenueTab();
        }


        [When(@"\[Smith clicks on save Retainer  button On Deals add screen]")]
        public void WhenSmithClicksOnSaveRetainerButtonOnDealsAddScreen()
        {
            newDeal.ClickRevenueSaveButton();

        }
        [When(@"Smith enters ""([^""]*)"" as the actual deal amount")]
        public void WhenSmithEntersAsTheActualDealAmount(string DealAmount)
        {
            newDeal.enterActualDealAmount_Add(DealAmount);
        }
        [When(@"Smith enters ""([^""]*)"" as the actual commission rate")]
        public void WhenSmithEntersAsTheActualCommissionRate(string CommissionRate)
        {
            newDeal.enterActuaCommissionRate_Add(CommissionRate);
        }
        [Then(@"I see the actual commission amount calculated as ""([^""]*)""")]
        public void ThenISeeTheActualCommissionAmountCalculatedAs(string CommissionAmount)
        {
            

         
            Assert.AreEqual(newDeal.ActuaCommissionAmountAdd.GetAttribute("value"), CommissionAmount);
        }

        [Then(@"I see that the actual commission amount textbox is readonly by default\.")]
        public void ThenISeeThatTheActualCommissionAmountTextboxIsDisabledByDefault_()
        {

            Assert.NotNull(newDeal.ActuaCommissionAmountAdd.GetAttribute("readonly"));
        }


        [Then(@"\[Smith should see the Added Revenue  grid results]")]
        public void ThenSmithShouldSeeTheAddedRetianerGridResults()
        {
            dynamic actualData = _scenarioContext["userData2"];
            List<string> gridData = newDeal.ValidateRevenueGridData();
            Assert.Multiple(() =>
            {
                WebDriverWait Wait = new WebDriverWait(_driverHelper.Driver, TimeSpan.FromSeconds(60));
                Wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
       
                Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(newDeal.DealRevenueGridCol)));
             Assert.That(newDeal.RevenueGridResultsDisplay, Is.True, "Grid does not contain data");
                foreach (var userData in actualData)
            {


                    if (!string.IsNullOrEmpty(userData)) Assert.Contains(userData, gridData);

                    //DateTime SettlementDate = userData.SettlementDate;



                    //Assert.Contains(userData.RevenueType, newDeal.ValidateRevenueGridData());

                    //Assert.Contains(userData.Amount, newDeal.ValidateRevenueGridData());
                    //Assert.Contains(userData.RevenueSource, newDeal.ValidateRevenueGridData());
                    //Assert.Contains(Convert.ToString (userData.CheckWireNumber), newDeal.ValidateRevenueGridData());
                    //Assert.Contains(SettlementDate.ToShortDateString(), newDeal.ValidateRevenueGridData());



                }
            });

        }
        //Assersions for the investment banker Grid
        [Then(@"\[Smith should see the Added investment bannker  grid results]")]
        public void ThenSmithShouldSeeTheAddedInvestmentBannkerGridResults()
        {
            dynamic actualData = _scenarioContext["userData1"];
            List<string> gridData = newDeal.ValidateInvestBankerGridData();

            Assert.Multiple(() =>
            {

                WebDriverWait Wait = new WebDriverWait(_driverHelper.Driver, TimeSpan.FromSeconds(60));
                Wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
                Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(newDeal.btnGridEdit)));


                Assert.That(newDeal.DealsIVBGridResultsDisplay, Is.True, "Grid does not contain data");

                foreach (var userData in actualData)
            {

                    if (!string.IsNullOrEmpty(userData)) Assert.Contains(userData, gridData);
                   
               


            }
            });
        } 

        [Then(@"Smith should see a popup which says deal type is required")]
        public void ThenSmithShouldSeeAPopupWhichSaysDealTypeIsRequired()
        {
           
                Assert.That(newDeal.ConfirmDealType_Validation, Is.True, "validation not set on Deal type");
               
           
        }

        [Then(@"Smith should see a popup which says deal Status is required")]
        public void ThenSmithShouldSeeAPopupWhichSaysDealStatusIsRequired()
        {
            Assert.That(newDeal.ConfirmDealStatus_Validation, Is.True, "validation not set on Deal Status");
        }

        [Then(@"Smith should see a popup which says client name is required")]
        public void ThenSmithShouldSeeAPopupWhichSaysClientNameIsRequired()
        {
            Assert.That(newDeal.ConfirmClientName_Validation, Is.True, "validation not set on Client Name");
        
        }

        [Then(@"Smith should see an error which origination dates are invalid")]
        public void ThenSmithShouldSeeAnErrorWhichOriginationAndSettlementDatesAreRequired()
        {
            Assert.Multiple(() =>
            {
                Assert.That(newDeal.ConfirmOriginationDate_Validation, Is.True, "validation not set on Origination Date");

            });
        }


    }
}
