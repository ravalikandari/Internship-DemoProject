using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            //LAUNCH THE BROWSER//
            IWebDriver driver = new ChromeDriver(@"C:\Users\Nitin\Downloads");
            //ENTER THE URL//
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2fTimeMaterial");

            //LOCATE THE USERNAME TEXTBOX AND ENTER THE USERNAME//
            IWebElement Username = driver.FindElement(By.XPath("//*[@id='UserName']"));
            Username.SendKeys("Hari");

            //LOCATE THE PASSWORD TEXTBOX AND ENTER THE PASSWORD//
            IWebElement Password = driver.FindElement(By.Id("Password"));
            Password.SendKeys("123123");

            //CLICK ON LOGIN BUTTON//
            IWebElement Login = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            Login.Click();

            //CHECK WHERE THE DISPLAYED PAGE IS CORRECT OR NOT//
            IWebElement Hellohari = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));
            if (Hellohari.Text.ToLower() == "Hellohari")
            {
                Console.WriteLine("The login page is sucessfull");
            }
            else
            {
                Console.WriteLine("the login pge is unsucessfull");
            }

            //ADMINSTRATION TAB
            IWebElement Administration = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            Administration.Click();

            //CLICK ON TIMES & MATERIALS PAGE//
            IWebElement Tp = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            Tp.Click();

            //CLICK ON CREATE NEW //
            IWebElement Createnew = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            Createnew.Click();

            //TYPE CODE SEL 
            IWebElement Material = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]"));
            Material.Click();

            //Enter the code//
            IWebElement Code = driver.FindElement(By.XPath("//*[@id='Code']"));
            Code.SendKeys("poppy");

            //Enter the description//
            IWebElement Description = driver.FindElement(By.XPath("//*[@id='Description']"));
            Description.SendKeys("poppy poppy");

            IWebElement Priceperunit = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            Priceperunit.SendKeys("100000000");

            //Save//
            IWebElement Save = driver.FindElement(By.XPath("//*[@id='SaveButton']"));
            Save.Click();

            // check if the time & material page is created//
            System.Threading.Thread.Sleep(1500);
            //IWebElement ForwardButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/ul/li[5]/span"));//
            IWebElement ForwardButton = driver.FindElement(By.XPath("//*[@title='Go to the last page']"));
            ForwardButton.Click();
            if (driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr/td[1]")).Text == "poppy")
            {
                Console.WriteLine("T&P created");
            }
                else
          {
                Console.WriteLine("T&P not created");

            }

//-----------------------

            // For EditingTrail 123 T&M page//
            IWebElement Edit = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[3]/td[5]/a[1]"));
            Edit.Click();

            //editing values//
            IWebElement Code1 = driver.FindElement(By.XPath("//*[@id='Code']"));
            Code1.Clear();
            Code1.SendKeys("IM editing");

            //enter the Description//
            IWebElement Description1 = driver.FindElement(By.XPath("//*[@id='Description']"));
            Description1.Clear();
            Description1.SendKeys("editing the description");

            //enter the Price//
            IWebElement Price1 = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            Price1.Clear();
            IWebElement Price2 = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            Price2.Clear();
            IWebElement Price3 = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            System.Threading.Thread.Sleep(1500);
            Price3.SendKeys("123456");
        

            // save the eited page//
            IWebElement Save1 = driver.FindElement(By.XPath("//*[@id='SaveButton']"));
            Save1.Click();

            System.Threading.Thread.Sleep(1500);
            IWebElement ForwardButton1 = driver.FindElement(By.XPath("//*[@title='Go to the last page']"));
            ForwardButton1.Click();
            if (driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr/td[1]")).Text == "IM editing")
            {
                Console.WriteLine("editedT&P created");
            }
            else
            {
                Console.WriteLine("editedT&P not created");

            }


            // for deleting code123 on T&M page
            IWebElement Delete = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[6]/td[1]"));
            Delete.Click();

            //clicking popup ok//
            String alart = driver.SwitchTo().Alert().Text;
            Console.WriteLine(alart);
            if (alart == "Are you sure you want to delete this record?")
            {
                driver.SwitchTo().Alert().Accept();
                Console.WriteLine("deleted sucessful");
            }
            else
            {
                Console.WriteLine("deleted unsucessful");

            }
        }
    }
}
