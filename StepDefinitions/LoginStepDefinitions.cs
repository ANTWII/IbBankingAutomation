using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using InvestmentBankingAutomation.Pages;
using InvestmentBankingAutomation.Drivers;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace InvestmentBankingAutomation.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        LoginPage newlogin;
        private DriverHelper _driverHelper;
        public LoginStepDefinitions(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
 
            newlogin = new LoginPage(_driverHelper.Driver);

        }


        [Given(@"Smith has launched the intrepid application")]
        public void GivenSmithHasLaunchedTheIntrepidApplication()
        {
            _driverHelper.Driver.Navigate().GoToUrl("https://i22dev.eaiinfosys.com/");

           

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driverHelper.Driver);

            fluentWait.Timeout = TimeSpan.FromSeconds(60);

            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException),typeof(StaleElementReferenceException));
            fluentWait.Until(ExpectedConditions.UrlContains(_driverHelper.Driver.Url= "http://i22dev.eaiinfosys.com/Account/Login"));
            
        }



        [Given(@"Smith entered the following login details")]
        public void GivenSmithEnteredTheFollowingLoginDetails(Table table)
        {
            WebDriverWait Wait = new WebDriverWait(_driverHelper.Driver, TimeSpan.FromSeconds(60));
           Wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException),typeof(StaleElementReferenceException));
          Wait.Until(ExpectedConditions.ElementExists(By.XPath(newlogin.userName)));
           
           newlogin.confirmLoginPageExist();
            dynamic data = table.CreateDynamicInstance();
            newlogin.login(data.UserNameField, data.PasswordField);
        }

        [Given(@"Smith clicked login button")]
        public void GivenSmithClickedLoginButton()
        {
            newlogin.ClickSubmitButton();
            
        }

        [Then(@"Smith should see home menu")]
        public void ThenSmithShouldSeeHomeMenu()
        {
            Assert.That(newlogin.HomeMenuDisplay, Is.True, "User details link not found");
        }

        [Then(@"Smith should see invalid user name error")]
        public void ThenSmithShouldSeeInvalidUserNameError()
        {
            Assert.That(newlogin.ConfirminvalidLoginUsername, Is.True, "User details link not found");
        }

        [Then(@"Smith should see invalid Password error")]
        public void ThenSmithShouldSeeInvalidPasswordError()
        {
          
            Assert.That(newlogin.ConfirminvalidLoginPassword, Is.True, "User details link not found");
        }

        [Given(@"Smith clicked forgot password Link")]
        public void GivenSmithClickedForgotPasswordLink()
        {
            newlogin.ClickForgotPassword();
        }
        [Then(@"Smith should see the frgot password screeen")]
        public void ThenSmithShouldSeeTheFrgotPasswordScreeen()
        {
           Assert.That(newlogin.ConfirminforgotPassword, Is.True, "User details link not found");
        }


       

    }

}

