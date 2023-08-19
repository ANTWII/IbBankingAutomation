
using InvestmentBankingAutomation.Pages;
using InvestmentBankingAutomation.Drivers;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium;

namespace InvestmentBankingAutomation.StepDefinitions
{
    [Binding]
    public class HomeStepDefinitions
    {
        HomePage newHomepage;
        private DriverHelper _driverHelper;
        public HomeStepDefinitions(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;

            newHomepage = new HomePage(_driverHelper.Driver);

        }

        [Then(@"Smith should see welcome Investment Banking Module")]
        public void ThenSmithShouldSeeWelcomeInvestmentBankingModule()
        {
            WebDriverWait Wait = new WebDriverWait(_driverHelper.Driver, TimeSpan.FromSeconds(20));
            Wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            Wait.Until(ExpectedConditions.ElementExists(By.XPath(newHomepage.welcomeHomePage)));

            //Asser home page exits
           Assert.That(newHomepage.confirmHomePageExist, Is.True, "Homepage not loaded");
        }
    }
}
