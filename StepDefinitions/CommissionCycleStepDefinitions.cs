
using TechTalk.SpecFlow.Assist;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using InvestmentBankingAutomation.Pages;
using InvestmentBankingAutomation.Drivers;

namespace InvestmentBankingAutomation.StepDefinitions
{
    [Binding]
    public class CommissionCycleStepDefinitions
    {

        CommissonCyclePage NewCommissionCycle;
        private DriverHelper _driverHelper;
        private readonly ScenarioContext _scenarioContext;

        public CommissionCycleStepDefinitions(DriverHelper driverHelper, ScenarioContext scenarioContext)
        {
            _driverHelper = driverHelper;

            NewCommissionCycle = new CommissonCyclePage(_driverHelper.Driver);
            _scenarioContext = scenarioContext;

        }




        [Given(@"smith clicked on the CommissionCycle Menu")]
        public void GivenSmithClickedOnTheCommissionCycleMenu()
        {
            WebDriverWait Wait = new WebDriverWait(_driverHelper.Driver, TimeSpan.FromSeconds(80));

            Wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(NewCommissionCycle.commissionCycleMenu)));

            NewCommissionCycle.ClickCommissionMenu();
        }

        [Given(@"Smith entered the folllowng CommissionCycle date details")]
        public void GivenSmithEnteredTheFolllowngCommissionCycleDateDetails(Table table)
        {
            dynamic data = table.CreateDynamicSet();
            foreach (var userData in data)
            {

                if (userData.startDate == "faker_startdate") userData.startDate = Faker.Finance.Maturity(1, 12).ToString("MM/dd/yyyy");
                else userData.startDate = userData.startDate;
                if (userData.endDate == "faker_enddate") userData.endDate = Faker.Finance.Maturity(12, 36).ToString("MM/dd/yyyy");
                else userData.endDate = userData.endDate;
                if (userData.coverageStartDate == "faker_Coveragestartdate") userData.coverageStartDate = Faker.Finance.Maturity(1, 12).ToString("MM/dd/yyyy");
                else userData.coverageStartDate = userData.coverageStartDate;
                if (userData.coverageEndDate == "faker_Coverageenddate") userData.coverageEndDate = Faker.Finance.Maturity(12, 36).ToString("MM/dd/yyyy");
                else userData.coverageEndDate = userData.coverageEndDate;

                userData.startDate = Convert.ToString(userData.startDate);
                userData.endDate = Convert.ToString(userData.endDate);
                userData.coverageStartDate = Convert.ToString(userData.coverageStartDate);
                userData.coverageEndDate = Convert.ToString(userData.coverageEndDate);

                if (!string.IsNullOrEmpty(userData.startDate)) NewCommissionCycle.CommStartDate(userData.startDate);
                if (!string.IsNullOrEmpty(userData.endDate)) NewCommissionCycle.CommEndDate(userData.endDate);
                if (!string.IsNullOrEmpty(userData.coverageStartDate)) NewCommissionCycle.CommCoverageStartDate(userData.coverageStartDate);
                if (!string.IsNullOrEmpty(userData.coverageEndDate)) NewCommissionCycle.CommCoverageEndDate(userData.coverageEndDate);
                // create an array with 4 elements
                string[] CommCycle = new string[] { userData.startDate, userData.endDate, userData.coverageStartDate, userData.coverageEndDate }; 


                _scenarioContext["userData"] = CommCycle;

            }
        }

        [When(@"\[Smith clicks on the Add button ON CommissionCycle add screen]")]
        public void WhenSmithClicksOnTheAddButtonONCommissionCycleAddScreen()
        {
            NewCommissionCycle.ClickAddButton();
        }

        [Then(@"\[Smith should see the Added CommissionCycle  grid results]")]
        public void ThenSmithShouldSeeTheAddedCommissionCycleGridResults()
        {
            dynamic actualData = _scenarioContext["userData"];

            //DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driverHelper.Driver);

            //fluentWait.Timeout = TimeSpan.FromSeconds(60);

            //fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            //fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            //fluentWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(NewCommissionCycle.CommGridCol)));

            Thread.Sleep(5000);
            foreach (var userData in actualData)
            {
               

              

                if (!string.IsNullOrEmpty(userData)) Assert.Contains((userData.Substring(0, 10).Trim()), NewCommissionCycle.ValidateCommissionCycleGridData());


            }

            
        }
        
        [Then(@"\[Smith should see the Endate  date  required field validation error]")]
        public void ThenSmithShouldSeeTheEndateDateRequiredFieldValidationError()
        {
            Assert.That(NewCommissionCycle.EnddateRequiredValidation, Is.True, "validation not set on End date ");
        }
    

    }
}
