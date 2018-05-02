using Automation_TestScripts;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace npoi.Tests2
{
    [TestFixture]
    public class loginpage
    {

        public By selecthospital = By.XPath("//*[@id='hospitalSelect']/span/input");
        public By username = By.XPath("//*[@id='UserName']");
        public By password = By.XPath("//*[@id='Password']");
        public By loginbtn = By.XPath("//*[@id='btnLogin']");
        public By homepage = By.XPath("//*[@id='DivQuickLinks']/ul/li[1]/a");
        public By logout = By.XPath("//a[@href='/Home/Logout']");
        public By logoutlink1 = By.XPath("//*[@id='content']/a");
        public By errmsg = By.XPath("//*[@id='GenericErrorLabel']");

        //public IWebDriver driver;
        public WebDriverWait wait = null;

        public static Object[][] obj2;
        public static Dictionary<String, String> data;



        IWebDriver driver;

        [Test, TestCaseSource("getdata")]

        public void TestMethod(Dictionary<String, String> obj)
        {

            string nav = obj["username"];



           
            //  FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"D:\RNG_Automation", "geckodriver.exe");

            // service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";

            // driver = new FirefoxDriver(service);
            if (driver == null)
            {
                driver = new ChromeDriver();

               driver.Navigate().GoToUrl("https://dashadmit123.com");
                driver.Manage().Window.Maximize();

            }

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            //wait.Until(ExpectedConditions.ElementIsVisible(username));

            //driver.FindElement(selecthospital).Click();
            //driver.FindElement(selecthospital).Clear();
            //driver.FindElement(selecthospital).SendKeys(obj["Hospital"]);

            //driver.FindElement(username).Clear();
            //driver.FindElement(username).SendKeys(obj["UserName"]);

            //driver.FindElement(password).Clear();
            //driver.FindElement(password).SendKeys(obj["Password"]);
            //driver.FindElement(loginbtn).Click();

            //Thread.Sleep(2000);

            //try
            //{
            //    if (driver.FindElement(logout) != null)
            //    {
            //        // wait.Until(ExpectedConditions.ElementIsVisible(homepage));
            //        // if (driver.FindElement(homepage).Displayed)
            //        //{
            //        //wait.Until(ExpectedConditions.ElementIsVisible(homepage));
            //        driver.FindElement(logout).Click();
            //        driver.FindElement(logoutlink1).Click();
            //        //}
            //    }
            //}
            //catch (Exception rr) { }


        }

        public static Object[][] getdata()
        {
            Xls_Reader xls = new Xls_Reader(@"d:\data.xls");

            String sheetName = "Sheet1";
            int testStartRowNum = 1;
            while (!xls.getCellData(sheetName, 0, testStartRowNum).Equals("ptest"))
            {
                testStartRowNum++;
            }
            Console.WriteLine("Test starts from no- " + testStartRowNum);
            int colStartRowNum = testStartRowNum + 1;
            int dataStartRowNum = testStartRowNum + 2;

            //Calculate rows of data
            int rows = 0;
            while (!xls.getCellData(sheetName, 0, dataStartRowNum + rows).Equals(""))
            {
                rows++;

            }
            Console.WriteLine("Total rows is: " + rows);

            //Calculate cols of data
            int cols = 0;
            while (!xls.getCellData(sheetName, cols, colStartRowNum).Equals(""))
            {
                cols++;
            }
            Console.WriteLine("Total cols is: " + cols);
            obj2 = new Object[rows][];
            int datarow = 0;

            //  Hashtable myDict = new Hashtable();

            for (int rNum = dataStartRowNum; rNum < dataStartRowNum + rows; rNum++)
            {
                obj2[datarow] = new object[1];
                data = new Dictionary<String, String>();
                for (int cNum = 0; cNum < cols; cNum++)
                {

                    //data[datarow, cNum]=xls.getCellData(sheetName, cNum, rNum);
                    //table = new Dictionary<string, string>();
                    String key = xls.getCellData(sheetName, cNum, colStartRowNum);
                    String value = xls.getCellData(sheetName, cNum, rNum);
                    data.Add(key, value);
                    //  myDict.Add(table);


                }
                obj2[datarow][0] = data;
                datarow++;
                //   myDict = new List<Dictionary<string, string>>();
            }
            return obj2;

        }
    }
}

