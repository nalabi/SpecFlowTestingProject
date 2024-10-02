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
                NLogProgrammaticSetup.Setup();
                Logger.Info("Test run started");

                // Clean up old log files
                LogFileCleanup.DeleteOldLogFiles(@"C:\Logs\MyApp", 30);
                Logger.Info("Old log files cleaned up successfully.");
            }
            catch (System.Exception ex)
            {
                Logger.Error($"Error during log setup or cleanup: {ex.Message}");
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
        }
    }
}
