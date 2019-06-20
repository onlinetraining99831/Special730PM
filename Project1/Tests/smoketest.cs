using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Configuration;
using System.Reflection;
using System.IO;
using Project1.Framework;
using Project1.Utilities;
using Project1.POM;
using OpenQA.Selenium;
using AventStack.ExtentReports;

namespace Project1.Tests
{
    [TestFixture]
    public class smoketest : Report
    {

        [OneTimeSetUp]
        public void initialstep()
        {
            extentreport.AttachReporter(extenthtmlreporter);
        }
        [SetUp]
        public void setup()
        {
            driver.getDriver();
            browser.navigateTo(constants.appurl);
        }

        [Test]
        public void Verify_new_order_creation()
        {
            string testname = TestContext.CurrentContext.Test.MethodName;
            extenttest = extentreport.CreateTest(testname);

            Dictionary<string,string> testdata = excelreader.getdata(testname);
            
            LoginPage loginpage = new LoginPage(driver.getDriver());
            loginpage.loginAs("admin");
            extenttest.Log(Status.Info, "Login is successfull");
            HomePage homepage = new HomePage(driver.getDriver());
            homepage.clickOrders();
            extenttest.Log(Status.Info, "Clicked on the Orders link.");
            
            OrdersPage orderspage = new OrdersPage(driver.getDriver());
            orderspage.enterdetails(testdata["quantity"], testdata["custname"], testdata["street"], testdata["city"],
                testdata["state"], testdata["zip"], testdata["cardno"], testdata["expdate"]);
            extenttest.Log(Status.Info,"Entered all data into the application");
            orderspage.clickProcessbtn();
            extenttest.Log(Status.Info, "Clicked on Process button.");
            System.Threading.Thread.Sleep(10000);
            Assert.IsTrue(driver.getDriver().PageSource.Contains("New order has been successfully added."));
            extenttest.Log(Status.Pass, "User orders is processed correctly.");
            System.Threading.Thread.Sleep(10000);
            homepage.logout();
        }

        
        [TearDown]
        public void closure()
        {
            string testname = TestContext.CurrentContext.Test.MethodName;
            string teststatus = TestContext.CurrentContext.Result.Outcome.ToString();

            switch (teststatus)
            {
                case "Passed":
                    extenttest.Pass(testname);
                    break;

                default:
                    var messsage=TestContext.CurrentContext.Result.Message;
                    var stacktrace = TestContext.CurrentContext.Result.StackTrace;

                    // Below two lines are for taking a snapshot.
                    var screenshot=((ITakesScreenshot)driver.getDriver()).GetScreenshot();
                    screenshot.SaveAsFile(constants.projectpath + @"/Screenshots/" + testname + ".jpg");

                    System.Threading.Thread.Sleep(3000);
                    extenttest.AddScreenCaptureFromPath(constants.projectpath + @"/Screenshots/" + testname + ".jpg");

                    extenttest.Log(Status.Error, messsage);
                    extenttest.Fail(stacktrace);
                    break;
            }
            extentreport.Flush();
            //System.Threading.Thread.Sleep(10000);
            browser.closeAllBrowsers();
        }
    }
}
