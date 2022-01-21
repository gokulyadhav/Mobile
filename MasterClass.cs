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
using System.Net.Mail;
using System.Text;
using System.Linq;

namespace Folio_Grow_Mobile_Application
{
    class MasterClass
    {
        public AndroidDriver<AndroidElement> driver;
        public WebDriverWait wait;
        public  string projectPath = "";
        public ExtentReports _extent;
        public ExtentHtmlReporter htmlReporter;
        public string currr;


        public void reports(string Title)
        {
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            projectPath = new Uri(actualPath).LocalPath;
            string reportPath = string.Format(projectPath + "Reports\\Result\\" + DateTime.Now.ToString("hhmmss") + ".html");
            htmlReporter = new ExtentHtmlReporter(reportPath);
            htmlReporter.Configuration().ReportName = "FG Mobile Application";
            htmlReporter.Configuration().DocumentTitle = Title;

            _extent = new ExtentReports();
            _extent.AddSystemInfo("Application", "FG Mobile Application");
            _extent.AddSystemInfo("Environment", "QA");
            _extent.AddSystemInfo("Tool", "Appium");
            _extent.AddSystemInfo("Screen", Title);
            _extent.AttachReporter(htmlReporter);
        }


        public string screenshot(string screenshotName)
        {

            var screenshot = driver.GetScreenshot();
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "Screenshot\\" + screenshotName + ".png";
            string localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return localpath;
        }
        public void Send_Report_In_Mail()
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("gokulg@techaffinity.com");
            mail.To.Add("gokulg@techaffinity.com");

            StringBuilder TimeAndDate = new StringBuilder(DateTime.Now.ToString());
            TimeAndDate.Replace("/", "_");
            TimeAndDate.Replace(":", "_");

            mail.Subject = "Automation Test Report_"+TimeAndDate;

            mail.Body = "Please find the attached report to get details.";

            //string actualPath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin", "\\Reports"); //Reports should store in Test_Execution_Reports folder

            var mostRecentlyModified = Directory.GetFiles("C:\\Users\\gokulg\\source\\repos\\Folio_Grow_Mobile_Application\\Folio_Grow_Mobile_Application\\Reports\\Result", "*.html")
            .Select(f => new FileInfo(f))
            .OrderByDescending(fi => fi.LastWriteTime)
            .First()
            .FullName;

            Attachment attachment;
            attachment = new Attachment(mostRecentlyModified);
            mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("gokulg@techaffinity.com", "Gokul@12345");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }

        public void currendate()
        {
            string curr = DateTime.Now.ToString("dd");
            if (curr.StartsWith("0"))
            {
                currr = curr.Remove(0, 1);
            }
            else
            {
                currr = curr;
            }

        }
        public void starttask()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Assigned));
            driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                          + "new UiSelector().text(\"Start Task\"));").Click();

        }

        public void Resumetask()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FG_PageObject.Pageobject.Assigned));
            driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                          + "new UiSelector().text(\"Resume Task\"));").Click();

        }


        [OneTimeSetUp]
        public void TestMethod1()
        {
            var cap = new AppiumOptions();
            cap.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Moto");
            cap.AddAdditionalCapability(MobileCapabilityType.Udid, "emulator-5554");
            cap.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            cap.AddAdditionalCapability(MobileCapabilityType.AutomationName, "uiautomator2");
            cap.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "8.1");
            cap.AddAdditionalCapability(MobileCapabilityType.App, @"D:\Apk\FolioGrow_02Jul2020.apk");
            cap.AddAdditionalCapability(MobileCapabilityType.FullReset, true);
            cap.AddAdditionalCapability("autoGrantPermissions", true);

            driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), cap, TimeSpan.FromMinutes(2));

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [TearDown]
        public void TearDown()
        {
            _extent.Flush();
            driver.ResetApp();
            

        }
        [OneTimeTearDown]
        public void tea()
        {
            Send_Report_In_Mail();
        }
    }
}
