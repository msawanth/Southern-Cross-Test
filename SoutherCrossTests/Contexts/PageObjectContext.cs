using SouthernCrossTests.PageObjects;

namespace SouthernCrossTests.Contexts
{
    public class PageObjectContext
    {
        private readonly WebDriverContext _webDriverContext;
        private readonly ApplicationInitializerContext _applicationInitializerContext;

        public RegistrationPage RegistrationPage;
        public HomePage HomePage;
        public LoginForm LoginForm;

        public PageObjectContext(WebDriverContext webDriverContext, ApplicationInitializerContext applicationInitializerContext)
        {
            _webDriverContext = webDriverContext;
            _applicationInitializerContext = applicationInitializerContext;

            this.RegistrationPage = new RegistrationPage(webDriverContext, applicationInitializerContext);
            this.HomePage = new HomePage(webDriverContext, applicationInitializerContext);
            this.LoginForm = new LoginForm(webDriverContext);
        }
    }
}
