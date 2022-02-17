using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace VSG
{
    class TestCase
    {
        IWebDriver _driver;
        WebDriverWait wait;


        [SetUp]
        public void startBrowser()
        {
            _driver = new ChromeDriver("C:\\key");
            _driver.Manage().Window.Maximize();
            wait = new WebDriverWait(_driver, System.TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Test Case One
        /// </summary>
        /// 

        [Test]
        public void Test1()
        {
            _driver.Url = "https://qafour.profitstarsfps.com/";
            wait.Until(c => c.FindElement(By.Id("signInName")));
            _driver.FindElement(By.CssSelector("#signInName")).SendKeys("testuser123");
            _driver.FindElement(By.CssSelector("#password")).SendKeys("jZ8G;:A5Ky");
            _driver.FindElement(By.CssSelector("#next")).Click();
            wait.Until(c => c.FindElement(By.CssSelector(".ng-scope.ng-isolate-scope")));
            Assert.That((_driver.FindElement(By.CssSelector(".ng-scope.ng-isolate-scope")).Text).Trim().Replace("\n", ""), Is.EqualTo("Scorecard"), "The Header is not displayed");

            _driver.FindElement(By.CssSelector(".nav-tabs > li:nth-child(2)")).Click();
            wait.Until(c => c.FindElement(By.CssSelector(".fa.ng-scope.fa-plus")));
            _driver.FindElement(By.CssSelector(".fa.ng-scope.fa-plus")).Click();
            wait.Until(c => c.FindElement(By.CssSelector(".breadcrumb > li:nth-child(3)")));

            Assert.That((_driver.FindElement(By.CssSelector(".breadcrumb > li:nth-child(3)")).Text).Trim().Replace("\n", ""), Is.EqualTo("Scorecard Details"), "The header is ont displayed ");
            Assert.That(_driver.FindElement(By.CssSelector(".col-md-7")).GetCssValue("display") != "null", Is.True, "The scored detiled are not showed");
            Assert.That(_driver.FindElement(By.CssSelector(".col-sm-6")).GetCssValue("display") != "null", Is.True, "The scored detiled col-6 are not showed");

            _driver.FindElement(By.CssSelector("#content > div.shuffle-animation.ng-scope > form > div:nth-child(1) > div.col-md-7 > div:nth-child(7) > div > div > span:nth-child(1) > span")).Click();
            IWebElement saveButton = _driver.FindElement(By.CssSelector(".px-vertical-middle.ng-binding.ng-scope.btn.btn-primary"));

            Assert.That(_driver.FindElement(By.CssSelector(".px-vertical-middle.ng-binding.ng-scope.btn.btn-default")).GetCssValue("align-items").Contains("flex-start"), "The cansel button is on the right place");
            Assert.That(saveButton.GetCssValue("align-items").Contains("flex-start"), "The save button is on the right place");
            saveButton.Click();

            Assert.That(_driver.FindElements(By.CssSelector(".px-validation-form-error-msg.text-danger")).Count, Is.EqualTo(10), "Not all error are displayed");
        }

        [Test]
        public void Test2()
        {
            _driver.Url = "https://qafour.profitstarsfps.com/";
            wait.Until(c => c.FindElement(By.Id("signInName")));
            _driver.FindElement(By.CssSelector("#signInName")).SendKeys("testuser123");
            _driver.FindElement(By.CssSelector("#password")).SendKeys("jZ8G;:A5Ky");
            _driver.FindElement(By.CssSelector("#next")).Click();
            wait.Until(c => c.FindElement(By.CssSelector(".ng-scope.ng-isolate-scope")));
            Assert.That(_driver.FindElement(By.CssSelector(".ng-scope.ng-isolate-scope")).Text.Trim().Replace("\n", ""), Is.EqualTo("Scorecard"), "The Header is not displayed");

            _driver.FindElement(By.CssSelector(".nav-tabs > li:nth-child(2)")).Click();
            wait.Until(c => c.FindElement(By.CssSelector(".fa.ng-scope.fa-plus")));
            _driver.FindElement(By.CssSelector(".fa.ng-scope.fa-plus")).Click();
            wait.Until(c => c.FindElement(By.CssSelector(".breadcrumb > li:nth-child(3)")));
            Assert.That(_driver.FindElement(By.CssSelector(".breadcrumb > li:nth-child(3)")).Text.Trim().Replace("\n", ""), Is.EqualTo("Scorecard Details"), "The header is ont displayed ");

            IWebElement salary = _driver.FindElement(By.CssSelector("#salaryInputField"));
            salary.SendKeys("-1");
            IWebElement saveButton = _driver.FindElement(By.CssSelector(".px-vertical-middle.ng-binding.ng-scope.btn.btn-primary"));
            saveButton.Click();
            Assert.That(_driver.FindElement(By.CssSelector("#salary .text-danger")).Text.Trim().Replace("\n", ""), Is.EqualTo(@"The value must be between 0 and 999,999,999."));

            salary.Clear();
            salary.SendKeys("1000000000");
            saveButton.Click();

            Assert.That(_driver.FindElement(By.CssSelector(@"#salary .text-danger")).Text.Trim().Replace("\n", ""), Is.EqualTo(@"The value must be between 0 and 999,999,999."));

            salary.Clear();
            IWebElement opportunityInputField = _driver.FindElement(By.CssSelector("#opportunityInputField"));
            opportunityInputField.SendKeys("-1");
            saveButton.Click();
            Assert.That(_driver.FindElement(By.CssSelector("#opportunity .text-danger")).Text.Trim().Replace("\n", ""), Is.EqualTo(@"The value must be between 0.00 and 200.00."));

            opportunityInputField.SendKeys("201");
            saveButton.Click();
            Assert.That(_driver.FindElement(By.CssSelector("#opportunity .text-danger")).Text.Trim().Replace("\n", ""), Is.EqualTo(@"The value must be between 0.00 and 200.00."));
        }

        [Test]
        public void Test3()
        {
            _driver.Url = "https://qafour.profitstarsfps.com/";
            wait.Until(c => c.FindElement(By.Id("signInName")));
            _driver.FindElement(By.CssSelector("#signInName")).SendKeys("testuser123");
            _driver.FindElement(By.CssSelector("#password")).SendKeys("jZ8G;:A5Ky");
            _driver.FindElement(By.CssSelector("#next")).Click();
            wait.Until(c => c.FindElement(By.CssSelector(".ng-scope.ng-isolate-scope")));
            Assert.That((_driver.FindElement(By.CssSelector(".ng-scope.ng-isolate-scope")).Text).Trim().Replace("\n", ""), Is.EqualTo("Scorecard"), "The Header is not displayed");

            _driver.FindElement(By.CssSelector(".nav-tabs > li:nth-child(2)")).Click();
            wait.Until(c => c.FindElement(By.CssSelector(".fa.ng-scope.fa-plus")));
            _driver.FindElement(By.CssSelector(".fa.ng-scope.fa-plus")).Click();
            wait.Until(c => c.FindElement(By.CssSelector(".breadcrumb > li:nth-child(3)")));
            Assert.That((_driver.FindElement(By.CssSelector(".breadcrumb > li:nth-child(3)")).Text).Trim().Replace("\n", ""), Is.EqualTo("Scorecard Details"), "The header is ont displayed ");

            IWebElement name = _driver.FindElement(By.CssSelector("#AddScorecardUserSelectionPanelSearchPanelInputControl"));
            name.SendKeys("Test User");

            IWebElement organizatione = _driver.FindElement(By.CssSelector("#organizationInputField"));
            organizatione.Click();
            ((IJavaScriptExecutor)_driver).ExecuteScript("document.querySelector('#treeviewNode1').click()");

            ((IJavaScriptExecutor)_driver).ExecuteScript("document.querySelector('#treeviewNode0').click()");

            IWebElement year = _driver.FindElement(By.CssSelector("#yearInputField"));
            year.Click();
            year.SendKeys(Keys.ArrowDown);
            year.SendKeys(Keys.ArrowDown);

            IWebElement salary = _driver.FindElement(By.CssSelector("#salaryInputField"));
            salary.SendKeys("50 000");

            IWebElement opportunityInputField = _driver.FindElement(By.CssSelector("#opportunityInputField"));
            opportunityInputField.SendKeys("15");

            IWebElement category = _driver.FindElement(By.CssSelector("#category-1InputField"));
            category.Click();
            category.SendKeys(Keys.ArrowDown);
            category.SendKeys(Keys.Enter);
            //((IJavaScriptExecutor)_driver).ExecuteScript("document.querySelector('#treeviewNode0').click()");

            IWebElement weight = _driver.FindElement(By.CssSelector("#weight-1InputField"));
            weight.SendKeys("100");

            IWebElement baseIn = _driver.FindElement(By.CssSelector("#base-1InputField"));
            baseIn.SendKeys("10000");

            IWebElement threshold = _driver.FindElement(By.CssSelector("#threshold-1InputField"));
            threshold.SendKeys("25000");

            IWebElement objective = _driver.FindElement(By.CssSelector("#objective-1InputField")); objective
            .SendKeys("35000");
            //Bug into the product!
            IWebElement saveButton = _driver.FindElement(By.CssSelector(".px-vertical-middle.ng-binding.ng-scope.btn.btn-primary"));
            saveButton.Click();

            Assert.That(_driver.FindElement(By.CssSelector(".px-breadcrumb-text.px-cannot-edit.ng-binding.ng-scope")).Text, Is.EqualTo("Manage Scorecards"), "The breadcrump are wrong");

            IWebElement tableElement = _driver.FindElement(By.CssSelector("table"));
            Assert.That(tableElement.FindElements(By.TagName("tr")).Count, Is.EqualTo(1), "There is one row");

            IWebElement pencilIcon = _driver.FindElement(By.CssSelector("#scorecardsGridInner_active_cell"));
            pencilIcon.Click();
            Assert.That(_driver.FindElement(By.CssSelector(".ng-scope.ng-isolate-scope")), Is.EqualTo("Scorecard"), "The Header is not displayed");

            opportunityInputField.SendKeys("20");

            saveButton.Click();

            Assert.That(_driver.FindElement(By.CssSelector(".px-breadcrumb-text.px-cannot-edit.ng-binding.ng-scope")).Text, Is.EqualTo("Manage Scorecards"), "The breaadcrump are wrong");

            IWebElement xButton = _driver.FindElement(By.CssSelector("#scorecardsGridInner_active_cell"));
            xButton.Click();
            IWebElement deleteModal = _driver.FindElement(By.CssSelector(".modal-content.ui-draggable"));
            IWebElement yesButton = deleteModal.FindElement(By.CssSelector(".btn-primary"));

            Assert.That(deleteModal.Displayed, "Delete modal window is not displayed");
            Assert.That(yesButton.Displayed && deleteModal.FindElement(By.CssSelector("btn-default")).Displayed, "Primary and Secondary butto are not in the modal");
            yesButton.Click();

            Assert.That(!deleteModal.Displayed, "Delete modal window is not displayed");
        }
        [TearDown]
        public void close_Browser3()
        {
            _driver.Close();
            _driver.Quit();
        }

    }
}
