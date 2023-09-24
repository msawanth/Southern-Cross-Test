using SouthernCrossTests.Contexts;
using SouthernCrossTests.Models;
using OpenQA.Selenium;
using NUnit.Framework;

namespace SouthernCrossTests.PageObjects
{
    public class RegistrationPage : BasePage
    {
        private readonly WebDriverContext _driverContext;
        private readonly ApplicationInitializerContext _applicationInitializerContext;
        public RegistrationPage(WebDriverContext webDriverContext, ApplicationInitializerContext applicationInitializerContext) : base(webDriverContext)
        {
            _driverContext = webDriverContext;
            _applicationInitializerContext = applicationInitializerContext;
        }

        public IWebElement navigateRegisterButton => _driverContext.ChromeDriver.FindElement(By.LinkText("Register"));
        public IWebElement registrationPage => _driverContext.ChromeDriver.FindElement(By.ClassName("my-form"));
        public IWebElement userName => _driverContext.ChromeDriver.FindElement(By.Id("username"));
        public IWebElement firstName => _driverContext.ChromeDriver.FindElement(By.Id("firstName"));
        public IWebElement lastName => _driverContext.ChromeDriver.FindElement(By.Id("lastName"));
        public IWebElement password => _driverContext.ChromeDriver.FindElement(By.Id("password"));
        public IWebElement confirmPassword => _driverContext.ChromeDriver.FindElement(By.Id("confirmPassword"));
        public IWebElement registerButton => _driverContext.ChromeDriver.FindElement(By.XPath("//button[text()='Register']"));
        public IWebElement registrationResult => _driverContext.ChromeDriver.FindElement(By.ClassName("result"));

        public void GoToRegistrationPage()
        {
            navigateRegisterButton.Click();
            Assert.That(registrationPage.Text.Contains("Register with Buggy Cars Rating"));
        }

        // Enter user details for registration
        public void EnterRegistrationDetails(RegistrationModel details)
        {
            if (details.Username == "BuggyValidator")
                details.Username = Faker.Name.Middle();

            userName.SendKeys(details.Username);
            firstName.SendKeys(Faker.Name.First());
            lastName.SendKeys(Faker.Name.Last());
            password.SendKeys(details.Password);
            confirmPassword.SendKeys(details.Password);
        }

        public void ClickOnRegistrationButton()
        {
            registerButton.Click();
        }
    }
}
