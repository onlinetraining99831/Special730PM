using OpenQA.Selenium;
using Project1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.POM
{
    // 1. Element properties. - Two ways.
    // 2. Methods to deal with those elements.
    
    public class LoginPage
    {
        IWebDriver driver;
        Dictionary<string, string> data;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // int x = 10;
        By usernametxt = By.Id("ctl00_MainContent_username");
        By passwordtxt = By.Id("ctl00_MainContent_password");
        By loginbtn = By.Id("ctl00_MainContent_login_button");

        public void login(string uname, string pwd)
        {
            driver.FindElement(usernametxt).SendKeys(uname);
            driver.FindElement(passwordtxt).SendKeys(pwd);
            driver.FindElement(loginbtn).Click();
        }

        public void loginAs(string usertype)
        {
            data=xmlreader.getCredentials("login", usertype);
            login(data["username"],data["password"]);
        }



    }
}
