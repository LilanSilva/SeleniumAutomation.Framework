using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomation.Framework.Enums;
using SeleniumExtras.WaitHelpers;

namespace SeleniumAutomation.Framework.SeleniumDrivers
{
    public static partial class SeleniumDriverSupport
    {
        #region Wait

        public static IWebElement FindElement(this Driver driver, By by)
        {
            driver.WaitTillElementExists(by);
            driver.WaitTillDisplayed(by);

            return SeleniumDriver.Instance.FindElement(by);
        }

        public static List<IWebElement> FindElements(this Driver driver, By by)
        {
            driver.WaitTillElementExists(by);
            driver.WaitTillDisplayed(by);

            return SeleniumDriver.Instance.FindElements(by).ToList();
        }

        public static void WaitTillDisplayed(this Driver driver, By by)
        {
            var wait = new WebDriverWait(SeleniumDriver.Instance, SeleniumDriverSupport._waitTime);
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
        }

        public static void WaitTillNotDisplayed(this Driver driver, By by)
        {
            var wait = new WebDriverWait(SeleniumDriver.Instance, SeleniumDriverSupport._waitTime);
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
        }

        private static void WaitTillElementExists(this Driver driver, By by)
        {
            var wait = new WebDriverWait(SeleniumDriver.Instance, SeleniumDriverSupport._waitTime);
            wait.Until(ExpectedConditions.ElementExists(by));
        }

