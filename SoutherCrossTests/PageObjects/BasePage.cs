using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SouthernCrossTests.Contexts;
using OpenQA.Selenium;

namespace SouthernCrossTests.PageObjects
{
    public class BasePage
    {
        private WebDriverContext _webDriverContext;
        private ApplicationInitializerContext _applicationInitializerContext;

        public BasePage(WebDriverContext webDriverContext) => _webDriverContext = webDriverContext;
        public IWebElement Logo => _webDriverContext.ChromeDriver.FindElement(By.LinkText("Buggy Rating"));

        public void ClickLogo() => Logo.Click();
    }
}
