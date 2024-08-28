using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

public abstract class BasePage
{
    protected IWebDriver Driver { get; }

    protected BasePage(IWebDriver driver)
    {
        Driver = driver;
        PageFactory.InitElements(driver, this);
    }

    // Common methods shared across different pages can be added here
    public void NavigateTo(string url)
    {
        Driver.Navigate().GoToUrl(url);
    }

    public string GetPageTitle()
    {
        return Driver.Title;
    }
}
