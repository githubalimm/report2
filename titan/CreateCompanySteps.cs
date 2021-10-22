using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace titan
{
    [Binding]
    public class CreateCompanySteps
    {
      IWebDriver driver;
        public string homecenter = "2818";
        [Given(@"Login to Titan Url And enter user name and password")]
        public void GivenLoginToTitanUrlAndEnterUserNameAndPassword()
        {
            Thread.Sleep(8000);
            driver = new ChromeDriver();
            driver.Url = "https://titanreleasetest.regus.com/aspx/main/adminhome.aspx";
            Thread.Sleep(8000);
            IWebElement search = driver.FindElement(By.XPath("//*[@id='i0116']"));
            search.SendKeys("Q.A@iwgplc.com");
           



            IWebElement enterid = driver.FindElement(By.XPath("//*[@id='idSIButton9']"));
            enterid.Click();
            Thread.Sleep(8000);

            IWebElement enterpass = driver.FindElement(By.XPath("//*[@id='i0118']"));
            enterpass.SendKeys("cFZsDNvP9%rvTTu3");


            IWebElement okbutton = driver.FindElement(By.XPath("//*[@id='idSIButton9']"));
            okbutton.Click();
            Thread.Sleep(10000);
        }
        
        [Given(@"Search for test Company And click on Add new Company")]
        public void GivenSearchForTestCompanyAndClickOnAddNewCompany()
        {

            IWebElement headerimg = driver.FindElement(By.XPath("//div[@class='PageHeader']//img[3]"));

            Actions action1 = new Actions(driver);
            action1.MoveToElement(headerimg).Perform();
            Thread.Sleep(5000);

                 //  FOR FRAME CODE //

            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@src='about:blank']")));

            driver.FindElement(By.XPath("//td[normalize-space()='Client Search']")).Click();
        
                 //  USE TO COME OUT FROM THE FRAME //

            driver.SwitchTo().DefaultContent();


            IWebElement entercompany = driver.FindElement(By.XPath("//input[@id='txtCompanyName']"));
            entercompany.SendKeys("RTA-TEST2");
            Thread.Sleep(2000);
            IWebElement searchcom = driver.FindElement(By.XPath("//input[@id='ibtnSearchCompanies']"));
            searchcom.Click();
            Thread.Sleep(5000);
            IWebElement createcom = driver.FindElement(By.XPath("//input[@id='ibtnAddCompany']"));
            createcom.Click();
            ////////////// 


        }

        [When(@"Enter all the Company mandatory field and save it")]
        public void WhenEnterAllTheCompanyMandatoryFieldAndSaveIt()
        {
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@id='ifEdit']")));


            IWebElement newnamecom = driver.FindElement(By.XPath("//input[@id='bfcMain_txtCompanyName']"));
            Random r = new Random();

            string RTATEST = string.Format($"RTA-TEST{r.Next(1000)}");

            newnamecom.SendKeys(RTATEST);

            Thread.Sleep(5000);
            if (homecenter == "2818")
            {

                IWebElement selecthome = driver.FindElement(By.XPath("//select[@id='bfcMain_ddlCentre']"));
                SelectElement os = new SelectElement(selecthome);
                os.SelectByValue(homecenter);
                Thread.Sleep(5000);
                IWebElement customertype = driver.FindElement(By.XPath("//select[@id='bfcMain_ddlCustomerType']"));
                SelectElement cp = new SelectElement(customertype);
                cp.SelectByValue("100");
                Thread.Sleep(5000);
                IWebElement selectprice = driver.FindElement(By.XPath("//select[@id='bfcMain_ddlClassification']"));
                SelectElement sp = new SelectElement(selectprice);
                sp.SelectByValue("199");
                Thread.Sleep(5000);
            }
            else
            {
                IWebElement selecthome = driver.FindElement(By.XPath("//select[@id='bfcMain_ddlCentre']"));
                SelectElement os = new SelectElement(selecthome);
                os.SelectByValue("4011");
                Thread.Sleep(5000);

            }
            //IWebElement selecthome = driver.FindElement(By.XPath("//select[@id='bfcMain_ddlCentre']"));
            //SelectElement os = new SelectElement(selecthome);
            //os.SelectByValue("827");
            //Thread.Sleep(5000);


            IWebElement enteraddress = driver.FindElement(By.XPath("//input[@id='bfcMain_ucCompanyAddress_txtAddress1']"));
            enteraddress.SendKeys("street 7d");
            Thread.Sleep(5000);
            IWebElement selectcode = driver.FindElement(By.XPath("//select[@id='bfcMain_ddlCountryDialCodes']"));
            SelectElement sc = new SelectElement(selectcode);
            sc.SelectByValue("611");
            IWebElement enternum = driver.FindElement(By.XPath("//input[@id='bfcMain_txtPhone']"));
            enternum.SendKeys("2547896584");
            Thread.Sleep(5000);
            IWebElement entercity = driver.FindElement(By.XPath("//input[@id='bfcMain_ucCompanyAddress_txtCity']"));
            entercity.SendKeys("torontoss");
            Thread.Sleep(5000);
            IWebElement zipcode = driver.FindElement(By.XPath("//input[@id='bfcMain_ucCompanyAddress_txtZip']"));
            zipcode.SendKeys("MI-456");
            Thread.Sleep(7000);
            IWebElement selectcountry = driver.FindElement(By.XPath("//select[@id='bfcMain_ucCompanyAddress_ddlCountry']"));
            SelectElement sel = new SelectElement(selectcountry);
            sel.SelectByValue("611");
            Thread.Sleep(11000);
            IWebElement enterstate = driver.FindElement(By.XPath("//select[@id='bfcMain_ucCompanyAddress_ddlState']"));
            SelectElement stt = new SelectElement(enterstate);
            stt.SelectByValue("1147");
            Thread.Sleep(5000);

            IWebElement savebutton = driver.FindElement(By.XPath("//input[@id='bfcMain_iBtnUpdate']"));
            savebutton.Click();
            Thread.Sleep(5000);
            IWebElement copymembership = driver.FindElement(By.XPath("//span[@id='bfcMain_lblCompanyRef']"));
            string text = copymembership.Text;
            Console.WriteLine("reference is " + text);
            Thread.Sleep(5000);
        }
        
        [When(@"Take the company reference number and Add contact")]
        public void WhenTakeTheCompanyReferenceNumberAndAddContact()
        {
            //  add new contact
            IWebElement addnewcontact = driver.FindElement(By.XPath("//a[normalize-space()='Add New Contact']"));
            addnewcontact.Click();
            Thread.Sleep(5000);

            IWebElement enterfirstnam = driver.FindElement(By.XPath("//input[@id='bfcMain_txtFirstName']"));
            // char[] letter = "qwertyuioplkjhgfdsa".ToCharArray();
            Random ran = new Random();

            String b = "abcdefghijklmnopqrstuvwxyz";

            int length = 3;

            String random = "";

            for (int i = 0; i < length; i++)
            {
                int a = ran.Next(26);
                random = random + b.ElementAt(a);
            }




            //string test = string.Format($"TEST{r.Next(100)}");
            enterfirstnam.SendKeys("test" + random);
            Thread.Sleep(5000);
            IWebElement entersecondnam = driver.FindElement(By.XPath("//input[@id='bfcMain_txtLastName']"));
            // string test1 = string.Format($"TEST{r.Next(100)}");
            entersecondnam.SendKeys("test" + random);
            Thread.Sleep(2000);

            IWebElement gendermale = driver.FindElement(By.XPath("//input[@id='bfcMain_radGenderMale']"));
            //IWebElement genderfemale = driver.FindElement(By.XPath("//input[@id='bfcMain_radGenderFemale']"));
            gendermale.Click();

            Thread.Sleep(2000);

            IWebElement entercity1 = driver.FindElement(By.XPath("//input[@id='bfcMain_ucContactAddress_txtAddress1']"));
            entercity1.SendKeys("torontoss");
            Thread.Sleep(2000);

            IWebElement enteraddress1 = driver.FindElement(By.XPath("//input[@id='bfcMain_ucContactAddress_txtCity']"));
            enteraddress1.SendKeys("street 7d");
            Thread.Sleep(5000);
            IWebElement zipcode1 = driver.FindElement(By.XPath("//input[@id='bfcMain_ucContactAddress_txtZip']"));
            zipcode1.SendKeys("MI-456");
            Thread.Sleep(5000);
            IWebElement selectcountry1 = driver.FindElement(By.XPath("//select[@id='bfcMain_ucContactAddress_ddlCountry']"));
            SelectElement sel1 = new SelectElement(selectcountry1);
            sel1.SelectByValue("611");
            Thread.Sleep(14000);
            IWebElement state = driver.FindElement(By.XPath("//select[@id='bfcMain_ucContactAddress_ddlState']"));
            SelectElement aa = new SelectElement(state);
            aa.SelectByValue("1147");
            Thread.Sleep(5000);
            IWebElement copycustomer = driver.FindElement(By.XPath("//a[normalize-space()='Copy from Company Details']"));
            copycustomer.Click();
            Thread.Sleep(5000);
            //////////////////////////////////////////////

            IWebElement selectcode1 = driver.FindElement(By.XPath("//select[@id='bfcMain_ddlCountryDialCodes']"));
            SelectElement sc1 = new SelectElement(selectcode1);
            sc1.SelectByValue("611");
            Thread.Sleep(2000);
            IWebElement enternum1 = driver.FindElement(By.XPath("//input[@id='bfcMain_txtPhone']"));
            enternum1.SendKeys("2547896584");
            Thread.Sleep(5000);

            IWebElement email = driver.FindElement(By.XPath("//input[@id='bfcMain_txtEmail']"));
            Random r3 = new Random();

            string em = string.Format($"rta{r3.Next(100)}@zetmail.com");
            //string a = "@zetmail.com";
            email.SendKeys(em);
            Thread.Sleep(2000);
            IWebElement save = driver.FindElement(By.XPath("//input[@id='bfcMain_iBtnUpdate']"));
            save.Click();
            Thread.Sleep(5000);
        }
        
        [Then(@"Take the contact ID")]
        public void ThenTakeTheContactID()
        {
            IWebElement copymembership1 = driver.FindElement(By.XPath("//span[@id='bfcMain_lblMembershipNumber']"));
            string ship = copymembership1.Text;
            Console.WriteLine("membership reference is " + ship);


            driver.SwitchTo().DefaultContent();

            //driver.Quit();
            Console.WriteLine("Datasave");
        }
        //[BeforeScenario]

        //public void beforescenario()
        //{
        //    Console.WriteLine("before scenario");


        //}

        //[AfterScenario]
        //public void afterscenario()

        //{

        //}


    }




}
