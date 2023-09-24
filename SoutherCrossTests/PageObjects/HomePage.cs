using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SouthernCrossTests.Contexts;
using OpenQA.Selenium;

namespace SouthernCrossTests.PageObjects
{
    public class HomePage : BasePage
    {
        private readonly WebDriverContext _driverContext;
        private readonly ApplicationInitializerContext _applicationInitializerContext;

        public HomePage(WebDriverContext webDriverContext, ApplicationInitializerContext applicationInitializerContext)
            : base(webDriverContext)
        {
            _driverContext = webDriverContext;
            _applicationInitializerContext = applicationInitializerContext;
        }

        public IWebElement HomePageSection => _driverContext.ChromeDriver.FindElement(By.XPath("//my-home"));

        public void NavigateToHomePage()
        {
            _driverContext.ChromeDriver.Navigate().GoToUrl(_applicationInitializerContext.applicationInitializer.ApplicationBaseUrl);
            _ = HomePageSection.Displayed;
        }
    }
}
