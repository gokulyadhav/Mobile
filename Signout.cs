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
    class Signout : MasterClass
    {


        [Test]

        public void TC_FG_4001_Signout()
        {


            reports("Signout");

            ExtentTest TC01 = _extent.CreateTest("#FG_1001 - To verify Functionality Signout");

            GetData.GetDataFrom_Excel("Login", 2);
            try
            {

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

                TC01.Log(Status.Info, "Click signout");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.signout));
                TC01.Log(Status.Pass, "SignOut" + TC01.AddScreenCaptureFromPath(screenshot("FG_4001_PASS" + DateTime.Now.ToString("hhmmss"))));
                driver.FindElement(FG_PageObject.Pageobject.signout).Click();


                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
                TC01.Log(Status.Pass, "SignOut Succesfully " + TC01.AddScreenCaptureFromPath(screenshot("FG_4001_PASS" + DateTime.Now.ToString("hhmmss"))));

            }
            catch
            {
                TC01.Log(Status.Fail, "Signout Not Successfull " + TC01.AddScreenCaptureFromPath(screenshot("TC_4001_PASS" + DateTime.Now.ToString("hhmmss"))));

            }

        }

    }
}
