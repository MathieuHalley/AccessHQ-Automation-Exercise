using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text;

namespace TripPlannerTestSuite
{
    [TestFixture]
    public class TripPlannerResultGenerationTestCase
    {
        private IWebDriver driver;
        private StringBuilder testOutput;
        private WebDriverWait wait;
        private string url;
        private string fromText, toText;
        private string fromInputElementID, toInputElementID, searchButtonID, searchResultsElementID;

        [SetUp]
        public void SetUp()
        {
            //  Initialise objects
            driver = new FirefoxDriver();
            testOutput = new StringBuilder();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));

            //  Establish the url of the page to be tested
            url = "https://transportnsw.info/trip";

            //  Establish station names
            fromText = "North Sydney Station";
            toText = "Town Hall Station";

            //  Establish the required web element IDs
            fromInputElementID = "search-input-From";
            toInputElementID = "search-input-To";
            searchButtonID = "search-button";
            searchResultsElementID = "search-results-success";
        }

        [Test]
        public void ResultGenerationTest()
        {
            IWebElement fromInputElement, toInputElement, searchButton, searchResultsElement;

            driver.Navigate().GoToUrl(url);

            //  Find the From Input element and input the name of a station, output success/failure messages as required.
            fromInputElement = TryFindWebElement
            (
                driver,
                By.Id(fromInputElementID),
                new Action<IWebElement>(e =>
                {
                    testOutput.AppendLine("The From Input element is present.");
                    e.SendKeys(fromText);
                }),
                new Action<IWebElement>(e => Console.Write(testOutput.AppendLine("The From Input element isn't present."))));

            //  Find the To Input element and input the name of a station, output success/failure messages as required.
            toInputElement = TryFindWebElement(
                driver,
                By.Id(toInputElementID),
                new Action<IWebElement>(e =>
                {
                    testOutput.AppendLine("The To input element is present.");
                    e.SendKeys(toText);
                }),
                new Action<IWebElement>(e => Console.Write(testOutput.AppendLine("The To Input element isn't present."))));

            //  Wait for the two Input elements to finish processing their inputs.
            wait.Until(d =>
                {
                    var isFromInputValid = !fromInputElement.GetAttribute("class").Contains("ng-invalid-remove-active");
                    var isToInputValid = !toInputElement.GetAttribute("class").Contains("ng-invalid-remove-active");

                    return isFromInputValid && isToInputValid;
                });

            //  Find the To Search button and perform a click action upon it, output success/failure messages as required.
            searchButton = TryFindWebElement
            (
                driver,
                By.Id(searchButtonID),
                new Action<IWebElement>(e =>
                {
                    testOutput.AppendLine("The Search button is present.");
                    e.Click();
                }),
                new Action<IWebElement>(e => Console.Write(testOutput.AppendLine("The Search button isn't present."))));

            //  Find the To Search Results element, output success/failure messages as required.
            //  Success here is the focus of the test.
            searchResultsElement = TryFindWebElement(
                driver,
                By.Id(searchResultsElementID),
                new Action<IWebElement>(e => testOutput.AppendLine("The Search Results element is present.")),
                new Action<IWebElement>(e => Console.Write(testOutput.AppendLine("The Search Results element isn't present."))));
        }

        [TearDown]
        public void TearDown()
        {
            //  Write any output from the test to the console and close the browser

            Console.Write(testOutput);
            driver.Close();
        }

        /// <summary>
        ///     Attempt to find a IWebElement within a given WebDriver. Perform success or failure actions depending on how the find goes
        /// </summary>
        /// <param name="driver">The IWebDriver that potentially contains the IWebElement to be found.</param>
        /// <param name="by">The attribute used to identify the IWebElement</param>
        /// <param name="successAction">An action to perform if the IWebElement is successfully found.</param>
        /// <param name="failureAction">An action to perform if the IWebElement is unable to be found.</param>
        /// <returns>The found IWebElement; null if the IWebElement can't be found.</returns>
        public static IWebElement TryFindWebElement(
            IWebDriver driver,
            By by,
            Action<IWebElement> successAction = null,
            Action<IWebElement> failureAction = null)
        {
            IWebElement element = null;

            //  Attempt to find an element within the page. Catch & throw all exceptions. Invoke the failure action on NoSuchElementException exception
            try
            {
                element = driver.FindElement(by);
            }
            catch (NoSuchElementException e)
            {
                if (failureAction != null)
                {
                    failureAction.Invoke(element);
                }
                throw;
            }
            catch
            {
                throw;
            }

            //  If the find was successful, invoke the success action
            if (element != null && successAction != null)
            {
                successAction.Invoke(element);
            }

            return element;
        }
    }
}