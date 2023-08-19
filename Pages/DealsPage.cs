
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using InvestmentBankingAutomation.Extensions;

namespace InvestmentBankingAutomation.Pages
{
    internal class DealsPage
    {
        private IWebDriver Driver;
        WebElementExtensions _WebElementExtensions;

        public DealsPage(IWebDriver driver)
        {
            Driver = driver;
            _WebElementExtensions = new WebElementExtensions(Driver);

        }


        //Search Page Locators
        public string dealsMenu = "//i[@title='Deals']";

        public IWebElement DealsMenu => Driver.FindElement(By.XPath(dealsMenu));
        public IWebElement DealType=> Driver.FindElement(By.XPath("//Select[@id='dealType']"));
        public IWebElement DealStatus => Driver.FindElement(By.XPath("//Select[@id='dealStatus']"));
        public IWebElement DealIndustry => Driver.FindElement(By.XPath("//Select[@id='industry']"));
        public IWebElement DealInvestmentBanker => Driver.FindElement(By.XPath("//Select[@id='banker']"));
        public IWebElement DealSearchButton => Driver.FindElement(By.XPath("//button[@id='btnSearchDeal']"));
        public IWebElement DealResetButton => Driver.FindElement(By.XPath("//button[@id='btnResetDeal']"));
        public IWebElement DealsAddButton => Driver.FindElement(By.XPath("//button[normalize-space()='Add Deals']"));
        public IWebElement DisplayNodataInGridResults => Driver.FindElement(By.XPath("//div[@id='gridDeals']//span[@class='dx-datagrid-nodata'][normalize-space()='No data']"));
        public IWebElement DisplayEditInGridResults => Driver.FindElement(By.XPath("//td[@class='dx-cell-focus-disabled']//a[@title='Edit'][normalize-space()='Edit']"));

        //Add Deals  Page Locators
        public IWebElement DealTypeAdd => Driver.FindElement(By.XPath("//Select[@id='addDealType']"));
        public IWebElement DealStatusAdd => Driver.FindElement(By.XPath("//Select[@id='addDealStatus']"));
        public IWebElement IndustryAdd => Driver.FindElement(By.XPath("//Select[@id='addIndustry']"));

        public IWebElement ClientNameAdd => Driver.FindElement(By.XPath("//input[@id='clientName']"));
        public IWebElement ActualDealAmountAdd => Driver.FindElement(By.XPath("//input[@id='addada']"));
       public string ActualCommissionAmount = "//input[@id='addaca']";
        
        public IWebElement ActuaCommissionAmountAdd => Driver.FindElement(By.XPath(ActualCommissionAmount));

        public IWebElement ActuaCommissionRateAdd => Driver.FindElement(By.XPath("//input[@id='addacr']"));

        public IWebElement OriginationDateAdd => Driver.FindElement(By.XPath("//div[@id='addOriginDate']//input[@role='combobox']"));
        public IWebElement PhoneNumberAdd => Driver.FindElement(By.XPath("//input[@id='phone']"));
        public IWebElement AddrressAdd => Driver.FindElement(By.XPath("//input[@id='address']"));
        public IWebElement SaveAddDeal => Driver.FindElement(By.XPath("//button[@id='btnAddDeal']"));

        public IWebElement DealType_Validation => Driver.FindElement(By.XPath(" //div[contains(text(),'Please select a Deal Type ')]"));
        public IWebElement DealStatus_Validation => Driver.FindElement(By.XPath(" //div[contains(text(),'Please select a Deal Status')]"));
        public IWebElement ClientName_Validation => Driver.FindElement(By.XPath(" //div[contains(text(),'Please Enter Value for Client Name ')]"));

        public IWebElement OriginationDate_Validation => Driver.FindElement(By.XPath("//div[@id='addOriginDate']//input[@role='combobox'and @aria-invalid='true']"));
        public IWebElement SettlementDate_Validation => Driver.FindElement(By.XPath("//div[@id='addSetDate']//input[@role='combobox'and @aria-invalid='true']"));
        //  , Add Revenue on Deals  Page Locators

        string revenueSource = "//input[contains(@id,'_RevenueSource')]";
        public IWebElement RevenueTab => Driver.FindElement(By.XPath("//*[@id='gridTabbs']"));

        public IWebElement RevenueAdd_Btn => Driver.FindElement(By.XPath("//button[normalize-space()='Add Revenue']"));
        public IWebElement RevenueTypeDropDown => Driver.FindElement(By.XPath(" //input[contains(@id,'_RetainerType')]"));
        public IWebElement RevenueSourceDropDown => Driver.FindElement(By.XPath(revenueSource));
        public IWebElement RevenueCheckWireNumber=> Driver.FindElement(By.XPath("//input[contains(@id,'PayTransactionNo')] "));

