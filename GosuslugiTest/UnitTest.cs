using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Support.UI;

namespace GosuslugiTest
{
    public class Tests
    {
        public IWebDriver driver;
        private readonly By _SignButton = By.XPath("//button[text() = 'Войти']");
        private readonly By _CheckButton = By.XPath("//button[contains(text(), 'Не удаётся войти?')]");
        private readonly By _passwordRecoveryButton = By.XPath("//button[contains(text(), 'восстановления пароля')]");
        private const string _ExpectedUrl = "https://esia.gosuslugi.ru/login/recovery";


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.gosuslugi.ru");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
               
                wait.Until(ExpectedConditions.ElementToBeClickable(_SignButton)).Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(_CheckButton)).Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(_passwordRecoveryButton)).Click();   
                wait.Until(driver => driver.Url.Contains(_ExpectedUrl));
            
            Assert.IsTrue(string.Compare(_ExpectedUrl, driver.Url, StringComparison.OrdinalIgnoreCase) == 0, "The password recovery is not open");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}