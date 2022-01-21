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
    class PausedTask : MasterClass
    {


        [OneTimeSetUp]
        public void reports()
        {
            reports("Paused Task");
        }

        [Test]
        public void TC_FG_2001_PausedTask()
        {
            ExtentTest TC01 = _extent.CreateTest("#FG_2001 - To verify Functionality Navigate to Paused Task Screen");

            GetData.GetDataFrom_Excel("PausedTask", 2);

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

            TC01.Log(Status.Info, "Click Paused Task Screen");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.PausedTask));
            driver.FindElement(FG_PageObject.Pageobject.PausedTask).Click();

            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.ResumeTask));
                TC01.Log(Status.Pass, "Navigated to Paused Task Screen" + TC01.AddScreenCaptureFromPath(screenshot("FG_2001_PASS" + DateTime.Now.ToString("hhmmss"))));

            }
            catch
            {
                TC01.Log(Status.Fail, "Application is not navigated to Paused Task screen" + TC01.AddScreenCaptureFromPath(screenshot("TC_2001_PASS" + DateTime.Now.ToString("hhmmss"))));

            }
        }

        [Test]
        public void TC_FG_2002_All_Pausedtask_in_PausedTask_Screen()
        {
            ExtentTest TC02 = _extent.CreateTest("#FG_2002 - To verify Functionality all paused tasks in Paused Task screen");

            GetData.GetDataFrom_Excel("PausedTask", 3);

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

            TC02.Log(Status.Info, "Click Paused Task Screen");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.PausedTask));
            driver.FindElement(FG_PageObject.Pageobject.PausedTask).Click();

            TC02.Log(Status.Info, "Click Resume Task");
            driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                          + "new UiSelector().text(\"Resume Task\"));");

            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.ResumeTask));
                TC02.Log(Status.Pass, "Only Resume Tasks in Paused Task Screen" + TC02.AddScreenCaptureFromPath(screenshot("FG_3001_PASS" + DateTime.Now.ToString("hhmmss"))));

            }
            catch
            {
                TC02.Log(Status.Fail, "Application is not only Paused Task screen" + TC02.AddScreenCaptureFromPath(screenshot("TC_3001_PASS" + DateTime.Now.ToString("hhmmss"))));

            }
        }

        [Test]
        public void TC_FG_2003_Verify_the_functionality_of_Resumetask()
        {
            ExtentTest TC03 = _extent.CreateTest("#FG_2003 - To verify Functionality of Resume Task");

            GetData.GetDataFrom_Excel("PausedTask", 3);

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

            TC03.Log(Status.Info, "Click Paused Task Screen");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.PausedTask));
            driver.FindElement(FG_PageObject.Pageobject.PausedTask).Click();
            TC03.Log(Status.Info, "Resume Tasks " + TC03.AddScreenCaptureFromPath(screenshot("FG_2003_PASS" + DateTime.Now.ToString("hhmmss"))));

            TC03.Log(Status.Info, "Click Resume Task");
            driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                          + "new UiSelector().text(\"Resume Task\"));").Click();

            TC03.Log(Status.Info, "Verify Resume Task");

            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.StopTask));
                TC03.Log(Status.Pass, "Resume Tasks is verified in Paused Task Screen" + TC03.AddScreenCaptureFromPath(screenshot("FG_2003_PASS" + DateTime.Now.ToString("hhmmss"))));
                driver.FindElement(FG_PageObject.Pageobject.StopTask).Click();

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Pausetaskbutton));
                driver.FindElement(FG_PageObject.Pageobject.Pausetaskbutton).Click();


            }
            catch
            {
                TC03.Log(Status.Fail, "Resume task is not verified in Paused Task screen" + TC03.AddScreenCaptureFromPath(screenshot("TC_2003_PASS" + DateTime.Now.ToString("hhmmss"))));

            }
        }

        [Test]
        public void TC_FG_2004_Verify_the_functionality_of_Complete_Button()
        {
            ExtentTest TC04 = _extent.CreateTest("#FG_2004 - To verify Functionality of Complete Button");

            GetData.GetDataFrom_Excel("PausedTask", 3);

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

            TC04.Log(Status.Info, "Click Paused Task Screen");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.PausedTask));
            driver.FindElement(FG_PageObject.Pageobject.PausedTask).Click();

            TC04.Log(Status.Info, "Click Resume Task");
            driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                          + "new UiSelector().text(\"Resume Task\"));").Click();

            TC04.Log(Status.Info, "Click Stop Task");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.StopTask));
            driver.FindElement(FG_PageObject.Pageobject.StopTask).Click();


            TC04.Log(Status.Info, "Click Complete task button");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Completetask));
            TC04.Log(Status.Pass, "Complete Task" + TC04.AddScreenCaptureFromPath(screenshot("FG_2004_PASS" + DateTime.Now.ToString("hhmmss"))));
            driver.FindElement(FG_PageObject.Pageobject.Completetask).Click();


            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.ResumeTask));
                TC04.Log(Status.Pass, "Complete Tasks is verified in Paused Task Screen" + TC04.AddScreenCaptureFromPath(screenshot("FG_2004_PASS" + DateTime.Now.ToString("hhmmss"))));

            }
            catch
            {
                TC04.Log(Status.Fail, "Complete task is not verified in Paused Task screen" + TC04.AddScreenCaptureFromPath(screenshot("TC_2004_PASS" + DateTime.Now.ToString("hhmmss"))));

            }
        }

        [Test]
        public void TC_FG_2005_Verify_the_functionality_of_Paused_Task()
        {
            ExtentTest TC05 = _extent.CreateTest("#FG_2005 - To verify Functionality of Paused Task");

            GetData.GetDataFrom_Excel("PausedTask", 3);

            TC05.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC05.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC05.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();

            TC05.Log(Status.Info, "Click Menu");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Validation));
            driver.FindElement(FG_PageObject.Pageobject.Validation).Click();

            TC05.Log(Status.Info, "Click Paused Task Screen");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.PausedTask));
            driver.FindElement(FG_PageObject.Pageobject.PausedTask).Click();

            TC05.Log(Status.Info, "Click Resume Task");
            driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                          + "new UiSelector().text(\"Resume Task\"));").Click();


            TC05.Log(Status.Info, "Click stop task");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.StopTask));
            driver.FindElement(FG_PageObject.Pageobject.StopTask).Click();

            TC05.Log(Status.Info, "Click Pause task");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Pausetaskbutton));
            TC05.Log(Status.Pass, "Paused Tasks" + TC05.AddScreenCaptureFromPath(screenshot("FG_2005_PASS" + DateTime.Now.ToString("hhmmss"))));
            driver.FindElement(FG_PageObject.Pageobject.Pausetaskbutton).Click();


            // wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.PausedTaskvalidation));
            Thread.Sleep(2000);
            TC05.Log(Status.Pass, "Paused Task" + TC05.AddScreenCaptureFromPath(screenshot("FG_2005_PASS" + DateTime.Now.ToString("hhmmss"))));

            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.ResumeTask));
                TC05.Log(Status.Pass, "Paused Tasks is verified in Paused Task Screen" + TC05.AddScreenCaptureFromPath(screenshot("FG_2005_PASS" + DateTime.Now.ToString("hhmmss"))));

            }
            catch
            {
                TC05.Log(Status.Fail, "Paused task is not verified in Paused Task screen" + TC05.AddScreenCaptureFromPath(screenshot("TC_2005_PASS" + DateTime.Now.ToString("hhmmss"))));

            }
        }

        [Test]
        public void TC_FG_2006_Verify_the_functionality_of_Stop_Task()
        {
            ExtentTest TC05 = _extent.CreateTest("#FG_2006 - To verify Functionality of Stop Task");

            GetData.GetDataFrom_Excel("PausedTask", 3);

            TC05.Log(Status.Info, "Enter Username");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
            driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

            TC05.Log(Status.Info, "Enter Password");
            driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

            TC05.Log(Status.Info, "Click Get Started button");
            driver.FindElement(FG_PageObject.Pageobject.Login).Click();

            TC05.Log(Status.Info, "Click Menu");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Validation));
            driver.FindElement(FG_PageObject.Pageobject.Validation).Click();

            TC05.Log(Status.Info, "Click Paused Task Screen");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.PausedTask));
            driver.FindElement(FG_PageObject.Pageobject.PausedTask).Click();

            TC05.Log(Status.Info, "Click Resume Task");
            driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                          + "new UiSelector().text(\"Resume Task\"));").Click();

            TC05.Log(Status.Info, "Click stop task");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.StopTask));
            driver.FindElement(FG_PageObject.Pageobject.StopTask).Click();


            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Completetask));
                TC05.Log(Status.Pass, "Stop Tasks is verified in Paused Task Screen" + TC05.AddScreenCaptureFromPath(screenshot("FG_2006_PASS" + DateTime.Now.ToString("hhmmss"))));
                driver.FindElement(FG_PageObject.Pageobject.Pausetaskbutton).Click();

            }
            catch
            {
                TC05.Log(Status.Fail, "Stop task is not verified in Paused Task screen" + TC05.AddScreenCaptureFromPath(screenshot("TC_2006_PASS" + DateTime.Now.ToString("hhmmss"))));

            }
        }

        [Test]
        public void TC_FG_2007_Verify_the_functionality_of_Complete_Task()
        {
            ExtentTest TC06 = _extent.CreateTest("#FG_2007 - To verify Functionality of Complete Task");

            GetData.GetDataFrom_Excel("PausedTask", 3);
            try
            {

                TC06.Log(Status.Info, "Enter Username");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Username));
                driver.FindElement(FG_PageObject.Pageobject.Username).SendKeys(GetData.UserName);

                TC06.Log(Status.Info, "Enter Password");
                driver.FindElement(FG_PageObject.Pageobject.Password).SendKeys(GetData.Password);

                TC06.Log(Status.Info, "Click Get Started button");
                driver.FindElement(FG_PageObject.Pageobject.Login).Click();

                TC06.Log(Status.Info, "Click Menu");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Validation));
                driver.FindElement(FG_PageObject.Pageobject.Validation).Click();

                TC06.Log(Status.Info, "Click Paused Task Screen");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.PausedTask));
                driver.FindElement(FG_PageObject.Pageobject.PausedTask).Click();

                TC06.Log(Status.Info, "Click Resume Task");
                driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                              + "new UiSelector().text(\"Resume Task\"));").Click();

                TC06.Log(Status.Info, "Click stop task");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.StopTask));
                driver.FindElement(FG_PageObject.Pageobject.StopTask).Click();

                TC06.Log(Status.Info, "Click complete task");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Completetask));
                driver.FindElement(FG_PageObject.Pageobject.Completetask).Click();

                Thread.Sleep(2500);
                TC06.Log(Status.Pass, "Complete Tasks is verified" + TC06.AddScreenCaptureFromPath(screenshot("FG_2007_PASS" + DateTime.Now.ToString("hhmmss"))));




            }
            catch
            {
                TC06.Log(Status.Fail, "Complete task is not verified in Completed screen" + TC06.AddScreenCaptureFromPath(screenshot("TC_2007_PASS" + DateTime.Now.ToString("hhmmss"))));

            }
        }



        [Test]
        public void TC_FG_2009_Verify_the_tips()
        {
            ExtentTest TC09 = _extent.CreateTest("#FG_2009 - To verify Functionality of tips");

            GetData.GetDataFrom_Excel("PausedTask", 4);

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
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.PausedTask));
            driver.FindElement(FG_PageObject.Pageobject.PausedTask).Click();


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Tips));
            driver.FindElement(FG_PageObject.Pageobject.Tips).Click();



            TC09.Log(Status.Info, "verify tips");
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.TestTips));
                TC09.Log(Status.Pass, "Tips is verified in Paused Task Screen" + TC09.AddScreenCaptureFromPath(screenshot("FG_2002_PASS" + DateTime.Now.ToString("hhmmss"))));

            }
            catch
            {
                driver.FindElement(FG_PageObject.Pageobject.Tips).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Notips));
                TC09.Log(Status.Pass, "No Tips for task" + TC09.AddScreenCaptureFromPath(screenshot("TC_2002_PASS" + DateTime.Now.ToString("hhmmss"))));
            }




        }

        [Test]
        public void TC_FG_2010_Verify_the_functionality_of_only_pausedtasks()
        {
            ExtentTest TC09 = _extent.CreateTest("#FG_2010 - To verify Functionality of only paused tasks");

            GetData.GetDataFrom_Excel("PausedTask", 5);

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
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.PausedTask));
            driver.FindElement(FG_PageObject.Pageobject.PausedTask).Click();

            try
            {
                driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                              + "new UiSelector().text(\"//android.widget.TextView[@text='Task 2:']\"));").Click();
            }
            catch { }

            try
            {
                TC09.Log(Status.Info, "verify Paused Task");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.ResumeTask));
                TC09.Log(Status.Pass, "Only Paused Tasks in Paused Task Screen" + TC09.AddScreenCaptureFromPath(screenshot("FG_3001_PASS" + DateTime.Now.ToString("hhmmss"))));

            }
            catch
            {
                TC09.Log(Status.Fail, "Application is not only Paused Task screen" + TC09.AddScreenCaptureFromPath(screenshot("TC_3001_PASS" + DateTime.Now.ToString("hhmmss"))));

            }
        }

        [Test]
        public void TC_FG_2011_Verify_the_functionality_of_date_for_Particular_task()
        {
            ExtentTest TC10 = _extent.CreateTest("#FG_2011 - To verify Functionality of date for particular task");

            GetData.GetDataFrom_Excel("PausedTask", 5);

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

            TC10.Log(Status.Info, "Click Paused Task");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.PausedTask));
            driver.FindElement(FG_PageObject.Pageobject.PausedTask).Click();

            TC10.Log(Status.Info, "Click Resume task");
            driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                          + "new UiSelector().text(\"Resume Task\"));").Click();

            Thread.Sleep(2000);
            TC10.Log(Status.Info, "verify Date field for paused task");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.Id("com.example.mediafg:id/tv_task_no")));
            string date = driver.FindElementById("com.example.mediafg:id/tv_task_no").Text;
            TC10.Log(Status.Pass, "Paused task date" + TC10.AddScreenCaptureFromPath(screenshot("FG_3001_PASS" + DateTime.Now.ToString("hhmmss"))));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.StopTask));
            driver.FindElement(FG_PageObject.Pageobject.StopTask).Click();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Pausetaskbutton));
            driver.FindElement(FG_PageObject.Pageobject.Pausetaskbutton).Click();

            try
            {
                if (date.Contains(DateTime.Today.ToString("yyyy")))
                {
                    TC10.Log(Status.Pass, "Paused Task date is verified" + TC10.AddScreenCaptureFromPath(screenshot("FG_2011_PASS" + DateTime.Now.ToString("hhmmss"))));
                }
            }
            catch
            {
                TC10.Log(Status.Fail, "Application is not verified paused task date" + TC10.AddScreenCaptureFromPath(screenshot("TC_2011_FAIL" + DateTime.Now.ToString("hhmmss"))));

            }

        }

        [Test]
        public void TC_FG_2012_Verify_the_functionality_Paused_task_count()
        {
            ExtentTest TC11 = _extent.CreateTest("#FG_2012 - To verify Functionality Paused task count");

            GetData.GetDataFrom_Excel("PausedTask", 12);

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

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Pausedtaskcount));
            string Pausedcount1 = driver.FindElement(FG_PageObject.Pageobject.Pausedtaskcount).Text;
            TC11.Log(Status.Pass, "Paused task count Checking" + TC11.AddScreenCaptureFromPath(screenshot("FG_3001_PASS" + DateTime.Now.ToString("hhmmss"))));


            TC11.Log(Status.Info, "Click Paused Task");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Today));
            driver.FindElement(FG_PageObject.Pageobject.Today).Click();


            TC11.Log(Status.Info, "Click Date");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Datepicker));
            driver.FindElement(FG_PageObject.Pageobject.Datepicker).Click();


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Pastmonthnavigation));
            driver.FindElement(FG_PageObject.Pageobject.Pastmonthnavigation).Click();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@text='" + GetData.Date + "']")));
            driver.FindElement(By.XPath("//*[@text='" + GetData.Date + "']")).Click();

            TC11.Log(Status.Info, "Click Resume Task");
            driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                          + "new UiSelector().text(\"Start Task\"));").Click();


            TC11.Log(Status.Info, "Click stop Task");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.StopTask));
            driver.FindElement(FG_PageObject.Pageobject.StopTask).Click();

            TC11.Log(Status.Info, "Click Paused Task");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Pausetaskbutton));
            driver.FindElement(FG_PageObject.Pageobject.Pausetaskbutton).Click();

            TC11.Log(Status.Info, "Click Menu");
            Thread.Sleep(1000);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Validation));
            driver.FindElement(FG_PageObject.Pageobject.Validation).Click();

            try
            {
                TC11.Log(Status.Info, "Verify passed task count");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Pausedtaskcount));
                string Pausedcount = driver.FindElement(FG_PageObject.Pageobject.Pausedtaskcount).Text;

                if (Pausedcount != Pausedcount1)
                {
                    TC11.Log(Status.Pass, "Paused task count is verified" + TC11.AddScreenCaptureFromPath(screenshot("FG_3001_PASS" + DateTime.Now.ToString("hhmmss"))));
                }
            }
            catch
            {
                TC11.Log(Status.Fail, "Application is not only Paused Task screen" + TC11.AddScreenCaptureFromPath(screenshot("TC_3001_PASS" + DateTime.Now.ToString("hhmmss"))));

            }

        }

        [Test]
        public void TC_FG_2013_Verify_the_functionality_Chatprocess_in_Pausedtask()
        {
            ExtentTest TC12 = _extent.CreateTest("#FG_2013 - To verify Functionality of Chat Process in Paused Task");

            GetData.GetDataFrom_Excel("PausedTask", 13);
            try
            {
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

                TC12.Log(Status.Info, "Click Paused task");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.PausedTask));
                driver.FindElement(FG_PageObject.Pageobject.PausedTask).Click();


                TC12.Log(Status.Info, "Click Resume Task");
                driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                              + "new UiSelector().text(\"Resume Task\"));").Click();

                TC12.Log(Status.Info, "Click Chat");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Chat));
                driver.FindElement(FG_PageObject.Pageobject.Chat).Click();

                TC12.Log(Status.Info, "Enter Chat Messgae");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Chatbox));
                driver.FindElement(FG_PageObject.Pageobject.Chatbox).SendKeys(GetData.Chatmessgae);
                TC12.Log(Status.Pass, "Chat Message is verified" + TC12.AddScreenCaptureFromPath(screenshot("FG_2013_PASS" + DateTime.Now.ToString("hhmmss"))));

                TC12.Log(Status.Info, "Click Send button");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Chatsend));
                driver.FindElement(FG_PageObject.Pageobject.Chatsend).Click();

                TC12.Log(Status.Info, "Click Chatback");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Chatback));
                driver.FindElement(FG_PageObject.Pageobject.Chatback).Click();

                TC12.Log(Status.Info, "Click Chat button");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Chat));
                driver.FindElement(FG_PageObject.Pageobject.Chat).Click();


                TC12.Log(Status.Info, "Verify Chat Process");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Chatmessagevaliation));
                TC12.Log(Status.Pass, "Chat Message is verified" + TC12.AddScreenCaptureFromPath(screenshot("FG_2013_PASS" + DateTime.Now.ToString("hhmmss"))));

            }
            catch
            {
                TC12.Log(Status.Fail, "Chat Message is not verified" + TC12.AddScreenCaptureFromPath(screenshot("TC_2013_Fail" + DateTime.Now.ToString("hhmmss"))));

            }


        }
    }
}
