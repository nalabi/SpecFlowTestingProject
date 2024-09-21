using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;


public abstract class BasePage
{
    protected IWebDriver Driver { get; }

    protected BasePage(IWebDriver driver)
    {
        Driver = driver;
        PageFactory.InitElements(driver, this);
    }

        public void NavigateTo(string url)
    {
        Driver.Navigate().GoToUrl(url);
    }

    public string GetPageTitle()
    {
        return Driver.Title;
    }

    // Method to find an element using the By locator
    public IWebElement Find(By by)
    {
        return Driver.FindElement(by);
    }

    // Common method for clicking elements
    protected void Click(By by)
    {
        Find(by).Click();
    }

    public void EnterText(By locator, string text)
    {
        IWebElement element = Driver.FindElement(locator);
        element.Clear();  // Clear any pre-filled text (optional)
        element.SendKeys(text);
    }


protected void WaitForElement(By by, int timeoutInSeconds)
    {
        WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
    
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
    }

    public void SubmitForm(By submitButtonLocator)
    {
        IWebElement submitButton = Driver.FindElement(submitButtonLocator);
        submitButton.Click();
    }
}

 