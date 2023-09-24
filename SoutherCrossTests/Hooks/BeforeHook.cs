using Microsoft.Extensions.Configuration;
using SouthernCrossTests.Contexts;
using TechTalk.SpecFlow;
using SouthernCrossTests.Models;

namespace SouthernCrossTests.Hooks
{
    [Binding]
    public class BeforeHook
    {
        private readonly ApplicationInitializerContext _applicationInitializerContext;

        public BeforeHook(ApplicationInitializerContext applicationInitializerContext)
        {
            _applicationInitializerContext = applicationInitializerContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("AppSettings.json", optional: false)
                .Build();

            _applicationInitializerContext.applicationInitializer = config.Get<ApplicationInitializerModel>();
        }
    }
}
