using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace InvestmentBankingAutomation.Pages
{
    internal class SecuritySettingsPage
    {
        private IWebDriver Driver;

        public SecuritySettingsPage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