        public static void WaitTillClickable(this Driver driver, By by)
        {
            var wait = new WebDriverWait(SeleniumDriver.Instance, SeleniumDriverSupport._waitTime);
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        public static void WaitTillNotDisplayed(this Driver driver, ElementBy by, string elementIdentifier)
        {
            driver.WaitTillNotDisplayed(by, elementIdentifier, SeleniumDriverSupport._waitTime);
        }

        public static void WaitTillDisplayed(this Driver driver, ElementBy by, string elementIdentifier)
        {
            driver.WaitTillDisplayed(by, elementIdentifier, SeleniumDriverSupport._waitTime);
        }

        public static void WaitTillElementExists(this Driver driver, ElementBy by, string elementIdentifier)
        {
            driver.WaitTillElementExists(by, elementIdentifier, SeleniumDriverSupport._waitTime);
        }

        public static void WaitTillEnabled(this Driver driver, ElementBy by, string elementIdentifier)
        {
            driver.WaitTillEnabled(by, elementIdentifier, SeleniumDriverSupport._waitTime);
        }

        public static void WaitTillClickable(this Driver driver, ElementBy by, string elementIdentifier)
        {
            driver.WaitTillClickable(by, elementIdentifier, SeleniumDriverSupport._waitTime);
        }

        public static void WaitTillAlertPresent(this Driver driver)
        {
            WebDriverWait wait = new WebDriverWait(SeleniumDriver.Instance, SeleniumDriverSupport._waitTime);
            wait.Until(ExpectedConditions.AlertIsPresent());
        }

        private static void WaitTillNotDisplayed(this Driver driver, ElementBy by, string elementIdentifier, TimeSpan timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(SeleniumDriver.Instance, timeInSeconds);

            switch (by)
            {
                case ElementBy.Id:
                    wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id(elementIdentifier)));
                    break;
                case ElementBy.Name:
                    wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Name(elementIdentifier)));
                    break;
                case ElementBy.XPath:
                    wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(elementIdentifier)));
                    break;
                case ElementBy.ClassName:
                    wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName(elementIdentifier)));
                    break;
                case ElementBy.CssSelector:
                    wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(elementIdentifier)));
                    break;
                case ElementBy.LinkText:
                    wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.LinkText(elementIdentifier)));
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private static void WaitTillDisplayed(this Driver driver, ElementBy by, string elementIdentifier, TimeSpan timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(SeleniumDriver.Instance, timeInSeconds);

            switch (by)
            {
                case ElementBy.Id:
                    wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id(elementIdentifier)));
                    break;
                case ElementBy.Name:
                    wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Name(elementIdentifier)));
                    break;
                case ElementBy.XPath:
                    wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(elementIdentifier)));
                    break;
                case ElementBy.ClassName:
                    wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.ClassName(elementIdentifier)));
                    break;
                case ElementBy.CssSelector:
                    wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(elementIdentifier)));
                    break;
                case ElementBy.LinkText:
                    wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.LinkText(elementIdentifier)));
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private static void WaitTillElementExists(this Driver driver, ElementBy by, string elementIdentifier, TimeSpan timeInSeconds)
        {
            var wait = new WebDriverWait(SeleniumDriver.Instance, timeInSeconds);

            switch (by)
            {
                case ElementBy.Id:
                    wait.Until(ExpectedConditions.ElementExists(By.Id(elementIdentifier)));
                    break;
                case ElementBy.Name:
                    wait.Until(ExpectedConditions.ElementExists(By.Name(elementIdentifier)));
                    break;
                case ElementBy.XPath:
                    wait.Until(ExpectedConditions.ElementExists(By.XPath(elementIdentifier)));
                    break;
                case ElementBy.ClassName:
                    wait.Until(ExpectedConditions.ElementExists(By.ClassName(elementIdentifier)));
                    break;
                case ElementBy.CssSelector:
                    wait.Until(ExpectedConditions.ElementExists(By.CssSelector(elementIdentifier)));
                    break;
                case ElementBy.LinkText:
                    wait.Until(ExpectedConditions.ElementExists(By.LinkText(elementIdentifier)));
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private static void WaitTillEnabled(this Driver driver, ElementBy by, string elementIdentifier, TimeSpan timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(SeleniumDriver.Instance, timeInSeconds);

            switch (by)
            {
                case ElementBy.Id:
                    wait.Until(d => d.FindElement(By.Id(elementIdentifier)).Enabled);
                    break;
                case ElementBy.Name:
                    wait.Until(d => d.FindElement(By.Name(elementIdentifier)).Enabled);
                    break;
                case ElementBy.XPath:
                    wait.Until(d => d.FindElement(By.XPath(elementIdentifier)).Enabled);
                    break;
                case ElementBy.ClassName:
                    wait.Until(d => d.FindElement(By.ClassName(elementIdentifier)).Enabled);
                    break;
                case ElementBy.CssSelector:
                    wait.Until(d => d.FindElement(By.CssSelector(elementIdentifier)).Enabled);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private static void WaitTillClickable(this Driver driver, ElementBy by, string elementIdentifier, TimeSpan timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(SeleniumDriver.Instance, timeInSeconds);

            switch (by)
            {
                case ElementBy.Id:
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(elementIdentifier)));
                    break;
                case ElementBy.Name:
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.Name(elementIdentifier)));
                    break;
                case ElementBy.XPath:
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(elementIdentifier)));
                    break;
                case ElementBy.ClassName:
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName(elementIdentifier)));
                    break;
                case ElementBy.CssSelector:
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(elementIdentifier)));
                    break;
                case ElementBy.LinkText:
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText(elementIdentifier)));
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public static IWebElement FindElement(this Driver driver, ElementBy by, string elementIdentifier)
        {
            driver.WaitTillElementExists(by, elementIdentifier);
            driver.WaitTillDisplayed(by, elementIdentifier);

            switch (by)
            {
                case ElementBy.Id:
                    return SeleniumDriver.Instance.FindElement(By.Id(elementIdentifier));
                case ElementBy.Name:
                    return SeleniumDriver.Instance.FindElement(By.Name(elementIdentifier));
                case ElementBy.XPath:
                    return SeleniumDriver.Instance.FindElement(By.XPath(elementIdentifier));
                case ElementBy.ClassName:
                    return SeleniumDriver.Instance.FindElement(By.ClassName(elementIdentifier));
                case ElementBy.CssSelector:
                    return SeleniumDriver.Instance.FindElement(By.CssSelector(elementIdentifier));
                case ElementBy.LinkText:
                    return SeleniumDriver.Instance.FindElement(By.LinkText(elementIdentifier));
                default:
                    throw new NotImplementedException();
            }
        }

        public static List<IWebElement> FindElements(this Driver driver, ElementBy by, string elementIdentifier)
        {
            driver.WaitTillElementExists(by, elementIdentifier);
            driver.WaitTillDisplayed(by, elementIdentifier);

            switch (by)
            {
                case ElementBy.Id:
                    return SeleniumDriver.Instance.FindElements(By.Id(elementIdentifier)).ToList();
                case ElementBy.Name:
                    return SeleniumDriver.Instance.FindElements(By.Name(elementIdentifier)).ToList();
                case ElementBy.XPath:
                    return SeleniumDriver.Instance.FindElements(By.XPath(elementIdentifier)).ToList();
                case ElementBy.ClassName:
                    return SeleniumDriver.Instance.FindElements(By.ClassName(elementIdentifier)).ToList();
                case ElementBy.CssSelector:
                    return SeleniumDriver.Instance.FindElements(By.CssSelector(elementIdentifier)).ToList();
                case ElementBy.LinkText:
                    return SeleniumDriver.Instance.FindElements(By.LinkText(elementIdentifier)).ToList();
                default:
                    throw new NotImplementedException();
            }
        }

        #endregion


        #region Is Element displayed

        public static bool IsElementDisplayedInsideElement(this Driver driver, ElementBy by, string elementIdentifier, IWebElement inside)
        {
            switch (by)
            {
                case ElementBy.Id:
                    return inside.FindElement(By.Id(elementIdentifier)).Displayed;
                case ElementBy.Name:
                    return inside.FindElement(By.Name(elementIdentifier)).Displayed;
                case ElementBy.XPath:
                    return inside.FindElement(By.XPath(elementIdentifier)).Displayed;
                case ElementBy.TagName:
                    return inside.FindElement(By.TagName(elementIdentifier)).Displayed;
                case ElementBy.ClassName:
                    return inside.FindElement(By.ClassName(elementIdentifier)).Displayed;
                case ElementBy.CssSelector:
                    return inside.FindElement(By.CssSelector(elementIdentifier)).Displayed;
                case ElementBy.LinkText:
                    return inside.FindElement(By.LinkText(elementIdentifier)).Displayed;
                default:
                    throw new NotImplementedException();
            }
        }

        public static bool IsElementDisplayed(this Driver driver, ElementBy by, string elementIdentifier)
        {
            switch (by)
            {
                case ElementBy.Id:
                    return SeleniumDriver.Instance.FindElement(By.Id(elementIdentifier)).Displayed;
                case ElementBy.Name:
                    return SeleniumDriver.Instance.FindElement(By.Name(elementIdentifier)).Displayed;
                case ElementBy.XPath:
                    return SeleniumDriver.Instance.FindElement(By.XPath(elementIdentifier)).Displayed;
                case ElementBy.ClassName:
                    return SeleniumDriver.Instance.FindElement(By.ClassName(elementIdentifier)).Displayed;
                case ElementBy.CssSelector:
                    return SeleniumDriver.Instance.FindElement(By.CssSelector(elementIdentifier)).Displayed;
                case ElementBy.LinkText:
                    return SeleniumDriver.Instance.FindElement(By.LinkText(elementIdentifier)).Displayed;
                default:
                    throw new NotImplementedException();
            }
        }

        public static bool IsElementDisplayed(By by)
        {
            try
            {
                return SeleniumDriver.Instance.FindElement(by).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static bool IsElementDisplayed(IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        #endregion
    }
}
