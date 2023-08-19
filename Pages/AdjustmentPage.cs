
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using InvestmentBankingAutomation.Extensions;

using OpenQA.Selenium.Chrome;

namespace InvestmentBankingAutomation.Pages
{
    internal class AdjustmentPage
    {
        private IWebDriver Driver;
        WebElementExtensions _WebElementExtensions;

        public AdjustmentPage(IWebDriver driver)
        {
            Driver = driver;
            _WebElementExtensions = new WebElementExtensions(Driver);
        }

        public string adjustmentMenu = "//span[normalize-space()='Adjustment']";

        public IWebElement AdjustmentMenu => Driver.FindElement(By.XPath(adjustmentMenu));
        public IWebElement AdjustmentMode => Driver.FindElement(By.XPath("//Select[@id='drpMode']"));
        public IWebElement AdjustmentCycleStartDate => Driver.FindElement(By.XPath("//input[@id='txtStartDate']"));
        public IWebElement AdjustmentCycleEndtDate => Driver.FindElement(By.XPath("//input[@id='txtEndDate']"));

        public IWebElement InvestmentBanker => Driver.FindElement(By.XPath("//Select[@id='drpInvestmentBanker']"));
        public IWebElement AdjustmentCode => Driver.FindElement(By.XPath("//Select[@id='drpAdjCode']"));
        public IWebElement AdjustmentSearchButton => Driver.FindElement(By.XPath("//button[@id='btnSearchAdjustment']"));
        public IWebElement AdjustmentResetButton => Driver.FindElement(By.XPath("//button[@type='reset']"));
        public IWebElement AdjustmentAddButton => Driver.FindElement(By.XPath("//button[normalize-space()='Add Adjustment']"));
        public IWebElement AdjustmentCode_AddButton => Driver.FindElement(By.XPath("//button[normalize-space()='Adjustment Codes']"));

        // Add Adjustment Page Locators
        string enddate = "//input[contains(@id,'_EndDate')]";
        string startdate = "//input[contains(@id,'_StartDate')]";
       public string DuplicateAdjustmentCode = "//div[text()='Duplicate found']";
        public IWebElement AdjustmentCode_Add => Driver.FindElement(By.XPath("//input[contains(@id,'_AdjCodeID')]"));
        public IWebElement AdjustmentCode_Add_Validation => Driver.FindElement(By.XPath("//input[contains(@id,'_AdjCodeID') and @aria-invalid='true']"));

        public IWebElement AdjustmentMode_Add => Driver.FindElement(By.XPath("//input[contains(@id,'_ErrMiscMode')]"));
        public IWebElement AdjustmentMode_Add_Validation => Driver.FindElement(By.XPath("//input[contains(@id,'_ErrMiscMode')and @aria-invalid='true']"));
        public IWebElement Amount_Add => Driver.FindElement(By.XPath("//label[contains(@for,'_AdjAmt')]//following::input[2]"));
        public IWebElement StartDate_Add => Driver.FindElement(By.XPath(startdate));
        public IWebElement EndDate_Add => Driver.FindElement(By.XPath(enddate));

        public IWebElement StartDate_Add_Validation => Driver.FindElement(By.XPath("//input[contains(@id,'_StartDate')and @aria-invalid='true']"));
        public IWebElement EndDate_Add_Validation => Driver.FindElement(By.XPath("//input[contains(@id,'_EndDate')and @aria-invalid='true']"));


        public string investmentBanker_Add = "//label[contains(@for,'_AgentID')]//following::input[contains(@id,'AgentID')]";

        public IWebElement InvestmentBanker_Add => Driver.FindElement(By.XPath(investmentBanker_Add));
        public IWebElement InvestmentBanker_Add_Validation => Driver.FindElement(By.XPath("//label[contains(@for,'_AgentID')]//following::input[contains(@id,'AgentID')and @aria-invalid='true']"));

        public IWebElement Note_Add => Driver.FindElement(By.XPath("//textarea[contains(@id,'_Note')]"));
        public IWebElement Save => Driver.FindElement(By.XPath("//span[@class='dx-button-text' and text()='Save']"));

