
using TechTalk.SpecFlow.Assist;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using InvestmentBankingAutomation.Pages;
using InvestmentBankingAutomation.Drivers;
using Faker;
using InvestmentBankingAutomation.Extensions;

namespace InvestmentBankingAutomation.StepDefinitions
{
    [Binding]
    public class AdjustmentStepDefinitions
    {

        AdjustmentPage newAdjustment;
        private DriverHelper _driverHelper;
        private readonly ScenarioContext _scenarioContext;
        public AdjustmentStepDefinitions(DriverHelper driverHelper, ScenarioContext scenarioContext)
        {
            _driverHelper = driverHelper;

            newAdjustment = new AdjustmentPage(_driverHelper.Driver);
            _scenarioContext = scenarioContext;

        }



        [Given(@"smith clicked on the Adjustment Menu")]
        public void GivenSmithClickedOnTheAdjustmentMenu()
        {
            WebDriverWait Wait = new WebDriverWait(_driverHelper.Driver, TimeSpan.FromSeconds(60));

            Wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(newAdjustment.adjustmentMenu)));
            newAdjustment.ClickAdjustmentMenu();
        }

        [Given(@"Smith entered the following Search adjustment details")]
        public void GivenSmithEnteredTheFollowingSearchAdjustmentDetails(Table table)
        {
            dynamic data = table.CreateDynamicSet();
            _scenarioContext["userData"] = data;

            foreach (var userData in data)
            {
                

             

                newAdjustment.adjustmentMode_Search(userData.AdjustmentMode);
                newAdjustment.investmentBanker_Search(userData.InvestmentBanker);
                newAdjustment.adjustmentCode_Search(userData.AdjustmentCode);

                string cycleEndDate = Convert.ToString( userData.AdjCycleEndtDate);
                string cyclestartDate = Convert.ToString( userData.AdjCycleStartDate);

                // Check if the string  object is not null or empty

                if (!string.IsNullOrEmpty(cyclestartDate))
                {
                    cyclestartDate = userData.AdjCycleStartDate.ToString("MM/dd/yyyy");
                    newAdjustment.adjCycleStartDate_Search(cyclestartDate);

                }

                // Check if the string  object is not null or empty

                if (!string.IsNullOrEmpty(cycleEndDate))
                {
                    cycleEndDate = userData.AdjCycleEndtDate.ToString("MM/dd/yyyy");

                    newAdjustment.adjCycleEndtDate_Search(cycleEndDate);

                }




            }

        }

       



        [When(@"\[Smith clicks Search Adjustment button]")]
        public void WhenSmithClicksSearchAdjustmentButton()
        {
            newAdjustment.ClickSearchButton();
        }



        [Then(@"\[Smith should see the search Adjustment grid  results]")]
        public void SearchAdjustmentGridResults()
        {
            dynamic actualData = _scenarioContext["userData"];
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driverHelper.Driver);

            fluentWait.Timeout = TimeSpan.FromSeconds(90);

            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            fluentWait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(newAdjustment.btnGridEdit)));

            Assert.That(newAdjustment.AdjustGridResultsDisplay, Is.True, "Grid does not contain data");
           
        }

        [Given(@"Smith clicked on the Add Adjustment Button")]
        public void GivenSmithClickedOnTheAddAdjustmentButton()
        {
            newAdjustment.ClickAddButton();
        }
        

        [Given(@"Smith entered the folllowng Add Adjustment details")]
        public void GivenSmithEnteredTheFolllowngAddAdjustmentDetails(Table table)
        {
            dynamic data = table.CreateDynamicSet();
            _scenarioContext["userData"] = data;

            foreach (var userData in data)
            {
               

                if (userData.Amount == "faker_amount") userData.Amount = string.Format("{0:C}", Faker.RandomNumber.Next(1000, 1000000));
                else userData.Amount = userData.Amount;
                if (userData.Note == "faker_note") userData.Note = Faker.Lorem.Sentence(1);
                else userData.Note = userData.Note;
                if (userData.AdjCycleStartDate == "faker_startdate") userData.AdjCycleStartDate = Faker.Finance.Maturity(1,12).ToString("MM/dd/yyyy");
                else userData.AdjCycleStartDate = userData.AdjCycleStartDate;
                if (userData.AdjCycleEndtDate == "faker_enddate") userData.AdjCycleEndtDate = Faker.Finance.Maturity(12, 36).ToString("MM/dd/yyyy");
                else userData.AdjCycleEndtDate = userData.AdjCycleEndtDate;

                newAdjustment.amount_Add(userData.Amount);
                newAdjustment.note_Add(userData.Note);
                newAdjustment.adjustmentCode_Add(userData.AdjustmentCode);
                newAdjustment.adjustmentMode_Add(userData.AdjustmentMode);
                if (!string.IsNullOrEmpty(userData.InvestmentBanker)) newAdjustment.Adj_InvestmentBanker_Add(userData.InvestmentBanker);




                //userData.AdjCycleStartDate = Convert.ToString(userData.AdjCycleStartDate);
                //userData.AdjCycleEndtDate = Convert.ToString(userData.AdjCycleEndtDate);


                if (!string.IsNullOrEmpty(userData.AdjCycleStartDate)) newAdjustment.adjCycleStartDate_Add(userData.AdjCycleStartDate);


                if (userData.AdjustmentMode == "Dynamic")
                {
                    if (!string.IsNullOrEmpty(userData.AdjCycleEndtDate)) newAdjustment.adjCycleEndtDate_Add(userData.AdjCycleEndtDate); 
                }
               
               
            }
        }


        [When(@"\[Smith clicks on save button On Adjstment add screen]")]
        public void WhenSmithClicksOnSaveButtonOnAdjstmentAddScreen()
        {
            newAdjustment.ClickSaveButton();
        }


        [Given(@"the user clicks the ""([^""]*)"" button")]
        public void GivenTheUserClicksTheButton(string p0)
        {
            newAdjustment.ClickAddAdjustmentCodebutton();
        }
        [When(@"the Adjustment Code popup screen appears")]
        public void WhenTheAdjustmentCodePopupScreenAppears()
        {

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driverHelper.Driver);

            fluentWait.Timeout = TimeSpan.FromSeconds(60);

            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(newAdjustment.addNewCodeBtn)));

            
        }


        [When(@"the user clicks the ""([^""]*)"" button")]
        public void WhenTheUserClicksTheButton(string p0)
        {
            newAdjustment.ClickAddNewButton();
        }

        [Then(@"the ""([^""]*)"" popup appears")]
        public void ThenThePopupAppears(string p0)
        {
            Assert.That(newAdjustment.ConfirmAddAdjustmentCodepopup, Is.True, "Add adustment code scren not showing");
        }
        [Then(@"the user enters the following valid inputs:")]
        public void ThenTheUserEntersTheFollowingValidInputs(Table table)
        {
            dynamic data = table.CreateDynamicSet();



            
            foreach (var userData in data)
            {



                // Enter the valid inputs in the form
                // Note: The data in this table is generated using .NET Faker
                if (userData.AdjustmentCode  == "faker_code") userData.AdjustmentCode = Faker.Identification.UkNationalInsuranceNumber(false);
                else userData.AdjustmentCode= userData.AdjustmentCode;
                if (userData.AdjustmentDescription== "faker_descrip") userData.AdjustmentDescription = Faker.Lorem.Sentence(1);
               else userData.AdjustmentDescription= userData.AdjustmentDescription;
                if(userData.Amount== "faker_amount") userData.Amount = string.Format("{0:C}", Faker.RandomNumber.Next(1000, 1000000));
              else userData.Amount= userData.Amount;
                if(userData.GLCode== "faker_glcode") userData.GLCode = Faker.Identification.BulgarianPin();
                else userData.GLCode= userData.GLCode;
                if(userData.CostCenter== "faker_cost") userData.CostCenter = Faker.Company.Name();
                else userData.CostCenter= userData.CostCenter;
                if (userData.Category == "faker_category") userData.Category = Faker.Country.Name();
                else userData.Category = userData.Category;

                newAdjustment.adjustmentCode(userData.AdjustmentCode);
                newAdjustment.adjustmentDescription(userData.AdjustmentDescription);
                newAdjustment.Amount( userData.Amount);
                newAdjustment.category(userData.Category);
                newAdjustment.CostCenter(userData.CostCenter);
                newAdjustment.GLcode(userData.GLCode);
                string[] Adjus = new string[] { userData.AdjustmentCode, userData.AdjustmentDescription, userData.Amount, userData.Category, userData.GLCode, userData.CostCenter }; // create an array with 3 elements


                _scenarioContext["userData"] = Adjus;
            }





        }

        [Then(@"clicks ""([^""]*)"" button")]
        public void ThenClicksButton(string save)
        {
            newAdjustment.ClickSaveCodeButton();
        }

        [Then(@"the new Adjustment Code is added to the grid")]
        public void ThenTheNewAdjustmentCodeIsAddedToTheGrid()
        {
              

            

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driverHelper.Driver);

            fluentWait.Timeout = TimeSpan.FromSeconds(90);

            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            fluentWait.Until(ExpectedConditions.ElementExists(By.XPath(newAdjustment.AdjustCodeCol)));

            dynamic actualData = _scenarioContext["userData"];


            List<string> gridData = newAdjustment.ValidateADJSCodeGridData();
            Assert.Multiple(() =>
            {
                WebDriverWait Wait = new WebDriverWait(_driverHelper.Driver, TimeSpan.FromSeconds(60));
                Wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
                Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(newAdjustment.btnGridEdit)));
                Assert.That(newAdjustment.AdjustCodeGridResultsDisplay, Is.True, "Grid does not contain data");


                foreach (var userData in actualData)
                {
                    if (!string.IsNullOrEmpty(userData)) Assert.Contains(userData, gridData);

                }
                   

             

                

            });
        }
        [Then(@"the system displays an error message indicating that Adstment code  field is required")]
        public void ThenTheSystemDisplaysAnErrorMessageIndicatingThatAdstmentCodeFieldIsRequired()
        {
            Assert.That(newAdjustment.ConfirmAddcodeValidationError, Is.True, "validation not set on Adjustment Code");
        }


        [Then(@"\[Smith should see an error message indicating missing required fields]")]
        public void ThenSmithShouldSeeAnErrorMessageIndicatingMissingRequiredFields()
        {
            Assert.Multiple(() =>
            {
                Assert.That(newAdjustment.ConfirmAdjustmentModeValidationError, Is.True, "validation not set on Adjustment Mode");
                Assert.That(newAdjustment.ConfirmAdustmentCodeValidationError, Is.True, "validation not set on Adjustment Code");
                Assert.That(newAdjustment.ConfirmInvestmentBankerValidationError, Is.True, "validation not set on investment banker");

            });
        }
        [Then(@"\[Smith should see an error message indicating invalid date format]")]
        public void ThenSmithShouldSeeAnErrorMessageIndicatingInvalidDateFormat()
        {

            Assert.Multiple(() =>
            {
                Assert.That(newAdjustment.ConfirmStartDateValidationError, Is.True, "validation not set on start date");
                Assert.That(newAdjustment.ConfirmEndDateValidationError, Is.True, "validation not set on end date");

            });
        }

        [Then(@"display a popup indicicating Adjustment Code a duplicate")]
        public void ThenDisplayAPopupIndicicatingAdjustmentCodeADuplicate()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driverHelper.Driver);

            fluentWait.Timeout = TimeSpan.FromSeconds(60);

            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            fluentWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(newAdjustment.DuplicateAdjustmentCode)));
            Assert.That(newAdjustment.ConfirmDuplicateAdjustmentCode, Is.True, "Adjustment code must not allow for duplicates ");
        }


    }
}