using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Folio_Grow_Mobile_Application.FGHelpers
{
   public class FGHelpers
    {
        
        string date = DateTime.Now.ToString("MM/dd/yyyy").Replace('-', '/');
        public static bool load;
        public static void loading(AndroidDriver<AndroidElement> driver)
        {
            do
            {
                try
                {
                    load = driver.FindElement(By.Id("com.example.mediafg:id/progress_layout")).Displayed;
                }
                catch { }
            }
            while (load != false);
        }
        


        public static void Scroll(string Direction,AndroidDriver<AndroidElement> driver)
        {
            int height = driver.Manage().Window.Size.Height;
            int width = driver.Manage().Window.Size.Width; //720

            //Left to Right Swipe
            int startxx = (int)(width * 0.90);
            int endxx = (int)(width * 0.10);
            int startyy = (int)(height / 2);

            //full bottom to top swipe(down)
            var size = driver.Manage().Window.Size;
            int startyyyy = (int)(size.Height * 0.65);
            int endyyyy = (int)(size.Height * 0.20);
            int startxxxx = size.Width / 2;

            //half down
            int startx12 = size.Width / 2;
            int starty112 = (int)(size.Height * 0.50);
            int endy112 = (int)(size.Height * 0.20);


            //right to left
            int startx = (int)(size.Width * 0.70);
            int endx = (int)(size.Width * 0.30);
            int starty = size.Height / 2;

            if (Direction == "down")
            {
                Thread.Sleep(1000);
                new TouchAction(driver).Press(startxxxx, startyyyy).Wait(700).MoveTo(startxxxx, endyyyy).Release().Perform();
                
            }
            //else if(Direction == "up")
            //{
            //    driver.Swipe(Convert.ToInt32(startx1), Convert.ToInt32(endy11), Convert.ToInt32(startx1), Convert.ToInt32(starty11), 3000);
            //}
            else if (Direction == "halfdown")
            {
                new TouchAction(driver).Press(startx12, starty112).Wait(700).MoveTo(startx12, endy112).Release().Perform();
            }
            //else if (Direction == "halfup")
            //{
            //    driver.Swipe(Convert.ToInt32(startx12), Convert.ToInt32(endy112), Convert.ToInt32(startx12), Convert.ToInt32(starty112), 3000);
            //}
            //else if (Direction == "dobhalfup")
            //{
            //    driver.Swipe(Startx, Starty, Startx, Endy, 3000);
            //}
            else if (Direction == "LeftRight")
            {
                Thread.Sleep(1000);
                new TouchAction(driver).Press(startx, starty).Wait(700).MoveTo(endx, starty).Release().Perform();

            }
            else if (Direction == "Rightleft")
            {
                Thread.Sleep(1000);
                new TouchAction(driver).Press(endx, starty).Wait(700).MoveTo(startx, starty).Release().Perform();

            }

        }


        public static void Currentdate(IWebDriver driver,IWebElement Element)
        {
            string Currdate = DateTime.Now.ToString("dd");
            if (Currdate.Contains("01")) {
                Currdate = "1";
                driver.FindElement(FG_PageObject.Pageobject.Currentdate(Currdate)).Click();

            }
            else if (Currdate.Contains("02")){
                Currdate = "2";
                driver.FindElement(FG_PageObject.Pageobject.Currentdate(Currdate)).Click();

            }
            else if (Currdate.Contains("03"))
            {
                Currdate = "3";
                driver.FindElement(FG_PageObject.Pageobject.Currentdate(Currdate)).Click();

            }

            else if (Currdate.Contains("04"))
            {
                Currdate = "4";
                driver.FindElement(FG_PageObject.Pageobject.Currentdate(Currdate)).Click();
            }
            else if (Currdate.Contains("05"))
            {
                Currdate = "5";
                driver.FindElement(FG_PageObject.Pageobject.Currentdate(Currdate)).Click();

            }

            else if (Currdate.Contains("06"))
            {
                Currdate = "6";
                driver.FindElement(FG_PageObject.Pageobject.Currentdate(Currdate)).Click();

            }
            else if (Currdate.Contains("07"))
            {
                Currdate = "7";
                driver.FindElement(FG_PageObject.Pageobject.Currentdate(Currdate)).Click();

            }
            else if (Currdate.Contains("08"))
            {
                Currdate = "8";
                driver.FindElement(FG_PageObject.Pageobject.Currentdate(Currdate)).Click();

            }
            else if (Currdate.Contains("09"))
            {
                Currdate = "9";
                driver.FindElement(FG_PageObject.Pageobject.Currentdate(Currdate)).Click();

            }else
            {
                driver.FindElement(FG_PageObject.Pageobject.Currentdate(Currdate)).Click();

            }
        }
    }

    }

