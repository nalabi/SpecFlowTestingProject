using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SpecFlowProjectTesting.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // Store WebDriver instance in ScenarioContext
            _scenarioContext["WebDriver"] = driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            // Retrieve WebDriver instance from ScenarioContext and quit
            if (_scenarioContext.ContainsKey("WebDriver"))
            {
                var driver = _scenarioContext["WebDriver"] as IWebDriver;
                driver?.Quit();
            }
        }
    }
}
