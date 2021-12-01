using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebAppDemoTestFrameWork.GenericLib
{
    public static class SeleniumSetMethods
    {
        // extended method enter text
        public static void EnterText(this IWebElement element, string value)
        {
            element.SendKeys(value);

        }
        //extended method for Click into a button , checkbox, option etc

        public static void Clicks(this IWebElement element)
        {
            element.Click();

        }

        //extended method for selecting a drop down control
        public static void SelectDropDown(this IWebElement element, string value)
        {
            new SelectElement(element).SelectByText(value);

        }
    }
}
