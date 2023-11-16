using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace Functional_testing_assignment
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [TestCategory("Smoke test")]
        public void AnalyticsSmoke()
        {
            using (IWebDriver wdriver = new ChromeDriver())
            {
                wdriver.Navigate().GoToUrl("https://web-domains-analytics.netlify.app/");
                wdriver.Manage().Window.Maximize();
                Thread.Sleep(5000);
                wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div[1]/div/a[1]")).Click();

                Assert.AreEqual(wdriver.Url, "https://web-domains-analytics.netlify.app/login");

                wdriver.Quit();
            }
        }

        [TestMethod]
        public void Login_Logout() //Test login and logout
        {
            using (IWebDriver wdriver = new ChromeDriver())
            {
                wdriver.Navigate().GoToUrl("https://web-domains-analytics.netlify.app/");
                wdriver.Manage().Window.Maximize();
                Thread.Sleep(5000);

                IWebElement login = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div[1]/div/a[1]"));
                login.Click();

                IWebElement nameInput = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div[2]/form/div[1]/input[1]"));
                nameInput.Click();
                nameInput.SendKeys("John Doe");

                IWebElement emailInput = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div[2]/form/div[1]/input[2]"));
                emailInput.Click();
                emailInput.SendKeys("john.doe@email.com");

                IWebElement passwordInput = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div[2]/form/div[1]/input[3]"));
                passwordInput.Click();
                passwordInput.SendKeys("P@ssw0rd123");

                IWebElement submit = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div[2]/form/input"));
                submit.Click();

                Thread.Sleep(2000);

                IWebElement logOut = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[1]/div/h2"));

                Assert.AreEqual("Log out", logOut.Text);
                Assert.AreEqual(wdriver.Url, "https://web-domains-analytics.netlify.app/");

                logOut.Click();

                Thread.Sleep(2000);

                // Check that the "Log out" element does not exist
                try
                {
                    IWebElement logOutAfterLogout = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[1]/div/h2"));
                    // If the element is found, fail the test
                    Assert.Fail("Element 'Log out' exists after logout");
                }
                catch (NoSuchElementException)
                {
                    // If NoSuchElementException is thrown, the element does not exist (which is expected)
                }

                wdriver.Quit();
            }
        }

        [TestMethod]
        public void FindData() //Find URL stored in data base
        {
            using (IWebDriver wdriver = new ChromeDriver())
            {
                wdriver.Navigate().GoToUrl("https://web-domains-analytics.netlify.app/");
                wdriver.Manage().Window.Maximize();
                Thread.Sleep(5000);

                IWebElement login = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div[1]/div/a[1]"));
                login.Click();

                IWebElement nameInput = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div[2]/form/div[1]/input[1]"));
                nameInput.Click();
                nameInput.SendKeys("John Doe");

                IWebElement emailInput = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div[2]/form/div[1]/input[2]"));
                emailInput.Click();
                emailInput.SendKeys("john.doe@email.com");

                IWebElement passwordInput = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div[2]/form/div[1]/input[3]"));
                passwordInput.Click();
                passwordInput.SendKeys("P@ssw0rd123");

                IWebElement submit = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div[2]/form/input"));
                submit.Click();

                Thread.Sleep(3000);

                IWebElement urlInput = wdriver.FindElement(By.ClassName("wordInput"));
                urlInput.Click();
                urlInput.SendKeys("https://kotaku.com/the-legend-of-zelda-tears-of-the-kingdom-the-kotaku-r-1850570840");

                IWebElement checkButton = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div/div[1]/div[1]/div[2]/input[2]"));
                checkButton.Click();

                Thread.Sleep(4000);

                //If this button exists, data is being found.
                IWebElement reScrapeButton = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div/div[1]/div[1]/div[2]/input[1]"));

                Assert.AreEqual("Re-Scrape", reScrapeButton.GetAttribute("value"));
            }
        }

        [TestMethod]
        public void StartScraping() //Start scraping with new URL
        {
            using (IWebDriver wdriver = new ChromeDriver())
            {
                wdriver.Navigate().GoToUrl("https://web-domains-analytics.netlify.app/");
                wdriver.Manage().Window.Maximize();
                Thread.Sleep(5000);

                IWebElement login = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div[1]/div/a[1]"));
                login.Click();

                IWebElement nameInput = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div[2]/form/div[1]/input[1]"));
                nameInput.Click();
                nameInput.SendKeys("John Doe");

                IWebElement emailInput = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div[2]/form/div[1]/input[2]"));
                emailInput.Click();
                emailInput.SendKeys("john.doe@email.com");

                IWebElement passwordInput = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div[2]/form/div[1]/input[3]"));
                passwordInput.Click();
                passwordInput.SendKeys("P@ssw0rd123");

                IWebElement submit = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div[2]/form/input"));
                submit.Click();

                Thread.Sleep(3000);

                IWebElement urlInput = wdriver.FindElement(By.ClassName("wordInput"));
                urlInput.Click();
                urlInput.SendKeys("https://www.dunedinorienteering.org/");

                IWebElement checkButton = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div/div[1]/div[1]/div[2]/input[2]"));
                checkButton.Click();

                Thread.Sleep(4000);

                IWebElement scrapeFeedback = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div/div[1]/div[1]/div[3]/h4"));

                Assert.AreEqual("Scraping...this may take a while", scrapeFeedback.Text);
            }
        }

        [TestMethod]
        public void SwitchHistogram() //Switch histogram outputs
        {
            using (IWebDriver wdriver = new ChromeDriver())
            {
                wdriver.Navigate().GoToUrl("https://web-domains-analytics.netlify.app/");
                wdriver.Manage().Window.Maximize();
                Thread.Sleep(5000);

                IWebElement login = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div[1]/div/a[1]"));
                login.Click();

                IWebElement nameInput = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div[2]/form/div[1]/input[1]"));
                nameInput.Click();
                nameInput.SendKeys("John Doe");

                IWebElement emailInput = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div[2]/form/div[1]/input[2]"));
                emailInput.Click();
                emailInput.SendKeys("john.doe@email.com");

                IWebElement passwordInput = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div[2]/form/div[1]/input[3]"));
                passwordInput.Click();
                passwordInput.SendKeys("P@ssw0rd123");

                IWebElement submit = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div[2]/form/input"));
                submit.Click();

                Thread.Sleep(3000);

                IWebElement urlInput = wdriver.FindElement(By.ClassName("wordInput"));
                urlInput.Click();
                urlInput.SendKeys("https://kotaku.com/the-legend-of-zelda-tears-of-the-kingdom-the-kotaku-r-1850570840");

                IWebElement checkButton = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div/div[1]/div[1]/div[2]/input[2]"));
                checkButton.Click();

                Thread.Sleep(4000);

                IWebElement titleWords = wdriver.FindElement(By.TagName("text"));
                Assert.AreEqual("Top 10 Words", titleWords.Text);
                
                //Change to bigrams

                IWebElement bigramsButton = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div/div[2]/div[1]/input[2]"));
                bigramsButton.Click();

                IWebElement titleBigrams = wdriver.FindElement(By.TagName("text"));
                Assert.AreEqual("Top 10 Bigrams", titleBigrams.Text);

                //Change to trigrams

                IWebElement trigramsButton = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div/div[2]/div[1]/input[3]"));
                trigramsButton.Click();

                IWebElement titleTrigrams = wdriver.FindElement(By.TagName("text"));
                Assert.AreEqual("Top 10 Trigrams", titleTrigrams.Text);

                //Change to NER

                IWebElement nerButton = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div/div[2]/div[1]/input[4]"));
                nerButton.Click();

                IWebElement titleNer = wdriver.FindElement(By.TagName("text"));
                Assert.AreEqual("Top 10 Ner", titleNer.Text);

            }
        }

        [TestMethod]
        public void SwitchSentimentChart() //Switch histogram outputs
        {
            using (IWebDriver wdriver = new ChromeDriver())
            {
                wdriver.Navigate().GoToUrl("https://web-domains-analytics.netlify.app/");
                wdriver.Manage().Window.Maximize();
                Thread.Sleep(5000);

                IWebElement login = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div[1]/div/a[1]"));
                login.Click();

                IWebElement nameInput = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div[2]/form/div[1]/input[1]"));
                nameInput.Click();
                nameInput.SendKeys("John Doe");

                IWebElement emailInput = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div[2]/form/div[1]/input[2]"));
                emailInput.Click();
                emailInput.SendKeys("john.doe@email.com");

                IWebElement passwordInput = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div[2]/form/div[1]/input[3]"));
                passwordInput.Click();
                passwordInput.SendKeys("P@ssw0rd123");

                IWebElement submit = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div[2]/form/input"));
                submit.Click();

                Thread.Sleep(3000);

                IWebElement urlInput = wdriver.FindElement(By.ClassName("wordInput"));
                urlInput.Click();
                urlInput.SendKeys("https://kotaku.com/the-legend-of-zelda-tears-of-the-kingdom-the-kotaku-r-1850570840");

                IWebElement checkButton = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div/div[1]/div[1]/div[2]/input[2]"));
                checkButton.Click();

                Thread.Sleep(4000);

                // Check that the "Pie chart" element exists
                try
                {
                    // If the element is found, pass the test
                    IWebElement pieChart = wdriver.FindElement(By.ClassName("recharts-pie"));                 
                }
                catch (NoSuchElementException)
                {
                    // If NoSuchElementException is thrown, the element does not exist and test fails
                    Assert.Fail("Element 'pie chart' does not exists");
                }

                // Switch to Polar grid chart
                IWebElement changeButton = wdriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div/div[3]/div[2]/button"));
                changeButton.Click();

                // Check that the "Grid chart" element exists
                try
                {
                    // If the element is found, pass the test
                    IWebElement gridChart = wdriver.FindElement(By.ClassName("recharts-pie"));
                }
                catch (NoSuchElementException)
                {
                    // If NoSuchElementException is thrown, the element does not exist and test fails
                    Assert.Fail("Element 'pie chart' does not exists");
                }
            }
        }
    }
}
