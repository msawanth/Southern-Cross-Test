using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthernCrossTests.Contexts
{
    public class WebDriverContext
    {
        private readonly ApplicationInitializerContext _applicationInitializerContext;
        public IWebDriver ChromeDriver;

        public WebDriverContext(ApplicationInitializerContext applicationInitializerContext)
        {
            _applicationInitializerContext = applicationInitializerContext;

            ChromeOptions options = new ChromeOptions();
            //if (_configurationContext.Configuration.WebDriver.IsHeadless)
            //    options.AddArgument("--headless");

            ChromeDriver = new ChromeDriver(options);

            ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_applicationInitializerContext.applicationInitializer.webDriver.ImplicitWaitInSeconds);
        }
    }
}
