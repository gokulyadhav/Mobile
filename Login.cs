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
     class Login:MasterClass
    {
        [OneTimeSetUp]
        public void reports()
        {
            reports("Login");
        }
        [Test]
        public void TC_FG_1001_Login()
        {
           
            ExtentTest TC01 = _extent.CreateTest("#FG_1001 - To verify Functionality of Login with valid Username and Password");

            GetData.GetDataFrom_Excel("Login", 2);

            TC01.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC01.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC01.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Validation));

                TC01.Log(Status.Pass, "Login  Successfully " + TC01.AddScreenCaptureFromPath(screenshot("FG_1001_PASS" + DateTime.Now.ToString("hhmmss"))));

            }
            catch
            {
                TC01.Log(Status.Fail, "Login Not Successfull " + TC01.AddScreenCaptureFromPath(screenshot("TC_1001_PASS" + DateTime.Now.ToString("hhmmss"))));

            }

        }

        [Test]
        public void TC_FG_1002_Login()
        {
            ExtentTest TC02 = _extent.CreateTest("#FG_1002 - To verify Functionality of Login with Invalid Username and Valid Password");

            GetData.GetDataFrom_Excel("Login", 3);

            TC02.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC02.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC02.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.InValidation));

                TC02.Log(Status.Pass, "Login Not Successfull " + TC02.AddScreenCaptureFromPath(screenshot("FG_1002_PASS" + DateTime.Now.ToString("hhmmss"))));

            }
            catch
            {
                TC02.Log(Status.Fail, "Login  Successfull " + TC02.AddScreenCaptureFromPath(screenshot("TC_1002_PASS" + DateTime.Now.ToString("hhmmss"))));

            }

        }

        [Test]

        public void TC_FG_1003_Login()
        {
           
            ExtentTest TC03 = _extent.CreateTest("#FG_1003 - To verify Functionality of Login with Valid UserName and Invalid Password");

            GetData.GetDataFrom_Excel("Login", 4);

            TC03.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC03.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC03.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.InValidation));

                TC03.Log(Status.Pass, "Login Not Successfull " + TC03.AddScreenCaptureFromPath(screenshot("FG_1003_PASS" + DateTime.Now.ToString("hhmmss"))));

            }
            catch
            {
                TC03.Log(Status.Fail, "Login  Successfull " + TC03.AddScreenCaptureFromPath(screenshot("TC_1003_PASS" + DateTime.Now.ToString("hhmmss"))));

            }

        }

        [Test]
        public void TC_FG_1004_Login()
        {
         
            ExtentTest TC04 = _extent.CreateTest("#FG_1004 - To verify Functionality of Login with invalid username and invalid password");

            GetData.GetDataFrom_Excel("Login", 5);

            TC04.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC04.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC04.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.InValidation));

                TC04.Log(Status.Pass, "Login Not Successfull " + TC04.AddScreenCaptureFromPath(screenshot("FG_1004_PASS" + DateTime.Now.ToString("hhmmss"))));

            }
            catch
            {
                TC04.Log(Status.Fail, "Login  Successfull " + TC04.AddScreenCaptureFromPath(screenshot("TC_1004_PASS" + DateTime.Now.ToString("hhmmss"))));

            }

        }

        [Test]
        public void TC_FG_1005_Login()
        {

            ExtentTest TC05 = _extent.CreateTest("#FG_1005 - To verify Functionality of Login with only password");

            GetData.GetDataFrom_Excel("Login", 6);

            TC05.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC05.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC05.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();

            TC05.Log(Status.Pass, "Login Not Successfull " + TC05.AddScreenCaptureFromPath(screenshot("FG_1005_PASS" + DateTime.Now.ToString("hhmmss"))));

        }

        [Test]
        public void TC_FG_1006_Login()
        {

            ExtentTest TC06 = _extent.CreateTest("#FG_1006 - To verify Functionality of Login with only UserName");

            GetData.GetDataFrom_Excel("Login", 7);

            TC06.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC06.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC06.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();

            TC06.Log(Status.Pass, "Login Not Successfull " + TC06.AddScreenCaptureFromPath(screenshot("FG_1006_PASS" + DateTime.Now.ToString("hhmmss"))));

        }


    }
}
