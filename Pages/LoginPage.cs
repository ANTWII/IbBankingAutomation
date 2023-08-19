using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using InvestmentBankingAutomation.Extensions;

namespace InvestmentBankingAutomation.Pages
{
    internal class LoginPage
    {

        private IWebDriver Driver;
        WebElementExtensions _WebElementExtensions;

        public LoginPage(IWebDriver driver)
        {
            Driver = driver;
            _WebElementExtensions = new WebElementExtensions(Driver);

        }


       public string userName = "//input[@id='Email']";
        public IWebElement loginUsername => Driver.FindElement(By.XPath(userName));
        public IWebElement Password => Driver.FindElement(By.XPath("//input[@id='Password']"));
        public IWebElement LoginBtn => Driver.FindElement(By.XPath("//input[@type='submit']"));
       //public IWebElement HomeMenu => Driver.FindElement(By.XPath("//span[contains(text(),'Home')]"));
        public IWebElement HomeMenu => Driver.FindElement(By.XPath("//span[normalize-space()='Home']"));
        public IWebElement InvalidUsername => Driver.FindElement(By.CssSelector("li:nth-child(1)"));
        public IWebElement InvalidPassword => Driver.FindElement(By.CssSelector("ul:nth-child(1) li:nth-child(1)"));

        public IWebElement ForgotPassword => Driver.FindElement(By.XPath("//a[@onclick='forgotPasword()']"));
        public IWebElement ForgotPasswordScreen => Driver.FindElement(By.XPath("//span[contains(text(),'If you forgot your password or username:')]"));


        public void login(string LoginUserName, string LoginPassword)

        {
            loginUsername.SendKeys(LoginUserName);
            Password.SendKeys(LoginPassword);


        }

        public void ClickSubmitButton() => LoginBtn.Submit();
        public void ClickForgotPassword() => ForgotPassword.Click();

        public bool HomeMenuDisplay=> _WebElementExtensions.IsElementPresent(HomeMenu);
        public bool ConfirminvalidLoginUsername => InvalidUsername.Displayed;
        public bool ConfirminvalidLoginPassword => _WebElementExtensions.IsElementPresent( InvalidPassword);
        public bool ConfirminforgotPassword => ForgotPasswordScreen.Displayed;

        public void confirmLoginPageExist() => _WebElementExtensions.AssertElementPresent(loginUsername);


    }
}
