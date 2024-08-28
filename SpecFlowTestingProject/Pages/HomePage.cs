using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace SpecFlowTestingProject.Pages
{
    public class HomePage
    {

        protected IWebDriver Driver { get; }
        public HomePage(IWebDriver driver) {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-primary btn-lg mr-2'][contains(.,'Register')]")]


        public IWebElement btnRegister { get; set;}
        [FindsBy(How = How.XPath, Using = "//input[@value='male']")]
        private IWebElement GenderDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@placeholder,'Email Address')]")]
        private IWebElement EmailField { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[contains(@type,'text')])[3]")]
        private IWebElement UsernameField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@placeholder,'Known As')]")]
        private IWebElement KnownAsField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@placeholder,'Date Of Birth')]")]
        private IWebElement DateOfBirthField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@placeholder,'City')]")]
        private IWebElement CityDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@placeholder,'Country')]")]
        private IWebElement CountryDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[contains(@type,'password')])[2]")]
        private IWebElement PasswordField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@placeholder,'Confirm Password')]")]
        private IWebElement ConfirmPasswordField { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@type='submit'][contains(.,'Register')]")]
        private IWebElement SubmitButton { get; set; }

        public void SelectGender(string gender)
        {
            GenderDropdown.Click();
        }

        public void EnterEmail(string email)
        {
            EmailField.SendKeys(email);
        }

        public void EnterUsername(string username)
        {
            UsernameField.SendKeys(username);
        }

        public void EnterKnownAs(string knownAs)
        {
            KnownAsField.SendKeys(knownAs);
        }

        public void EnterDateOfBirth(string dob)
        {
            DateOfBirthField.SendKeys(dob);
        }

        public void SelectCity(string city)
        {
            CityDropdown.SendKeys(city);
           
        }

        public void SelectCountry(string country)
        {
            CountryDropdown.SendKeys(country);
        }

        public void EnterPassword(string password)
        {
            PasswordField.SendKeys(password);
        }

        public void EnterConfirmPassword(string confirmPassword)
        {
            ConfirmPasswordField.SendKeys(confirmPassword);
        }

        public void Submit()
        {
            SubmitButton.Click();
        }

        public void MembersPage()
        {
            string MembersPage = "https://hotrave.herokuapp.com/members";
        }

     
    }
}
