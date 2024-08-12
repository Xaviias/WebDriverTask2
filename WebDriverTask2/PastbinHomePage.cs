using OpenQA.Selenium;

namespace WebDriverTask2
{
    public class PastebinHomePage
    {
        private readonly IWebDriver _driver;

        private const string url = "https://pastebin.com/";

        private readonly By newPasteTextArea = By.Id("postform-text");
        private readonly By expirationDropdown = By.Id("select2-postform-expiration-container");
        private readonly By expirationOption = By.XPath("//li[contains(text(),'10 Minutes')]");
        private readonly By syntaxDropdown = By.Id("select2-postform-format-container");
        private readonly By syntaxOption = By.XPath("//li[contains(text(),'Bash')]");
        private readonly By pasteNameTitleField = By.Id("postform-name");
        private readonly By createNewPasteButton = By.XPath("//button[text()='Create New Paste']");

        public PastebinHomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateToPage()
        {
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
        }

        public void EnterPasteCode(string code)
        {
            _driver.FindElement(newPasteTextArea).SendKeys(code);
        }

        public void SelectPasteExpiration()
        {
            _driver.FindElement(expirationDropdown).Click();
            _driver.FindElement(expirationOption).Click();
        }

        public void SelectSyntaxHighlight()
        {
            _driver.FindElement(syntaxDropdown).Click();
            _driver.FindElement(syntaxOption).Click();
        }

        public void EnterPasteName(string name)
        {
            _driver.FindElement(pasteNameTitleField).SendKeys(name);
        }

        public void CreateNewPaste()
        {
            _driver.FindElement(createNewPasteButton).Click();
        }
    }
}