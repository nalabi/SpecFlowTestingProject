using Gherkin.CucumberMessages.Types;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowTestingProject.Utilities;
using TechTalk.SpecFlow;


namespace SpecFlowProjectTesting.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        // Path to your log directory
        private readonly string logDirectory = @"C:\Logs\MyApp";

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

            try
            {
                // Ensure the log directory exists
                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }

                NLogProgrammaticSetup.Setup();
                Logger.Info("Test run started");

                // Clean up old log files
                LogFileCleanup.DeleteOldLogFiles(logDirectory, 30);
                Logger.Info("Old log files cleaned up successfully.");
            }
            catch (System.Exception ex)
            {
                Logger.Error($"Error during log setup or cleanup: {ex.Message}");
            }
        }

        [BeforeStep]
        public void BeforeStep()
        {
            Logger.Info($"{nameof(Hooks)}");    
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepText = scenarioContext.StepContext.StepInfo.Text;

            // Generate a unique scenario ID for logging purposes
            string scenarioId = Guid.NewGuid().ToString();
            string tags = string.Join(", ", scenarioContext.ScenarioInfo.Tags);

            if (scenarioContext.TestError == null)
            {
                // Log success message
                Logger.Info($"Step passed: {stepText} | Scenario: {scenarioContext.ScenarioInfo.Title} | ID: {scenarioId} | Tags: {tags}");

              
            }
            else
            {
                // Log full error details
                string errorMessage = scenarioContext.TestError.Message;
                string stackTrace = scenarioContext.TestError.StackTrace ?? "No stack trace available";

                Logger.Error($"Scenario failed: {scenarioContext.ScenarioInfo.Title} | ID: {scenarioId} | Tags: {tags} | {scenarioContext.TestError.GetType()}: {errorMessage}\n{stackTrace}");

            }
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
          
            {
                // Retrieve WebDriver instance from ScenarioContext and quit
                if (_scenarioContext.ContainsKey("WebDriver"))
                {
                    var driver = _scenarioContext["WebDriver"] as IWebDriver;
                    driver?.Quit();
                }

                // Shutdown NLog to flush logs
                LogManager.Shutdown();
            }

        }
    }
}
