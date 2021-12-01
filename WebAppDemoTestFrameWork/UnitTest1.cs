using NUnit.Framework;
using System;
using WebAppDemoTestFrameWork.GenericLib;
using WebAppDemoTestFrameWork.ElementLocators;

namespace WebAppDemoTestFrameWork
{
    public class Tests : Login
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCaseSource(typeof(Login), "BrowserToRunWith")]
        public void Test1(String browserName)
        {
            Setup(browserName);
            SeleniumElementLocators SeleniumElementLocators = new SeleniumElementLocators();
            SeleniumElementLocators.amount.SendKeys("2");
            SeleniumElementLocators.fromCurrency.SendKeys("USD");
            SeleniumElementLocators.toCurrency.SendKeys("INR");
            SeleniumElementLocators.convertButon.Click();


        }
    }
}