        public IWebElement RevenueAmount => Driver.FindElement(By.XPath("//*[@id='retainerGrid']//descendant::table[2]//input[@inputmode='decimal']"));
        public IWebElement RevenueSave => Driver.FindElement(By.XPath("//*[@id='retainerGrid']//descendant::table[2]//descendant::span[text()='Save']"));
        public IWebElement RevenueSettlementDate => Driver.FindElement(By.XPath("//input[contains(@id,'_SettlementDate')]"));








        //  , Add investment banker on Deals  Page Locators
        string Standardpayout = "//input[contains(@id,'_StandardPayout')]";
        public IWebElement IVBAdd_Btn => Driver.FindElement(By.XPath("//button[normalize-space()='Add Investment Banker']"));
        public IWebElement InvestmentbankerDropDown => Driver.FindElement(By.XPath(" //input[contains(@id,'_AgentID')]"));
        public IWebElement IVBOriginatin => Driver.FindElement(By.XPath("//label[contains(@for,'OriginationPercent')]//following::input[@inputmode='decimal'][1]"));
        public IWebElement StandardPayout => Driver.FindElement(By.XPath(Standardpayout));
        public IWebElement capAmount => Driver.FindElement(By.XPath("//input[contains(@id,'_CapAmt')]"));

        public IWebElement IVBSave => Driver.FindElement(By.XPath("//*[@id='bankerGrid']//descendant::table[2]//descendant::span[text()='Save']"));
        public IWebElement IVDetailsTab => Driver.FindElement(By.XPath("//*[@id='gridTabb']"));



        //Search grid Locators 
       public string mainDealGridCol = "//*[@id='gridDeals']//descendant::table[2]/tbody/tr/td";
        public string mainDealGridRow = "//*[@id='gridDeals']//descendant::table[2]/tbody/tr";
        public string mainDealGridtable = "//*[@id='gridDeals']//descendant::table[2]";
        public string btnGridEdit = "//a[ contains(text(),'Edit')]";

        public IWebElement SearchGridtableElement => Driver.FindElement(By.XPath(mainDealGridtable));
        public IList<IWebElement> SearchDealGrideRow => SearchGridtableElement.FindElements(By.XPath(mainDealGridRow));
     public   IList<IWebElement> SearchDealGridColumn => SearchGridtableElement.FindElements(By.XPath(mainDealGridCol));





        //Add deal-Investmentbanker grid Locators 
        public String DealIVBGridTable = "//*[@id='bankerGrid']//descendant::table[2]";
        public String DealIVBGridRow = "//*[@id='bankerGrid']//descendant::table[2]/tbody/tr";
        public String DealIVBGridCol = "//*[@id='bankerGrid']//descendant::table[2]/tbody/tr/td";
        public IWebElement IVBGridtableElement => Driver.FindElement(By.XPath(DealIVBGridTable));
        public IList<IWebElement> IVBGridRow => IVBGridtableElement.FindElements(By.XPath(DealIVBGridRow));
        public IList<IWebElement> IVBGridColumn => IVBGridtableElement.FindElements(By.XPath(DealIVBGridCol));




        //Add deal-Revenue grid Locators 

        public string DealRevenueGridtable = "//*[@id='retainerGrid']//descendant::table[2]";
        public string DealRevenueGridRow = "//*[@id='retainerGrid']//descendant::table[2]/tbody/tr";
        public string DealRevenueGridCol = "//*[@id='retainerGrid']//descendant::table[2]/tbody/tr/td";
        public IWebElement RevenueGridtableElement => Driver.FindElement(By.XPath(DealRevenueGridtable));
        public IList<IWebElement> RevenueGridRow => RevenueGridtableElement.FindElements(By.XPath(DealRevenueGridRow));
        public IList<IWebElement> RevenueGridColumn => RevenueGridtableElement.FindElements(By.XPath(DealRevenueGridCol));


        //Search Deal Options
       public void selectDealStatus_Search(string DealStatusValue) => _WebElementExtensions.SelectDropdownByText(DealStatus,DealStatusValue);
       public void selectDealType_Search(string DealTypeValue) => _WebElementExtensions.SelectDropdownByText(DealType, DealTypeValue);
       public void selectDealIndustry_Search(string DealIndustryValue) => _WebElementExtensions.SelectDropdownByText(DealIndustry, DealIndustryValue);
       public void selectDealInvestmentBanker_Search(string DealInvestmentBankerValue) => _WebElementExtensions.SelectDropdownByText(DealInvestmentBanker, DealInvestmentBankerValue);


