using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;

namespace TripPlannerTestSuite
{
    //  A testcase to determine whether the trip planner returns a list of search results
    [TestFixture]
    public class TripPlannerTripSearchResultsTest
    {
        public IWebDriver Driver { get; set; }
        private TripPlannerPage tripPlannerPage;
        private List<IWebElement> tripSearchResults;
        private string from, to;

        [SetUp]
        public void SetUp()
        {
            //  Initialise objects
            Driver = new FirefoxDriver();
            tripPlannerPage = new TripPlannerPage(Driver);
            tripSearchResults = new List<IWebElement>();

            //  Establish station names
            from = "North Sydney Station";
            to = "Town Hall Station";
        }

        [Test]
        public void TripSearchResultsTest()
        {
            //  Execute test
            tripPlannerPage.Navigate();
            tripPlannerPage.InputTripSearchDetails(from, to);
            tripPlannerPage.BeginTripSearch();
            tripSearchResults = tripPlannerPage.CollectTripSearchResults();

            //  Assert test wasn't unsuccessful
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(tripSearchResults, "The trip search has generated invalid results.");
                Assert.IsTrue(tripSearchResults.Count > 0, "The trip search hasn't generated any results.");
            });
        }

        [TearDown]
        public void TearDown()
        {
            //  Close the browser
            Driver.Close();
        }
    }
}