        // Add Adjustment Codes Locators
        public string addNewCodeBtn = "//*[@id='modalAdjCode']//following::button[@onclick='addAdjustmentCode();']";
        public IWebElement AddCode_AddNewBtn => Driver.FindElement(By.XPath(addNewCodeBtn));
        public IWebElement AddCode => Driver.FindElement(By.XPath("//label[contains(text(),'Adjustment Code:')]//following::div//input[contains(@id,'AdjCode')]"));
        public IWebElement AddCode_Validation => Driver.FindElement(By.XPath("//label[contains(text(),'Adjustment Code:')]//following::div//input[contains(@id,'AdjCode')and @aria-invalid='true']"));
        public IWebElement AddCodeDescription => Driver.FindElement(By.XPath(" //input[contains(@id,'AdjDesc')]"));
        public IWebElement AddcodeAmount => Driver.FindElement(By.XPath("//label[contains(@for,'_AdjCharge')]//following::input[@inputmode='decimal']"));
        public IWebElement AddcodeCategory => Driver.FindElement(By.XPath("//input[contains(@id,'AdjCategory')] "));
        public IWebElement AddcodeGLcode => Driver.FindElement(By.XPath(" //input[contains(@id,'AdjGLCode')]"));
        public IWebElement AddcodeCostCenter => Driver.FindElement(By.XPath("//input[contains(@id,'AdjCostCenter')]"));
        public IWebElement AddcodeSave => Driver.FindElement(By.XPath("//span[contains(text(),'Save')]"));
        public IWebElement AddcodeCancel => Driver.FindElement(By.XPath("//div[@id='gridAdjustment']//div//span[contains(text(),'Cancel')]"));
        public IWebElement AddAdjustmentCodePopup => Driver.FindElement(By.XPath(" //div[contains(text(),'Add Adjustment Code New')]"));
        public IWebElement duplicateAdjustmentCode => Driver.FindElement(By.XPath(DuplicateAdjustmentCode));


        // Add Adjustment Code grid Locators 

        public string AdjustCodeCol = "//*[@id='gridAdjustmentCode']//descendant::table[2]/tbody/tr/td";
        public string AdjustCodeRow = "//*[@id='gridAdjustmentCode']//descendant::table[2]/tbody/tr";
        public string AdjustCodetable = "//*[@id='gridAdjustmentCode']//descendant::table[2]";

        public IWebElement CodetableElement => Driver.FindElement(By.XPath(AdjustCodetable));
        public IList<IWebElement> CodetableRow => tableElement.FindElements(By.XPath(AdjustCodeRow));
        public IList<IWebElement> CodetableCol => tableElement.FindElements(By.XPath(AdjustCodeCol));



        // search Adjustment grid Locators 

        public string AdjustGridCol = "//*[@id='gridAdjustment']//descendant::table[2]/tbody/tr/td";
        public string AdjustGridRow = "//*[@id='gridAdjustment']//descendant::table[2]/tbody/tr";
        public string AdjustGridtable = "//*[@id='gridAdjustment']//descendant::table[2]";
        public string btnGridEdit = "//a[ contains(text(),'Edit')]";


        public IWebElement tableElement => Driver.FindElement(By.XPath(AdjustGridtable));
        public IList<IWebElement> tableRow => tableElement.FindElements(By.XPath(AdjustGridRow));
      public IList<IWebElement> tableCol => tableElement.FindElements(By.XPath(AdjustGridCol));


       


    //Method to handle search 

    public void adjustmentMode_Search(string AdjustmentModeValue) => _WebElementExtensions.SelectDropdownByText(AdjustmentMode, AdjustmentModeValue);
        public void investmentBanker_Search(string InvestmentBankerValue) => _WebElementExtensions.SelectDropdownByText(InvestmentBanker, InvestmentBankerValue);
        public void adjustmentCode_Search(string AdjustmentCodeValue) => _WebElementExtensions.SelectDropdownByText(AdjustmentCode, AdjustmentCodeValue);
        public void adjCycleStartDate_Search(string adjCycleStartDate) => AdjustmentCycleStartDate.SendKeys(adjCycleStartDate);
        public void adjCycleEndtDate_Search(string adjCycleEndtDate) => AdjustmentCycleEndtDate.SendKeys(adjCycleEndtDate);
        public void ClickSearchButton() => AdjustmentSearchButton.Submit();
        public void ClickResetButton() => AdjustmentResetButton.Click();





