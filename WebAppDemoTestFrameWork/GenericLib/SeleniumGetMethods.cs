using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace WebAppDemoTestFrameWork.GenericLib
{
    public static class SeleniumGetMethods
    {
        public static string GetText(IWebElement element)
        {
            return element.GetAttribute("value");

        }
        public static string GetTextFromDropDown(IWebElement element)
        {
            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;

        }
    }
}
