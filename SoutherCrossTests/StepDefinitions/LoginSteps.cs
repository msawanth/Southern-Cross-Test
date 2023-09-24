using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SouthernCrossTests.Contexts;
using TechTalk.SpecFlow;

namespace SouthernCrossTests.StepDefinitions
{
    [Binding]
    public class LoginSteps : TechTalk.SpecFlow.Steps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly PageObjectContext _pageObjectContext;

        public LoginSteps(ScenarioContext scenarioContext, PageObjectContext pageObjectContext)
        {
            _scenarioContext = scenarioContext;
            _pageObjectContext = pageObjectContext;
        }

        [Given(@"I am in home page")]
        public void GivenIAmInHomePage()
        {
            _pageObjectContext.HomePage.NavigateToHomePage();
        }

        [Given(@"I enter username (.*) and password (.*)")]
        public void GivenIEnterUsernameAndPassword(string login, string password)
        {
            _pageObjectContext.LoginForm.EnterLoginCredentials(login, password);
        }

        [When(@"I click login button")]
        public void WhenIClickLoginButton()
        {
            _pageObjectContext.LoginForm.ClickLoginButton();
        }

        [Then(@"I should be logged in")]
        public void ThenIshouldBeLoggedIn()
        {
            _pageObjectContext.LoginForm.VerifyLogin();
        }

        [Then(@"I should see a invalid credential validation error")]
        public void ThenIShouldSeeAInvalidCredentialValidationError()
        {
            Assert.That(_pageObjectContext.LoginForm.InvalidCredentialError.Displayed, Is.True);
        }
    }
}
