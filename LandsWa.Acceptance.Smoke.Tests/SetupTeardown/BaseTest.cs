﻿using System.Reflection;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using LandsWa.Acceptance.Smoke.Tests.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using static LandsWa.Acceptance.Smoke.Tests.Helper.Enumerations;
using System.Text.RegularExpressions;

namespace LandsWa.Acceptance.Smoke.Tests.SetupTeardown
{
    [TestFixture]
    public class BaseTest
    {
        string LoginUrl = "https://walandstest.appiancloud.com/suite/";
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected IWebDriver Driver { get; private set; }

        [OneTimeSetUp]
        public void TestSuiteSetup()
        {
            Driver = GetLocalDriver(BrowserType.Chrome);
            Driver.Manage().Window.Maximize();
        }

        [SetUp]
        public virtual void SetUp()
        {
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Navigate().GoToUrl(LoginUrl);
        }

        [TearDown]
        public void TearDown()
        {
            string path = BasePage.GetFolderPathInProjectRoot("ss");
            string method = String.Join("", Regex.Unescape(TestContext.CurrentContext.Test.Name).Split('\"'));
            path = $@"{path}{method}.png";
            BasePage.TakeScreenshot(path);
        }

        [OneTimeTearDown]
        public void TestTeardown()
        {
            try
            {
                CleanUpInstances();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
            }
        }

        private IWebDriver GetLocalDriver(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    /**
                     * ChromeOptions options = new ChromeOptions();
                     * this path needs to be setup on TeamCity build agent as well - about:version
                     * options.AddArguments(@"user-data-dir=C:\Chromium\Temp\Profile\Default");
                     * driver = new ChromeDriver(options);
                     **/
                    ChromeOptions options = new ChromeOptions();
                    //options.AddArguments(@"user-data-dir=C:\Chromium\Temp\Profile\Default");
                    //Driver = new ChromeDriver(options);
                    Driver = new ChromeDriver();
                    break;
                case BrowserType.FireFox:
                    Driver = new FirefoxDriver();
                    break;
                case BrowserType.InternetExplorer:
                    Driver = new InternetExplorerDriver();
                    break;
            }
            return Driver;
        }

        public void CleanUpInstances()
        {
            if (Driver != null)
            {
                Driver.Dispose();
                Driver = null;
            }
        }
    }
}
