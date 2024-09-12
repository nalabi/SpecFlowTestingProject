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

    // Common method for entering text
    protected void EnterText(By by, string text)
    {
        Find(by).SendKeys(text);
    }


    protected void WaitForElement(By by, int timeoutInSeconds)
    {
        //WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
        //wait.Until(SeleniumExtras.PageObjects.Wa)
        //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
    }
}

