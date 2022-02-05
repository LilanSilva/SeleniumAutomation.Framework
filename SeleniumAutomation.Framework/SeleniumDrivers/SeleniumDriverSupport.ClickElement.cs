using OpenQA.Selenium;
using SeleniumAutomation.Framework.Enums;

namespace SeleniumAutomation.Framework.SeleniumDrivers
{
    public static partial class SeleniumDriverSupport
    {
        public static void ClickElement(this Driver driver, ElementBy by, string elementIdentifier)
        {
            try
            {
                var clickElement = driver.FindElement(by, elementIdentifier);

                driver.WaitTillClickable(by, elementIdentifier);

                clickElement.Click();

                Thread.Sleep(500);
            }
            catch (WebDriverException e)
            {
                throw new Exception($"EXCEPTION THROWN WHILE CLICK ELEMENT.", e);
            }
        }
    }
}
