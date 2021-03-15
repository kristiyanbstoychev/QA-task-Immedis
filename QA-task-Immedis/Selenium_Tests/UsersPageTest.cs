using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;


namespace UsersPageTest
{
    [TestFixture]
    public class UsersPageTest
    {
        private IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }
        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }
        [Test]
        public void succesfullLogIn()
        {
            driver.Navigate().GoToUrl("https://qa-task.immedis.com/");
            driver.Manage().Window.Size = new System.Drawing.Size(1366, 728);
            driver.FindElement(By.Name("username")).Click();
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).Click();
            driver.FindElement(By.Name("password")).SendKeys("123456");
            driver.FindElement(By.CssSelector("a:nth-child(3) > div")).Click();
            driver.Close();
        }
        [Test]
        public void createNewUserWithouthName()
        {
           
            
            driver.Navigate().GoToUrl("https://qa-task.immedis.com/");
            driver.Manage().Window.Size = new System.Drawing.Size(1366, 728);
            driver.FindElement(By.Name("username")).Click();
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("123456");
            driver.FindElement(By.CssSelector("a:nth-child(3) > div")).Click();
            driver.FindElement(By.XPath("/html/body/nav[2]/div/div[2]/div/button")).Click();
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.FindElement(By.CssSelector(".btn")).Click();
            Assert.That(driver.Title, Is.EqualTo("Error - Library"));
            var elements = driver.FindElements(By.CssSelector(".text-danger:nth-child(2)"));
            Assert.True(elements.Count > 0);
            driver.Close();
        }
        [Test]
        public void createNewUser()
        {
            driver.Navigate().GoToUrl("https://qa-task.immedis.com/");
            driver.Manage().Window.Size = new System.Drawing.Size(1366, 728);
            driver.FindElement(By.Name("username")).Click();
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("123456");
            driver.FindElement(By.CssSelector("a:nth-child(3) > div")).Click();
            driver.FindElement(By.XPath("/html/body/nav[2]/div/div[2]/div/button")).Click();
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.FindElement(By.Id("Name")).Click();
            driver.FindElement(By.Id("Name")).SendKeys("testUser");
            driver.FindElement(By.CssSelector(".form-group:nth-child(1)")).Click();
            driver.FindElement(By.CssSelector(".btn")).Click();
            var elements = driver.FindElements(By.CssSelector("tr:nth-child(17) > td:nth-child(1)"));
            Assert.True(elements.Count > 0);
            driver.Close();
        }
        [Test]
        public void editExistingUser()
        {
            driver.Navigate().GoToUrl("https://qa-task.immedis.com/");
            driver.Manage().Window.Size = new System.Drawing.Size(1366, 728);
            driver.FindElement(By.Name("username")).Click();
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("123456");
            driver.FindElement(By.CssSelector("a:nth-child(3) > div")).Click();
            driver.FindElement(By.XPath("/html/body/nav[2]/div/div[2]/div/button")).Click();
            driver.FindElement(By.CssSelector("tr:nth-child(17) a:nth-child(1)")).Click();
            driver.Close();
        }
        [Test]
        public void usersPageDispyedCorrectly()
        {
            driver.Navigate().GoToUrl("https://qa-task.immedis.com/");
            driver.Manage().Window.Size = new System.Drawing.Size(1366, 728);
            driver.FindElement(By.Name("username")).Click();
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("123456");
            driver.FindElement(By.CssSelector("a:nth-child(3) > div")).Click();
            driver.FindElement(By.XPath("/html/body/nav[2]/div/div[2]/div/button")).Click();
            driver.FindElement(By.LinkText("Users")).Click();
            Assert.That(driver.Title, Is.EqualTo("Users Screen - Library"));
            var elements = driver.FindElements(By.CssSelector(".body-content"));
            Assert.True(elements.Count > 0);
            var elementss = driver.FindElements(By.LinkText("Create New"));
            Assert.True(elementss.Count > 0);
            driver.Close();
        }
        [Test]
        public void viewExistingUser()
        {
            driver.Navigate().GoToUrl("https://qa-task.immedis.com/");
            driver.Manage().Window.Size = new System.Drawing.Size(1366, 728);
            driver.FindElement(By.Name("username")).Click();
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("123456");
            driver.FindElement(By.CssSelector("a:nth-child(3) > div")).Click();
            driver.FindElement(By.XPath("/html/body/nav[2]/div/div[2]/div/button")).Click();
            driver.FindElement(By.CssSelector("tr:nth-child(17) a:nth-child(2)")).Click();
            Assert.That(driver.Title, Is.EqualTo("Details - Library"));
            var elements = driver.FindElements(By.CssSelector("h2"));
            Assert.True(elements.Count > 0);
            var elementss = driver.FindElements(By.CssSelector("dd"));
            Assert.True(elementss.Count > 0);
            driver.FindElement(By.CssSelector("p")).Click();
            driver.Close();
        }
    }

}