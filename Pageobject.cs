using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Folio_Grow_Mobile_Application.FG_PageObject
{
    class Pageobject
    {

        public static By Username { get { return By.Id("et_user_name"); } }

        public static By Password { get { return By.Id("et_password"); } }

        public static By Login { get { return By.Id("btn_login"); } }

        public static By Validation { get { return By.Id("iv_menu"); } }

        public static By loading { get { return By.Id("com.example.mediafg:id/progress_layout"); } }

        public static By InValidation { get { return By.Id("snackbar_text"); } }
        public static By PausedTaskvalidation { get { return By.Id("snackbar_text"); } }

        public static By Taskname { get { return By.Id("tv_task_name"); } }

        public static By Taskpicture { get { return By.Id("iv_take_pic"); } }

        public static By Cameraclicking { get { return By.Id("com.example.mediafg:id/clickme"); } }

        public static By Uploadimage { get { return By.Id("iv_upload"); } }

        public static By Taskno { get { return By.Id("com.example.mediafg:id/tv_task_no"); } }

        public static By Pausedtaskcount { get { return By.Id("tv_badge_text"); } }

        public static By signout { get { return By.XPath("//*[@text='Sign Out']"); } }

        public static By Today { get { return By.XPath("//*[@text='Today']"); } }

        public static By PausedTask { get { return By.XPath("//*[@text='Paused Tasks']"); } }

      //  public static By PausedTaskvalidation { get { return By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout"); } }

      //public static By PausedTaskvalidation { get { return By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.TextView"); } }

        public static By Assigned { get { return By.XPath("//*[@text='Assigned']"); } }

        public static By ResumeTask { get { return By.XPath("//*[@text='Resume Task']"); } }

        public static By Starttask { get { return By.XPath("//*[@text='Start Task']"); } }

        public static By StopTask { get { return By.XPath("//*[@text='Stop Task']"); } }

        public static By Completetask { get { return By.Id("tv_complete"); } }

        public static By Noofplants { get { return By.Id("et_plant_count"); } }

        public static By Notes { get { return By.Id("et_notes"); } }

        public static By Pausetaskbutton { get { return By.Id("tv_pause"); } }

        public static By Tasktimervalue { get { return By.Id("tv_timer_value"); } }

        public static By Completed { get { return By.XPath("//*[@text='Completed']"); } }

        public static By HideActivities { get { return By.XPath("//*[@text='Hide Activities']"); } }

        public static By ViewActivities { get { return By.XPath("//*[@text='View Activities']"); } }

        public static By Datepicker { get { return By.Id("tv_datetime"); } }

        public static By Tips { get { return By.Id("iv_tips"); } }

        public static By Chat { get { return By.Id("iv_chat"); } }

        public static By Chatbox { get { return By.Id("et_chat_message"); } }

        public static By Chatsend { get { return By.Id("iv_send"); } }

        public static By Chatback { get { return By.Id("iv_back"); } }

        public static By Chatmessagevaliation { get { return By.Id("tv_user_message"); } }

        public static By TestTips { get { return By.Id("tv_tips"); } }

        public static By Notips { get { return By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.TextView"); } }

        public static By verifytips { get { return By.XPath("//*[@text='No tips for this task' or 'Task 1: test md']"); } }

        public static By Pastmonthnavigation { get { return By.Id("android:id/prev"); } }

        public static By Futuremonthnavigation { get { return By.Id("android:id/next"); } }

        public static By Selectingdate { get { return By.XPath("//*[@text='1']"); } }

        public static By Currentdate(string date) {  { return By.XPath("//*[@text='"+date+"']"); } }

        public static By LeftNavigation { get { return By.Id("iv_left"); } }

        public static By RightNavigation { get { return By.Id("iv_right"); } }

    }
}
