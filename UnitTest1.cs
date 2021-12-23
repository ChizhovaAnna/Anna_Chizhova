using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace selenium_h_w
{
    [TestFixture()]
    public class Tests
    {
        private IWebDriver driver;
        private readonly By _loginInputButton = By.XPath("//input[@name='txtUsername']");
        private readonly By _passwordInputButton = By.XPath("//input[@name='txtPassword']");
        private readonly By _submitButton = By.XPath("//input[@type='submit']");
        private readonly By _AdminButton = By.XPath("//b[text()='Admin']");
        private readonly By _AddButton = By.XPath("//input[@name='btnAdd']");
        private readonly By _nameInput = By.XPath("//input[@name='systemUser[employeeName][empName]']");
        private readonly By _usernameInput = By.XPath("//input[@name='systemUser[userName]']");
        private readonly By _userPasswordInput = By.XPath("//input[@name='systemUser[password]']");
        private readonly By _userPasswordConfirmInput = By.XPath("//input[@name='systemUser[confirmPassword]']");
        private readonly By _saveButton = By.XPath("//input[@id='btnSave']");
        private readonly By _searchInput = By.XPath("//input[@name='searchSystemUser[userName]']");
        private readonly By _searchButton = By.XPath("//input[@name='_search']");
        private readonly By _resetButton = By.XPath("//input[@name='_reset']");
        private readonly By _deleteButton = By.XPath("//input[@name='btnDelete']");
        private readonly By _deleteOkButton = By.XPath("//input[@id='dialogDeleteBtn']");
        Random rnd = new Random();
        //string _username = "abcdf"+ Convert.ToString(rnd.Next());





        
        
        private string name = Convert.ToString(5);
        private const string _login = "Admin";
        private const string _password = "admin123";
        //private const string _user_password = "";
        


        [SetUp]
        public void Setup()
        {

            

        }

        [Test]
        public void Test1()
        {
            string _username = "abcdfk";
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            int result;
            
            string _user_password = "fgcv344fggFCC4552";//+ _username;

            var login = driver.FindElement(_loginInputButton);
            login.SendKeys(_login);

            var password = driver.FindElement(_passwordInputButton);
            password.SendKeys(_password);

            var submit = driver.FindElement(_submitButton);
            submit.Click();

            var admin = driver.FindElement(_AdminButton);
            admin.Click();

            var add = driver.FindElement(_AddButton);
            add.Click();

            var name = driver.FindElement(_nameInput);
            name.SendKeys("Odis Adalwin");

            var username = driver.FindElement(_usernameInput);
            username.SendKeys(_username);

            var user_password = driver.FindElement(_userPasswordInput);
            user_password.SendKeys(_user_password);

            var user_password_confirm = driver.FindElement(_userPasswordConfirmInput);
            user_password_confirm.SendKeys(_user_password);

            while (driver.Url != "https://opensource-demo.orangehrmlive.com/index.php/admin/viewSystemUsers") {

                var save = driver.FindElement(_saveButton);
                save.Click();
                Thread.Sleep(1000);

            }
            var search = driver.FindElement(_searchInput);

            search.SendKeys(_username);

            var search_button = driver.FindElement(_searchButton);
            search_button.Click();

            if (this.driver.PageSource.Contains(_username))
            {
                result = 1; 
            }
            else
            {
                result = 0;
            }
            Assert.AreEqual(result, 1);
            
        }

        [Test]
        public void Test2()
        {
            var reset = driver.FindElement(_resetButton);
            reset.Click();
            string _username = "abcdfk";
            int result;

            if (this.driver.PageSource.Contains(_username))
            {
                result = 1;
            }
            else
            {
                result = 0;
            }
            Assert.AreEqual(result, 1);
            

        }
        [Test]
        public void Test3()
        {
            int result;
            string _username = "abcdfk";
            string href = this.driver.FindElement(By.LinkText(_username)).GetAttribute("href");
            string[] Id = href.Split('=');
            string id = Id[1];
            this.driver.FindElement(By.Id("ohrmList_chkSelectRecord_" + id)).Click();

            var delete = driver.FindElement(_deleteButton);
            delete.Click();

            var delete_ok = driver.FindElement(_deleteOkButton);
            delete_ok.Click();

            if (this.driver.PageSource.Contains(_username))
            {
                result = 0;
            }
            else
            {
                result = 1;
            }

            driver.Quit();
            Assert.AreEqual(result, 1);
        }


    }
   
}
