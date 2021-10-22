using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace titan
{
    [TestFixture]
   public class extentreportdemo
    {
        IWebDriver driver;
        ExtentReports extent=null;
        ExtentTest test = null;

        [OneTimeSetUp]
        public void extentstart()
        {
            extent = new ExtentReports();
            var htmlreporter = new ExtentHtmlReporter(@"C:\Users\Ali\source\repos\titan\titan\report1\extentreport.html");
            extent.AttachReporter(htmlreporter);

        }
        [OneTimeTearDown]
        public void extentclose()
        {
            extent.Flush();

        }
        [Test]
        public void TestMethod1()
        {
            test=extent.CreateTest("TestMethod1").Info("TEST Start");
            driver = new ChromeDriver();
            test.Log(Status.Info,"chrome browser launch");
            driver.Url = "https://titanuat.regus.com/aspx/main/adminhome.aspx";
            Thread.Sleep(8000);
            test.Log(Status.Info, "open titan website");
            IWebElement search = driver.FindElement(By.XPath("//*[@id='i0116']"));
            search.SendKeys("Q.A@iwgplc.com");
            test.Log(Status.Info, "email is entered");



            IWebElement enterid = driver.FindElement(By.XPath("//*[@id='idSIButton9']"));
            enterid.Click();
            Thread.Sleep(8000);

            IWebElement enterpass = driver.FindElement(By.XPath("//*[@id='i0118']"));
            enterpass.SendKeys("cFZsDNvP9%rvTTu3");
            test.Log(Status.Info, "password is enter");

            IWebElement okbutton = driver.FindElement(By.XPath("//*[@id='idSIButton9']"));
            okbutton.Click();
            test.Log(Status.Info, "signin to account ");
            Thread.Sleep(10000);

            test.Log(Status.Info, "TestMethod1 passed");


        }

   }
}
