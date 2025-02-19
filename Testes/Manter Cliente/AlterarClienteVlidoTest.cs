// Generated by Selenium IDE
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
[TestFixture]
public class AlterarClienteVlidoTest {
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
  public void alterarClienteVlido() {
    driver.Navigate().GoToUrl("https://localhost:7245/");
    driver.Manage().Window.Size = new System.Drawing.Size(697, 728);
    Assert.That(driver.FindElement(By.LinkText("Cliente")).Text, Is.EqualTo("Cliente"));
    driver.FindElement(By.LinkText("Cliente")).Click();
    Assert.That(driver.FindElement(By.LinkText("Edit")).Text, Is.EqualTo("Edit"));
    driver.FindElement(By.LinkText("Edit")).Click();
    driver.FindElement(By.Id("Rua")).Click();
    driver.FindElement(By.Id("Rua")).SendKeys("Centro");
    driver.FindElement(By.Id("NumResidencia")).Click();
    driver.FindElement(By.Id("NumResidencia")).SendKeys("306");
    driver.FindElement(By.CssSelector(".col-md-4")).Click();
    driver.FindElement(By.Id("Telefone")).SendKeys("79998548821");
    driver.FindElement(By.CssSelector(".btn-primary")).Click();
    driver.FindElement(By.CssSelector("tr:nth-child(1) > td:nth-child(6)")).Click();
    Assert.That(driver.FindElement(By.CssSelector("tr:nth-child(1) > td:nth-child(6)")).Text, Is.EqualTo("79998548821"));
    driver.FindElement(By.CssSelector("tr:nth-child(1) > td:nth-child(11)")).Click();
    Assert.That(driver.FindElement(By.CssSelector("tr:nth-child(1) > td:nth-child(11)")).Text, Is.EqualTo("Centro"));
    driver.FindElement(By.CssSelector("tr:nth-child(1) > td:nth-child(12)")).Click();
    Assert.That(driver.FindElement(By.CssSelector("tr:nth-child(1) > td:nth-child(12)")).Text, Is.EqualTo("306"));
  }
}
