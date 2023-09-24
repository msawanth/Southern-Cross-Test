using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthernCrossTests.Models
{
    public class ApplicationInitializerModel
    {
        public string ApplicationBaseUrl { get; set; }
        public WebDriverConfigurationModel webDriver { get; set; }
    }

    public class WebDriverConfigurationModel
    {
        public bool IsHeadless { get; set; }
        public int ImplicitWaitInSeconds { get; set; }
    }
}
   