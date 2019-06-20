using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project1.Framework
{
    public class driver
    {
        private static IWebDriver _driver;

        public static void setdriverasnull()
        {
            _driver = null;
        }


        public static IWebDriver getDriver()
        {
            // show this when we have two or more pages.
            if(_driver==null)
            {
                initializeBrowser(constants.browser);
            }
            return _driver;
        }

        public static void initializeBrowser(string typeofbrowser)
        {
            switch (typeofbrowser.ToLower())
            {
                case "chrome":
                    _driver = new ChromeDriver(constants.chromedriverpath);
                    break;
                case "firefox":
                    FirefoxDriverService service =FirefoxDriverService.CreateDefaultService(constants.firefoxdriverpath);
                    service.FirefoxBinaryPath = constants.firefoxbinarypath;
                    _driver = new FirefoxDriver(service);
                    break;
                default:
                    throw new Exception(typeofbrowser + " is not supported yet.....");
              }
            _driver.Manage().Window.Maximize();
        }



    }
}
