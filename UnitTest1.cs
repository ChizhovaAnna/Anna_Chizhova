﻿using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace selenium_h_w
{
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
        
        private string name = Convert.ToString(5);
        private const string _login = "Admin";
        private const string _password = "admin123";
        //private const string _user_password = "";
        


        [SetUp]
        public void Setup()
        {

            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");

        }

        [Test]
        public void Test1()
        {
            

            string _username = "abcdf"+ Convert.ToString(rnd.Next());
            string _user_password = "FGHJg5672jv";//+ _username;

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

            var save = driver.FindElement(_saveButton);
            save.Click();

            Thread.Sleep(50000);
            var search = driver.FindElement(_searchInput);

            search.SendKeys(_username);
            Thread.Sleep(10000);

            var search_button = driver.FindElement(_searchButton);
            search_button.Click();
            Thread.Sleep(10000);

            if (this.driver.PageSource.Contains(_username));
           
            var reset = driver.FindElement(_resetButton);
            reset.Click();
            Thread.Sleep(10000);

            if (this.driver.PageSource.Contains(_username)) ;
              
            string href = this.driver.FindElement(By.LinkText(_username)).GetAttribute("href");
            string[] Id = href.Split('=');
            string id = Id[1];
            this.driver.FindElement(By.Id("ohrmList_chkSelectRecord_" + id)).Click();
            Thread.Sleep(10000);

            var delete = driver.FindElement(_deleteButton);
            delete.Click();
            Thread.Sleep(10000);

            var delete_ok = driver.FindElement(_deleteOkButton);
            delete_ok.Click();
            Thread.Sleep(10000);

            if (this.driver.PageSource.Contains(_username)) ;
              

            //Assert.Pass();
        }
        
    }
}
