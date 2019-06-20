using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.POM
{
    public class HomePage
    {
        IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By logoutlnk = By.Id("ctl00_logout");
        By orderslnk = By.LinkText("Order");

        public void logout()
        {
            driver.FindElement(logoutlnk).Click();
        }

        public void clickOrders()
        {
            driver.FindElement(orderslnk).Click();
        }



    }
}
