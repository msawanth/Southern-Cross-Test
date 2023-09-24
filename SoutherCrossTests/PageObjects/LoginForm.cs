using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SouthernCrossTests.Contexts;
using OpenQA.Selenium;
using SouthernCrossTests.Models;

namespace SouthernCrossTests.PageObjects
{
    public class LoginForm
    {
        private WebDriverContext _driverContext;

        public LoginForm(WebDriverContext webDriverContext) => _driverContext = webDriverContext;

        public IWebElement LoginField => _driverContext.ChromeDriver.FindElement(By.Name("login"));
        public IWebElement PasswordField => _driverContext.ChromeDriver.FindElement(By.Name("password"));
        public IWebElement LoginButton => _driverContext.ChromeDriver.FindElement(By.XPath("//button[text()='Login']"));
        public IWebElement ProfileLink => _driverContext.ChromeDriver.FindElement(By.LinkText("Profile"));
        public IWebElement LogoutLink => _driverContext.ChromeDriver.FindElement(By.LinkText("Logout"));
        public IWebElement InvalidCredentialError => _driverContext.ChromeDriver.FindElement(By.XPath("//span[contains(text(), 'Invalid username/password')]"));

        public void EnterLoginCredentials(string username, string password)
        {
            LoginField.SendKeys(username);
            PasswordField.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        public void VerifyLogin()
        {
            _ = ProfileLink.Displayed;
            _ = LogoutLink.Displayed;
        }
    }
}
