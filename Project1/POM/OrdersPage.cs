using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.POM
{
    public class OrdersPage
    {
        IWebDriver driver;

        public OrdersPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_fmwOrder_txtQuantity")]
        private IWebElement _txtquantity;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_fmwOrder_txtName")]
        private IWebElement _txtcustname;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_fmwOrder_TextBox2")]
        private IWebElement _txtstreet;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_fmwOrder_TextBox3")]
        private IWebElement _txtcity;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_fmwOrder_TextBox4")]
        private IWebElement _txtstate;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_fmwOrder_TextBox5")]
        private IWebElement _txtzip;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_fmwOrder_cardList_0")]
        private IWebElement _radvisa;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_fmwOrder_TextBox6")]
        private IWebElement _txtcardno;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_fmwOrder_TextBox1")]
        private IWebElement _txtexpiry;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_fmwOrder_InsertButton")]
        private IWebElement _btnprocess;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_orderGrid")]
        private IWebElement _tblorders;

        public void enterdetails(string quantity, string custname, string street, string city,
                                 string state, string zip, string cardno, string expdate)
        {
            _txtquantity.SendKeys(quantity);
            _txtcustname.SendKeys(custname);
            _txtstreet.SendKeys(street);
            _txtcity.SendKeys(city);
            _txtstate.SendKeys(state);
            _txtzip.SendKeys(zip);
            _radvisa.Click();
            _txtcardno.SendKeys(cardno);
            _txtexpiry.SendKeys(expdate);
        }

        public void clickProcessbtn()
        {
            _btnprocess.Click();
        }





    }
}
