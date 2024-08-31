using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowTestingProject.Pages
{
    public class UserLoginPage
    {
        protected IWebDriver Driver { get; }
        public UserLoginPage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'username')]")]
        //input[contains(@name,'username')]
        public IWebElement txtUsername { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='password']")]
        public IWebElement txtPassword { get; set; }


        [FindsBy(How = How.XPath, Using = "//button[@type='submit'][contains(.,'Login')]")]
        public IWebElement btnLogin{ get; set; }
        public void validUsername(string username)
        {
          
            txtUsername.SendKeys(username);
        }

        public void validPassword(string password)
        {
           
            txtPassword.SendKeys(password);
        }

        public void loginButton()
        {
            btnLogin.Submit();
        }

       
    }
    
}
