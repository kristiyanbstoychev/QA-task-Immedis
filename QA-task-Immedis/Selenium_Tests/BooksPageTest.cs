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
namespace BooksPageTest { 
[TestFixture]
public class BooksPageTest {
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
  public void booksPageIsDisplayed() {
    driver.Navigate().GoToUrl("https://qa-task.immedis.com/");
    driver.Manage().Window.Size = new System.Drawing.Size(1366, 728);
    driver.FindElement(By.Name("username")).Click();
    driver.FindElement(By.Name("username")).SendKeys("admin");
    driver.FindElement(By.Name("password")).Click();
    driver.FindElement(By.Name("password")).SendKeys("123456");
    driver.FindElement(By.CssSelector("a:nth-child(3) > div")).Click();
    driver.FindElement(By.XPath("/html/body/nav[2]/div/div[2]/div/button")).Click();
    driver.FindElement(By.LinkText("Books")).Click();
    Assert.That(driver.Title, Is.EqualTo("Books Screen - Library"));
    var elements = driver.FindElements(By.LinkText("Create New"));
    Assert.True(elements.Count > 0);
    var elementss = driver.FindElements(By.CssSelector(".body-content"));
    Assert.True(elementss.Count > 0);
    driver.Close();
  }
  [Test]
  public void createNewBook() {
    driver.Navigate().GoToUrl("https://qa-task.immedis.com/");
    driver.Manage().Window.Size = new System.Drawing.Size(1366, 728);
    driver.FindElement(By.Name("username")).Click();
    driver.FindElement(By.Name("username")).SendKeys("admin");
    driver.FindElement(By.Name("password")).Click();
    driver.FindElement(By.Name("password")).SendKeys("123456");
    driver.FindElement(By.CssSelector("a:nth-child(3) > div")).Click();
    driver.FindElement(By.XPath("/html/body/nav[2]/div/div[2]/div/button")).Click();
    driver.FindElement(By.LinkText("Books")).Click();
    driver.FindElement(By.LinkText("Create New")).Click();
    driver.FindElement(By.Id("Name")).Click();
    driver.FindElement(By.Id("Name")).SendKeys("testBook");
    driver.FindElement(By.Id("Author")).SendKeys("testAuthor");
    driver.FindElement(By.Id("Genre")).SendKeys("testGenre");
    driver.FindElement(By.Id("Quontity")).Click();
    driver.FindElement(By.Id("Quontity")).SendKeys("1");
    driver.FindElement(By.CssSelector(".btn")).Click();
    var elements = driver.FindElements(By.CssSelector("tr:nth-child(8) > td:nth-child(1)"));
    Assert.True(elements.Count > 0);
    driver.Close();
  }
  [Test]
  public void createNewBookWithouthName() {
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
    driver.FindElement(By.Name("username")).Click();
    driver.FindElement(By.Name("username")).SendKeys("admin");
    driver.FindElement(By.Name("password")).SendKeys("123456");
    driver.FindElement(By.CssSelector("a:nth-child(3) > div")).Click();
    driver.FindElement(By.XPath("/html/body/nav[2]/div/div[2]/div/button")).Click();
    driver.FindElement(By.LinkText("Books")).Click();
    driver.FindElement(By.LinkText("Create New")).Click();
    driver.FindElement(By.CssSelector(".btn")).Click();
    {
      var element = driver.FindElement(By.Id("Quontity-error"));
      Actions builder = new Actions(driver);
      builder.MoveToElement(element).Release().Perform();
    }
    var elements = driver.FindElements(By.Id("Quontity-error"));
    Assert.True(elements.Count > 0);
    driver.FindElement(By.Id("Quontity")).Click();
    driver.FindElement(By.Id("Quontity")).SendKeys("1");
    driver.FindElement(By.CssSelector(".btn")).Click();
    Assert.That(driver.Title, Is.EqualTo("Error - Library"));
    var elementss = driver.FindElements(By.CssSelector(".text-danger:nth-child(2)"));
    Assert.True(elementss.Count > 0);
    driver.Close();
  }
  [Test]
  public void deleteExistingBook() {
    driver.Navigate().GoToUrl("https://qa-task.immedis.com/");
    driver.Manage().Window.Size = new System.Drawing.Size(1366, 728);
    driver.FindElement(By.Name("username")).Click();
    driver.FindElement(By.Name("username")).SendKeys("admin");
    driver.FindElement(By.Name("password")).Click();
    driver.FindElement(By.Name("password")).SendKeys("123456");
    driver.FindElement(By.CssSelector("a:nth-child(3) > div")).Click();
    driver.FindElement(By.XPath("/html/body/nav[2]/div/div[2]/div/button")).Click();
    driver.FindElement(By.LinkText("Books")).Click();
    driver.FindElement(By.CssSelector("tr:nth-child(9) a:nth-child(3)")).Click();
    driver.FindElement(By.CssSelector(".btn")).Click();
    driver.Close();
  }
  [Test]
  public void editExistingBook() {
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
    driver.FindElement(By.LinkText("Books")).Click();
    driver.FindElement(By.CssSelector("tr:nth-child(8) a:nth-child(1)")).Click();
    driver.FindElement(By.Id("Name")).Click();
    driver.FindElement(By.Id("Name")).SendKeys("testBook_edited");
    driver.FindElement(By.CssSelector(".btn")).Click();
    var elements = driver.FindElements(By.CssSelector("tr:nth-child(11) > td:nth-child(1)"));
    Assert.True(elements.Count > 0);
    driver.Close();
  }
  [Test]
  public void viewExistingBook() {
    driver.Navigate().GoToUrl("https://qa-task.immedis.com/");
    driver.Manage().Window.Size = new System.Drawing.Size(1366, 728);
    driver.FindElement(By.Name("username")).Click();
    driver.FindElement(By.Name("username")).SendKeys("admin");
    driver.FindElement(By.Name("password")).SendKeys("123456");
    driver.FindElement(By.CssSelector("a:nth-child(3) > div")).Click();
    driver.FindElement(By.XPath("/html/body/nav[2]/div/div[2]/div/button")).Click();
    driver.FindElement(By.LinkText("Books")).Click();
    driver.FindElement(By.CssSelector("tr:nth-child(10) a:nth-child(2)")).Click();
    Assert.That(driver.Title, Is.EqualTo("Details - Library"));
    var elements = driver.FindElements(By.CssSelector("dd:nth-child(2)"));
    Assert.True(elements.Count > 0);
    var elementss = driver.FindElements(By.CssSelector("dd:nth-child(4)"));
    Assert.True(elementss.Count > 0);
    var elementsss = driver.FindElements(By.CssSelector("dd:nth-child(6)"));
    Assert.True(elementsss.Count > 0);
    driver.Close();
  }
}
}