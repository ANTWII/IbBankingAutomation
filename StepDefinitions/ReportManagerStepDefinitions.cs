
using TechTalk.SpecFlow.Assist;
using NUnit.Framework;
using OpenQA.Selenium;
using InvestmentBankingAutomation.Pages;
using InvestmentBankingAutomation.Drivers;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace InvestmentBankingAutomation.StepDefinitions
{
    [Binding]
    public class ReportManagerStepDefinitions
    {


        ReportManagerPage newReport;
        private DriverHelper _driverHelper;
        private readonly ScenarioContext _scenarioContext;

        public ReportManagerStepDefinitions(DriverHelper driverHelper, ScenarioContext scenarioContext)
        {
            _driverHelper = driverHelper;

            newReport = new ReportManagerPage(_driverHelper.Driver);
            _scenarioContext = scenarioContext;

        }

        [Given(@"Smith has navigated to the Report Manager page")]
        public void GivenSmithClickedOnTheReportManagerMenu()
        {
            WebDriverWait Wait = new WebDriverWait(_driverHelper.Driver, TimeSpan.FromSeconds(80));

            Wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(newReport.reportManagerMenu)));


            newReport.ReportManagerMenu.Click();
        }

        [Given(@"Smith is on the Report Manager page")]
        public void GivenSmithIsOnTheReportManagerPage()
        {
            Assert.That(newReport.ConfirmReportManagerPage, Is.True, "Report Page not loading");
        }

        [When(@"Smith selects the ""([^""]*)"" report folder")]
        public void WhenSmithSelectsTheReportFolder(string blotter)
        {
            WebDriverWait Wait = new WebDriverWait(_driverHelper.Driver, TimeSpan.FromSeconds(80));

            Wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(newReport.collapseReport)));

        }

        [When(@"Smith clicks on the ""([^""]*)"" report link")]
        public void WhenSmithClicksOnTheReportLink(string report)
        {
            newReport.SelectReport(report);
        }



        [When(@"Smith enters the following criteria on cancelation report:""([^""]*)"" ""([^""]*)"" ""([^""]*)""""([^""]*)""")]
        public void WhenSmithEntersTheFollowingCriteria(string StartDate, string EndDate, string ProductMode, string BankList)
        {
           
            if (!string.IsNullOrEmpty(StartDate)) newReport.reportStartDate(StartDate.Remove(10).Trim());
            if (!string.IsNullOrEmpty(EndDate)) newReport.reportEndDate(EndDate.Remove(10).Trim());
            newReport.reportProductMode(ProductMode);
            newReport.ReportBankList(BankList);

        }

        [When(@"Smith enters the following criteria on BankerMonthlyStatement report:""([^""]*)"" ""([^""]*)""")]
        public void WhenSmithEntersTheFollowingCriteriaOnBankerMonthlyStatementReport(string cycleDate, string bankerList)
        {
           
            newReport.reportCycleDate(cycleDate);
            newReport.reportBankerList(bankerList);

        }

        [When(@"Smith enters the following criteria on transaction blotter:""([^""]*)"" ""([^""]*)"" ""([^""]*)""""([^""]*)""""([^""]*)"" ""([^""]*)""""([^""]*)""""([^""]*)""""([^""]*)""""([^""]*)""")]
        public void WhenSmithEntersTheFollowingCriteriaOnTransactionBlotter(string StartDate, string EndDate, string ProductType, string BankList, string AgentList,string DateType, string AccountType, string TradeType, string DatafeedList, string BranchList)
        {
            if (!string.IsNullOrEmpty(StartDate)) newReport.reportStartDate(StartDate.Remove(10).Trim());
            if (!string.IsNullOrEmpty(EndDate)) newReport.reportEndDate(EndDate.Remove(10).Trim());
            newReport.reportproductType(ProductType);
            newReport.ReportBankList(BankList);
            newReport.reportbranchList(BranchList);
            newReport.reportagentList(AgentList);
            newReport.reportdateType(DateType);
            newReport.reportaccountType(AccountType);
            newReport.reporttradeType(TradeType);
            newReport.reportdataFeedList(DatafeedList);
        }


        [When(@"Smith clicks on the Run report button")]
        public void WhenSmithClicksOnTheButton()
        {
            

            newReport.ClickRunReport();

        }

        [Then(@"the report should load and display I22 Investment Banking")]
        public void ThenTheCancelationReportShouldLoadAndDisplayTheCancelationDataWithinTheSpecifiedDateRange()
        {
            // Store the current window handle
            string mainWindowHandle = _driverHelper.Driver.CurrentWindowHandle;


            // Get all the open window handles
            ReadOnlyCollection<string> windowHandles = _driverHelper.Driver.WindowHandles;

            foreach (string windowHandle in windowHandles)
            {
                if (windowHandle != mainWindowHandle)
                {
                    _driverHelper.Driver.SwitchTo().Window(windowHandle);

                 

                    // Get the URL of the new tab
                    //string newUrl = _driverHelper.Driver.Url;
                    //Console.WriteLine(newUrl);
                    DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driverHelper.Driver);

                    fluentWait.Timeout = TimeSpan.FromSeconds(60);

                    fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
                    fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
                    fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(newReport.excelbuttonReport)));

                   


                    Assert.Multiple(() =>
                    {
                        Assert.That(newReport.ConfirmExcelButton, Is.True, "Report Not Loaded");
                        Assert.That(newReport.ConfirmPdfButton, Is.True, "Report Not Loaded");
                       // Assert.That(newReport.ConfirmReportLoad, Is.True, "Report Not Loaded");

                    });
                    // Close the new tab
                    _driverHelper.Driver.Close();
                    break;
                }
            }
            // Switch back to the original tab
            _driverHelper.Driver.SwitchTo().Window(mainWindowHandle);

           






        }
    }
}
