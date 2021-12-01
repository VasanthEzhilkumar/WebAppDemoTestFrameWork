using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using AventStack.ExtentReports;
using System.Threading.Tasks;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using NUnit.Framework.Interfaces;


namespace WebAppDemoTestFrameWork.GenericLib
{
    public class Login
    {
        public  Uri url = new Uri(System.Configuration.ConfigurationManager.AppSettings["URL"].ToString());
        public static ExtentReports extent;
        public static ExtentTest test;
        private static TestContext _testContext;


        public TestContext TestContext
        {
            get { return _testContext; }
            set { _testContext = value; }
        }

        public void Setup(String browserName)
        {
            if (browserName.Equals("IE"))
            {
                PropertiesCollection.driver = new InternetExplorerDriver();
                PropertiesCollection.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            }


            if (browserName.Equals("Chrome"))

                PropertiesCollection.driver = new ChromeDriver();


            PropertiesCollection.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            PropertiesCollection.driver.Manage().Window.Maximize();

            PropertiesCollection.driver.Navigate().GoToUrl(url);

            Thread.Sleep(5000);
            PropertiesCollection.driver.Navigate().Refresh();
            Thread.Sleep(5000);
        }

        [TearDown]
        public void GetResult()
        {

            var status = TestContext.CurrentContext.Result.Outcome.Status;

            if (status == TestStatus.Failed)
            {

                CaptureScreenshot();

            }
            extent.Flush();
            PropertiesCollection.driver.Quit();
        }
        private void CaptureScreenshot()
        {
            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;
            Random rndName = new Random();
            ITakesScreenshot ts = (ITakesScreenshot)PropertiesCollection.driver;
            Screenshot screenshot = ts.GetScreenshot();
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string screenShotsfolderPath = projectPath + "ErrorScreenshots\\";

            //string screenShotsfolderPath = "C:\\QA.RegressionTesting.ForC&W\\QA.RegressionTesting.ForCandW\\QA.RegressionTesting.ForCandW\\ErrorScreenshots\\";
            string fileName = rndName.Next().ToString() + ".png";
            string localPath = screenShotsfolderPath + fileName;
            screenshot.SaveAsFile(localPath, ScreenshotImageFormat.Png);
            test.Log(Status.Fail, stackTrace + errorMessage + "Error Screenshot below " + test.AddScreenCaptureFromPath(localPath));
        }


        public string ProjectPath()
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            //string filesPath = projectPath + "DataManagementPackage\\" + fileName;

            return projectPath;
        }
        public static IEnumerable<String> BrowserToRunWith()
        {
            String[] browsers = BrowserSettings.BrowserToRunWith.Split(',');

            foreach (String b in browsers)
            {
                yield return b;
            }
        }
    }
}
