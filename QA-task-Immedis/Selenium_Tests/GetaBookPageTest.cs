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
using NUnit.Framework;

namespace GetaBookPageTest { 
[TestFixture]
public class GetaBookPageTest {
  private IWebDriver driver;
  public IDictionary<string, object> vars {get; private set;}
  private IJavaScriptExecutor js;
  [SetUp]
  public void SetUp() {
    driver = new ChromeDriver();
    js = (IJavaScriptExecutor)driver;
    vars = new Dictionary<string, object>();
  }
  [TearDown]
  protected void TearDown() {
    driver.Quit();
  }
  [Test]
  public void createaBookRequest() {
    driver.Navigate().GoToUrl("https://qa-task.immedis.com/");
    driver.Manage().Window.Size = new System.Drawing.Size(1366, 728);
    driver.FindElement(By.Name("username")).Click();
    driver.FindElement(By.Name("username")).Click();
    {
      var element = driver.FindElement(By.Name("username"));
      Actions builder = new Actions(driver);
      builder.DoubleClick(element).Perform();
    }
    driver.FindElement(By.Name("username")).Click();
    driver.FindElement(By.Name("username")).SendKeys("admin");
    driver.FindElement(By.Name("password")).Click();
    driver.FindElement(By.Name("password")).SendKeys("123456");
    driver.FindElement(By.CssSelector("a:nth-child(3) > div")).Click();
    driver.FindElement(By.XPath("/html/body/nav[2]/div/div[2]/div/button")).Click();
    driver.FindElement(By.LinkText("Get a book")).Click();
    driver.FindElement(By.LinkText("Create New")).Click();
    driver.FindElement(By.Id("UserId")).Click();
    {
      var dropdown = driver.FindElement(By.Id("UserId"));
      dropdown.FindElement(By.XPath("//option[. = 'testUser']")).Click();
    }
    driver.FindElement(By.Id("UserId")).Click();
    driver.FindElement(By.Id("BookId")).Click();
    {
      var dropdown = driver.FindElement(By.Id("BookId"));
      dropdown.FindElement(By.XPath("//option[. = 'testAuthor']")).Click();
    }
    driver.FindElement(By.Id("BookId")).Click();
    driver.FindElement(By.CssSelector(".btn")).Click();
    var elements = driver.FindElements(By.CssSelector("tr:nth-child(7) > td:nth-child(2)"));
    Assert.True(elements.Count > 0);
    var elementss = driver.FindElements(By.CssSelector("tr:nth-child(7) > td:nth-child(3)"));
    Assert.True(elementss.Count > 0);
    driver.Close();
  }
  [Test]
  public void deleteExistingBookRequest() {
    driver.Navigate().GoToUrl("https://qa-task.immedis.com/");
    driver.Manage().Window.Size = new System.Drawing.Size(1366, 728);
    driver.FindElement(By.Name("username")).Click();
    driver.FindElement(By.Name("username")).SendKeys("admin");
    driver.FindElement(By.Name("password")).Click();
    driver.FindElement(By.Name("password")).SendKeys("123456");
    driver.FindElement(By.CssSelector("a:nth-child(3) > div")).Click();
    driver.FindElement(By.XPath("/html/body/nav[2]/div/div[2]/div/button")).Click();
    driver.FindElement(By.LinkText("Get a book")).Click();
    driver.FindElement(By.CssSelector("tr:nth-child(7) a:nth-child(3)")).Click();
    driver.FindElement(By.CssSelector(".btn")).Click();
    driver.Close();
  }
  [Test]
  public void editExistingBookRequest() {
    driver.Navigate().GoToUrl("https://qa-task.immedis.com/");
    driver.Manage().Window.Size = new System.Drawing.Size(1366, 728);
    driver.FindElement(By.Name("username")).Click();
    driver.FindElement(By.Name("username")).SendKeys("admin");
    driver.FindElement(By.Name("password")).Click();
    driver.FindElement(By.Name("password")).SendKeys("123456");
    driver.FindElement(By.CssSelector("a:nth-child(3) > div")).Click();
    driver.FindElement(By.XPath("/html/body/nav[2]/div/div[2]/div/button")).Click();
    driver.FindElement(By.LinkText("Get a book")).Click();
    driver.FindElement(By.CssSelector("tr:nth-child(7) a:nth-child(1)")).Click();
    driver.FindElement(By.Id("UserId")).Click();
    {
      var dropdown = driver.FindElement(By.Id("UserId"));
      dropdown.FindElement(By.XPath("//option[. = 'New user 2']")).Click();
    }
    driver.FindElement(By.CssSelector(".btn")).Click();
    var elements = driver.FindElements(By.CssSelector("tr:nth-child(7) > td:nth-child(2)"));
    Assert.True(elements.Count > 0);
    var elementss = driver.FindElements(By.CssSelector("tr:nth-child(7) > td:nth-child(3)"));
    Assert.True(elementss.Count > 0);
    driver.Close();
  }
  [Test]
  public void getabookpageisdisplayed() {
    driver.Navigate().GoToUrl("https://qa-task.immedis.com/");
    driver.Manage().Window.Size = new System.Drawing.Size(1366, 728);
    driver.FindElement(By.Name("username")).Click();
    driver.FindElement(By.Name("username")).SendKeys("admin");
    driver.FindElement(By.Name("password")).Click();
    driver.FindElement(By.Name("password")).SendKeys("123456");
    driver.FindElement(By.CssSelector("a:nth-child(3) > div")).Click();
    driver.FindElement(By.XPath("/html/body/nav[2]/div/div[2]/div/button")).Click();
    driver.FindElement(By.LinkText("Get a book")).Click();
    Assert.That(driver.Title, Is.EqualTo("Books taken by the users - Library"));
    var elements = driver.FindElements(By.LinkText("Create New"));
    Assert.True(elements.Count > 0);
    var elementss = driver.FindElements(By.CssSelector(".body-content"));
    Assert.True(elementss.Count > 0);
    driver.Close();
  }
}
}