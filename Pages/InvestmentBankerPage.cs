
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using InvestmentBankingAutomation.Extensions;

using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;

namespace InvestmentBankingAutomation.Pages
{
    internal class InvestmentBankerPage
    {
        private IWebDriver Driver;
        WebElementExtensions _WebElementExtensions;

        public InvestmentBankerPage(IWebDriver driver)
        {
            Driver = driver;
            _WebElementExtensions = new WebElementExtensions(Driver);
        }


        //Search InvestentBanker Page Locators
        public string searchBtn   = "//button[@id='btnSearchBanker']";
        public string addBtn = "//button[@id='btnAddInv']";
        public string investmentBankerMenu = "//i[@title='Investment Banker']";
        public string btnGridEdit = "//a[ contains(text(),'Edit')]";

        public IWebElement InvestmentBankerMenu => Driver.FindElement(By.XPath("//i[@title='Investment Banker']"));
        public IWebElement InvestmentBankerType => Driver.FindElement(By.XPath("//Select[@id='drpstatusType']"));
        public IWebElement InvestmentBankerStatus => Driver.FindElement(By.XPath("//Select[@id='tblstatus']"));
        public IWebElement InvestmentBankerLastName => Driver.FindElement(By.XPath("//input[@id='tblLastName']"));
        public IWebElement InvestmentBankerFirstName => Driver.FindElement(By.XPath("//input[@id='tblFirstName']"));
        public IWebElement InvestmentBankerSSN => Driver.FindElement(By.XPath("//input[@id='tblSSN']"));
        public IWebElement InvestmentBankerSearchButton => Driver.FindElement(By.XPath(searchBtn));
        public IWebElement InvestmentBankerResetButton => Driver.FindElement(By.XPath("//button[@type='reset']"));
        public IWebElement InvestmentBankerAddButton => Driver.FindElement(By.XPath(addBtn));

        //Add Investment banker page Locator
        public string EmailTextbox = "//input[contains(@id,'_Email')]";
        public IWebElement IBroleDropdown_Add => Driver.FindElement(By.XPath(" //input[contains(@id,'_TypeCode')]"));
        public IWebElement IBSupervisorDropdown_Add => Driver.FindElement(By.XPath(" //input[contains(@id,'_SupervisorId')]"));

        public IWebElement Status_Add => Driver.FindElement(By.XPath("//input[contains(@id,'_Status')] "));
        public IWebElement Status_Validation => Driver.FindElement(By.XPath("//input[contains(@id,'_Status')and @aria-invalid='true'] "));
        public IWebElement Lastname_Add => Driver.FindElement(By.XPath(" //input[contains(@id,'_LastName')] "));
        public IWebElement Lastname_Validation => Driver.FindElement(By.XPath(" //input[contains(@id,'_LastName')and @aria-invalid='true'] "));
        public IWebElement Email_Add => Driver.FindElement(By.XPath(EmailTextbox));
        public IWebElement Email_Validation => Driver.FindElement(By.XPath("//input[contains(@id,'_Email')and @aria-invalid='true']"));
      
        public IWebElement IBFname => Driver.FindElement(By.XPath("//input[contains(@id,'_FirstName')]"));
        public IWebElement IBMiddleName => Driver.FindElement(By.XPath("//input[contains(@id,'_MiddleName')]"));
        public IWebElement IBNickName => Driver.FindElement(By.XPath("//input[contains(@id,'_NickName')]"));
        public IWebElement IBDOB => Driver.FindElement(By.XPath("//input[contains(@id,'_DOB')]"));
        public IWebElement IBHireDate => Driver.FindElement(By.XPath("//input[contains(@id,'_HiredDate')]"));
        public IWebElement IBTerminatedDate => Driver.FindElement(By.XPath("//input[contains(@id,'_TerminatedDate')]"));

        public IWebElement IBDOB_Validation => Driver.FindElement(By.XPath("//input[contains(@id,'_DOB')and @aria-invalid='true']"));
        public IWebElement IBHireDate_Validation => Driver.FindElement(By.XPath("//input[contains(@id,'_HiredDate')and @aria-invalid='true']"));
        public IWebElement IBTerminatedDate_Validation => Driver.FindElement(By.XPath("//input[contains(@id,'_TerminatedDate')and @aria-invalid='true']"));

        public IWebElement IBEmployeeNum => Driver.FindElement(By.XPath("//input[contains(@id,'_AltAgent')]"));

        string _IBHomePhone ="//span[contains(text(),'Home Phone')]//following::div[4]//descendant::input";
        string _IBWorkPhone = "//span[contains(text(),'Work Phone')]//following::div[4]//descendant::input";
        public IWebElement IBHomePhone => Driver.FindElement(By.XPath(_IBHomePhone));
        public IWebElement IBWorkPhone => Driver.FindElement(By.XPath(_IBWorkPhone));

        public IWebElement IBFax => Driver.FindElement(By.XPath("//input[contains(@id,'_FaxNumber')]"));
        public IWebElement IBCellNumber => Driver.FindElement(By.XPath("//input[contains(@id,'_PagerNumber')]"));
        public IWebElement IBAddress => Driver.FindElement(By.XPath("//input[contains(@id,'_AddressLine1')]"));
        public IWebElement IBSSN => Driver.FindElement(By.XPath("//input[contains(@id,'_SSN')]"));
        public IWebElement IBCity => Driver.FindElement(By.XPath("//input[contains(@id,'_City')]"));
        public IWebElement IBState => Driver.FindElement(By.XPath("//input[contains(@id,'_State')]"));
        public IWebElement IBZip => Driver.FindElement(By.XPath("//input[contains(@id,'_ZipCode')]"));


