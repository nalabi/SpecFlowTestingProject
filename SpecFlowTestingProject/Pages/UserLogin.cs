using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace SpecFlowTestingProject.Pages
{
    public class UserLoginPage : BasePage
    {

        public UserLoginPage(IWebDriver driver) : base(driver)
        {
        }

        private readonly By txtUsername = By.XPath("//input[contains(@name,'username')]");
        private readonly By txtPassword = By.XPath("//input[@name='password']");
        private readonly By btnLogin = By.XPath("//button[@type='submit'][contains(.,'Login')]");

      
        public void EnterUsername(string username)
        {
            Driver.FindElement(txtUsername).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            Driver.FindElement(txtPassword).SendKeys(password);
        }

        public void ClickLoginButton()
        {
            Driver.FindElement(btnLogin).Click();
        }



    }

}
