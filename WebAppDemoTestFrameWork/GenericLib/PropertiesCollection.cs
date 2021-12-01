using OpenQA.Selenium;

namespace WebAppDemoTestFrameWork.GenericLib
{
    enum PropertyType
    {
        Id,
        Name,
        LinkText,
        CssName,
        ClassName

    }
    class PropertiesCollection
    {
        public static IWebDriver driver { get; set; }
    }
}
