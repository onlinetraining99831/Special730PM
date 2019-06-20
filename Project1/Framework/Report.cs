using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Framework
{
    public class Report
    {
        public static ExtentHtmlReporter extenthtmlreporter =
            new ExtentHtmlReporter(constants.projectpath + @"\Reports\Reports.html");

        public static ExtentReports extentreport = new ExtentReports();

        public static ExtentTest extenttest;
    }
}
