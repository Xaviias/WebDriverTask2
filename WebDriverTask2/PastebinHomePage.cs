using OpenQA.Selenium;
using SeleniumExtras.PageObjects; 

namespace WebDriverTask2
{
    public class PastebinHomePage
    {
        private readonly IWebDriver _driver;

        private const string url = "https://pastebin.com/";

        // Locators
        [FindsBy(How = How.Id, Using = "postform-text")]
        private IWebElement NewPasteTextArea { get; set; }

        [FindsBy(How = How.Id, Using = "select2-postform-expiration-container")]
        private IWebElement ExpirationDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[contains(text(),'10 Minutes')]")]
        private IWebElement ExpirationOption { get; set; }

        [FindsBy(How = How.Id, Using = "select2-postform-format-container")]
        private IWebElement SyntaxDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[contains(text(),'Bash')]")]
        private IWebElement SyntaxOption { get; set; }

        [FindsBy(How = How.Id, Using = "postform-name")]
        private IWebElement PasteNameTitleField { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text()='Create New Paste']")]
        private IWebElement CreateNewPasteButton { get; set; }

        public PastebinHomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void NavigateToPage()
        {
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
        }

        public void EnterPasteCode(string code)
        {
            NewPasteTextArea.SendKeys(code);
        }

        public void SelectPasteExpiration()
        {
            ExpirationDropdown.Click();
            ExpirationOption.Click();
        }

        public void SelectSyntaxHighlight()
        {
            SyntaxDropdown.Click();
            SyntaxOption.Click();
        }

        public void EnterPasteName(string name)
        {
            PasteNameTitleField.SendKeys(name);
        }

        public void CreateNewPaste()
        {
            CreateNewPasteButton.Click();
        }
    }
}