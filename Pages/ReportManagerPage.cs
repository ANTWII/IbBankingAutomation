using InvestmentBankingAutomation.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace InvestmentBankingAutomation.Pages
{
    internal class ReportManagerPage
    {
        private IWebDriver Driver;
        WebElementExtensions _WebElementExtensions;
        public ReportManagerPage(IWebDriver driver)
        {
            Driver = driver;
            _WebElementExtensions = new WebElementExtensions(Driver);
        }

        public string reportManagerMenu = "//span[normalize-space()='Report Manager']";
        public string reportManagerMainPage = "//h4[normalize-space()='Report Manager']";
        public string LoadReport = "//td[contains(@id,'_oReportCell')]//following::div[contains(text(),'I22 Investment Banking')]";
        public string excelbuttonReport = "//button[@id='btnAddExcel']";
        public string pdfbuttonReport = "//button[@id='btnAddPDF']";
       
        public IWebElement ReportManagerMenu => Driver.FindElement(By.XPath(reportManagerMenu));
        public IWebElement ReportManagerMainPage => Driver.FindElement(By.XPath(reportManagerMainPage));
       public string collapseReport = "//div[contains(@id,'default_collapse')and contains(@class,'show')]";
        public IWebElement CollapseReport => Driver.FindElement(By.XPath(collapseReport));
        public IWebElement StartDate => Driver.FindElement(By.XPath(" //input[@id='reportParameter_SDT']"));
        public IWebElement EndtDate => Driver.FindElement(By.XPath("//input[@id='reportParameter_EDT']"));
        public IWebElement ProductMode => Driver.FindElement(By.XPath("//Select[@id='reportParameter_PM9']"));
        public IWebElement BankList => Driver.FindElement(By.XPath("//Select[@id='reportParameter_BKL']"));
        public IWebElement RunReportBtn => Driver.FindElement(By.XPath("//input[@id='runReportButton']"));
        public IWebElement OpenI22Report => Driver.FindElement(By.XPath(LoadReport));
        public IWebElement excelReport => Driver.FindElement(By.XPath(excelbuttonReport));
        public IWebElement pdfReport => Driver.FindElement(By.XPath(pdfbuttonReport));

        public IWebElement BranchList => Driver.FindElement(By.XPath("//Select[@id='reportParameter_BRL']"));
        public IWebElement ProductType => Driver.FindElement(By.XPath("//Select[@id='reportParameter_PM9']"));
        public IWebElement AgentList => Driver.FindElement(By.XPath("//Select[@id='reportParameter_AGL']"));
        public IWebElement DateType => Driver.FindElement(By.XPath("//Select[@id='reportParameter_PM0']"));
        public IWebElement AccountType => Driver.FindElement(By.XPath("//Select[@id='reportParameter_PM7']"));

        public IWebElement TradeType => Driver.FindElement(By.XPath("//Select[@id='reportParameter_PM8']"));
        public IWebElement DataFeedList => Driver.FindElement(By.XPath("//Select[@id='reportParameter_SRC']"));

        public IWebElement CycleDate => Driver.FindElement(By.XPath("//Select[@id='reportParameter_CDT']"));
        public IWebElement BankerList => Driver.FindElement(By.XPath("//Select[@id='reportParameter_AGL']"));







        public void SelectReportFolder(string text)
        {

            if (!string.IsNullOrEmpty(text))
                {
                     IWebElement ReportFolderType = Driver.FindElement(By.XPath($".//span[normalize-space()='{text}']")) ;
                     ReportFolderType.Click();

            }



        }
        
        public void SelectReport( string text)
        {

            if (!string.IsNullOrEmpty(text))
            {
              
                IWebElement ReportType = Driver.FindElement(By.XPath($" //div[contains(@id,'default_collapse')]//descendant::a[contains(text(),'{text}')]"));
                ReportType.Click();

            }



        }
        //Method to handle reports
        public void reportStartDate(string startDate) => StartDate.SendKeys(startDate);
        public void reportEndDate(string endDate) => EndtDate.SendKeys(endDate);

        public void reportProductMode(string productMode)=>   _WebElementExtensions.SelectDropdownByText(ProductMode, productMode);
        public void ReportBankList(string banklist) => _WebElementExtensions.SelectDropdownByText(BankList, banklist);
        public void reportbranchList(string branchlist) => _WebElementExtensions.SelectDropdownByText(BranchList, branchlist);
        public void reportproductType(string producttype) => _WebElementExtensions.SelectDropdownByText(ProductType, producttype);
        public void reportagentList(string agentlist) => _WebElementExtensions.SelectDropdownByText(AgentList, agentlist);
        public void reportdateType(string datetype) => _WebElementExtensions.SelectDropdownByText(DateType, datetype);
        public void reportaccountType(string accounttype) => _WebElementExtensions.SelectDropdownByText(AccountType, accounttype);
        public void reporttradeType(string tradetype) => _WebElementExtensions.SelectDropdownByText(TradeType, tradetype);
        public void reportdataFeedList(string dataFeedlist) => _WebElementExtensions.SelectDropdownByText(DataFeedList, dataFeedlist);

        public void reportCycleDate(string cycleDate) => _WebElementExtensions.SelectDropdownByText(CycleDate, cycleDate);
        public void reportBankerList(string bankerList) => _WebElementExtensions.SelectDropdownByText(BankerList, bankerList);


        public void ClickRunReport() => RunReportBtn.Click();

        //verification
        public bool ConfirmReportManagerPage => _WebElementExtensions.IsElementPresent(ReportManagerMainPage);
        public bool ConfirmReportLoad => _WebElementExtensions.IsElementPresent(OpenI22Report);
        public bool ConfirmExcelButton => _WebElementExtensions.IsElementPresent(excelReport);
        public bool ConfirmPdfButton => _WebElementExtensions.IsElementPresent(pdfReport);


    }
}
