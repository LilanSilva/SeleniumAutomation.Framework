using OpenQA.Selenium;
using SeleniumAutomation.Framework.Enums;

namespace SeleniumAutomation.Framework.SeleniumDrivers
{
    public static partial class SeleniumDriverSupport
    {
        internal static TimeSpan _waitTime;
        public static Driver Driver;

        public static Driver GetDriver(WebBrowser webBrowser, TimeSpan waitTime)
        {
            if (SeleniumDriver.Instance == null)
            {
                SeleniumDriver.Initialise(webBrowser);

                _waitTime = waitTime;
                Driver = new Driver();
            }

            return Driver;
        }

        public static void ClearAllBrowserCache(this Driver driver)
        {
            try
            {
                if (SeleniumDriver.Instance == null)
                {
                    return;
                }

                //// issue in current web driver, but selenium will fix that issue 
                //var js = SeleniumDriver.Instance as IJavaScriptExecutor;
                //js?.ExecuteScript("window.localStorage.clear();");

                SeleniumDriver.Instance.Manage().Cookies.DeleteAllCookies();
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        public static void Shutdown(this Driver driver)
        {
            driver.ClearAllBrowserCache();
            SeleniumDriver.Instance.Quit();
        }

        public static void RefreshPage(this Driver driver)
        {
            SeleniumDriver.Instance.Navigate().Refresh();
        }

        public static void Back(this Driver driver)
        {
            SeleniumDriver.Instance.Navigate().Back();
        }

        public static void Forward(this Driver driver)
        {
            SeleniumDriver.Instance.Navigate().Forward();
        }

        public static void GoToUrl(this Driver driver, string url)
        {
            SeleniumDriver.Instance.Navigate().GoToUrl(url);
        }

        public static void GoToUrl(this Driver driver, Uri url)
        {
            SeleniumDriver.Instance.Navigate().GoToUrl(url);
        }

        public static bool IsOnCorrectPage(this Driver driver, string pageUrlText)
        {
            return SeleniumDriver.Instance.Url.Contains(pageUrlText);
        }

        public static void TakeScreenShot(this Driver driver, string fileName, string filePath)
        {
            string fileFullPathName = "";
            try
            {
                fileFullPathName = $"{filePath}{fileName}{DateTime.Now.ToString("ddd d MMM_HH-mm-ss")}.jpg";
                var screenshot = ((ITakesScreenshot)SeleniumDriver.Instance).GetScreenshot();

                screenshot.SaveAsFile(fileFullPathName, ScreenshotImageFormat.Jpeg);
            }
            catch (Exception e)
            {
                throw new Exception($"Path : {fileFullPathName}", e);
            }
        }


    }
}