        //Add Deal Options
        public void selectDealType_Add(string DealTypeValue) => _WebElementExtensions.SelectDropdownByText(DealTypeAdd, DealTypeValue);
        public void selectDealStatus_Add(string DealStatusValue) => _WebElementExtensions.SelectDropdownByText(DealStatusAdd, DealStatusValue);
        public void selectDealIndustry_Add(string IndustryValue) => _WebElementExtensions.SelectDropdownByText(IndustryAdd, IndustryValue);
        public void enterClientName_Add(string ClientName) => ClientNameAdd.SendKeys(ClientName);
        public void enterActualDealAmount_Add(string ActualDealAmount) => ActualDealAmountAdd.SendKeys(ActualDealAmount);
        public void enterActuaCommissionRate_Add(string ActuaCommissionRate) => ActuaCommissionRateAdd.SendKeys(ActuaCommissionRate);
        public void enterOriginationDate_Add(string OriginationDate) => OriginationDateAdd.SendKeys(OriginationDate);
        public void enterPhoneNumber_Add(string PhoneNumber) => PhoneNumberAdd.SendKeys(PhoneNumber);
        public void enterAddrress_Add(string Addrress) => AddrressAdd.SendKeys(Addrress);

        //Add Deal //add investment Banker
        public void selectIVB_Add(string IVBValue) => _WebElementExtensions.DropdownControl(InvestmentbankerDropDown, IVBValue);
        public void enterIOrigination_Add(string IOrigination) => IVBOriginatin.SendKeys(IOrigination);
        public void entercapAmount_Add(string CapAmount) => capAmount.SendKeys(CapAmount);

        public void standardPayout(string standardpayout)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(Driver);

            fluentWait.Timeout = TimeSpan.FromSeconds(60);

            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Standardpayout))).Click();
           StandardPayout.Clear();

            StandardPayout.SendKeys(standardpayout); } 

        //  public void enterICommission_Add(string ICommission) => IVBCommision.SendKeys(ICommission);


        //Add Deal //add Revenue

        public void selectRevenueType_Add(string RevenueTypeValue) => _WebElementExtensions.DropdownControl(RevenueTypeDropDown, RevenueTypeValue);
        public void enterAmount_Add(string Amount) => RevenueAmount.SendKeys(Amount);
       
        public void enterCheckWireNumbe_Add(string CheckWireNumbe) => RevenueCheckWireNumber.SendKeys(CheckWireNumbe);
        public void enterSettlementDate_Add(string SettlementDate) => RevenueSettlementDate.SendKeys(SettlementDate);

        public void selectRevenueSource_Add(string RevenueSource)
        {

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(Driver);

            fluentWait.Timeout = TimeSpan.FromSeconds(60);

            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(revenueSource))).Click();
            fluentWait.Until(ExpectedConditions.ElementIsVisible(By.XPath($".//div[text()='{RevenueSource}']"))).Click();

        }





        //Methods to Click buttons ad Tabs
        public void ClickSearchButton() => DealSearchButton.Submit();
        public void ClickResetButton() => DealResetButton.Click();
        public void ClickAddButton() => DealsAddButton.Click();
        public void ClickDealsMenu() => DealsMenu.Click();
        public void ClickDealSaveButton() => SaveAddDeal.Click();
        public void ClickIVBSaveButton() => IVBSave.Click();
        public void ClickADDIVBButton() => IVBAdd_Btn.Click();
        public void ClickAddRevenueButton() => RevenueAdd_Btn.Click();
        public void revenueTab() => RevenueTab.Click();
        public void ClickRevenueSaveButton() => RevenueSave.Click();


        // verification
        public List<string> ValidateSearchDealGridData() => _WebElementExtensions.ValidateGridData(SearchDealGrideRow, SearchDealGridColumn);
        public List<string> ValidateInvestBankerGridData() => _WebElementExtensions.ValidateGridData(IVBGridRow, IVBGridColumn);

        public List<string> ValidateRevenueGridData() => _WebElementExtensions.ValidateGridData(RevenueGridRow, RevenueGridColumn);

        public bool DealsGridResultsDisplay => _WebElementExtensions.IsGridDisplayData(SearchDealGrideRow, SearchDealGridColumn);
        public bool RevenueGridResultsDisplay => _WebElementExtensions.IsGridDisplayData(RevenueGridRow, RevenueGridColumn);
        public bool DealsIVBGridResultsDisplay => _WebElementExtensions.IsGridDisplayData(IVBGridRow, IVBGridColumn);

        public bool ConfirmDealType_Validation => _WebElementExtensions.IsElementPresent(DealType_Validation);
        public bool ConfirmDealStatus_Validation => _WebElementExtensions.IsElementPresent(DealStatus_Validation);
        public bool ConfirmClientName_Validation => _WebElementExtensions.IsElementPresent(ClientName_Validation);
        public bool ConfirmOriginationDate_Validation => _WebElementExtensions.IsElementPresent(OriginationDate_Validation);
        public bool ConfirmSettlementDate_Validation => _WebElementExtensions.IsElementPresent(SettlementDate_Validation);


       
    }
}
