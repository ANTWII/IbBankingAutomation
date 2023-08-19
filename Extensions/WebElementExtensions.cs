
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace InvestmentBankingAutomation.Extensions
{
    internal class WebElementExtensions
    {
        private IWebDriver Driver;

        public WebElementExtensions(IWebDriver driver)
        {
            Driver = driver;
        }



        // Method to handle every drop down selection for all select tags
        public  void SelectDropdownByText(IWebElement webElement, string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                SelectElement selectElement = new SelectElement(webElement);
                // execute JavaScript to deselect the default option
                IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
                js.ExecuteScript("arguments[0].selectedIndex = -1;", webElement);

                selectElement.SelectByText(text);
            }
           
        }

        // Method to handle every drop down selection for complex and hidden controls
        //controls which do not have select tags
        public void DropdownControl(IWebElement element1, string text)
        {
      
                if(!string.IsNullOrEmpty(text))
            {
                element1.Click();

                IWebElement element2 = Driver.FindElement(By.XPath($".//div[contains(text(),'{text}')]"));
                element2.Click();
            }

            
         
        }

        public void Hover(IWebElement element)
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(element).Perform();
        }

        public void HoverAndClick( IWebElement elementToHover, IWebElement elementToClick)
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(elementToHover).Click(elementToClick).Build().Perform();
        }


    // Funtion to get string fro a web element
        public string GetText(IWebElement element)
        {
            return element.Text;
        }

        //return selected dropdown string
        public  string GetSelectedDropDown(IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions.First().ToString();
        }

        //Return all dropdown list
        public  IList<IWebElement> GetSelectedListOptions(IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions;
        }

        //Funtion which returns grid data in everry row and column
        public List<string> ValidateGridData(IList<IWebElement> Row, IList<IWebElement> Column)
        {
            int RowCount = Row.Count();
             List<string> gridData = new List<string>();
            int ColumnCount = 0;
                   

            foreach (IWebElement row in Row)
            {

                foreach (IWebElement TD in Column)
                {
                    if (ColumnCount++ <= Column.Count())
                    {
                        if (!string.IsNullOrEmpty(TD.Text))
                        {
                            //gridData.Add(TD.GetAttribute("text"));
                          
                            gridData.Add(TD.Text);
                           

                        }


                    }
                    
                }
                break;
            }
            return gridData;
        }


        public bool IsGridDisplayData(IList<IWebElement> Row, IList<IWebElement> Column)
        {
            int gridataCount = ValidateGridData(Row, Column).Count();
            if (gridataCount != 0)


                return true;

            else
                
                    return false;
            throw new AssertionException(String.Format("Grid Data not present exception"));

        }

        /// Assert if the Element is present
        public void AssertElementPresent(IWebElement element)
        {
           
            if (!IsElementPresent(element))
              throw new AssertionException(String.Format("AssertElementNotPresent exception"));
        }

        
        ///Check if the element exist
        

        public bool IsElementPresent(IWebElement element)
        {
            try
            {
                bool b = element.Displayed;
                return true;
            }
            catch
            {
                return false;
            }
        }

       
        
        class Assertions
    {
        private static readonly List<AssertionFailure> failures = new List<AssertionFailure>();

        public static void AssertSoft(bool condition, string message,
            string fileName = "",
             int lineNumber = 0,
           string methodName = "")
        {
            if (!condition)
            {
                var failure = new AssertionFailure
                {
                    Message = message,
                    FileName = fileName,
                    LineNumber = lineNumber,
                    MethodName = methodName
                };
                failures.Add(failure);
                Console.WriteLine("Soft assertion failed: " + message);
                Console.WriteLine($"\tat {methodName} in {fileName}, line {lineNumber}");
            }
        }

        public static IEnumerable<AssertionFailure> GetFailures()
        {
            return failures;
        }

        public class AssertionFailure
        {
            public string Message { get; set; }
            public string FileName { get; set; }
            public int LineNumber { get; set; }
            public string MethodName { get; set; }
        }
    }



}
}
