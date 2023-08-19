
using OpenQA.Selenium;
using InvestmentBankingAutomation.Extensions;

namespace InvestmentBankingAutomation.Pages
{
    internal class HomePage
    {
        private IWebDriver Driver;
        WebElementExtensions _WebElementExtensions;
        public HomePage(IWebDriver driver)
        {
            Driver = driver;
            _WebElementExtensions = new WebElementExtensions(Driver);
        }
        public string welcomeHomePage = "//*[contains(text(),'Welcome to Investment Banking Module')]";
        public IWebElement homePage => Driver.FindElement(By.XPath(welcomeHomePage));

        public bool confirmHomePageExist() => _WebElementExtensions.IsElementPresent(homePage);
    }
}
