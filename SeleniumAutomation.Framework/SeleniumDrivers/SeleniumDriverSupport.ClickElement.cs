using OpenQA.Selenium;
using SeleniumAutomation.Framework.Enums;

namespace SeleniumAutomation.Framework.SeleniumDrivers
{
    public static partial class SeleniumDriverSupport
    {
        /// <summary>
        /// Click Element
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="by"></param>
        /// <param name="elementIdentifier"></param>
        /// <param name="waitAfterClick">Wait 200 millisecond after click</param>
        /// <exception cref="Exception"></exception>
        public static void ClickElement(this Driver driver, ElementBy by, string elementIdentifier, int waitAfterClick = 250)
        {
            try
            {
                var clickElement = driver.FindElement(by, elementIdentifier);

                driver.WaitTillClickable(by, elementIdentifier);

                clickElement.Click();

                Thread.Sleep(waitAfterClick);
            }
            catch (WebDriverException e)
            {
                throw new Exception($"EXCEPTION THROWN WHILE CLICK ELEMENT.", e);
            }
        }
    }
}
