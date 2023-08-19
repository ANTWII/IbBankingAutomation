using InvestmentBankingAutomation.Extensions;
using OpenQA.Selenium;


namespace InvestmentBankingAutomation.Pages
{
    internal class CommissionSetup
    {

        private IWebDriver Driver;
        WebElementExtensions _WebElementExtensions;

        public CommissionSetup(IWebDriver driver)
        {
            Driver = driver;
            _WebElementExtensions = new WebElementExtensions(Driver);
        }

        public string commissionSetupMenu = "//span[normalize-space()='Commission Setup']";
        public IWebElement CommissionSetupMenu => Driver.FindElement(By.XPath(commissionSetupMenu));
        public IWebElement GeneralRole => Driver.FindElement(By.XPath("//a[normalize-space()='General Role']"));
        public IWebElement IndividualBanker => Driver.FindElement(By.XPath("//a[normalize-space()='Individual Banker']"));

        public IWebElement ClickAddBakerRoleLink => Driver.FindElement(By.XPath("//a[contains(text(),' Add Banker Role')]"));

    }
}
