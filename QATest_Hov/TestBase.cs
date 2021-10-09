using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
                                                             //In just one run the 4 test will execute to run
namespace QATest_Hov
{
	class TestBase
	{
		protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments(new string[] { "--headless", "--window-size=1920,1080" });     // headless = no UI shown. It makes the running faster without having lag to your components
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(300);
            BasicActions.GoToUrl(driver);                                                       // calling the url from the different class. To open the REITScreener website
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
