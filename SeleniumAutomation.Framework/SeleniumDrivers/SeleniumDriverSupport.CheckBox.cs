using OpenQA.Selenium;

namespace SeleniumAutomation.Framework.SeleniumDrivers
{
    public static partial class SeleniumDriverSupport
    {
        public static void SetCheckboxValue(IWebElement checkbox, bool setTo)
        {
            try
            {
                var js = SeleniumDriver.Instance as IJavaScriptExecutor;
                if (setTo && !checkbox.Selected)
                {
                    js.ExecuteScript("arguments[0].click();", checkbox);
                }
                else if (!setTo && checkbox.Selected)
                {
                    js.ExecuteScript("arguments[0].click();", checkbox);
                }
            }
            catch (WebDriverException e)
            {
                throw new Exception($"EXCEPTION THROWN WHILE SELECTING THE CHECKBOX.", e);
            }
        }
    }
}
