using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using SouthernCrossTests.Contexts;

namespace SouthernCrossTests.Hooks
{
    [Binding]
    public class AfterHook
    {
        private WebDriverContext _webDriverContext;

        public AfterHook(WebDriverContext webDriverContext) => _webDriverContext = webDriverContext;
        

        [AfterScenario]
        public void AfterScenario()
        {
            _webDriverContext.ChromeDriver.Quit();
        }
    }
}
