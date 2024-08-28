using OpenQA.Selenium;
using SpecFlowTestingProject.Methods;
using SpecFlowTestingProject.Pages;

namespace SpecFlowTestingProject.StepDefinitions
{
    [Binding]
    public class HomePageStepDefinitions
    {
        String WebUrls = "https://hotrave.herokuapp.com/";
        private readonly IWebDriver _driver;
       private readonly HomePage _homePage;

        public HomePageStepDefinitions(ScenarioContext scenarioContext)
        {
            _driver = scenarioContext["WebDriver"] as IWebDriver
                      ?? throw new ArgumentNullException("WebDriver instance is not found in ScenarioContext.");

            // Initialize the SignUpPage object
            _homePage = new HomePage(_driver);

        }
       

        [Given(@"I am on the Sign Up page")]
        public void GivenIAmOnTheSignUpPage()
        {
            _driver.Navigate().GoToUrl(WebUrls);
            _homePage.btnRegister.Click();
        }

        [When(@"I enter the following details:")]
        public void WhenIEnterTheFollowingDetails(Table table)
        {
            foreach (var row in table.Rows)
            {
                var field = row["Field"];
                var value = row["Value"];

                switch (field)
                {
                    case "Gender":
                        _homePage.SelectGender(value);
                        break;
                    case "Email Address":
                        // Check if the email value should be randomly generated
                        if (string.IsNullOrEmpty(value))
                        {
                            value = Randomer.GenerateRandomEmail();
                        }
                        _homePage.EnterEmail(value);
                        break;
                    case "Username":
                        // Check if the email value should be randomly generated
                        if (string.IsNullOrEmpty(value))
                        {
                            value = Randomer.GenerateRandomEmail();
                        }
                        _homePage.EnterUsername(value);
                        break;
                    case "Known As":
                        _homePage.EnterKnownAs(value);
                        break;
                    case "Date Of Birth":
                        _homePage.EnterDateOfBirth(value);
                        break;
                    case "City":
                        _homePage.SelectCity(value);
                        break;
                    case "Country":
                        _homePage.SelectCountry(value);
                        break;
                    case "Password":
                        _homePage.EnterPassword(value);
                        break;
                    case "Confirm Password":
                        _homePage.EnterConfirmPassword(value);
                        break;
                    default:
                        throw new ArgumentException($"Field '{field}' is not recognized.");
                }
            }
        }

        [When(@"I submit the sign-up form")]
        public void WhenISubmitTheSign_UpForm()
        {
            _homePage.Submit();
        }

        [Then(@"I should see a welcome message")]
        public void ThenIShouldSeeAWelcomeMessage()
        {
            _homePage.MembersPage();
        }
    }
}
