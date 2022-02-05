using OpenQA.Selenium;
using SeleniumAutomation.Framework.Enums;

namespace SeleniumAutomation.Framework.SeleniumDrivers
{
    public static partial class SeleniumDriverSupport
    {
        public static void EnterText(this IWebElement element, string text)
        {
            try
            {
                element.Clear();
                element.SendKeys(text);
            }
            catch (WebDriverException e)
            {
                throw new Exception($"EXCEPTION THROWN WHILE EnterText.", e);
            }
        }

        public static void EnterText(this Driver driver, ElementBy by, string elementIdentifier, string text)
        {
            try
            {
                var textElement = driver.FindElement(by, elementIdentifier);

                driver.WaitTillElementExists(by, elementIdentifier);

                textElement.EnterText(text);
            }
            catch (WebDriverException e)
            {
                throw new Exception($"EXCEPTION THROWN WHILE EnterText.", e);
            }
        }
    }
}
