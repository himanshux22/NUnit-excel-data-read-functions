using Automation_TestScripts;
using NUnit.Framework;
using NUnit.Tests2;
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

        public static Xls_Reader xls = new Xls_Reader(@"d:\data.xls");
        public static string testcaseName = "UserLogin";

        //  public By errmsg = By.XPath("//*[@id='GenericErrorLabel']");

        //public IWebDriver driver;
        public WebDriverWait wait = null;

        IWebDriver driver=null;
        [Test]
        public void TestMethod()
        {

            // FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"D:\RNG_Automation", "geckodriver.exe");

            // service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";

            Dictionary<String, String> patient = (Dictionary<String, String>)Getdata.getTestdata2(xls, "Patientdetails")[0][0];

            if (patient["AdmType"] == "Direct")
            {

                for (int i = 0; i < 1; i++)
                {
                    Dictionary<String, String> obj = (Dictionary<String, String>)Getdata.getTestdata2(xls, "UserLogin")[i][0];
                    string user = obj["username"];
                    string pass = obj["pass"];



                    Login(user, pass);

                    if (i == 0)
                    {
                        //for (int j = 0; j < Getdata.getTestdata2(xls, "Patientdetails").Length; j++)
                        {
                            Dictionary<String, String> obj1 = (Dictionary<String, String>)Getdata.getTestdata2(xls, "Patientdetails")[i][0];
                            FillForm(obj1);
                        }

                    }
                    else
                 if (i == 1)
                    {

                        HospitilistAccept();

                    }
                    if (i == 2)
                    {
                        Bed_ava_arrived();
                    }
                    else if (i == 3)
                    {
                        Patient_dis();
                    }

                    Thread.Sleep(3000);
                    Logout();

                }

                //tcc tasks by phanee
                {
                    Dictionary<String, String> obj1 = (Dictionary<String, String>)Getdata.getTestdata2(xls, "UserLogin")[4][0];
                    string user1 = obj1["username"];
                    string pass1 = obj1["pass"];


                    Login(user1, pass1);
                    TccReroutePhy();

                    Thread.Sleep(3000);
                    Logout();
                }

            }

            else
                 if (patient["AdmType"] == "Edreferral")
            {
                Dictionary<String, String> obj = (Dictionary<String, String>)Getdata.getTestdata2(xls, "UserLogin")[0][0];
                string user = obj["username"];
                string pass = obj["pass"];



                Login(user, pass);


                //for (int j = 0; j < Getdata.getTestdata2(xls, "Patientdetails").Length; j++)
                {
                    Dictionary<String, String> obj1 = (Dictionary<String, String>)Getdata.getTestdata2(xls, "Patientdetails")[0][0];
                    FillForm(obj1);
                }

                Thread.Sleep(3000);
                Logout();


            }
            else
                 if (patient["AdmType"] == "Phych")
            {
               
                    Dictionary<String, String> obj = (Dictionary<String, String>)Getdata.getTestdata2(xls, "UserLogin")[0][0];
                    string user = obj["username"];
                    string pass = obj["pass"];

                    Login(user, pass);

                       //for (int j = 0; j < Getdata.getTestdata2(xls, "Patientdetails").Length; j++)
                        {
                            Dictionary<String, String> obj1 = (Dictionary<String, String>)Getdata.getTestdata2(xls, "Patientdetails")[0][0];
                            FillForm(obj1);
                        }
                Thread.Sleep(3000);
                Logout();
                //tcclogin
               
                     obj = (Dictionary<String, String>)Getdata.getTestdata2(xls, "UserLogin")[4][0];
                     user = obj["username"];
                     pass = obj["pass"];

                    Login(user, pass);


                TccAccept();
                Thread.Sleep(3000);
                Logout();

                //hcat mcat login
                obj = (Dictionary<String, String>)Getdata.getTestdata2(xls, "UserLogin")[5][0];
                user = obj["username"];
                pass = obj["pass"];

                Login(user, pass);
                 hcatAccept();


                Thread.Sleep(3000);
                    Logout();

                

                for (int i= 1; i < 4; i++){
                    obj = (Dictionary<String, String>)Getdata.getTestdata2(xls, "UserLogin")[i][0];
                    user = obj["username"];
                    pass = obj["pass"];

                    Login(user, pass);


                    if (i == 1)
                    {

                        HospitilistAccept();

                    }
                    if (i == 2)
                    {
                       Bed_ava_arrived();
                    }
                    else if (i == 3)
                    {
                       Patient_dis();
                    }

                    Thread.Sleep(3000);
                    Logout();
                }
                

            }

            }

        public void TccReroutePhy()
        {
            wait.Until(ExpectedConditions.ElementIsVisible((By.XPath("//*[@id='dashboard-table-body']/tr[1]/td[3]/a"))));
            driver.FindElement(By.XPath("//*[@id='dashboard-table-body']/tr[1]/td[3]/a")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible((By.LinkText("Take Action"))));
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("Take Action")).Click();
            driver.FindElement(By.XPath("//*[@id='reffacgrofil']")).SendKeys("h");
            driver.FindElement(By.XPath("//*[@id='reffacgroup']")).SendKeys("h");
            driver.FindElement(By.XPath("//*[@id='tccre-rt2']/div[5]/div/table/tbody/tr[2]/td[1]/label/input")).Click();
            driver.FindElement(By.LinkText("Re-Route Physician")).Click();


        }

        public void hcatAccept()
        {
            wait.Until(ExpectedConditions.ElementIsVisible((By.XPath("//*[@id='dashboard-table-body']/tr[1]/td[2]/a"))));
            driver.FindElement(By.XPath("//*[@id='dashboard-table-body']/tr[1]/td[2]/a")).Click();
            System.Threading.Thread.Sleep(4000);
            wait.Until(ExpectedConditions.ElementIsVisible((By.XPath("//*[@id='body-content']/div[3]/div/div/div/div[8]/a"))));
            driver.FindElement(By.XPath("//*[@id='body-content']/div[3]/div/div/div/div[8]/a")).Click();
            driver.FindElement(By.LinkText("Re-Route Physician")).Click();

        }

        public void TccAccept()
        {
            wait.Until(ExpectedConditions.ElementIsVisible((By.XPath("//*[@id='dashboard-table-body']/tr[1]/td[3]/a"))));
            driver.FindElement(By.XPath("//*[@id='dashboard-table-body']/tr[1]/td[3]/a")).Click();
            System.Threading.Thread.Sleep(4000);
            wait.Until(ExpectedConditions.ElementIsVisible((By.XPath("//*[@id='body-content']/div[3]/div/div/div/div[8]/a"))));
            driver.FindElement(By.XPath("//*[@id='body-content']/div[3]/div/div/div/div[8]/a")).Click();
            driver.FindElement(By.LinkText("Forward to HCAT")).Click();

        }

        public void Logout()
        {
          
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Logout")));
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        public void Login(string user, string pass)
        {
            if (driver == null)
            {
                //driver = new FirefoxDriver();
                driver = new ChromeDriver();
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
                driver.Navigate().GoToUrl("https://dashadmit123.com");
                driver.Manage().Window.Maximize();

            }

            string username = user;
            string password = pass;
            driver.Manage().Window.Maximize();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login")));
            driver.FindElement(By.Id("login")).SendKeys(username);
            driver.FindElement(By.Id("passwd")).SendKeys(password + Keys.Enter);

        }


        private void Patient_dis()
        {
          
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='dashboard-table-body']/tr[1]/td[2]/a/span")));
            driver.FindElement(By.XPath("//*[@id='dashboard-table-body']/tr[1]/td[2]/a/span")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.LinkText("Take Action")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("idpdisAl")));
            driver.FindElement(By.Id("idpdisAl")).Click();
        }

        private void Bed_ava_arrived()
        {

          
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='dashboard-table-body']/tr[1]/td[2]/a/span")));
            driver.FindElement(By.XPath("//*[@id='dashboard-table-body']/tr[1]/td[2]/a/span")).Click();
            Thread.Sleep(2000);
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Take Action")));
            driver.FindElement(By.LinkText("Take Action")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Bed Assign")));
            driver.FindElement(By.LinkText("Bed Assign")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Take Action")).Click();
            driver.FindElement(By.LinkText("Patient Arrived")).Click();
            driver.FindElement(By.XPath("//*[@id='pae0' and @name='']")).Click();
            driver.FindElement(By.LinkText("Confirm")).Click();

        }

        private void HospitilistAccept()
        {
          
            wait.Until(ExpectedConditions.ElementIsVisible((By.XPath("//*[@id='dashboard-table-body']/tr[1]/td[2]/a"))));
            driver.FindElement(By.XPath("//*[@id='dashboard-table-body']/tr[1]/td[2]/a")).Click();
            System.Threading.Thread.Sleep(4000);
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Take Action")));
            driver.FindElement(By.LinkText("Take Action")).Click();
            driver.FindElement(By.XPath("//*[@id='idPhAc']")).Click();
            driver.FindElement(By.XPath("//*[@id='idhosaccp']/span")).Click();

        }
       
        public void FillForm(Dictionary<String, String> obj1)
        {
            string AdmType = obj1["AdmType"];
            string FirstName = obj1["FirstName"];
            string LastName = obj1["LastName"];
            string Gender = obj1["Gender"];
            string month = obj1["month"];
            string day = obj1["day"];
            string year = obj1["year"];
            string AdmitHospital = obj1["AdmitHospital"];
            string AdmitGroup = obj1["AdmitGroup"];
            string ETA = obj1["ETA"];
            string temp = obj1["temp"];
            string Bpsystolic = obj1["Bpsystolic"];
            string BpDiastolic = obj1["BpDiastolic"];
            string pulse = obj1["pulse"];
            string respiration = obj1["respiration"];
            string wcb = obj1["wcb"];
            string Cc = obj1["Cc"];
            string TravelWA = obj1["TravelWA"];
            string ebola = obj1["ebola"];
            string sepsis = obj1["sepsis"];
            string Suspected = obj1["Suspected"];
            string Condition = obj1["Condition"];
            string BedType = obj1["Bedtype"];
            string stable = obj1["stable"];
            string evaluated = obj1["evaluated"];
            string voluntary = obj1["voluntary"];
            string submitForm = obj1["submitForm"];
            string guardian = obj1["guardian"];
            string dementia = obj1["dementia"];
            string drug = obj1["drug"];
            string mental = obj1["mental"];
            string pending = obj1["pending"];
            string delirium = obj1["delirium"];

            //edreferrel
            string Isolation = obj1["Isolation"];
            string fever = obj1["fever"];
            string aches = obj1["fatigue"];
            string fatigue = obj1["fatigue"];
            string diarrhea = obj1["diarrhea"];
            string bleeding = obj1["bleeding"];
            string paperwork = obj1["paperwork"];
           


            Thread.Sleep(2000);
            wait.Until(ExpectedConditions.ElementIsVisible((By.LinkText("Form"))));
            driver.FindElement(By.LinkText("Form")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible((By.Id("alertify-ok"))));

            driver.FindElement(By.Id("alertify-ok")).Click();

            string directadmission = "//*[@id='formtype-checks']/div/label[1]/i";

            string Phychadmission = "//*[@id='formtype-checks']/div/label[3]/i";
            string Edrefadmission = "//*[@id='formtype-checks']/div/label[2]/i";
            

            //direct admission
            if (AdmType == "Direct")
            {

                IWebElement admission = driver.FindElement(By.XPath(directadmission));
                admission.Click();
            }
            else if (AdmType == "Phych")
            {
                IWebElement admission = driver.FindElement(By.XPath(Phychadmission));
                admission.Click();
            }
            else {
                IWebElement admission = driver.FindElement(By.XPath(Edrefadmission));
                admission.Click();

            }
            Thread.Sleep(3000);

             driver.FindElement(By.Id("alertify-ok")).Click();

            driver.FindElement(By.Id("fName")).SendKeys(FirstName);
             driver.FindElement(By.Id("lName")).SendKeys(LastName);
             if (Gender == "Male")
            {
                driver.FindElement(By.XPath("//*[@id='gender']/label[2]/i")).Click();
            }
            else
            {
                driver.FindElement(By.XPath("//*[@id='gender']/label[1]/i")).Click();

            }
            driver.FindElement(By.XPath("//*[@id='Patient']/div/div[1]/div/fieldset[1]/div/div/div[4]/div[1]/select[1]")).SendKeys(month);
            driver.FindElement(By.Id("idDob")).SendKeys(day);
            driver.FindElement(By.XPath("//*[@id='Patient']/div/div[1]/div/fieldset[1]/div/div/div[4]/div[1]/select[2]")).SendKeys(year);
            if (AdmType == "Edreferral")
            {
                if (Isolation == "No")
                {
                    driver.FindElement(By.XPath("//*[@id='radIsoc']/label[1]/i")).Click();
                }
                else { }
                if (fever == "No")
                {
                    driver.FindElement(By.XPath("//*[@id='fever']/label[1]/i")).Click();
                }
                else { }
                if (aches == "No")
                {
                    driver.FindElement(By.XPath("//*[@id='ache']/label[1]/i")).Click();
                }
                else { }
                if (fatigue == "No")
                {
                    driver.FindElement(By.XPath("//*[@id='weak']/label[1]/i")).Click();
                }
                else { }
                if (diarrhea == "No")
                {
                    driver.FindElement(By.XPath("//*[@id='pain']/label[1]/i")).Click();
                }
                else { }
                if (bleeding == "No")
                {
                    driver.FindElement(By.XPath("//*[@id='bleed']/label[1]/i")).Click();
                }
                else { }
                if (paperwork == "No")
                {
                    driver.FindElement(By.XPath("//*[@id='quest-fax']/label[3]/i")).Click();
                    }
                    else { }
            }

           
                driver.FindElement(By.Id("sHosps")).SendKeys(AdmitHospital);
            if (AdmType == "Direct" || AdmType == "Phych")
            {
                if (AdmitGroup == "Himanshu demo") {
                    driver.FindElement(By.XPath("//*[@id='sgsGrps']/label[1]/i")).Click();
                }
                driver.FindElement(By.XPath("//*[@id='sPeta']")).SendKeys(ETA);

            }

            driver.FindElement(By.XPath("//*[@id='cComplaint']")).SendKeys(Cc);

            if (AdmType == "Direct") {
                driver.FindElement(By.XPath("//*[@id='intemp']")).SendKeys(temp);
                driver.FindElement(By.XPath("//*[@id='bpSystolic']")).SendKeys(Bpsystolic);
                driver.FindElement(By.XPath("//*[@id='bpDiastolic']")).SendKeys(BpDiastolic);
                driver.FindElement(By.XPath("//*[@id='inpulse']")).SendKeys(pulse);
                driver.FindElement(By.XPath("//*[@id='inrespiration']")).SendKeys(respiration);
                driver.FindElement(By.XPath("//*[@id='inwbc']")).SendKeys(wcb);
            }
            if (AdmType == "Direct" || AdmType == "Edreferral")
            {

                if (TravelWA == "Yes")
                {
                    driver.FindElement(By.XPath("//*[@id='travel']/label[1]/i")).Click();
                }
                else { }

                if (ebola == "Yes")
                {
                    driver.FindElement(By.XPath("//*[@id='contact']/label[1]/i")).Click();
                }
                else { }
            }
            if (AdmType == "Direct") { 
                if (sepsis == "No")
                {
                    driver.FindElement(By.XPath("//*[@id='chcsirs']/label[5]/i")).Click();
                }
                else { }
                driver.FindElement(By.XPath("//*[@id='idsrc']")).SendKeys(Suspected);
                driver.FindElement(By.XPath("//*[@id='sConds']")).SendKeys(Condition);
                driver.FindElement(By.XPath("//*[@id='sBt']")).SendKeys(BedType);
            }
            if (AdmType == "Phych")
            {
                if (stable == "No")
                {
                    driver.FindElement(By.XPath("//*[@id='mstable']/label[1]/i")).Click();
                }
                else { }
                if (evaluated == "No")
                {
                    driver.FindElement(By.XPath("//*[@id='eveph']/label[1]/i")).Click();
                }
                else { }
                if (voluntary == "No")
                {
                    driver.FindElement(By.XPath("//*[@id='volin']/label[1]/i")).Click();
                }
                else { }




                ///form 2nd part phych// 
                driver.FindElement(By.XPath("//*[@id='next-button']")).Click();

                if (submitForm == "online")
                {
                    driver.FindElement(By.XPath("//*[@id='Psych-Info']/div/div/div/fieldset/div/div/div[1]/div/div[1]/label[1]/i")).Click();
                }
                else { }


                if (guardian == "No")
                {
                    driver.FindElement(By.XPath("//*[@id='Psych-Info']/div/div/div/fieldset/div/div/div[2]/div[1]/label[2]/i")).Click();
                }
                else { }
                if (dementia == "No")
                {
                    driver.FindElement(By.XPath("//*[@id='Psych-Info']/div/div/div/fieldset/div/div/div[5]/div[1]/label[2]/i")).Click();
                }
                else { }
                if (drug == "No")
                {
                    driver.FindElement(By.XPath("//*[@id='Psych-Info']/div/div/div/fieldset/div/div/div[6]/div[1]/label[2]/i")).Click();
                }
                else { }
                if (mental == "No")
                {
                    driver.FindElement(By.XPath("//*[@id='Psych-Info']/div/div/div/fieldset/div/div/div[7]/div[1]/label[2]/i")).Click();
                }
                else { }
                if (pending == "No")
                {
                    driver.FindElement(By.XPath("//*[@id='Psych-Info']/div/div/div/fieldset/div/div/div[8]/div[1]/label[2]/i")).Click();
                }
                else { }
                if (delirium == "No")
                {
                    driver.FindElement(By.XPath("//*[@id='Psych-Info']/div/div/div/fieldset/div/div/div[9]/div[1]/label[2]/i")).Click();
                }
                else { }

            }
            
            

            driver.FindElement(By.Id("admit-submit")).Click();

            wait.Until(ExpectedConditions.ElementIsVisible((By.XPath("//*[@id='rootEle']/body/div[12]/div[3]/div/button"))));
            driver.FindElement(By.XPath("//*[@id='rootEle']/body/div[12]/div[3]/div/button")).Click();
        }



            public static Object[][] getdata()
        {
            return Getdata.getTestdata2(xls, testcaseName);
        }

    }
}

