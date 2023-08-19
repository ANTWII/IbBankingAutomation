
using OpenQA.Selenium;
using InvestmentBankingAutomation.Extensions;


namespace InvestmentBankingAutomation.Pages
{
    internal class CommissonCyclePage
    {
        private IWebDriver Driver;
        WebElementExtensions _WebElementExtensions;
        public CommissonCyclePage(IWebDriver driver)
        {
            Driver = driver;
            _WebElementExtensions = new WebElementExtensions(Driver);
        }


        //Add Page Locators
        public string commissionCycleMenu = "//span[normalize-space()='Commission Cycle']";
        public IWebElement CommissionCycleMenu => Driver.FindElement(By.XPath(commissionCycleMenu));
        public IWebElement CoverageStartDate => Driver.FindElement(By.XPath("//div[@id='cov_StartDate']//input[@role='combobox']"));
        public IWebElement CoverageEndDate => Driver.FindElement(By.XPath("//div[@id='cov_EndDate']//input[@role='combobox']"));

        public IWebElement StartDate => Driver.FindElement(By.XPath("//div[@id='startDate']//input[@role='combobox']"));
        public IWebElement EndDate => Driver.FindElement(By.XPath("//div[@id='endDate']//input[@role='combobox']"));
        public IWebElement CommisionCycleAddButton => Driver.FindElement(By.XPath("//button[@id='btnAdd']"));
        public IWebElement StartdateValidation => Driver.FindElement(By.XPath("//div[text()='Please Enter Start Date']"));
        public IWebElement EnddateValidation => Driver.FindElement(By.XPath("//div[text()='Please Enter End Date']"));
        public IWebElement okPopup => Driver.FindElement(By.XPath("//span[text()='OK']"));

        //div[text()='Please Enter End Date']

        //Search grid Locators 
        public string CommGridCol = "//*[@id='gridComCycle']//descendant::table[2]/tbody/tr/td";
        public string CommGridRow = "//*[@id='gridComCycle']//descendant::table[2]/tbody/tr";
        public string CommGridtable = "//*[@id='gridComCycle']//descendant::table[2]";
        public IWebElement tableElement => Driver.FindElement(By.XPath(CommGridtable));
        public IList<IWebElement> CommtableRow => tableElement.FindElements(By.XPath(CommGridRow));
        public IList<IWebElement> CommtableCol => tableElement.FindElements(By.XPath(CommGridCol));


        //Funtion which returns grid data in everry row ad column
        // verification
        public List<string> ValidateCommissionCycleGridData() => _WebElementExtensions.ValidateGridData(CommtableRow, CommtableCol);

        //Method to handle Add 
        public void CommCoverageEndDate(string coverageEndDate) => CoverageEndDate.SendKeys(coverageEndDate);
        public void CommEndDate(string endDate) => EndDate.SendKeys(endDate);

        public void CommStartDate(string startDate)

        {
            StartDate.Clear();
            StartDate.SendKeys(startDate);
        }
        public void CommCoverageStartDate(string coverageStartDate)

        {
            CoverageStartDate.Clear();
            CoverageStartDate.SendKeys(coverageStartDate);
        }
           
       



        
        public void ClickAddButton() => CommisionCycleAddButton.Click();
        public void ClickCommissionMenu() => CommissionCycleMenu.Click();

        //Verrification
        public bool ComCycleGridResultsDisplay => _WebElementExtensions.IsGridDisplayData(CommtableRow, CommtableCol);
        public bool CycledateExist => _WebElementExtensions.IsElementPresent(okPopup);

        public void AssertCycledateExist() => _WebElementExtensions.AssertElementPresent(okPopup);
        public bool EnddateRequiredValidation => EnddateValidation.Displayed;


       
    }
}
