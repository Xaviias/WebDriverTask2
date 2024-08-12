using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverTask2;
using System;

namespace Tests
{
    public class PastebinTests
    {
        private IWebDriver _driver;
        private PastebinHomePage _pastebinHomePage;
        private string pasteName;
        private string code;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _pastebinHomePage = new PastebinHomePage(_driver);
            pasteName = "how to gain dominance among developers";
            code = @"git config --global user.name ""New Sheriff in Town""
git reset $(git commit-tree HEAD^{tree} -m ""Legacy code"")
git push origin master --force";
        }

        [Test]
        public void CreateNewPasteTest()
        {
            _pastebinHomePage.NavigateToPage();

            _pastebinHomePage.EnterPasteCode(code);
            _pastebinHomePage.SelectPasteExpiration();
            _pastebinHomePage.SelectSyntaxHighlight();
            _pastebinHomePage.EnterPasteName(pasteName);
            _pastebinHomePage.CreateNewPaste();

            Assert.IsTrue(_driver.Title.Contains(pasteName));
        }

        [Test]
        public void VerifySyntaxHighlightingTest()
        {
            CreateNewPasteTest();

            IWebElement syntaxElement = _driver.FindElement(By.CssSelector(".left a[href='/archive/bash']"));
            Assert.IsTrue(syntaxElement.Displayed);
        }

        [Test]
        public void VerifyCodeContentTest()
        {
            CreateNewPasteTest();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IWebElement codeContentRaw = _driver.FindElement(By.XPath("//a[@class='btn -small']"));
            codeContentRaw.Click();

            IWebElement codeDescription = _driver.FindElement(By.TagName("pre"));
            Assert.That(codeDescription.Text, Is.EqualTo(code));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

    }
}
