
using TechTalk.SpecFlow.Assist;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using InvestmentBankingAutomation.Pages;
using InvestmentBankingAutomation.Drivers;
using Bogus;
using Faker;
namespace InvestmentBankingAutomation.StepDefinitions
{
    [Binding]
    public class InvestentBankerStepDefinitions
    {

        InvestmentBankerPage newInvestmentBanker;
        private DriverHelper _driverHelper;
        private readonly ScenarioContext _scenarioContext;

        public InvestentBankerStepDefinitions(DriverHelper driverHelper, ScenarioContext scenarioContext)
        {
            _driverHelper = driverHelper;

            newInvestmentBanker = new InvestmentBankerPage(_driverHelper.Driver);
            _scenarioContext = scenarioContext;

        }

        [Given(@"smith clicked on the InvestentBanker Menu")]
        public void GivenSmithClickedOnTheInvestentBankerMenu()
        {
            WebDriverWait Wait = new WebDriverWait(_driverHelper.Driver, TimeSpan.FromSeconds(80));

            Wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(newInvestmentBanker.investmentBankerMenu)));


            newInvestmentBanker.ClickInvestmentBankerMenu();
        }

        [Given(@"Smith entered the following Search Investment Banker details")]
        public void GivenSmithEnteredTheFollowingSearchInvestmentBankerDetails(Table table)
        {
            dynamic data = table.CreateDynamicSet();
            _scenarioContext["userData"] = data;
            foreach (var userData in data)
            {
                WebDriverWait Wait = new WebDriverWait(_driverHelper.Driver, TimeSpan.FromSeconds(60));
                Wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
                Wait.Until(ExpectedConditions.ElementExists(By.XPath(newInvestmentBanker.searchBtn)));

               

                newInvestmentBanker.enterLastName_Search(userData.IBLastName);
                newInvestmentBanker.enterFirstName_Search(userData.IBFirstName);
                newInvestmentBanker.enterSSN_Search(Convert.ToString(userData.IBSSN));
                newInvestmentBanker.InvestmentBankerType_Search(userData.IBRole);
                newInvestmentBanker.InvestmentBankerStatus_Search(userData.IBStatus);


            }

        }
    

        [When(@"\[Smith cliks Search on Investment banker]")]
        public void WhenSmithCliksSearchOnInvestmentBanker()
        {
        newInvestmentBanker.ClickSearchButton();
        }

        [Then(@"\[Smith should see investment banker grid search results]")]
        public void ThenSmithShouldSeeInvestmentBankerGridSearchResults()
        {

            dynamic actualData = _scenarioContext["userData"];


            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driverHelper.Driver);

            fluentWait.Timeout = TimeSpan.FromSeconds(60);

            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            fluentWait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.XPath(newInvestmentBanker.mainIVBGridCol), "Edit"));
            fluentWait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(newInvestmentBanker.btnGridEdit)));

            Assert.That(newInvestmentBanker.IVBankersGridResultsDisplay, Is.True, "Grid does not contain data");




            //WebDriverWait Wait = new WebDriverWait(_driverHelper.Driver, TimeSpan.FromSeconds(60));
            //Wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            //Wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.XPath(newInvestmentBanker.mainIVBGridCol),"Edit"));
            //Assert.That(newInvestmentBanker.IVBankersGridResultsDisplay, Is.True, "Grid does not contain data");



        }
        [Then(@"\[Smith should see a message indicating that no results were found]")]
        public void ThenSmithShouldSeeAMessageIndicatingThatNoResultsWereFound()
        {
            Assert.That(newInvestmentBanker.IVBankersGridResultsDisplay, Is.False, "Grid  contain data");
            
        }

        //Add investment Banker
        [Given(@"Smith clicked on the Add InvestmentBanker Button")]
        public void GivenSmithClickedOnTheAddInvestmentBankerButton()
        {
            newInvestmentBanker.ClickAddButton();
        }

        [Given(@"Smith entered the folllowng Add InvestmentBanker details")]
        public void GivenSmithEnteredTheFolllowngAddInvestmentBankerDetails(Table table)
        {
            dynamic data = table.CreateDynamicSet();
            _scenarioContext["userData"] = data;
            WebDriverWait Wait = new WebDriverWait(_driverHelper.Driver, TimeSpan.FromSeconds(60));
            Wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            Wait.Until(ExpectedConditions.ElementExists(By.XPath(newInvestmentBanker.EmailTextbox)));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(newInvestmentBanker.addBtn)));

            foreach (var userData in data)
            {

                // Enter the valid inputs in the form
                // Note: The data in this table is generated using .NET Faker
                if (userData.IBLastName == "faker_LastName") userData.IBLastName = Faker.Name.Last();
                else userData.IBLastName = userData.IBLastName;

                if (userData.IBFname == "faker_FirstName") userData.IBFname = Faker.Name.First();
                else userData.IBFname = userData.IBFname;

                if (userData.IBMiddleName == "faker_MiddleName") userData.IBMiddleName = Faker.Name.Middle();
                else userData.IBMiddleName = userData.IBMiddleName;

                if (userData.IBEmail == "faker_Email") userData.IBEmail = Faker.Internet.Email();
                else userData.IBEmail = userData.IBEmail;

                if (userData.IBNickName == "faker_NickName") userData.IBNickName = Faker.Name.First();
                else userData.IBNickName = userData.IBNickName;

                if (userData.IBEmployeeNum == "faker_EmployeeNum") userData.IBEmployeeNum = Faker.RandomNumber.Next(100,1000).ToString();
                else userData.IBEmployeeNum = userData.IBEmployeeNum;

                if (userData.IBHomePhone == "faker_HomePhone") userData.IBHomePhone = Faker.Phone.Number().ToString();
                else userData.IBHomePhone = userData.IBHomePhone;


                if (userData.IBWorkPhone == "faker_WorkPhone") userData.IBWorkPhone = Faker.Phone.Number().ToString();
                else userData.IBWorkPhone = userData.IBWorkPhone;

                 if (userData.IBFax == "faker_Fax") userData.IBFax = Faker.Phone.Number().ToString();
                else userData.IBFax = userData.IBFax;

                if (userData.IBCellNumber == "faker_CellNmber") userData.IBCellNumber = Faker.Phone.Number().ToString();
                else userData.IBCellNumber = userData.IBCellNumber;

                if (userData.IBAddress == "faker_Address") userData.IBAddress = Faker.Address.StreetAddress();
                else userData.IBAddress = userData.IBAddress;

                if (userData.IBSSN == "faker_SSN") userData.IBSSN = Faker.Identification.SocialSecurityNumber().ToString();
                else userData.IBSSN = userData.IBSSN;

                if (userData.IBCity == "faker_City") userData.IBCity = Faker.Address.City();
                else userData.IBCity = userData.IBCity;

                if (userData.IBState == "faker_State") userData.IBState = Faker.Address.UsState();
                else userData.IBState = userData.IBState;

                if (userData.IBZip == "faker_ZIP") userData.IBZip = Faker.Address.ZipCode().ToString();
                else userData.IBZip = userData.IBZip;

                if (userData.IBDOB == "faker_DOB") userData.IBDOB = Faker.Identification.DateOfBirth().ToString("MM/dd/yyyy");
                else userData.IBDOB = userData.IBDOB;

                if (userData.IBHireDate == "faker_HireDate") userData.IBHireDate = Faker.Finance.Maturity(1, 12).ToString("MM/dd/yyyy");
                else userData.IBHireDate = userData.IBHireDate;

                if (userData.IBTerminatedDate == "faker_TerminatedDate") userData.IBTerminatedDate = Faker.Finance.Maturity(12, 36).ToString("MM/dd/yyyy");
                else userData.IBTerminatedDate = userData.IBTerminatedDate;

                newInvestmentBanker.enterLastName_Add(userData.IBLastName);

                

                newInvestmentBanker.enterEmail_Add(userData.IBEmail);
                newInvestmentBanker.InvestmentBankerStatus_Add(userData.IBStatus);
                newInvestmentBanker.InvestmentBankerRole_Add(userData.IBrole);
                newInvestmentBanker.enterFirstName_Add(userData.IBFname);
                newInvestmentBanker.enterMiddleName_Add(userData.IBMiddleName);
                newInvestmentBanker.enterNickName_Add(userData.IBNickName);
              
                newInvestmentBanker.enterIBEmployeeNum_Add(userData.IBEmployeeNum);
                newInvestmentBanker.clickIBHomePhone_Add();
                newInvestmentBanker.enterIBHomePhone_Add(userData.IBHomePhone);
                newInvestmentBanker.clickIBWorkPhone_Add();
                newInvestmentBanker.enterIBWorkPhone_Add(userData.IBWorkPhone);
                newInvestmentBanker.enterIBFax_Add((userData.IBFax));
                newInvestmentBanker.enterIBCellNumber_Add(userData.IBCellNumber);
                newInvestmentBanker.enterIBAddress_Add(userData.IBAddress);
                newInvestmentBanker.enterIBSSN_Add(userData.IBSSN);
                newInvestmentBanker.enterIBCitY_Add(userData.IBCity);
                newInvestmentBanker.enterIBStatE_Add(userData.IBState);
                newInvestmentBanker.enterIBZiP_Add(userData.IBZip);
                newInvestmentBanker.Supervisor_Add(userData.Supervisor);
                if (!string.IsNullOrEmpty(userData.IBDOB)) newInvestmentBanker.enterDOB_Add(userData.IBDOB);
                if (!string.IsNullOrEmpty(userData.IBHireDate)) newInvestmentBanker.enterIBHireDate_Add(userData.IBHireDate);
                if (!string.IsNullOrEmpty(userData.IBTerminatedDate)) newInvestmentBanker.enterIBTerminatedDate_Add(userData.IBTerminatedDate);

               
            }
        }

        [When(@"\[Smith clicks on the save button ON InvesmentBanker add screen]")]
        public void WhenSmithClicksOnTheSaveButtonONInvesmentBankerAddScreen()
        {
            newInvestmentBanker.ClickSave_add();

        }
        [Then(@"Smith should see an error message indicating that the email address is invalid")]
        public void ThenSmithShouldSeeAnErrorMessageIndicatingThatTheEmailAddressIsInvalid()
        {
            Assert.That(newInvestmentBanker.ConfirminEmailValidationError, Is.True, "validation not set on email");
        }
        [Then(@"Smith should see an error message indicating that the Lastname is required")]
        public void ThenSmithShouldSeeAnErrorMessageIndicatingThatTheLastnameIsInvalid()
        {
            Assert.That(newInvestmentBanker.ConfirminLastnamelValidationError, Is.True, "validation not set on Last name");
        }
        [Then(@"Smith should see an error message indicating that status is required")]
        public void ThenSmithShouldSeeAnErrorMessageIndicatingThatStatusIsRequired()
        {
            Assert.That(newInvestmentBanker.ConfirminStatusValidationError, Is.True, "validation not set on Status");
        }

        [Then(@"Smith should see an error message indicating that the dates are invalid")]
        public void ThenSmithShouldSeeAnErrorMessageIndicatingThatTheDatesAreInvalid()
        {
           

            Assert.Multiple(() =>
            {
                Assert.That(newInvestmentBanker.ConfirminDOBValidationError, Is.True, "validation not set on Date of birth");
                Assert.That(newInvestmentBanker.ConfirminHireDateValidationError, Is.True, "validation not set on Hire date");
                Assert.That(newInvestmentBanker.ConfirminTerminatedDateValidationError, Is.True, "validation not set on Terminated date");

            });
        }

    }
}
