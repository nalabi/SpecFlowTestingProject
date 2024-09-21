using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace SpecFlowTestingProject.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        protected IWebDriver Driver { get; }

        private By btnRegister = By.XPath("//button[@class='btn btn-primary btn-lg mr-2'][contains(.,'Register')]");
        private By GenderDropdown = By.XPath("//input[@value='male']");
        private By GenderDropdownF = By.XPath("//input[@value='female']");
        private By EmailField = By.XPath("//input[contains(@placeholder,'Email Address')]");
        private By UsernameField = By.XPath("(//input[contains(@type,'text')])[3]");
        private By KnownAsField = By.XPath("//input[contains(@placeholder,'Known As')]");
        private By DateOfBirthField = By.XPath("//input[contains(@placeholder,'Date Of Birth')]");
        private By CityDropdown = By.XPath("//input[contains(@placeholder,'City')]");
        private By CountryText = By.XPath("//input[contains(@placeholder,'Country')]");
        private By PasswordField = By.XPath("(//input[contains(@type,'password')])[2]");
        private By ConfirmPasswordField = By.XPath("//input[contains(@placeholder,'Confirm Password')]");
        private By SubmitBtn = By.XPath("//button[@type='submit'][contains(.,'Register')]");
                
        public void SelectGender(string gender)
        {
            By GenderLocator;
            if (gender.ToLower() == "male")
            {
                GenderLocator = GenderDropdown;
            }
            else if (gender.ToLower() == "female")
            {
                GenderLocator = GenderDropdownF;           }
            else
            {
                throw new ArgumentException("Invalid gender selection");
            }

        }

        public void EnterEmail(string email)
        {
            EnterText(EmailField, email);
        }

        public void EnterUsername(string username)
        {
            EnterText(UsernameField, username);
        }

        public void EnterKnownAs(string knownAs)
        {
            EnterText(KnownAsField, knownAs);   
        }

        public void EnterDateOfBirth(string dob)
        {
            EnterText(DateOfBirthField, dob);
        }

        public void SelectCity(string city)
        {
            EnterText(CityDropdown, city);
           
        }

        public void SelectCountry(string country)
        {
            EnterText(CountryText, country);
        }

        public void EnterPassword(string password)
        {
            EnterText(PasswordField, password);
        }

        public void EnterConfirmPassword(string confirmPassword)
        {
            EnterText(ConfirmPasswordField, confirmPassword);
        }

        public void Submit()
        {
            SubmitForm(SubmitBtn);
        }

        public void MembersPage()
        {
            string MembersPage = "https://hotrave.herokuapp.com/members";
        }

        public void RegisterBtn()
        {
            SubmitForm(btnRegister);
        }
     
    }
}
