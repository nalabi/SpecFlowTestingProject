using OpenQA.Selenium;
using SpecFlowTestingProject.Methods;
using SpecFlowTestingProject.Pages;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowTestingProject.StepDefinitions
{
    [Binding]
    public class UserLoginStepDefinitions
    {

        String WebUrls = "https://hotrave.herokuapp.com/";
        
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;
        private readonly UserLoginPage _userLoginPage;
        public UserLoginStepDefinitions(ScenarioContext scenarioContext)
        {
            _driver = scenarioContext["WebDriver"] as IWebDriver
                     ?? throw new ArgumentNullException("WebDriver instance is not found in ScenarioContext.");

            // Initialize the SignUpPage object
           _userLoginPage = new UserLoginPage(_driver);
        }
        [Given(@"I am on the My Hot Rave login page")]
        public void GivenIAmOnTheMyHotRaveLoginPage()
        {
            _driver.Navigate().GoToUrl(WebUrls);
        }
        [When(@"I enter a valid username and passord field")]
        public void WhenIEnterAValidUsernameAndPassordField(Table table)
        {

            foreach (var row in table.Rows)
            {
                var field = row["Field"];
                var value = row["Value"];

                switch (field)
                {

                    case "Username":

                        _userLoginPage.EnterUsername(value);
                        break;

                    case "Password":
                        _userLoginPage.EnterPassword(value);
                        break;

                    default:
                        throw new ArgumentException($"Field '{field}' is not recognized.");
                }
            }
        }

    


    [When(@"I click on the ""([^""]*)"" button")]
        public void WhenIClickOnTheButton(string login)
        {
            _userLoginPage.ClickLoginButton();
        }

        [Then(@"I should be redirected to the homepage")]
        public void ThenIShouldBeRedirectedToTheHomepage()
        {
            _driver.Navigate().GoToUrl("https://hotrave.herokuapp.com/members");
        }

  
    }
}
