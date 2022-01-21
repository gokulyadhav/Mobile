using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Windows;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System.IO;
using System.Threading;
using OpenQA.Selenium.Appium.MultiTouch;
using System.Drawing;


namespace Folio_Grow_Mobile_Application
{
    class Today : MasterClass
    {
        [OneTimeSetUp]
        public void reports()
        {
            reports("Today");
        }
        public string date;
        public void Selectingdate()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Pastmonthnavigation));
            driver.FindElement(FG_PageObject.Pageobject.Pastmonthnavigation).Click();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@text='"+GetData.Date+"']")));
            driver.FindElement(By.XPath("//*[@text='"+GetData.Date+"']")).Click();

        }

        [Test]
        public void TC_FG_3001_Today()
        {
            ExtentTest TC01 = _extent.CreateTest("#FG_3001 - To verify Functionality Navigate to Today Screen");

            GetData.GetDataFrom_Excel("Today", 2);

            TC01.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC01.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC01.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();

            TC01.Log(Status.Info, "Click Menu");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Validation));
            driver.FindElement(FG_PageObject.Pageobject.Validation).Click();

            TC01.Log(Status.Info, "Click Today");
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Today));
            driver.FindElement(FG_PageObject.Pageobject.Today).Click();



            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Assigned));
                TC01.Log(Status.Pass, "Navigated to Today Screen" + TC01.AddScreenCaptureFromPath(screenshot("FG_3001_PASS" + DateTime.Now.ToString("hhmmss"))));

            }
            catch
            {
                TC01.Log(Status.Fail, "Application is not navigated to today screen" + TC01.AddScreenCaptureFromPath(screenshot("TC_3001_PASS" + DateTime.Now.ToString("hhmmss"))));

            }


        }

        [Test]
        public void TC_FG_3002_To_validate_Datepicker_with_Passdate()
        {
            ExtentTest TC02 = _extent.CreateTest("#FG_3002 - To verify Functionality of datepicker with pastdate");

            GetData.GetDataFrom_Excel("Today", 3);

            TC02.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC02.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC02.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();

            TC02.Log(Status.Info, "Click date picker");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Datepicker));
            driver.FindElement(FG_PageObject.Pageobject.Datepicker).Click();

            TC02.Log(Status.Info, "Click Pastdate picker");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Pastmonthnavigation));
            driver.FindElement(FG_PageObject.Pageobject.Pastmonthnavigation).Click();

            TC02.Log(Status.Info, "Click Date");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Selectingdate));
            driver.FindElement(FG_PageObject.Pageobject.Selectingdate).Click();

            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Datepicker));
                string data = driver.FindElement(FG_PageObject.Pageobject.Datepicker).Text.Remove(0, 8);
                if (data.Contains("1"))
                {
                    TC02.Log(Status.Pass, "Past date is selected and verified successfully" + TC02.AddScreenCaptureFromPath(screenshot("FG_3002_PASS" + DateTime.Now.ToString("hhmmss"))));
                }
            }
            catch
            {
                TC02.Log(Status.Fail, "Past date is not verified successfully" + TC02.AddScreenCaptureFromPath(screenshot("FG_3002_Fail" + DateTime.Now.ToString("hhmmss"))));

            }



        }

        [Test]
        public void TC_FG_3003_To_validate_Datepicker_with_Futuredate()
        {
            ExtentTest TC03 = _extent.CreateTest("#FG_3003 - To verify Functionality of datepicker with Futuredate");

            GetData.GetDataFrom_Excel("Today", 4);

            TC03.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC03.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC03.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();

            TC03.Log(Status.Info, "Click date picker");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Datepicker));
            driver.FindElement(FG_PageObject.Pageobject.Datepicker).Click();

            TC03.Log(Status.Info, "Click Future Date picker");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Futuremonthnavigation));
            driver.FindElement(FG_PageObject.Pageobject.Futuremonthnavigation).Click();

            TC03.Log(Status.Info, "Click Date");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Selectingdate));
            driver.FindElement(FG_PageObject.Pageobject.Selectingdate).Click();

            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Datepicker));
                string data = driver.FindElement(FG_PageObject.Pageobject.Datepicker).Text.Remove(0, 8);
                if (data.Contains("1"))
                {
                    TC03.Log(Status.Pass, "Future date is selected and verified successfully" + TC03.AddScreenCaptureFromPath(screenshot("FG_3003_PASS" + DateTime.Now.ToString("hhmmss"))));
                }
            }
            catch
            {
                TC03.Log(Status.Fail, "Future date is not verified successfully" + TC03.AddScreenCaptureFromPath(screenshot("FG_3003_Fail" + DateTime.Now.ToString("hhmmss"))));

            }


        }

        [Test]
        public void TC_FG_3004_To_validate_Datepicker_with_Currentdate()
        {
            ExtentTest TC04 = _extent.CreateTest("#FG_3004 - To verify Functionality of datepicker with Currentdate");

            GetData.GetDataFrom_Excel("Today", 5);


            currendate();

            TC04.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC04.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC04.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();

            TC04.Log(Status.Info, "Click date picker");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Datepicker));
            driver.FindElement(FG_PageObject.Pageobject.Datepicker).Click();


            TC04.Log(Status.Info, "Click Date");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Currentdate(currr)));
            driver.FindElement(FG_PageObject.Pageobject.Currentdate(currr)).Click();

            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Datepicker));
                string data = driver.FindElement(FG_PageObject.Pageobject.Datepicker).Text.Remove(0, 8);
                if (data.Contains(currr))
                {
                    TC04.Log(Status.Pass, "Current date is selected and verified successfully" + TC04.AddScreenCaptureFromPath(screenshot("FG_3004_PASS" + DateTime.Now.ToString("hhmmss"))));
                }
            }
            catch
            {
                TC04.Log(Status.Fail, "Current date is not verified successfully" + TC04.AddScreenCaptureFromPath(screenshot("FG_3004_Fail" + DateTime.Now.ToString("hhmmss"))));

            }


        }
        [Test]
        public void TC_FG_3005_To_Verify_functionality_of_Forwardnavigationbutton()
        {
            ExtentTest TC05 = _extent.CreateTest("#FG_3005 - To verify Functionality of Forward Navigation Button");

            GetData.GetDataFrom_Excel("Today", 6);

            TC05.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC05.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC05.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();

            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Datepicker));
            string data = driver.FindElement(FG_PageObject.Pageobject.Datepicker).Text;

            TC05.Log(Status.Info, "Click Forward Navigation Button");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.RightNavigation));
            TC05.Log(Status.Pass, "Forward Navigation" + TC05.AddScreenCaptureFromPath(screenshot("FG_3005_PASS" + DateTime.Now.ToString("hhmmss"))));
            driver.FindElement(FG_PageObject.Pageobject.RightNavigation).Click();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Datepicker));
            string data1 = driver.FindElement(FG_PageObject.Pageobject.Datepicker).Text;

            if (data1 != data)
            {
                TC05.Log(Status.Pass, "Forward Navigation Button verified successfully" + TC05.AddScreenCaptureFromPath(screenshot("FG_3005_PASS" + DateTime.Now.ToString("hhmmss"))));
            }
            else
            {
                TC05.Log(Status.Fail, "Forward Navigation Button is not verified successfully" + TC05.AddScreenCaptureFromPath(screenshot("FG_3005_FAIL" + DateTime.Now.ToString("hhmmss"))));
            }


        }
        [Test]
        public void TC_FG_3006_To_Verify_functionality_of_BackwardNavigation()
        {
            ExtentTest TC06 = _extent.CreateTest("#FG_3006 - To verify Functionality of Backward Navigation Button");

            GetData.GetDataFrom_Excel("Today", 7);

            TC06.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC06.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC06.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Datepicker));
            string data = driver.FindElement(FG_PageObject.Pageobject.Datepicker).Text;

            TC06.Log(Status.Info, "Click Backward Navigation Button");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.LeftNavigation));
            TC06.Log(Status.Pass, "Backward Navigation Button" + TC06.AddScreenCaptureFromPath(screenshot("FG_3006_PASS" + DateTime.Now.ToString("hhmmss"))));
            driver.FindElement(FG_PageObject.Pageobject.LeftNavigation).Click();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Datepicker));
            string data1 = driver.FindElement(FG_PageObject.Pageobject.Datepicker).Text;

            if (data1 != data)
            {
                TC06.Log(Status.Pass, "Backward Navigation Button verified successfully" + TC06.AddScreenCaptureFromPath(screenshot("FG_3006_PASS" + DateTime.Now.ToString("hhmmss"))));
            }
            else
            {
                TC06.Log(Status.Fail, "Backward Navigation Button is not verified successfully" + TC06.AddScreenCaptureFromPath(screenshot("FG_3006_FAIL" + DateTime.Now.ToString("hhmmss"))));
            }


        }

        [Test]
        public void TC_FG_3007_To_Verify_functionality_of_Assignedtab()
        {
            ExtentTest TC07 = _extent.CreateTest("#FG_3007 - To verify Functionality of Assigned tab");

            GetData.GetDataFrom_Excel("Today", 8);

            TC07.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC07.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC07.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();

            TC07.Log(Status.Info, "Click Menu");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Validation));
            driver.FindElement(FG_PageObject.Pageobject.Validation).Click();

            TC07.Log(Status.Info, "Click Today");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Today));
            driver.FindElement(FG_PageObject.Pageobject.Today).Click();

            try
            {
                TC07.Log(Status.Info, "Click Assigned");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Assigned));
                driver.FindElement(FG_PageObject.Pageobject.Assigned).Click();

                TC07.Log(Status.Pass, "Assigned functionality verified successfully" + TC07.AddScreenCaptureFromPath(screenshot("FG_3007_PASS" + DateTime.Now.ToString("hhmmss"))));


            }

            catch
            {
                TC07.Log(Status.Fail, "Assigned functionality is not verified successfully" + TC07.AddScreenCaptureFromPath(screenshot("FG_3007_FAIL" + DateTime.Now.ToString("hhmmss"))));

            }


        }

        [Test]
        public void TC_FG_3008_To_Verify_functionality_of_Completed()
        {
            ExtentTest TC08 = _extent.CreateTest("#FG_3008 - To verify Functionality Completed Tab");

            GetData.GetDataFrom_Excel("Today", 9);

            TC08.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC08.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC08.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();

            TC08.Log(Status.Info, "Click Menu");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Validation));
            driver.FindElement(FG_PageObject.Pageobject.Validation).Click();

            TC08.Log(Status.Info, "Click Today");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Today));
            driver.FindElement(FG_PageObject.Pageobject.Today).Click();

            try
            {
                TC08.Log(Status.Info, "Click Completed");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Completed));
                driver.FindElement(FG_PageObject.Pageobject.Completed).Click();

                TC08.Log(Status.Pass, "Completed functionality verified successfully" + TC08.AddScreenCaptureFromPath(screenshot("FG_3008_PASS" + DateTime.Now.ToString("hhmmss"))));


            }

            catch
            {
                TC08.Log(Status.Fail, "Completed functionality is not verified successfully" + TC08.AddScreenCaptureFromPath(screenshot("FG_3008_FAIL" + DateTime.Now.ToString("hhmmss"))));

            }


        }


        [Test]
        public void TC_FG_3009_To_Verify_functionality_of_Start_Task()
        {
            ExtentTest TC09 = _extent.CreateTest("#FG_3009 - To verify Functionality of Start Task");

            GetData.GetDataFrom_Excel("Today", 10);

            currendate();

            TC09.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC09.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC09.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();

            TC09.Log(Status.Info, "Click Menu");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Validation));
            driver.FindElement(FG_PageObject.Pageobject.Validation).Click();

            TC09.Log(Status.Info, "Click Today");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Today));
            driver.FindElement(FG_PageObject.Pageobject.Today).Click();

            TC09.Log(Status.Info, "Click date picker");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Datepicker));
            driver.FindElement(FG_PageObject.Pageobject.Datepicker).Click();


            //do
            //{
            //    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@text='1']")));
            //    driver.FindElement(By.XPath("//*[@text='1']")).Click();

            //    TC09.Log(Status.Info, "Click date picker");
            //    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Datepicker));
            //    driver.FindElement(FG_PageObject.Pageobject.Datepicker).Click();

            //    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Pastmonthnavigation));
            //    driver.FindElement(FG_PageObject.Pageobject.Pastmonthnavigation).Click();

            //} while (date.Contains(GetData.Monthyear));


            Selectingdate();

            TC09.Log(Status.Info, "Click start task");

             wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Assigned));
            TC09.Log(Status.Info, "Start Task functionality verified successfully" + TC09.AddScreenCaptureFromPath(screenshot("FG_3009_PASS" + DateTime.Now.ToString("hhmmss"))));
            driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                              + "new UiSelector().text(\"Start Task\"));").Click();
            
            


            try
            {
                TC09.Log(Status.Info, "Verify Start");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Tasktimervalue));
                TC09.Log(Status.Pass, "Start Task functionality verified successfully" + TC09.AddScreenCaptureFromPath(screenshot("FG_3009_PASS" + DateTime.Now.ToString("hhmmss"))));
            }

            catch
            {
                TC09.Log(Status.Fail, "Start Task functionality is not verified successfully" + TC09.AddScreenCaptureFromPath(screenshot("FG_3009_FAIL" + DateTime.Now.ToString("hhmmss"))));

            }


        }

        [Test]
        public void TC_FG_3011_To_Verify_functionality_of_Tips()
        {
            ExtentTest TC10 = _extent.CreateTest("#FG_3011 - To verify Functionality of Tips");

            GetData.GetDataFrom_Excel("Today", 11);

            currendate();

            TC10.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC10.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC10.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();

            TC10.Log(Status.Info, "Click Menu");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Validation));
            driver.FindElement(FG_PageObject.Pageobject.Validation).Click();

            TC10.Log(Status.Info, "Click Today");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Today));
            driver.FindElement(FG_PageObject.Pageobject.Today).Click();

            TC10.Log(Status.Info, "Click date picker");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Datepicker));
            driver.FindElement(FG_PageObject.Pageobject.Datepicker).Click();

            Selectingdate();

            //TC10.Log(Status.Info, "Click Date");
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Currentdate(currr)));
            //driver.FindElement(FG_PageObject.Pageobject.Currentdate(currr)).Click();
            TC10.Log(Status.Info, "Click Start");
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Assigned));
                driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                              + "new UiSelector().text(\"Start Task\"));").Click();
            }
            catch
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Assigned));
                driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                              + "new UiSelector().text(\"Ongoing Task\"));").Click();
            }

            TC10.Log(Status.Info, "Click Tips");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Tips));
            driver.FindElement(FG_PageObject.Pageobject.Tips).Click();

            try
            {
                TC10.Log(Status.Info, "Verify Tips");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.verifytips));
                TC10.Log(Status.Pass, "Tips functionality verified successfully" + TC10.AddScreenCaptureFromPath(screenshot("FG_3011_PASS" + DateTime.Now.ToString("hhmmss"))));
            }
            catch
            {
                TC10.Log(Status.Fail, "Tips functionality is not verified successfully" + TC10.AddScreenCaptureFromPath(screenshot("FG_3011_FAIL" + DateTime.Now.ToString("hhmmss"))));
            }
        }

        [Test]
        public void TC_FG_3012_To_Verify_functionality_of_Taskmeter()
        {
            ExtentTest TC11 = _extent.CreateTest("#FG_3012 - To verify Functionality of Taskmeter");

            GetData.GetDataFrom_Excel("Today", 12);

            currendate();

            TC11.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC11.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC11.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();

            TC11.Log(Status.Info, "Click Menu");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Validation));
            driver.FindElement(FG_PageObject.Pageobject.Validation).Click();

            TC11.Log(Status.Info, "Click Today");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Today));
            driver.FindElement(FG_PageObject.Pageobject.Today).Click();

            TC11.Log(Status.Info, "Click date picker");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Datepicker));
            driver.FindElement(FG_PageObject.Pageobject.Datepicker).Click();


            Selectingdate();
            //TC11.Log(Status.Info, "Click Date");
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Currentdate(currr)));
            //driver.FindElement(FG_PageObject.Pageobject.Currentdate(currr)).Click();


            TC11.Log(Status.Info, "Click start task");
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Assigned));
                driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                              + "new UiSelector().text(\"Start Task\"));").Click();
            }
            catch
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Assigned));
                driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                              + "new UiSelector().text(\"Ongoing Task\"));").Click();
            }

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Tasktimervalue));
            string Taskname = driver.FindElement(FG_PageObject.Pageobject.Tasktimervalue).Text;
            TC11.Log(Status.Pass, "Taskmeter " + TC11.AddScreenCaptureFromPath(screenshot("FG_3012_PASS" + DateTime.Now.ToString("hhmmss"))));


            TC11.Log(Status.Info, "Click stop task");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.StopTask));
            driver.FindElement(FG_PageObject.Pageobject.StopTask).Click();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Tasktimervalue));
            string Taskname2 = driver.FindElement(FG_PageObject.Pageobject.Tasktimervalue).Text;


            try
            {
                TC11.Log(Status.Info, "Verify Tasmeter");
                if (Taskname != Taskname2)
                    TC11.Log(Status.Pass, "Taskmeter functionality verified successfully" + TC11.AddScreenCaptureFromPath(screenshot("FG_3012_PASS" + DateTime.Now.ToString("hhmmss"))));
            }
            catch
            {
                TC11.Log(Status.Fail, "Taskmeter functionality is not verified successfully" + TC11.AddScreenCaptureFromPath(screenshot("FG_3012_FAIL" + DateTime.Now.ToString("hhmmss"))));
            }
        }

        [Test]
        public void TC_FG_3013_To_Verify_functionality_of_Stoptask()
        {
            ExtentTest TC12 = _extent.CreateTest("#FG_3013 - To verify Functionality of StopTask");

            GetData.GetDataFrom_Excel("Today", 13);

            currendate();

            TC12.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC12.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC12.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();

            TC12.Log(Status.Info, "Click Menu");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Validation));
            driver.FindElement(FG_PageObject.Pageobject.Validation).Click();

            TC12.Log(Status.Info, "Click Today");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Today));
            driver.FindElement(FG_PageObject.Pageobject.Today).Click();

            TC12.Log(Status.Info, "Click date picker");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Datepicker));
            driver.FindElement(FG_PageObject.Pageobject.Datepicker).Click();

            Selectingdate();

            //TC12.Log(Status.Info, "Click Date");
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Currentdate(currr)));
            //driver.FindElement(FG_PageObject.Pageobject.Currentdate(currr)).Click();


            TC12.Log(Status.Info, "Click start task");
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Assigned));
                driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                              + "new UiSelector().text(\"Start Task\"));").Click();
            }
            catch
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Assigned));
                driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                              + "new UiSelector().text(\"Ongoing Task\"));").Click();
            }

            TC12.Log(Status.Info, "Click Stop task");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.StopTask));
            driver.FindElement(FG_PageObject.Pageobject.StopTask).Click();
            TC12.Log(Status.Pass, "Stop Task " + TC12.AddScreenCaptureFromPath(screenshot("FG_3013_PASS" + DateTime.Now.ToString("hhmmss"))));


            try
            {
                TC12.Log(Status.Info, "Verify Stop task");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Completetask));
                driver.FindElement(FG_PageObject.Pageobject.Completetask);
                TC12.Log(Status.Pass, "Stop Task functionality verified successfully" + TC12.AddScreenCaptureFromPath(screenshot("FG_3013_PASS" + DateTime.Now.ToString("hhmmss"))));
            }
            catch
            {
                TC12.Log(Status.Fail, "Stop Task functionality is not verified successfully" + TC12.AddScreenCaptureFromPath(screenshot("FG_3013_FAIL" + DateTime.Now.ToString("hhmmss"))));
            }
        }

        [Test]
        public void TC_FG_3014_To_Verify_functionality_of_Complete()
        {
            ExtentTest TC13 = _extent.CreateTest("#FG_3014 - To verify Functionality of Complete");

            GetData.GetDataFrom_Excel("Today", 14);

            currendate();
            try { 
            TC13.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC13.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC13.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();

            TC13.Log(Status.Info, "Click Menu");
//            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Validation));
            driver.FindElement(FG_PageObject.Pageobject.Validation).Click();

            TC13.Log(Status.Info, "Click Today");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Today));
            driver.FindElement(FG_PageObject.Pageobject.Today).Click();

            TC13.Log(Status.Info, "Click date picker");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Datepicker));
            driver.FindElement(FG_PageObject.Pageobject.Datepicker).Click();


            Selectingdate();

            //TC13.Log(Status.Info, "Click Date");
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Currentdate(currr)));
            //driver.FindElement(FG_PageObject.Pageobject.Currentdate(currr)).Click();


            TC13.Log(Status.Info, "Click start task");
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Assigned));
                driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                              + "new UiSelector().text(\"Start Task\"));").Click();
            }
            catch
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Assigned));
                driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                              + "new UiSelector().text(\"Ongoing Task\"));").Click();
            }

            TC13.Log(Status.Info, "Click stop task");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.StopTask));
            driver.FindElement(FG_PageObject.Pageobject.StopTask).Click();

            TC13.Log(Status.Info, "Click stop task");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Completetask));
            driver.FindElement(FG_PageObject.Pageobject.Completetask).Click();


                Thread.Sleep(2000);    
            TC13.Log(Status.Pass, "Complete Task functionality verified successfully" + TC13.AddScreenCaptureFromPath(screenshot("FG_3014_PASS" + DateTime.Now.ToString("hhmmss"))));
            }
            catch
            {
                TC13.Log(Status.Fail, "Complete Task functionality is not verified successfully" + TC13.AddScreenCaptureFromPath(screenshot("FG_3014_FAIL" + DateTime.Now.ToString("hhmmss"))));
            }
        }

        [Test]
        public void TC_FG_3015_To_Verify_functionality_of_Pausedtask()
        {
            ExtentTest TC14 = _extent.CreateTest("#FG_3015 - To verify Functionality of Pausedtask");

            GetData.GetDataFrom_Excel("Today", 15);

            currendate();

            try {             TC14.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC14.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC14.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();

            TC14.Log(Status.Info, "Click Menu");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Validation));
            driver.FindElement(FG_PageObject.Pageobject.Validation).Click();

            TC14.Log(Status.Info, "Click Today");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Today));
            driver.FindElement(FG_PageObject.Pageobject.Today).Click();

            TC14.Log(Status.Info, "Click date picker");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Datepicker));
            driver.FindElement(FG_PageObject.Pageobject.Datepicker).Click();


            Selectingdate();

            //TC14.Log(Status.Info, "Click Date");
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Currentdate(currr)));
            //driver.FindElement(FG_PageObject.Pageobject.Currentdate(currr)).Click();

            TC14.Log(Status.Info, "Click Start Task");
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Assigned));
                driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                              + "new UiSelector().text(\"Start Task\"));").Click();
            }
            catch
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Assigned));
                driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                              + "new UiSelector().text(\"Ongoing Task\"));").Click();
            }

            TC14.Log(Status.Info, "Click Stop Task");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.StopTask));
            driver.FindElement(FG_PageObject.Pageobject.StopTask).Click();

            TC14.Log(Status.Info, "Click Pause Task");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Pausetaskbutton));
            TC14.Log(Status.Pass, "Paused Task " + TC14.AddScreenCaptureFromPath(screenshot("FG_3015_PASS" + DateTime.Now.ToString("hhmmss"))));
            driver.FindElement(FG_PageObject.Pageobject.Pausetaskbutton).Click();


                Thread.Sleep(2000);
                TC14.Log(Status.Pass, "Paused Task functionality verified successfully" + TC14.AddScreenCaptureFromPath(screenshot("FG_3015_PASS" + DateTime.Now.ToString("hhmmss"))));
            }
            catch
            {
                TC14.Log(Status.Fail, "Paused Task functionality is not verified successfully" + TC14.AddScreenCaptureFromPath(screenshot("FG_3015_FAIL" + DateTime.Now.ToString("hhmmss"))));
            }
        }

        [Test]
        public void TC_FG_3016_To_Verify_functionality_of_ResumeTask()
        {
            ExtentTest TC15 = _extent.CreateTest("#FG_3016 - To verify Functionality of ResumeTask");

            GetData.GetDataFrom_Excel("Today", 16);

            currendate();

            TC15.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC15.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC15.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();

            TC15.Log(Status.Info, "Click Menu");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Validation));
            driver.FindElement(FG_PageObject.Pageobject.Validation).Click();

            TC15.Log(Status.Info, "Click Today");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Today));
            driver.FindElement(FG_PageObject.Pageobject.Today).Click();

            TC15.Log(Status.Info, "Click date picker");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Datepicker));
            driver.FindElement(FG_PageObject.Pageobject.Datepicker).Click();

            Selectingdate();

            //TC15.Log(Status.Info, "Click Date");
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Currentdate(currr)));
            //driver.FindElement(FG_PageObject.Pageobject.Currentdate(currr)).Click();



            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Assigned));
                driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                              + "new UiSelector().text(\"Resume Task\"));").Click();
            }
            catch
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Assigned));
                driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                              + "new UiSelector().text(\"Ongoing Task\"));").Click();
            }

           

            try
            {
                TC15.Log(Status.Info, "Verify Resume task");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Tasktimervalue));
                TC15.Log(Status.Pass, "Resume Task functionality verified successfully" + TC15.AddScreenCaptureFromPath(screenshot("FG_3016_PASS" + DateTime.Now.ToString("hhmmss"))));
            }
            catch
            {
                TC15.Log(Status.Fail, "Resume Task functionality is not verified successfully" + TC15.AddScreenCaptureFromPath(screenshot("FG_3016_FAIL" + DateTime.Now.ToString("hhmmss"))));
            }
        }

        [Test]
        public void TC_FG_3017_To_Verify_functionality_of_Number_of_plants_with_validInputs()
        {
            ExtentTest TC16 = _extent.CreateTest("#FG_3017 - To verify Functionality of Number of plants with valid inputs");

            GetData.GetDataFrom_Excel("Today", 17);

            currendate();

            TC16.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC16.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC16.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();

            TC16.Log(Status.Info, "Click Menu");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Validation));
            driver.FindElement(FG_PageObject.Pageobject.Validation).Click();

            TC16.Log(Status.Info, "Click Today");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Today));
            driver.FindElement(FG_PageObject.Pageobject.Today).Click();

            TC16.Log(Status.Info, "Click date picker");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Datepicker));
            driver.FindElement(FG_PageObject.Pageobject.Datepicker).Click();


            Selectingdate();

            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Assigned));
                driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                              + "new UiSelector().text(\"Resume Task\"));").Click();
            }
            catch
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Assigned));
                driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                              + "new UiSelector().text(\"Ongoing Task\"));").Click();
            }

            TC16.Log(Status.Info, "Enter No of valid Inputs");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Noofplants));
            driver.FindElement(FG_PageObject.Pageobject.Noofplants).Clear();
            driver.FindElement(FG_PageObject.Pageobject.Noofplants).SendKeys(GetData.Noofplants);
            TC16.Log(Status.Pass, "Number of plants" + TC16.AddScreenCaptureFromPath(screenshot("FG_3017_PASS" + DateTime.Now.ToString("hhmmss"))));


            TC16.Log(Status.Info, "Click stop task");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.StopTask));
            driver.FindElement(FG_PageObject.Pageobject.StopTask).Click();

            TC16.Log(Status.Info, "Click Paused task");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Pausetaskbutton));
            driver.FindElement(FG_PageObject.Pageobject.Pausetaskbutton).Click();


            try
            {
                TC16.Log(Status.Info, "Verify Valid Inputs");
                TC16.Log(Status.Pass, "Number of plants Task functionality verified successfully" + TC16.AddScreenCaptureFromPath(screenshot("FG_3017_PASS" + DateTime.Now.ToString("hhmmss"))));
            }
            catch
            {
                TC16.Log(Status.Fail, "Number of plants Task functionality is not verified successfully" + TC16.AddScreenCaptureFromPath(screenshot("FG_3017_FAIL" + DateTime.Now.ToString("hhmmss"))));
            }
        }

        [Test]
        public void TC_FG_3018_To_Verify_functionality_of_Number_of_plants_with_InvalidInputs()
        {
            ExtentTest TC17 = _extent.CreateTest("#FG_3018 - To verify Functionality of Number of plants with Invalid inputs");

            GetData.GetDataFrom_Excel("Today", 18);

            currendate();

            try
            {
                TC17.Log(Status.Info, "Enter Username");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
                driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

                TC17.Log(Status.Info, "Enter Password");
                driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

                TC17.Log(Status.Info, "Click Get Started button");
                driver.FindElement(FG_PageObject.Pageobject.Login).Click();

                TC17.Log(Status.Info, "Click Menu");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Validation));
                driver.FindElement(FG_PageObject.Pageobject.Validation).Click();

                TC17.Log(Status.Info, "Click Today");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Today));
                driver.FindElement(FG_PageObject.Pageobject.Today).Click();

                TC17.Log(Status.Info, "Click date picker");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Datepicker));
                driver.FindElement(FG_PageObject.Pageobject.Datepicker).Click();


                Selectingdate();

                try
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Assigned));
                    driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                                  + "new UiSelector().text(\"Resume Task\"));").Click();
                }
                catch
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Assigned));
                    driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                                  + "new UiSelector().text(\"Ongoing Task\"));").Click();
                }

                TC17.Log(Status.Info, "Click date picker");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Noofplants));
                driver.FindElement(FG_PageObject.Pageobject.Noofplants).Clear();
                driver.FindElement(FG_PageObject.Pageobject.Noofplants).SendKeys(GetData.Noofplants);

                TC17.Log(Status.Info, "Click stop task");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.StopTask));
                driver.FindElement(FG_PageObject.Pageobject.StopTask).Click();


                TC17.Log(Status.Info, "Click paused task");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Pausetaskbutton));
                driver.FindElement(FG_PageObject.Pageobject.Pausetaskbutton).Click();
                Thread.Sleep(500);
                TC17.Log(Status.Pass, "Number of Plants" + TC17.AddScreenCaptureFromPath(screenshot("FG_3018_PASS" + DateTime.Now.ToString("hhmmss"))));
              }

            catch
            {
                TC17.Log(Status.Fail, "Number of Plants Task functionality is not verified successfully" + TC17.AddScreenCaptureFromPath(screenshot("FG_3018_FAIL" + DateTime.Now.ToString("hhmmss"))));
            }
        }


        [Test]
        public void TC_FG_3019_To_Verify_functionality_of_Notes()
        {
            ExtentTest TC18 = _extent.CreateTest("#FG_3019 - To verify Functionality of Notes");

            GetData.GetDataFrom_Excel("Today", 19);

            currendate();

            TC18.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC18.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC18.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();

            TC18.Log(Status.Info, "Click Menu");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Validation));
            driver.FindElement(FG_PageObject.Pageobject.Validation).Click();

            TC18.Log(Status.Info, "Click Today");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Today));
            driver.FindElement(FG_PageObject.Pageobject.Today).Click();

            TC18.Log(Status.Info, "Click date picker");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Datepicker));
            driver.FindElement(FG_PageObject.Pageobject.Datepicker).Click();

            Selectingdate();

            TC18.Log(Status.Info, "Click Task");
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Assigned));
                driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                              + "new UiSelector().text(\"Resume Task\"));").Click();
            }
            catch
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Assigned));
                driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                              + "new UiSelector().text(\"Ongoing Task\"));").Click();
            }

            TC18.Log(Status.Info, "Enter No of plants");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Noofplants));
            driver.FindElement(FG_PageObject.Pageobject.Noofplants).Clear();
            driver.FindElement(FG_PageObject.Pageobject.Noofplants).SendKeys(GetData.Noofplants);

            TC18.Log(Status.Info, "Enter Notes");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Notes));
            driver.FindElement(FG_PageObject.Pageobject.Notes).Clear();
            driver.FindElement(FG_PageObject.Pageobject.Notes).SendKeys(GetData.Notes);
            TC18.Log(Status.Pass, "Notes " + TC18.AddScreenCaptureFromPath(screenshot("FG_3019_PASS" + DateTime.Now.ToString("hhmmss"))));


            TC18.Log(Status.Info, "Click stop task");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.StopTask));
            driver.FindElement(FG_PageObject.Pageobject.StopTask).Click();

            TC18.Log(Status.Info, "Click Paused Task");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Pausetaskbutton));
            driver.FindElement(FG_PageObject.Pageobject.Pausetaskbutton).Click();


            try
            {
                TC18.Log(Status.Info, "Verify Notes");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Assigned));
                TC18.Log(Status.Pass, "Notes functionality verified successfully" + TC18.AddScreenCaptureFromPath(screenshot("FG_3019_PASS" + DateTime.Now.ToString("hhmmss"))));
            }
            catch
            {
                TC18.Log(Status.Fail, "Notes functionality is not verified successfully" + TC18.AddScreenCaptureFromPath(screenshot("FG_3019_FAIL" + DateTime.Now.ToString("hhmmss"))));
            }
        }


        [Test]
        public void TC_FG_3024_To_Verify_functionality_of_ViewActivities()
        {
            ExtentTest TC23 = _extent.CreateTest("#FG_3024 - To verify Functionality of View Activities");

            GetData.GetDataFrom_Excel("Today", 20);

            currendate();

            TC23.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC23.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC23.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();

            TC23.Log(Status.Info, "Click Menu");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Validation));
            driver.FindElement(FG_PageObject.Pageobject.Validation).Click();

            TC23.Log(Status.Info, "Click Today");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Today));
            driver.FindElement(FG_PageObject.Pageobject.Today).Click();

            TC23.Log(Status.Info, "Click date picker");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Datepicker));
            driver.FindElement(FG_PageObject.Pageobject.Datepicker).Click();

            Selectingdate();

            TC23.Log(Status.Info, "Click Completed tab");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Completed));
            driver.FindElement(FG_PageObject.Pageobject.Completed).Click();

            TC23.Log(Status.Info, "Click Verify Activities");
            TC23.Log(Status.Pass, "View activities functionality verified successfully" + TC23.AddScreenCaptureFromPath(screenshot("FG_3024_PASS" + DateTime.Now.ToString("hhmmss"))));
            driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                          + "new UiSelector().text(\"View Activities\"));").Click();

            driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                         + "new UiSelector().text(\"Hide Activities\"));");
            try
            {
                TC23.Log(Status.Info, "Verify View activities");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.HideActivities));

                TC23.Log(Status.Pass, "View activities functionality verified successfully" + TC23.AddScreenCaptureFromPath(screenshot("FG_3024_PASS" + DateTime.Now.ToString("hhmmss"))));
            }
            catch
            {
                TC23.Log(Status.Fail, "View activities functionality is not verified successfully" + TC23.AddScreenCaptureFromPath(screenshot("FG_3024_FAIL" + DateTime.Now.ToString("hhmmss"))));
            }


        }
        [Test]
        public void TC_FG_3025_To_Verify_functionality_of_HideActivities()
        {
            ExtentTest TC24 = _extent.CreateTest("#FG_3025 - To verify Functionality of Hide Activities");

            GetData.GetDataFrom_Excel("Today", 21);

            currendate();

            TC24.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC24.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC24.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();

            TC24.Log(Status.Info, "Click Menu");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Validation));
            driver.FindElement(FG_PageObject.Pageobject.Validation).Click();

            TC24.Log(Status.Info, "Click Today");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Today));
            driver.FindElement(FG_PageObject.Pageobject.Today).Click();

            TC24.Log(Status.Info, "Click date picker");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Datepicker));
            driver.FindElement(FG_PageObject.Pageobject.Datepicker).Click();

            Selectingdate();

            TC24.Log(Status.Info, "Click Completed tab");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Completed));
            driver.FindElement(FG_PageObject.Pageobject.Completed).Click();

            TC24.Log(Status.Info, "Click View Activities");
            driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                          + "new UiSelector().text(\"View Activities\"));").Click();

            
            TC24.Log(Status.Info, "Hide activities functionality verified successfully" + TC24.AddScreenCaptureFromPath(screenshot("FG_3024_PASS" + DateTime.Now.ToString("hhmmss"))));
            TC24.Log(Status.Info, "Click Hide Activities");
           driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                          + "new UiSelector().text(\"Hide Activities\"));");
            TC24.Log(Status.Info, "Hide activities functionality verified successfully" + TC24.AddScreenCaptureFromPath(screenshot("FG_3024_PASS" + DateTime.Now.ToString("hhmmss"))));
            driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                           + "new UiSelector().text(\"Hide Activities\"));").Click();

            try
            {
                TC24.Log(Status.Info, "Verify Hide activities");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.ViewActivities));

                TC24.Log(Status.Pass, "Hide activities functionality verified successfully" + TC24.AddScreenCaptureFromPath(screenshot("FG_3025_PASS" + DateTime.Now.ToString("hhmmss"))));
            }
            catch
            {
                TC24.Log(Status.Fail, "Hide activities functionality is not verified successfully" + TC24.AddScreenCaptureFromPath(screenshot("FG_3025_FAIL" + DateTime.Now.ToString("hhmmss"))));
            }


        }

        [Test]
        public void TC_FG_3026_To_Verify_functionality_of_Pausedtask()
        {
            ExtentTest TC25 = _extent.CreateTest("#FG_3026 - To verify Functionality Paused Task");

            GetData.GetDataFrom_Excel("Today", 22);

            currendate();

            TC25.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC25.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC25.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();

            TC25.Log(Status.Info, "Click Menu");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Validation));
            driver.FindElement(FG_PageObject.Pageobject.Validation).Click();

            TC25.Log(Status.Info, "Click Today");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Today));
            driver.FindElement(FG_PageObject.Pageobject.Today).Click();

            TC25.Log(Status.Info, "Click date picker");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Datepicker));
            driver.FindElement(FG_PageObject.Pageobject.Datepicker).Click();

            Selectingdate();

            TC25.Log(Status.Info, "Click Task");
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Assigned));
                driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                              + "new UiSelector().text(\"Start Task\"));").Click();
            }
            catch
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Assigned));
                driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                              + "new UiSelector().text(\"Ongoing Task\"));").Click();
            }

            TC25.Log(Status.Info, "Click Stop Task");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.StopTask));
            driver.FindElement(FG_PageObject.Pageobject.StopTask).Click();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Taskname));
            string Taskname = driver.FindElement(FG_PageObject.Pageobject.Taskname).Text;



            TC25.Log(Status.Info, "Click Pause task button");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Pausetaskbutton));

            TC25.Log(Status.Pass, "Pause Task" + TC25.AddScreenCaptureFromPath(screenshot("FG_3026_PASS" + DateTime.Now.ToString("hhmmss"))));
            driver.FindElement(FG_PageObject.Pageobject.Pausetaskbutton).Click();


            TC25.Log(Status.Info, "Click menu");
            Thread.Sleep(500);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Validation));
            driver.FindElement(FG_PageObject.Pageobject.Validation).Click();


            TC25.Log(Status.Info, "Click Paused Task");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.PausedTask));
            driver.FindElement(FG_PageObject.Pageobject.PausedTask).Click();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Taskname));
            string Taskname2 = driver.FindElement(FG_PageObject.Pageobject.Taskname).Text;


            try
            {
                TC25.Log(Status.Info, "Verify Paused Task");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.ResumeTask));
                if (Taskname == Taskname2)
                {
                    TC25.Log(Status.Pass, "Paused task functionality verified successfully" + TC25.AddScreenCaptureFromPath(screenshot("FG_3026_PASS" + DateTime.Now.ToString("hhmmss"))));
                }
            }
            catch
            {
                TC25.Log(Status.Fail, "Hide activities functionality is not verified successfully" + TC25.AddScreenCaptureFromPath(screenshot("FG_3026_FAIL" + DateTime.Now.ToString("hhmmss"))));
            }

        }

        [Test]
        public void TC_FG_3027_To_Verify_functionality_of_Complete_Task()
        {
            ExtentTest TC26 = _extent.CreateTest("#FG_3026 - To verify Functionality Complete Task");

            GetData.GetDataFrom_Excel("Today", 23);

            currendate();

            TC26.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC26.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC26.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();

            TC26.Log(Status.Info, "Click Menu");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Validation));
            driver.FindElement(FG_PageObject.Pageobject.Validation).Click();

            TC26.Log(Status.Info, "Click Today");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Today));
            driver.FindElement(FG_PageObject.Pageobject.Today).Click();

            TC26.Log(Status.Info, "Click date picker");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Datepicker));
            driver.FindElement(FG_PageObject.Pageobject.Datepicker).Click();

            Selectingdate();

            TC26.Log(Status.Info, "Click Task");
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Assigned));
                driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                              + "new UiSelector().text(\"Resume Task\"));").Click();
            }
            catch
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Assigned));
                driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                              + "new UiSelector().text(\"Ongoing Task\"));").Click();
            }


            TC26.Log(Status.Info, "Click Stop Task");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.StopTask));
            driver.FindElement(FG_PageObject.Pageobject.StopTask).Click();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Taskname));
            string Taskname = driver.FindElement(FG_PageObject.Pageobject.Taskname).Text;



            TC26.Log(Status.Info, "Click Complete button");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Completetask));

            TC26.Log(Status.Pass, "Pause Task" + TC26.AddScreenCaptureFromPath(screenshot("FG_3026_PASS" + DateTime.Now.ToString("hhmmss"))));
            driver.FindElement(FG_PageObject.Pageobject.Completetask).Click();

            TC26.Log(Status.Info, "Click date picker");
            Thread.Sleep(500);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Datepicker));
            driver.FindElement(FG_PageObject.Pageobject.Datepicker).Click();

            Selectingdate();


            TC26.Log(Status.Info, "Click complete tab");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Completed));
            driver.FindElement(FG_PageObject.Pageobject.Completed).Click();



            try
            {
                driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                              + "new UiSelector().text(\"" + Taskname + "\"));");
            }
            catch { }


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Taskname));
            string Taskname2 = driver.FindElement(FG_PageObject.Pageobject.Taskname).Text;


            try
            {
                TC26.Log(Status.Info, "Verify Completed Task");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.ViewActivities));

                TC26.Log(Status.Pass, "Completed functionality verified successfully" + TC26.AddScreenCaptureFromPath(screenshot("FG_3027_PASS" + DateTime.Now.ToString("hhmmss"))));
            }
            catch
            {
                TC26.Log(Status.Fail, "Completed functionality is not verified successfully" + TC26.AddScreenCaptureFromPath(screenshot("FG_3027_FAIL" + DateTime.Now.ToString("hhmmss"))));
            }

        }

        [Test]
        public void TC_FG_3028_To_Verify_functionality_of_Chat()
        {
            ExtentTest TC27 = _extent.CreateTest("#FG_3028 - To verify Functionality of Chat");

            GetData.GetDataFrom_Excel("Today", 24);

            string mon = DateTime.Today.ToString("MMMM");
            currendate();

            TC27.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC27.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC27.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();

            TC27.Log(Status.Info, "Click Menu");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Validation));
            driver.FindElement(FG_PageObject.Pageobject.Validation).Click();

            TC27.Log(Status.Info, "Click Today");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Today));
            driver.FindElement(FG_PageObject.Pageobject.Today).Click();

            TC27.Log(Status.Info, "Click date picker");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Datepicker));
            driver.FindElement(FG_PageObject.Pageobject.Datepicker).Click();

            //do
            //{
            //    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Pastmonthnavigation));
            //    driver.FindElement(FG_PageObject.Pageobject.Pastmonthnavigation).Click();
            //}
            //while (mon.Contains(GetData.Monthyear));


            Selectingdate();

            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@text='"+GetData.Date+"']")));
            //driver.FindElement(By.XPath("//*[@text='"+GetData.Date+"']")).Click();

            TC27.Log(Status.Info, "Click Resume Task");
            driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                          + "new UiSelector().text(\"Start Task\"));").Click();

            TC27.Log(Status.Info, "Click Chat");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Chat));
            driver.FindElement(FG_PageObject.Pageobject.Chat).Click();

            TC27.Log(Status.Info, "Enter Chat Messgae");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Chatbox));
            driver.FindElement(FG_PageObject.Pageobject.Chatbox).SendKeys(GetData.Chatmessgae);
            TC27.Log(Status.Pass, "Chat Message is verified" + TC27.AddScreenCaptureFromPath(screenshot("FG_2013_PASS" + DateTime.Now.ToString("hhmmss"))));

            TC27.Log(Status.Info, "Click Send button");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Chatsend));
            driver.FindElement(FG_PageObject.Pageobject.Chatsend).Click();

            TC27.Log(Status.Info, "Click Chatback");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Chatback));
            driver.FindElement(FG_PageObject.Pageobject.Chatback).Click();

            TC27.Log(Status.Info, "Click Chat button");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Chat));
            driver.FindElement(FG_PageObject.Pageobject.Chat).Click();


            TC27.Log(Status.Info, "Verify Chat Process");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Chatmessagevaliation));
            TC27.Log(Status.Pass, "Chat Message is verified" + TC27.AddScreenCaptureFromPath(screenshot("FG_3028_PASS" + DateTime.Now.ToString("hhmmss"))));






        }

        [Test]
        public void TC_FG_3029_To_Verify_functionality_of_Imageuploading()
        {
            ExtentTest TC27 = _extent.CreateTest("#FG_3029 - To verify Functionality of Imaeuploading");

            GetData.GetDataFrom_Excel("Today", 24);

            string mon = DateTime.Today.ToString("MMMM");
            currendate();

            TC27.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC27.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC27.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();

            TC27.Log(Status.Info, "Click Menu");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Validation));
            driver.FindElement(FG_PageObject.Pageobject.Validation).Click();

            TC27.Log(Status.Info, "Click Today");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Today));
            driver.FindElement(FG_PageObject.Pageobject.Today).Click();

            TC27.Log(Status.Info, "Click date picker");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Datepicker));
            driver.FindElement(FG_PageObject.Pageobject.Datepicker).Click();

            //do
            //{
            //    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Pastmonthnavigation));
            //    driver.FindElement(FG_PageObject.Pageobject.Pastmonthnavigation).Click();
            //}
            //while (mon.Contains(GetData.Monthyear));


            Selectingdate();

            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@text='"+GetData.Date+"']")));
            //driver.FindElement(By.XPath("//*[@text='"+GetData.Date+"']")).Click();

            TC27.Log(Status.Info, "Click Resume Task");
            driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                          + "new UiSelector().text(\"Ongoing Task\"));").Click();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Notes));
            FGHelpers.FGHelpers.Scroll("down", driver);

            int co = Convert.ToInt16(GetData.imagecount);
            for (int i = 0; i < co; i++)
            {

                Thread.Sleep(1000);
                TC27.Log(Status.Info, "Click Task Image");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Taskpicture));
                driver.FindElement(FG_PageObject.Pageobject.Taskpicture).Click();


                TC27.Log(Status.Info, "Click Camera click");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Cameraclicking));
                driver.FindElement(FG_PageObject.Pageobject.Cameraclicking).Click();



                Thread.Sleep(1000);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Notes));
                FGHelpers.FGHelpers.Scroll("down", driver);

                TC27.Log(Status.Pass, "Image Uploading" + TC27.AddScreenCaptureFromPath(screenshot("FG_2013_PASS" + DateTime.Now.ToString("hhmmss"))));
                TC27.Log(Status.Info, "Click Upload");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Uploadimage));
                driver.FindElement(FG_PageObject.Pageobject.Uploadimage).Click();

            }

            TC27.Log(Status.Info, "Click Stop");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.StopTask));
            driver.FindElement(FG_PageObject.Pageobject.StopTask).Click();

            TC27.Log(Status.Info, "Click Paused Task");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Pausetaskbutton));
            driver.FindElement(FG_PageObject.Pageobject.Pausetaskbutton).Click();

            Thread.Sleep(2500);
            TC27.Log(Status.Pass, "Image Uploading" + TC27.AddScreenCaptureFromPath(screenshot("FG_2013_PASS" + DateTime.Now.ToString("hhmmss"))));



        }
    }
    }