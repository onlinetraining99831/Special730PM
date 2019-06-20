using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Framework
{
    public class browser
    {
        public static void navigateTo(string URL)
        {
            driver.getDriver().Navigate().GoToUrl(URL);
        }

        public static void closeAllBrowsers()
        {
            driver.getDriver().Quit();
            driver.setdriverasnull();
        }

        public static void closeActiveBrowser()
        {
            driver.getDriver().Close();
        }



    }
}
