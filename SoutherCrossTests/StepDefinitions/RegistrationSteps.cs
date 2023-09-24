using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using SouthernCrossTests.Contexts;
using SouthernCrossTests.Models;
using NUnit.Framework;

namespace SouthernCrossTests.StepDefinitions
{
    [Binding]
    public class RegistrationSteps : TechTalk.SpecFlow.Steps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly PageObjectContext _pageObjectContext;

        public RegistrationSteps(ScenarioContext scenarioContext, PageObjectContext pageObjectContext)
        {
            _scenarioContext = scenarioContext;
            _pageObjectContext = pageObjectContext;
        }

        [Given(@"I am in registration page")]
        public void GivenIAmInRegistrationPage()
        {
            _pageObjectContext.HomePage.NavigateToHomePage();
            _pageObjectContext.RegistrationPage.GoToRegistrationPage();
        }

        [Given(@"I enter user details")]
        public void GivenIEnterUserDetails(Table table)
        {
            var userDetails = table.CreateInstance<RegistrationModel>();
            _pageObjectContext.RegistrationPage.EnterRegistrationDetails(userDetails);

            _scenarioContext.Add("registeredData", new LoginModel
            {
                Login = userDetails.Username,
                Password = userDetails.Password
            });
        }

        [When(@"I click on the register button")]
        public void WhenIClickOnTheRegisterButton()
        {
            _pageObjectContext.RegistrationPage.ClickOnRegistrationButton();
        }

        [Then(@"Registration successful message is displayed")]
        public void ThenRegistrationSuccessfulMessageIsDisplayed()
        {
            Assert.AreEqual("Registration is successful", _pageObjectContext.RegistrationPage.registrationResult.Text);
        }

        [Then(@"I should be able to login with the registered details")]
        public void ThenIShouldBeAbleToLoginWithTheRegisteredDetails()
        {
            var registeredData = _scenarioContext.Get<LoginModel>("registeredData");            
            Given($"I enter username {registeredData.Login} and password {registeredData.Password}");
            When(@"I click login button");
            Then(@"I should be logged in");
        }

        [Then(@"I should see user exists error message")]
        public void ThenIShouldSeeUserExistsErrorMessage()
        {
            Assert.AreEqual("UsernameExistsException: User already exists", _pageObjectContext.RegistrationPage.registrationResult.Text);
        }

        [Then(@"I should see invalid password error")]
        public void ThenIShouldSeeInvalidPasswordError()
        {
            Assert.That(_pageObjectContext.RegistrationPage.registrationResult.Text.Contains("InvalidPasswordException"));
        }
    }
}
