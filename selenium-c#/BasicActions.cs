using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace QATest_Hov
{
    public class BasicActions
    {
        public static void GoToUrl(IWebDriver driver)
        {
            var url = "https://dev-screener.reitscreener.com/";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            var count = 0;
            var maxTries = 3;                                                                                   //If the website didn't load on the first attempt, It still has 3 tries. 
            while (true)
            {
                try
                {
                    driver.Navigate().GoToUrl(url);
                    break;
                }
                catch (WebDriverException e)
                {
                    if (++count == maxTries) throw e;
                }
            }

            wait.Until(e => e.FindElement(By.CssSelector("#root > section > header > div")));                  //Incase the website is still loading, It makes sure that it sees the Navigation bar before performing anything.
        }

        public static void ClickRegister(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            var button = wait.Until(e => e.FindElement(By.CssSelector("#root > section > header > div > div > a:nth-child(2) > button")));
            button.Click();
        }

        public static void ClickSignIn(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            var button = wait.Until(e => e.FindElement(By.CssSelector("#root > section > header > div > div > a:nth-child(1) > button")));
            button.Click();
        }

        //FOR REGISTER
        public static void SetFirstName(IWebDriver driver, string value)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            var field1 = wait.Until(e => e.FindElement(By.CssSelector("#root > div > div > div.ant-col.d-flex.justify-content-center.justify-content-md-end.pr-0.ant-col-xs-24.ant-col-md-12 > div > div > div > form > div:nth-child(1) > div.ant-col.ant-form-item-control > div.ant-form-item-control-input > div > input")));
            field1.Clear();
            driver.Navigate().Refresh();

            var field = wait.Until(e => e.FindElement(By.CssSelector("#root > div > div > div.ant-col.d-flex.justify-content-center.justify-content-md-end.pr-0.ant-col-xs-24.ant-col-md-12 > div > div > div > form > div:nth-child(1) > div.ant-col.ant-form-item-control > div.ant-form-item-control-input > div > input")));
            field.SendKeys(Keys.Tab);
            Thread.Sleep(500);
            field.SendKeys(value + Keys.Tab);
            Thread.Sleep(500);
        }

        public static string GetErrorMessageFirstName(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
             var field = wait.Until(e => e.FindElement(By.CssSelector("#root > div > div > div.ant-col.d-flex.justify-content-center.justify-content-md-end.pr-0.ant-col-xs-24.ant-col-md-12 > div > div > div > form > div:nth-child(1) > div.ant-col.ant-form-item-control > div.ant-form-item-explain > div")));
            try
            {
                return field.GetAttribute("innerText").Trim();
            }
            catch (WebDriverException)
            {
                throw new AssertionException("No error message found");
            }
        }

        public static bool HasErrorMessageFirstName(IWebDriver driver)
        {
            var hasErrorMessage = (driver.FindElements(By.CssSelector("#root > div > div > div.ant-col.d-flex.justify-content-center.justify-content-md-end.pr-0.ant-col-xs-24.ant-col-md-12 > div > div > div > form > div:nth-child(1) > div.ant-col.ant-form-item-control > div.ant-form-item-explain > div")).Count > 0);
            return hasErrorMessage;
        }

        public static void SetLastName(IWebDriver driver, string value)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            var field1 = wait.Until(e => e.FindElement(By.CssSelector("#root > div > div > div.ant-col.d-flex.justify-content-center.justify-content-md-end.pr-0.ant-col-xs-24.ant-col-md-12 > div > div > div > form > div:nth-child(2) > div.ant-col.ant-form-item-control > div.ant-form-item-control-input > div > input")));
            field1.Clear();
            driver.Navigate().Refresh();
            var field = wait.Until(e => e.FindElement(By.CssSelector("#root > div > div > div.ant-col.d-flex.justify-content-center.justify-content-md-end.pr-0.ant-col-xs-24.ant-col-md-12 > div > div > div > form > div:nth-child(2) > div.ant-col.ant-form-item-control > div.ant-form-item-control-input > div > input")));
            field.SendKeys(Keys.Tab);
            Thread.Sleep(500);
            field.SendKeys(value + Keys.Tab);
            Thread.Sleep(500);
        }

        public static string GetErrorMessageLastName(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            var field = wait.Until(e => e.FindElement(By.CssSelector("#root > div > div > div.ant-col.d-flex.justify-content-center.justify-content-md-end.pr-0.ant-col-xs-24.ant-col-md-12 > div > div > div > form > div:nth-child(2) > div.ant-col.ant-form-item-control > div.ant-form-item-explain > div")));
            try
            {
                return field.GetAttribute("innerText").Trim();
            }
            catch (WebDriverException)
            {
                throw new AssertionException("No error message found");
            }
        }

        public static bool HasErrorMessageLastName(IWebDriver driver)
        {
            var hasErrorMessage = (driver.FindElements(By.CssSelector("#root > div > div > div.ant-col.d-flex.justify-content-center.justify-content-md-end.pr-0.ant-col-xs-24.ant-col-md-12 > div > div > div > form > div:nth-child(2) > div.ant-col.ant-form-item-control > div.ant-form-item-explain > div")).Count > 0);
            return hasErrorMessage;
        }

        public static void SetEmailAddress(IWebDriver driver, string value)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            var field1 = wait.Until(e => e.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div/div/div/form/div[3]/div[2]/div[1]/div/input")));
            field1.Clear();
            driver.Navigate().Refresh();
            var field = wait.Until(e => e.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div/div/div/form/div[3]/div[2]/div[1]/div/input")));
            field.SendKeys(Keys.Tab);
            Thread.Sleep(500);
            field.SendKeys(value + Keys.Tab);
            Thread.Sleep(500);
        }

        public static string GetErrorMessageEmail(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            var field = wait.Until(e => e.FindElement(By.CssSelector("#root > div > div > div.ant-col.d-flex.justify-content-center.justify-content-md-end.pr-0.ant-col-xs-24.ant-col-md-12 > div > div > div > form > div.ant-row.ant-form-item.ant-form-item-with-help.mb-2.d-block.text-left.ant-form-item-has-error > div.ant-col.ant-form-item-control > div.ant-form-item-explain > div")));
            try
            {
                return field.GetAttribute("innerText").Trim();
            }
            catch (WebDriverException)
            {
                throw new AssertionException("No error message found");
            }
        }

        public static bool HasErrorMessageEmail(IWebDriver driver)
        {
            var hasErrorMessage = (driver.FindElements(By.CssSelector("#root > div > div > div.ant-col.d-flex.justify-content-center.justify-content-md-end.pr-0.ant-col-xs-24.ant-col-md-12 > div > div > div > form > div.ant-row.ant-form-item.ant-form-item-with-help.mb-2.d-block.text-left.ant-form-item-has-error > div.ant-col.ant-form-item-control > div.ant-form-item-explain > div")).Count > 0);
            return hasErrorMessage;
        }

        public static bool HasLogo(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            var hasLogo = wait.Until(e => e.FindElements(By.CssSelector("#root > div > div > div.ant-col.d-flex.justify-content-center.justify-content-md-end.pr-0.ant-col-xs-24.ant-col-md-12 > div > div > div > a > img")).Count > 0);
            return hasLogo;
        }

        public static void ClickRegisterButton(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            var button = wait.Until(e => e.FindElement(By.CssSelector("#root > div > div > div.ant-col.d-flex.justify-content-center.justify-content-md-end.pr-0.ant-col-xs-24.ant-col-md-12 > div > div > div > form > div.ant-row.ant-form-item.mb-0 > div > div > div > button")));
            button.Click();
        }

        public static void SetFirstNameRegister(IWebDriver driver, string value)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            var field = wait.Until(e => e.FindElement(By.CssSelector("#root > div > div > div.ant-col.d-flex.justify-content-center.justify-content-md-end.pr-0.ant-col-xs-24.ant-col-md-12 > div > div > div > form > div:nth-child(1) > div.ant-col.ant-form-item-control > div.ant-form-item-control-input > div > input")));
            field.Clear();
            field.SendKeys(Keys.Tab);
            Thread.Sleep(500);
            field.SendKeys(value + Keys.Tab);
            Thread.Sleep(500);
        }

        public static void SetLastNameRegister(IWebDriver driver, string value)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            var field = wait.Until(e => e.FindElement(By.CssSelector("#root > div > div > div.ant-col.d-flex.justify-content-center.justify-content-md-end.pr-0.ant-col-xs-24.ant-col-md-12 > div > div > div > form > div:nth-child(2) > div.ant-col.ant-form-item-control > div.ant-form-item-control-input > div > input")));
            field.Clear();
            field.SendKeys(Keys.Tab);
            Thread.Sleep(500);
            field.SendKeys(value + Keys.Tab);
            Thread.Sleep(500);
        }

        public static void SetEmailAddressRegister(IWebDriver driver, string value)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            var field = wait.Until(e => e.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div/div/div/form/div[3]/div[2]/div[1]/div/input")));
            field.Clear();
            field.SendKeys(Keys.Tab);
            Thread.Sleep(500);
            field.SendKeys(value + Keys.Tab);
            Thread.Sleep(500);
        }

        //SIGNIN VIEW
        public static void SetEmailAddressLogin(IWebDriver driver, string value)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            var field1 = wait.Until(e => e.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div/div/div/div/div/form/div[1]/div[2]/div[1]/div/input")));
            field1.Clear();
            driver.Navigate().Refresh();
            var field = wait.Until(e => e.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div/div/div/div/div/form/div[1]/div[2]/div[1]/div/input")));
            field.SendKeys(Keys.Tab);
            Thread.Sleep(500);
            field.SendKeys(value + Keys.Tab);
            Thread.Sleep(500);
        }

        public static bool HasLogoLogin(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(e => e.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div/div/div/div/div/form/div[1]/div[2]/div[1]/div/input")));
            var hasLogo = (driver.FindElements(By.XPath("/html/body/div[1]/div/div/div[2]/div/div/div/div/div/a/img")).Count > 0);
            return hasLogo;
        }

        public static string GetErrorMessageEmailLogin(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            var field = wait.Until(e => e.FindElement(By.CssSelector("#root > div > div > div.ant-col.ant-col-order-2.d-flex.justify-content-center.justify-content-md-end.pr-0.ant-col-xs-24.ant-col-md-12 > div > div > div > div > div > form > div.ant-row.ant-form-item.ant-form-item-with-help.mb-2.d-block.text-left.ant-form-item-has-error > div.ant-col.ant-form-item-control > div.ant-form-item-explain > div")));
            try
            {
                return field.GetAttribute("innerText").Trim();
            }
            catch (WebDriverException)
            {
                throw new AssertionException("No error message found");
            }
        }

        public static bool HasErrorMessageEmailLogin(IWebDriver driver)
        {
            var hasErrorMessage = (driver.FindElements(By.CssSelector("#root > div > div > div.ant-col.ant-col-order-2.d-flex.justify-content-center.justify-content-md-end.pr-0.ant-col-xs-24.ant-col-md-12 > div > div > div > div > div > form > div.ant-row.ant-form-item.ant-form-item-with-help.mb-2.d-block.text-left.ant-form-item-has-error > div.ant-col.ant-form-item-control > div.ant-form-item-explain > div")).Count > 0);
            return hasErrorMessage;
        }

        public static void ClickSigninsButton(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            var button = wait.Until(e => e.FindElement(By.CssSelector("#root > div > div > div.ant-col.ant-col-order-2.d-flex.justify-content-center.justify-content-md-end.pr-0.ant-col-xs-24.ant-col-md-12 > div > div > div > div > div > form > div:nth-child(2) > div > div > div > button")));
            button.Click();
        }

        public static void SetEmailAddressLogin2(IWebDriver driver, string value)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            var field = wait.Until(e => e.FindElement(By.CssSelector("#root > div > div > div.ant-col.ant-col-order-2.d-flex.justify-content-center.justify-content-md-end.pr-0.ant-col-xs-24.ant-col-md-12 > div > div > div > div > div > form > div.ant-row.ant-form-item.mb-2.d-block.text-left > div.ant-col.ant-form-item-control > div > div > input")));
            field.SendKeys(Keys.Tab);
            Thread.Sleep(500);
            field.SendKeys(value + Keys.Tab);
            Thread.Sleep(500);
        }

        public static bool PopupForUnregEmail(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(e => e.FindElement(By.CssSelector("#error-msg > div > div > span > div > div > div")));
            var popup = driver.FindElements(By.CssSelector("#error-msg > div > div > span > div > div > div")).Count > 0;
            Thread.Sleep(3000);
            return popup;
        }

        //Result View
        public static bool ResultView(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(e => e.FindElement(By.CssSelector("#root > div > div > div.ant-col.d-flex.justify-content-center.justify-content-md-end.pr-0.ant-col-xs-24.ant-col-md-12 > div > div > div > span > button")));
            var resultview = (driver.FindElements(By.CssSelector("#root > div > div")).Count > 0);
            return resultview;
        }

        public static string MagicLink(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(e => e.FindElement(By.CssSelector("#root > div > div > div.ant-col.d-flex.justify-content-center.justify-content-md-end.pr-0.ant-col-xs-24.ant-col-md-12 > div > div > div > span > button")));
            var magiclink = driver.FindElement(By.CssSelector("#root > div > div > div.ant-col.d-flex.justify-content-center.justify-content-md-end.pr-0.ant-col-xs-24.ant-col-md-12 > div > div > div > h2"));
            return magiclink.GetAttribute("innerText").Trim();
        }

        public static string GetYourEmailAddress(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(e => e.FindElement(By.CssSelector("#root > div > div > div.ant-col.d-flex.justify-content-center.justify-content-md-end.pr-0.ant-col-xs-24.ant-col-md-12 > div > div > div > span > button")));
            var magiclink = driver.FindElement(By.CssSelector("#root > div > div > div.ant-col.d-flex.justify-content-center.justify-content-md-end.pr-0.ant-col-xs-24.ant-col-md-12 > div > div > div > div > span"));
            return magiclink.GetAttribute("innerText").Trim();
        }

        public static bool HasOpenEmailButton(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(e => e.FindElement(By.CssSelector("#root > div > div > div.ant-col.d-flex.justify-content-center.justify-content-md-end.pr-0.ant-col-xs-24.ant-col-md-12 > div > div > div > span > button")));
            var hasButton = (driver.FindElements(By.CssSelector("#root > div > div > div.ant-col.d-flex.justify-content-center.justify-content-md-end.pr-0.ant-col-xs-24.ant-col-md-12 > div > div > div > button")).Count > 0);
            return hasButton;
        }

        public static bool ResultViewSignin(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(e => e.FindElement(By.CssSelector("#root > div > div > div.ant-col.ant-col-order-2.d-flex.justify-content-center.justify-content-md-end.pr-0.ant-col-xs-24.ant-col-md-12 > div > div > div > div > div > span")));
            var resultview = (driver.FindElements(By.CssSelector("#root > div > div")).Count > 0);
            return resultview;
        }

        public static string MagicLinkSignin(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(e => e.FindElement(By.CssSelector("#root > div > div > div.ant-col.ant-col-order-2.d-flex.justify-content-center.justify-content-md-end.pr-0.ant-col-xs-24.ant-col-md-12 > div > div > div > div > div > h2")));
            var magiclink = driver.FindElement(By.CssSelector("#root > div > div > div.ant-col.ant-col-order-2.d-flex.justify-content-center.justify-content-md-end.pr-0.ant-col-xs-24.ant-col-md-12 > div > div > div > div > div > h2"));
            return magiclink.GetAttribute("innerText").Trim();
        }

        public static string GetYourEmailAddressSignin(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(e => e.FindElement(By.CssSelector("#root > div > div > div.ant-col.ant-col-order-2.d-flex.justify-content-center.justify-content-md-end.pr-0.ant-col-xs-24.ant-col-md-12 > div > div > div > div > div > span")));
            var magiclink = driver.FindElement(By.CssSelector("#root > div > div > div.ant-col.ant-col-order-2.d-flex.justify-content-center.justify-content-md-end.pr-0.ant-col-xs-24.ant-col-md-12 > div > div > div > div > div > div > span"));
            return magiclink.GetAttribute("innerText").Trim();
        }

        public static bool HasOpenEmailButtonSignin(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(e => e.FindElement(By.CssSelector("#root > div > div > div.ant-col.ant-col-order-2.d-flex.justify-content-center.justify-content-md-end.pr-0.ant-col-xs-24.ant-col-md-12 > div > div > div > div > div > span")));
            var hasButton = (driver.FindElements(By.CssSelector("#root > div > div > div.ant-col.ant-col-order-2.d-flex.justify-content-center.justify-content-md-end.pr-0.ant-col-xs-24.ant-col-md-12 > div > div > div > div > div > button")).Count > 0);
            return hasButton;
        }
    }
}