        //Method to handle Add Adjustment
        public void adjustmentMode_Add(string AdjustmentModeValue) => _WebElementExtensions.DropdownControl(AdjustmentMode_Add, AdjustmentModeValue);
        public void adjustmentCode_Add(string AdjustmentCodeValue) => _WebElementExtensions.DropdownControl(AdjustmentCode_Add, AdjustmentCodeValue);

        public void amount_Add(string Amount) => Amount_Add.SendKeys(Amount);
        public void note_Add(string Note) => Note_Add.SendKeys(Note);
        public void ClickSaveButton() => Save.Click();
        public void ClickAddButton() => AdjustmentAddButton.Click();
        public void ClickAdjustmentMenu() => AdjustmentMenu.Click();

        public void adjCycleStartDate_Add(string adjCycleStartDate) => StartDate_Add.SendKeys(adjCycleStartDate);



            
           

        public void adjCycleEndtDate_Add(string adjCycleEndtDate)

        {

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(Driver);

            fluentWait.Timeout = TimeSpan.FromSeconds(60);

            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(enddate))).Click();
            EndDate_Add.SendKeys(adjCycleEndtDate);

           

        }
        public void Adj_InvestmentBanker_Add(string InvestmentBankerValue)
        {
           
                DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(Driver);

                fluentWait.Timeout = TimeSpan.FromSeconds(60);

                fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
                fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(investmentBanker_Add))).Click();
                fluentWait.Until(ExpectedConditions.ElementIsVisible(By.XPath($".//div[contains(text(),'{InvestmentBankerValue}')]"))).Click();

            

        }
        //Method to handle Add Adjustment Code 
        public void ClickAddNewButton() => AddCode_AddNewBtn.Click();
        public void ClickSaveCodeButton() => AddcodeSave.Click();

        public void ClickAddAdjustmentCodebutton() => AdjustmentCode_AddButton.Click();
        public void adjustmentCode(string code) => AddCode.SendKeys(code);
        public void adjustmentDescription(string description) => AddCodeDescription.SendKeys(description);
        public void Amount(string Amount) => AddcodeAmount.SendKeys(Amount);
        public void category(string Category) => AddcodeCategory.SendKeys(Category);
        public void CostCenter(string CostCenter) => AddcodeCostCenter.SendKeys(CostCenter);
        public void GLcode(string GLcode) => AddcodeGLcode.SendKeys(GLcode);







        //Verification
        public List<string> ValidateSearchAdustmentGridData() => _WebElementExtensions.ValidateGridData(tableRow, tableCol);
        public List<string> ValidateADJSCodeGridData() => _WebElementExtensions.ValidateGridData(CodetableRow, CodetableCol);

        public bool AdjustGridResultsDisplay => _WebElementExtensions.IsGridDisplayData(tableRow, tableCol);
        public bool AdjustCodeGridResultsDisplay => _WebElementExtensions.IsGridDisplayData(CodetableRow, CodetableCol);

        public bool ConfirmAdustmentCodeValidationError => _WebElementExtensions.IsElementPresent(AdjustmentCode_Add_Validation);
        public bool ConfirmAdjustmentModeValidationError => _WebElementExtensions.IsElementPresent(AdjustmentMode_Add_Validation);
        public bool ConfirmInvestmentBankerValidationError => _WebElementExtensions.IsElementPresent(InvestmentBanker_Add_Validation);
        public bool ConfirmStartDateValidationError => _WebElementExtensions.IsElementPresent(StartDate_Add_Validation);
        public bool ConfirmEndDateValidationError => _WebElementExtensions.IsElementPresent(EndDate_Add_Validation);
        public bool ConfirmAddAdjustmentCodepopup => _WebElementExtensions.IsElementPresent(AddAdjustmentCodePopup);
        public bool ConfirmAddcodeValidationError => _WebElementExtensions.IsElementPresent(AddCode_Validation);
        public bool ConfirmDuplicateAdjustmentCode => _WebElementExtensions.IsElementPresent(duplicateAdjustmentCode);


    }
}
