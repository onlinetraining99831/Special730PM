using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Framework
{
    public class constants
    {
        public static string dllpath = Assembly.GetExecutingAssembly().Location.ToString();
        public static string projectpath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(dllpath)));
        public static string solpath = Path.GetDirectoryName(projectpath);
        public static string chromedriverpath = solpath + @"\packages\Selenium.Chrome.WebDriver.74.0.0\driver\";
        public static string firefoxdriverpath = solpath + @"\packages\Selenium.Firefox.WebDriver.0.24.0\driver\";
        public static string firefoxbinarypath = @"C:\Program Files\Mozilla Firefox\firefox.exe";

        public static string browser = ConfigurationManager.AppSettings["browser"];
        public static string appurl = ConfigurationManager.AppSettings["appURL"];
    }
}
