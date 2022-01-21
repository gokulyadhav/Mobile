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
    class SidemenuCalender:MasterClass
    {
        
        [OneTimeSetUp]
        public void Report()
        {
            reports("Side Menu Calculator");
        }

        [Test]
        public void TC_FG_5001_Verify_the_sidemenu_Calender()
        {
            
            ExtentTest TC01 = _extent.CreateTest("#FG_5001 - To verify Functionality Navigate to Side calender Screen");

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

            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Today));
                TC01.Log(Status.Pass, "Navigated to Side calender Screen" + TC01.AddScreenCaptureFromPath(screenshot("FG_5001_PASS" + DateTime.Now.ToString("hhmmss"))));

            }
            catch
            {
                TC01.Log(Status.Fail, "Application is not calender screen" + TC01.AddScreenCaptureFromPath(screenshot("TC_5001_PASS" + DateTime.Now.ToString("hhmmss"))));

            }


        }

        [Test]
        public void TC_FG_5002_Verify_the_calender_functionality_of_Pastdate()
        {
           
            ExtentTest TC02 = _extent.CreateTest("#FG_5002 - To verify Functionality of calender by selecting past date");

            GetData.GetDataFrom_Excel("Today", 2);

            TC02.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC02.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC02.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();

            TC02.Log(Status.Info, "Click Menu");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Validation));
            driver.FindElement(FG_PageObject.Pageobject.Validation).Click();

            TC02.Log(Status.Info, "Click Past Navigation button");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Pastmonthnavigation));
            TC02.Log(Status.Pass, "Past date " + TC02.AddScreenCaptureFromPath(screenshot("FG_5002_PASS" + DateTime.Now.ToString("hhmmss"))));
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
                    TC02.Log(Status.Pass, "Past date is selected and verified successfully" + TC02.AddScreenCaptureFromPath(screenshot("FG_5002_PASS" + DateTime.Now.ToString("hhmmss"))));
                }
            }
            catch
            {
                TC02.Log(Status.Fail, "Past date is not verified successfully" + TC02.AddScreenCaptureFromPath(screenshot("FG_5002_Fail" + DateTime.Now.ToString("hhmmss"))));

            }


        }

        [Test]
        public void TC_FG_5003_Verify_the_calender_functionality_of_Futuredate()
        {
            
            ExtentTest TC03 = _extent.CreateTest("#FG_5003 - To verify Functionality of datepicker with Futuredate");

            GetData.GetDataFrom_Excel("Today", 4);

            TC03.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC03.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC03.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();

            TC03.Log(Status.Info, "Click Menu");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Validation));
            driver.FindElement(FG_PageObject.Pageobject.Validation).Click();

            TC03.Log(Status.Info, "Click Future Date picker");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Futuremonthnavigation));
            TC03.Log(Status.Pass, "Future date is selected and verified successfully" + TC03.AddScreenCaptureFromPath(screenshot("FG_5003_PASS" + DateTime.Now.ToString("hhmmss"))));
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
                    TC03.Log(Status.Pass, "Future date is selected and verified successfully" + TC03.AddScreenCaptureFromPath(screenshot("FG_5003_PASS" + DateTime.Now.ToString("hhmmss"))));
                }
            }
            catch
            {
                TC03.Log(Status.Fail, "Future date is not verified successfully" + TC03.AddScreenCaptureFromPath(screenshot("FG_5003_Fail" + DateTime.Now.ToString("hhmmss"))));

            }


        }
        [Test]
        public void TC_FG_5004_Verify_the_calender_functionality_of_Currentdate()
        {
           
            ExtentTest TC04 = _extent.CreateTest("#FG_5004 - To verify Functionality of datepicker with Currengtdate");

            GetData.GetDataFrom_Excel("Today", 5);


            currendate();

            TC04.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC04.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC04.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();

            TC04.Log(Status.Info, "Click Menu");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Validation));
            driver.FindElement(FG_PageObject.Pageobject.Validation).Click();


            TC04.Log(Status.Info, "Click Date");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Currentdate(currr)));
            TC04.Log(Status.Pass, "Current date" + TC04.AddScreenCaptureFromPath(screenshot("FG_5004_PASS" + DateTime.Now.ToString("hhmmss"))));
            driver.FindElement(FG_PageObject.Pageobject.Currentdate(currr)).Click();

            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Datepicker));
                string data = driver.FindElement(FG_PageObject.Pageobject.Datepicker).Text.Remove(0, 8);
                if (data.Contains(currr))
                {
                    TC04.Log(Status.Pass, "Current date is selected and verified successfully" + TC04.AddScreenCaptureFromPath(screenshot("FG_5004_PASS" + DateTime.Now.ToString("hhmmss"))));
                }
            }
            catch
            {
                TC04.Log(Status.Fail, "Current date is not verified successfully" + TC04.AddScreenCaptureFromPath(screenshot("FG_5004_Fail" + DateTime.Now.ToString("hhmmss"))));

            }


        }
      
    }
    }
