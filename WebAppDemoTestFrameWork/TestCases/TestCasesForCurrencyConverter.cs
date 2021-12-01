using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppDemoTestFrameWork.GenericLib;
using WebAppDemoTestFrameWork.ElementLocators;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System.Threading;
using System.Data;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace WebAppDemoTestFrameWork.TestScripts
{
    public class TestCasesForCurrencyConverter : Login
    {
        [OneTimeSetUp]
        public void StartReport()
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;

            string reportPath = projectPath + "TestReports\\";
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportPath + "CurrencyCoverter");
            htmlReporter.LoadConfig(projectPath + "extent-config.xml");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

            extent.AddSystemInfo("Host Name", "Laptop");
        }


        [Test]
        [TestCaseSource(typeof(Login), "BrowserToRunWith")]
        public void CurrencyCoverter(String browserName)
        {
            test = extent.CreateTest("Verifying conversion of currency");
            test.Log(Status.Info, "Verifying conversion of currency");

            Setup(browserName);
            test.Log(Status.Info, "application lanched");
            string prjectPath = ProjectPath();
            string testDataFolderPath = prjectPath + "\\TestData\\";
            DataTable dataTable = SpreadsheetLightProcessor.ReadExcelData(testDataFolderPath + "TestData.xlsx", "Currency");
            int columns = dataTable.Columns.Count;
            int rows = dataTable.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
                //Reading values from the Excel 
                object amount = dataTable.Rows[i]["Amount"];
                object fromCurrency = dataTable.Rows[i]["From Currency"];
                object toCurrency = dataTable.Rows[i]["To Currency"];
                object expectedAmount = dataTable.Rows[i]["Expected Amount"];

                SeleniumElementLocators seleniumElementLocators = new SeleniumElementLocators();
                seleniumElementLocators.Converttab.Click();
                Thread.Sleep(3000);
                seleniumElementLocators.amount.SendKeys(Keys.Control + "a");
                Thread.Sleep(5000);

                SeleniumSetMethods.EnterText(seleniumElementLocators.amount, amount.ToString());

                Thread.Sleep(5000);

                //Setting up the From Currency
                seleniumElementLocators.fromCurrency.Click();
                seleniumElementLocators.fromCurrency.SendKeys(fromCurrency.ToString());
                seleniumElementLocators.fromCurrency.SendKeys(Keys.Enter);


                //Setting up To currency
                seleniumElementLocators.toCurrency.SendKeys(toCurrency.ToString());
                seleniumElementLocators.toCurrency.SendKeys(Keys.Enter);



                //Clicking on Convert button
                seleniumElementLocators.convertButon.Click();

                //Validating the Expected value
                Thread.Sleep(5000);
                string actualAmout = seleniumElementLocators.actualAmount.Text;
                Assert.IsNotNull(actualAmout);
                test.Log(Status.Pass, "actual amount is not null");
                Assert.That(actualAmout, Does.Match(expectedAmount.ToString()));
                test.Log(Status.Pass, "actual amount is " + actualAmout);


            }
        }
        [TearDown]
        public void tearDown()
        {
            extent.Flush();
            PropertiesCollection.driver.Close();

        }
    }
}