        public IWebElement Save_Add => Driver.FindElement(By.XPath("//span[normalize-space()='Save']"));





        // search investment Banker grid Locators 
        //Search grid Locators 
        public string mainIVBGridCol = "//*[@id='gridInvBanker']//descendant::table[2]/tbody/tr/td";
        public string mainIVBGridRow = "//*[@id='gridInvBanker']//descendant::table[2]/tbody/tr";
        public string mainIVBGridtable = "//*[@id='gridInvBanker']//descendant::table[2]";
        public IWebElement tableElement => Driver.FindElement(By.XPath(mainIVBGridtable));
      public  IList<IWebElement> tableRow => tableElement.FindElements(By.XPath(mainIVBGridRow));
        public IList<IWebElement> tableCol => tableElement.FindElements(By.XPath(mainIVBGridCol));
        public List<string> ValidateSearchIVBankerGridData()
        {

            return _WebElementExtensions.ValidateGridData(tableRow, tableCol);


        }






        //Method to handle search 
       
        public void enterLastName_Search(string LastName) => InvestmentBankerLastName.SendKeys(LastName);
        public void enterFirstName_Search(string FirstName) => InvestmentBankerFirstName.SendKeys(FirstName);
        public void enterSSN_Search(string SSN) => InvestmentBankerSSN.SendKeys(SSN);
        public void InvestmentBankerType_Search(string IBTypeValue) => _WebElementExtensions.SelectDropdownByText(InvestmentBankerType, IBTypeValue);
        public void InvestmentBankerStatus_Search(string IBStatusValue) => _WebElementExtensions.SelectDropdownByText(InvestmentBankerStatus, IBStatusValue);

        

        //Method to handle Add 
        public void enterLastName_Add(string LastName) => Lastname_Add.SendKeys(LastName);
        public void enterEmail_Add(string Email) => Email_Add.SendKeys(Email);
        public void InvestmentBankerStatus_Add(string IBStatusValue) => _WebElementExtensions.DropdownControl(Status_Add, IBStatusValue);
        public void InvestmentBankerRole_Add(string IBrolE) => _WebElementExtensions.DropdownControl(IBroleDropdown_Add, IBrolE);
        public void Supervisor_Add(string IBSupervisor) => _WebElementExtensions.DropdownControl(IBSupervisorDropdown_Add, IBSupervisor);

        public void enterFirstName_Add(string IBFnamE) => IBFname.SendKeys(IBFnamE);
        public void enterMiddleName_Add(string IBMiddleNamE) => IBMiddleName.SendKeys(IBMiddleNamE);
        public void enterNickName_Add(string IBNickNamE) => IBNickName.SendKeys(IBNickNamE);
        public void enterDOB_Add(string iBDOb) => IBDOB.SendKeys(iBDOb);
        public void enterIBHireDate_Add(string iBHireDate) => IBHireDate.SendKeys(iBHireDate);
        public void enterIBTerminatedDate_Add(string iBTerminatedDatE) => IBTerminatedDate.SendKeys(iBTerminatedDatE);
        public void enterIBEmployeeNum_Add(string IBEmployeeNuM) => IBEmployeeNum.SendKeys(IBEmployeeNuM);
        public void clickIBHomePhone_Add() => IBHomePhone.Click();
        public void enterIBHomePhone_Add(string IBHomePhonE) => IBHomePhone.SendKeys(IBHomePhonE);
        public void clickIBWorkPhone_Add() => IBWorkPhone.Click();
        public void enterIBWorkPhone_Add(string IBWorkPhonE) => IBWorkPhone.SendKeys(IBWorkPhonE);
        public void enterIBFax_Add(string IBFaX) => IBFax.SendKeys(IBFaX);
        public void enterIBCellNumber_Add(string IBCellNumbeR) => IBCellNumber.SendKeys(IBCellNumbeR);
        public void enterIBAddress_Add(string IBAddresS) => IBAddress.SendKeys(IBAddresS);
        public void enterIBSSN_Add(string IBSSn) => IBSSN.SendKeys(IBSSn);
        public void enterIBCitY_Add(string IBCitY) => IBCity.SendKeys(IBCitY);
        public void enterIBStatE_Add(string IBStatE) => IBState.SendKeys(IBStatE);
        public void enterIBZiP_Add(string IBZiP) => IBZip.SendKeys(IBZiP);




      


        //methods to handle submit and click events
        public void ClickSearchButton() => InvestmentBankerSearchButton.Submit();
        public void ClickResetButton() => InvestmentBankerResetButton.Click();
        public void ClickAddButton() => InvestmentBankerAddButton.Click();
        public void ClickInvestmentBankerMenu() => InvestmentBankerMenu.Click();
        public void ClickSave_add() => Save_Add.Click();

        // verification
        public bool IVBankersGridResultsDisplay => _WebElementExtensions.IsGridDisplayData(tableRow, tableCol);
        public bool ConfirminEmailValidationError => _WebElementExtensions.IsElementPresent(Email_Validation);
        public bool ConfirminLastnamelValidationError => _WebElementExtensions.IsElementPresent(Lastname_Validation);
        public bool ConfirminStatusValidationError => _WebElementExtensions.IsElementPresent(Status_Validation);
        public bool ConfirminDOBValidationError => _WebElementExtensions.IsElementPresent(IBDOB_Validation);
        public bool ConfirminHireDateValidationError => _WebElementExtensions.IsElementPresent(IBHireDate_Validation);
        public bool ConfirminTerminatedDateValidationError => _WebElementExtensions.IsElementPresent(IBTerminatedDate_Validation);
    }
}

