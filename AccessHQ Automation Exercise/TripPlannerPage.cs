using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TripPlannerTestSuite
{
    //  The interface between the testcase classes and the validator & element map;
    public class TripPlannerPage : TripPlannerBase
    {
        private readonly string url = @"https://transportnsw.info/trip";

        //  instances of the element map & the validator
        protected TripPlannerElementMap Map => new TripPlannerElementMap(driver);

        protected TripPlannerValidator Validator => new TripPlannerValidator(driver);

        //  An cached wait object for explicit waits
        protected WebDriverWait Wait => new WebDriverWait(driver, TimeSpan.FromSeconds(1));

        //  Constructor
        public TripPlannerPage(IWebDriver driver) : base(driver) { }

        //  Navigate to the trip planner url
        public void Navigate()
        {
            driver.Navigate().GoToUrl(url);
        }

        //  Input origin and destination locations for the trip planner to work with
        public void InputTripSearchDetails(string from, string to)
        {
            Map.SearchInputFrom.SendKeys(from);
            Map.SearchInputTo.SendKeys(to);
        }

        //  Confirm that the data from the from & to input elements has been processed, then click to begin the search
        public void BeginTripSearch()
        {
            Wait.Until(d => Validator.IsTripSearchInputValid());
            Map.SearchButton.Click();
        }

        //  Confirm that the trip search results have been generated & output them for later use
        public List<IWebElement> CollectTripSearchResults()
        {
            Wait.Until(d => Validator.IsTripSearchComplete());
            return Map.SearchResultList.ToList();
        }
    }
}