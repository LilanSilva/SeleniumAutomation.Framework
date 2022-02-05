using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomation.Framework.Enums;

namespace SeleniumAutomation.Framework.SeleniumDrivers
{
    public static partial class SeleniumDriverSupport
    {
        public static void SetDropdownValue(IWebElement select, string text)
        {
            try
            {
                var dropdown = new SelectElement(select);
                dropdown.SelectByText(text);
            }
            catch (WebDriverException e)
            {
                throw new Exception($"EXCEPTION THROWN WHILE SELECTING THE DROPDOWN TEXT.", e);
            }
        }

        public static void SetDropdownValue(this Driver driver, ElementBy by, string elementIdentifier, string text)
        {
            try
            {
                var select = driver.FindElement(by, elementIdentifier);

                var dropdown = new SelectElement(select);

                dropdown.SelectByText(text);
            }
            catch (WebDriverException e)
            {
                throw new Exception($"EXCEPTION THROWN WHILE SELECTING THE DROPDOWN TEXT.", e);
            }
        }

        public static bool CheckDropdownValuesEqual(IWebElement select, string[] list)
        {
            try
            {
                var dropdown = new SelectElement(select);
                IEnumerable<string> available = dropdown.Options.Select(i => i.Text.ToLower().Trim());
                return list.All(d => available.Contains(d.ToLower())) && list.Length.Equals(available.Count());
            }
            catch (WebDriverException e)
            {
                throw new Exception($"EXCEPTION THROWN WHILE CheckDropdownValuesEqual.", e);
            }
        }
    }
}
