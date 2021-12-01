using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppDemoTestFrameWork.GenericLib;

namespace WebAppDemoTestFrameWork.ElementLocators
{
    public class SeleniumElementLocators
    {
        public SeleniumElementLocators()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }
        [FindsBy(How = How.Id, Using = "amount")]
        public IWebElement amount { get; set; }

        [FindsBy(How = How.Id, Using = "midmarketFromCurrency")]
        public IWebElement fromCurrency { get; set; }

        [FindsBy(How = How.Id, Using = "midmarketToCurrency")]
        public IWebElement toCurrency { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text()='Convert']")]
        public IWebElement convertButon { get; set; }

        [FindsBy(How = How.XPath, Using = "//p[@class = 'result__BigRate-sc-1bsijpp-1 iGrAod']")]
        public IWebElement actualAmount { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text()='Learn more']")]
        public IWebElement learnMore { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='View transfer quote']")]
        public IWebElement Viewtransferquote { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='tab-box__Tab-sc-28io75-2 gfPaoD']")]
        public IWebElement Converttab { get; set; }


    }
}
