using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace titan
{
    [Binding]
    public class CreateLoginSteps
    {
        private RemoteWebDriver driver;
        [Given(@"Login to Titan Url")]
        public void GivenLoginToTitanUrl()
        {
            driver = new ChromeDriver();
            driver.Url = "https://titanuat.regus.com/aspx/main/adminhome.aspx";
            Thread.Sleep(8000);
        }
        
        [Given(@"enter username")]
        public void GivenEnterUsername()
        {
            IWebElement search = driver.FindElement(By.XPath("//*[@id='i0116']"));
            search.SendKeys("Q.A@iwgplc.com");
            IWebElement enterid = driver.FindElement(By.XPath("//*[@id='idSIButton9']"));
            enterid.Click();
            Thread.Sleep(8000);
        }
        
        [Given(@"enter password")]
        public void GivenEnterPassword()
        {
          
            IWebElement enterpass = driver.FindElement(By.XPath("//*[@id='i0118']"));
            enterpass.SendKeys("cFZsDNvP9%rvTTu3");
        }
        
        [Then(@"click on login button")]
        public void ThenClickOnLoginButton()
        {
             IWebElement okbutton = driver.FindElement(By.XPath("//*[@id='idSIButton9']"));
            okbutton.Click();
            Thread.Sleep(10000);
        }
        
        [Then(@"I logout of app")]
        public void ThenILogoutOfApp()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
