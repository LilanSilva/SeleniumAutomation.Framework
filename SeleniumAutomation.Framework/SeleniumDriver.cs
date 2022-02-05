using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using SeleniumAutomation.Framework.Enums;
using System.Drawing;
using System.Reflection;

namespace SeleniumAutomation.Framework
{
    public class Driver
    {
        internal Driver() { }
    }

    public class SeleniumDriver
    {
        public static IWebDriver Instance { get; internal set; }

        #region Private methods

        internal static void Initialise(WebBrowser webBrowser)
        {
            if (webBrowser == WebBrowser.Chrome)
            {
                Instance = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                Instance.Manage().Window.Maximize();
            }
            else if (webBrowser == WebBrowser.Phantom)
            {
                var options = new ChromeOptions();
                options.AddArguments("headless");
                Instance = new ChromeDriver(options);
                Instance.Manage().Window.Size = new Size(1920, 1080);
            }
            else if (webBrowser == WebBrowser.Firefox)
            {
                Instance = new FirefoxDriver();
                Instance.Manage().Window.Maximize();
            }
            else if (webBrowser == WebBrowser.Edge)
            {
                var driver = new EdgeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                Instance.Manage().Window.Maximize();
            }
        }

        #endregion
    }
}
